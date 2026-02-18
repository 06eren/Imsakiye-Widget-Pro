using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using NAudio.Wave;

namespace İmsakiye_Widget_Pro
{
    public partial class WidgetWindow : Window
    {
        private DispatcherTimer? updateTimer;
        private Dictionary<string, TimeSpan>? prayerTimes;
        private HashSet<string> playedPrayers = new HashSet<string>();
        private IWavePlayer? waveOut;
        private AudioFileReader? audioFile;
        private string cityName;

        public WidgetWindow(string city)
        {
            InitializeComponent();
            cityName = city;
            CityNameText.Text = $"🕌 {city.ToUpper()} İMSAKİYE";
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            updateTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            updateTimer.Tick += UpdateTimer_Tick;
            updateTimer.Start();
        }

        public void UpdatePrayerTimes(Dictionary<string, TimeSpan> times)
        {
            prayerTimes = times;
            DisplayPrayerTimes();
            UpdateCountdown();
        }

        public void UpdateCityName(string city)
        {
            cityName = city;
            CityNameText.Text = $"🕌 {city.ToUpper()} İMSAKİYE";
        }

        private void DisplayPrayerTimes()
        {
            PrayerTimesPanel.Children.Clear();

            if (prayerTimes == null) return;

            var prayerIcons = new Dictionary<string, string>
            {
                { "İmsak", "🌙" },
                { "Güneş", "🌅" },
                { "Öğle", "☀️" },
                { "İkindi", "🌤️" },
                { "Akşam", "🌆" },
                { "Yatsı", "🌃" }
            };

            var colors = new[] { "#00b894", "#00cec9", "#fdcb6e", "#e17055", "#fd79a8", "#6c5ce7" };
            int colorIndex = 0;

            foreach (var prayer in prayerTimes)
            {
                var border = new Border
                {
                    Background = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#1a1f24")!),
                    CornerRadius = new CornerRadius(8),
                    Padding = new Thickness(12, 10, 12, 10),
                    Margin = new Thickness(0, 0, 0, 8),
                    BorderBrush = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(colors[colorIndex])!),
                    BorderThickness = new Thickness(0, 0, 0, 2)
                };

                var grid = new Grid();
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

                var iconText = new TextBlock
                {
                    Text = prayerIcons.ContainsKey(prayer.Key) ? prayerIcons[prayer.Key] : "🕌",
                    FontSize = 20,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(0, 0, 10, 0)
                };

                var nameText = new TextBlock
                {
                    Text = prayer.Key,
                    FontSize = 14,
                    Foreground = new SolidColorBrush(Colors.White),
                    VerticalAlignment = VerticalAlignment.Center,
                    FontWeight = FontWeights.SemiBold
                };

                var timeText = new TextBlock
                {
                    Text = prayer.Value.ToString(@"hh\:mm"),
                    FontSize = 18,
                    FontWeight = FontWeights.Bold,
                    Foreground = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(colors[colorIndex])!),
                    VerticalAlignment = VerticalAlignment.Center
                };

                Grid.SetColumn(iconText, 0);
                Grid.SetColumn(nameText, 1);
                Grid.SetColumn(timeText, 2);

                grid.Children.Add(iconText);
                grid.Children.Add(nameText);
                grid.Children.Add(timeText);
                border.Child = grid;

                PrayerTimesPanel.Children.Add(border);
                colorIndex++;
            }
        }

        private void UpdateTimer_Tick(object? sender, EventArgs e)
        {
            UpdateCountdown();
        }

        private void UpdateCountdown()
        {
            if (prayerTimes == null || prayerTimes.Count == 0) return;

            var now = DateTime.Now.TimeOfDay;
            var nextPrayer = prayerTimes.FirstOrDefault(p => p.Value > now);

            if (nextPrayer.Key == null)
            {
                nextPrayer = prayerTimes.First();
                // Yeni güne geçildiğinde çalınan vakitleri sıfırla
                playedPrayers.Clear();
            }

            NextPrayerName.Text = nextPrayer.Key;

            var timeUntil = nextPrayer.Value - now;
            if (timeUntil < TimeSpan.Zero)
            {
                timeUntil = timeUntil.Add(TimeSpan.FromDays(1));
            }

            CountdownText.Text = timeUntil.ToString(@"hh\:mm\:ss");

            // Ezan vakti kontrolü - Vakit geldiğinde ezan çal
            CheckAndPlayAdhan(now);
        }

        private void CheckAndPlayAdhan(TimeSpan currentTime)
        {
            if (prayerTimes == null) return;

            foreach (var prayer in prayerTimes)
            {
                // Vakit geldi mi kontrol et (1 dakika tolerans)
                var timeDiff = (currentTime - prayer.Value).TotalSeconds;
                
                // Eğer vakit geldi ve daha önce çalınmadıysa
                if (timeDiff >= 0 && timeDiff < 60 && !playedPrayers.Contains(prayer.Key))
                {
                    PlayAdhan();
                    playedPrayers.Add(prayer.Key);
                    
                    // Bildirim göster
                    ShowPrayerNotification(prayer.Key);
                    break;
                }
            }
        }

        private void PlayAdhan()
        {
            try
            {
                // Önceki ses varsa durdur
                StopAdhan();

                var ezanPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AksamEzani.mp3");
                
                if (System.IO.File.Exists(ezanPath))
                {
                    waveOut = new WaveOutEvent();
                    audioFile = new AudioFileReader(ezanPath);
                    waveOut.Init(audioFile);
                    waveOut.Play();

                    // Ezan bittiğinde kaynakları temizle
                    waveOut.PlaybackStopped += (s, e) =>
                    {
                        StopAdhan();
                    };
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Ezan çalınırken hata: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void StopAdhan()
        {
            waveOut?.Stop();
            waveOut?.Dispose();
            audioFile?.Dispose();
            waveOut = null;
            audioFile = null;
        }

        private void ShowPrayerNotification(string prayerName)
        {
            // Pencereyi öne getir ve göster
            Show();
            WindowState = WindowState.Normal;
            Topmost = true;
            Activate();

            // Bildirim mesajı
            System.Windows.MessageBox.Show(
                $"{prayerName} vakti girdi!\n\nEzan okunuyor...",
                "🕌 Namaz Vakti",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            // Kontrol panelini göster
            foreach (Window window in System.Windows.Application.Current.Windows)
            {
                if (window is ControlPanel controlPanel)
                {
                    controlPanel.Show();
                    controlPanel.WindowState = WindowState.Normal;
                    controlPanel.Activate();
                    return;
                }
            }
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            var result = System.Windows.MessageBox.Show("Widget'ı kapatmak istediğinize emin misiniz?", 
                "Kapat", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Close();
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            updateTimer?.Stop();
            StopAdhan();
            base.OnClosed(e);
        }
    }
}
