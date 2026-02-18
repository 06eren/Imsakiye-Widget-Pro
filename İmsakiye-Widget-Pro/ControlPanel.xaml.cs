using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using MahApps.Metro.Controls;

namespace İmsakiye_Widget_Pro
{
    public partial class ControlPanel : MetroWindow
    {
        private WidgetWindow? widgetWindow;
        private Dictionary<string, TimeSpan>? prayerTimes;
        private AppSettings settings;
        private DispatcherTimer? midnightTimer;
        private string selectedCity;

        public ControlPanel()
        {
            InitializeComponent();
            settings = AppSettings.Load();
            selectedCity = settings.SelectedCity;
            Loaded += ControlPanel_Loaded;
        }

        private async void ControlPanel_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCityList();
            ApplySettings();
            await LoadPrayerTimes();
            ShowWidgetWindow();
            InitializeMidnightTimer();
            
            // Başlıkları güncelle
            Title = $"{selectedCity} İmsakiye - Kontrol Paneli";
            if (HeaderCityText != null)
                HeaderCityText.Text = $"🕌 {selectedCity.ToUpper()} İMSAKİYE";
        }

        private void LoadCityList()
        {
            CityListBox.ItemsSource = TurkishCities.Cities;
            CityListBox.SelectedItem = selectedCity;
            SelectedCityText.Text = $"Seçili: {selectedCity}";
        }

        private void CitySearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = CitySearchBox.Text.ToLower();
            if (string.IsNullOrWhiteSpace(searchText))
            {
                CityListBox.ItemsSource = TurkishCities.Cities;
            }
            else
            {
                var filtered = TurkishCities.Cities.Where(c => c.ToLower().Contains(searchText)).ToList();
                CityListBox.ItemsSource = filtered;
            }
        }

        private void CityListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CityListBox.SelectedItem != null)
            {
                selectedCity = CityListBox.SelectedItem.ToString()!;
                SelectedCityText.Text = $"Seçili: {selectedCity}";
            }
        }

        private async void SaveCity_Click(object sender, RoutedEventArgs e)
        {
            settings.SelectedCity = selectedCity;
            settings.Save();
            
            // Başlıkları güncelle
            Title = $"{selectedCity} İmsakiye - Kontrol Paneli";
            if (HeaderCityText != null)
                HeaderCityText.Text = $"🕌 {selectedCity.ToUpper()} İMSAKİYE";
            
            await LoadPrayerTimes();
            
            // Widget'ı güncelle
            if (widgetWindow != null)
            {
                widgetWindow.UpdateCityName(selectedCity);
            }
            
            System.Windows.MessageBox.Show(
                $"{selectedCity} şehri kaydedildi ve namaz vakitleri güncellendi!",
                "Başarılı",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        private void ApplySettings()
        {
            if (AlwaysOnTopToggle != null)
                AlwaysOnTopToggle.IsOn = settings.AlwaysOnTop;
            if (AutoStartToggle != null)
                AutoStartToggle.IsOn = settings.AutoStart;
            if (NotificationsToggle != null)
                NotificationsToggle.IsOn = settings.NotificationsEnabled;
            if (OpacitySlider != null)
                OpacitySlider.Value = settings.Opacity;
        }

        private void InitializeMidnightTimer()
        {
            midnightTimer = new DispatcherTimer();
            midnightTimer.Interval = TimeSpan.FromMinutes(1); // Her dakika kontrol et
            midnightTimer.Tick += async (s, e) =>
            {
                var now = DateTime.Now;
                // Gece 00:00 - 00:01 arası ise vakitleri yenile
                if (now.Hour == 0 && now.Minute == 0)
                {
                    await LoadPrayerTimes();
                    WidgetStatusText.Text = "Vakitler otomatik güncellendi (00:00)";
                }
            };
            midnightTimer.Start();
        }

        private async Task LoadPrayerTimes()
        {
            try
            {
                var today = DateTime.Now;
                var url = $"https://api.aladhan.com/v1/timingsByCity/{today.Day}-{today.Month}-{today.Year}?city={selectedCity}&country=Turkey&method=13";

                using var client = new HttpClient();
                var response = await client.GetStringAsync(url);
                var json = JsonDocument.Parse(response);

                var timings = json.RootElement.GetProperty("data").GetProperty("timings");

                prayerTimes = new Dictionary<string, TimeSpan>
                {
                    { "İmsak", ParseTime(timings.GetProperty("Fajr").GetString()!) },
                    { "Güneş", ParseTime(timings.GetProperty("Sunrise").GetString()!) },
                    { "Öğle", ParseTime(timings.GetProperty("Dhuhr").GetString()!) },
                    { "İkindi", ParseTime(timings.GetProperty("Asr").GetString()!) },
                    { "Akşam", ParseTime(timings.GetProperty("Maghrib").GetString()!) },
                    { "Yatsı", ParseTime(timings.GetProperty("Isha").GetString()!) }
                };

                DisplayPrayerTimes();

                if (widgetWindow != null)
                {
                    widgetWindow.UpdatePrayerTimes(prayerTimes);
                }

                WidgetStatusText.Text = $"Son güncelleme: {DateTime.Now:HH:mm}";
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Namaz vakitleri yüklenirken hata: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private TimeSpan ParseTime(string time)
        {
            var parts = time.Split(':');
            return new TimeSpan(int.Parse(parts[0]), int.Parse(parts[1]), 0);
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
                    Background = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#1e272e")!),
                    CornerRadius = new CornerRadius(8),
                    Padding = new Thickness(15, 12, 15, 12),
                    Margin = new Thickness(0, 0, 0, 10),
                    BorderBrush = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(colors[colorIndex])!),
                    BorderThickness = new Thickness(0, 0, 0, 3)
                };

                var grid = new Grid();
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

                var iconText = new TextBlock
                {
                    Text = prayerIcons.ContainsKey(prayer.Key) ? prayerIcons[prayer.Key] : "🕌",
                    FontSize = 24,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(0, 0, 15, 0)
                };

                var nameText = new TextBlock
                {
                    Text = prayer.Key,
                    FontSize = 16,
                    Foreground = new SolidColorBrush(Colors.White),
                    VerticalAlignment = VerticalAlignment.Center,
                    FontWeight = FontWeights.SemiBold
                };

                var timeText = new TextBlock
                {
                    Text = prayer.Value.ToString(@"hh\:mm"),
                    FontSize = 20,
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

        private void ShowWidgetWindow()
        {
            if (widgetWindow == null)
            {
                widgetWindow = new WidgetWindow(selectedCity);
                if (prayerTimes != null)
                {
                    widgetWindow.UpdatePrayerTimes(prayerTimes);
                }
                widgetWindow.Closed += (s, e) => widgetWindow = null;
            }
            widgetWindow.Show();
            
            if (AlwaysOnTopToggle != null)
                widgetWindow.Topmost = AlwaysOnTopToggle.IsOn;
            if (OpacitySlider != null)
                widgetWindow.Opacity = OpacitySlider.Value;
        }

        private void ShowWidget_Click(object sender, RoutedEventArgs e)
        {
            ShowWidgetWindow();
        }

        private void HideWidget_Click(object sender, RoutedEventArgs e)
        {
            widgetWindow?.Hide();
        }

        private void AlwaysOnTop_Toggled(object sender, RoutedEventArgs e)
        {
            if (settings != null && AlwaysOnTopToggle != null)
            {
                settings.AlwaysOnTop = AlwaysOnTopToggle.IsOn;
                settings.Save();
                
                if (widgetWindow != null)
                {
                    widgetWindow.Topmost = AlwaysOnTopToggle.IsOn;
                }
            }
        }

        private void OpacitySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (OpacityValueText != null && OpacitySlider != null)
            {
                OpacityValueText.Text = $"{(int)(OpacitySlider.Value * 100)}%";
            }
            
            if (settings != null && OpacitySlider != null)
            {
                settings.Opacity = OpacitySlider.Value;
                settings.Save();
                
                if (widgetWindow != null)
                {
                    widgetWindow.Opacity = OpacitySlider.Value;
                }
            }
        }

        private async void RefreshTimes_Click(object sender, RoutedEventArgs e)
        {
            await LoadPrayerTimes();
        }

        private void ClosePanel_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        protected override void OnClosed(EventArgs e)
        {
            midnightTimer?.Stop();
            widgetWindow?.Close();
            System.Windows.Application.Current.Shutdown();
            base.OnClosed(e);
        }
    }
}
