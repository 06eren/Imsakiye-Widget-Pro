using System;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using WpfColor = System.Windows.Media.Color;
using WpfColorConverter = System.Windows.Media.ColorConverter;
using System.Windows.Media;

namespace İmsakiye_Widget_Pro
{
    public partial class StatisticsWindow : Window
    {
        private StatisticsData stats = new();

        public StatisticsWindow()
        {
            InitializeComponent();
            LoadStatistics();
            UpdateDisplay();
        }

        private void LoadStatistics()
        {
            try
            {
                var path = GetStatsPath();
                if (File.Exists(path))
                {
                    var json = File.ReadAllText(path);
                    stats = JsonSerializer.Deserialize<StatisticsData>(json) ?? new StatisticsData();
                }
                else
                {
                    stats.FirstUseDate = DateTime.Now;
                    SaveStatistics();
                }
                
                stats.OpenCount++;
                SaveStatistics();
            }
            catch { }
        }

        private void SaveStatistics()
        {
            try
            {
                var path = GetStatsPath();
                var directory = Path.GetDirectoryName(path);
                if (directory != null && !Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                var json = JsonSerializer.Serialize(stats, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(path, json);
            }
            catch { }
        }

        private string GetStatsPath()
        {
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "ImsakiyeWidgetPro",
                "statistics.json"
            );
        }

        private void UpdateDisplay()
        {
            var now = DateTime.Now;
            var currentHour = now.TimeOfDay;
            
            // Bugünün vakitleri (örnek)
            int passedPrayers = 3;
            int totalPrayers = 6;
            PassedPrayersText.Text = $"{passedPrayers} / {totalPrayers}";
            RemainingPrayersText.Text = $"{totalPrayers - passedPrayers} / {totalPrayers}";
            
            // Bu ay
            int daysInMonth = DateTime.DaysInMonth(now.Year, now.Month);
            PassedDaysText.Text = now.Day.ToString();
            RemainingDaysText.Text = (daysInMonth - now.Day).ToString();
            
            // Uygulama kullanımı
            FirstUseText.Text = stats.FirstUseDate.ToString("dd MMMM yyyy");
            var usageDays = (now - stats.FirstUseDate).Days;
            TotalUsageText.Text = usageDays == 0 ? "Bugün başladınız" : $"{usageDays} gün";
            OpenCountText.Text = stats.OpenCount.ToString();
            
            // Vakit detayları
            LoadPrayerDetails();
        }

        private void LoadPrayerDetails()
        {
            var prayers = new[] { "İmsak", "Güneş", "Öğle", "İkindi", "Akşam", "Yatsı" };
            var colors = new[] { "#00b894", "#00cec9", "#fdcb6e", "#e17055", "#fd79a8", "#6c5ce7" };
            
            for (int i = 0; i < prayers.Length; i++)
            {
                var border = new Border
                {
                    Background = new SolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString("#1e272e")!),
                    CornerRadius = new CornerRadius(8),
                    Padding = new Thickness(15),
                    Margin = new Thickness(0, 0, 0, 10),
                    BorderBrush = new SolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString(colors[i])!),
                    BorderThickness = new Thickness(0, 0, 0, 2)
                };

                var grid = new Grid();
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

                var name = new TextBlock
                {
                    Text = prayers[i],
                    FontSize = 16,
                    FontWeight = FontWeights.SemiBold,
                    Foreground = new SolidColorBrush(System.Windows.Media.Colors.White),
                    VerticalAlignment = VerticalAlignment.Center
                };

                var status = new TextBlock
                {
                    Text = i < 3 ? "✓ Geçti" : "⏳ Bekliyor",
                    FontSize = 14,
                    Foreground = new SolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString(i < 3 ? "#00b894" : "#fdcb6e")!),
                    VerticalAlignment = VerticalAlignment.Center
                };

                Grid.SetColumn(name, 0);
                Grid.SetColumn(status, 1);

                grid.Children.Add(name);
                grid.Children.Add(status);
                border.Child = grid;
                PrayerDetailsPanel.Children.Add(border);
            }
        }
    }

    public class StatisticsData
    {
        public DateTime FirstUseDate { get; set; } = DateTime.Now;
        public int OpenCount { get; set; } = 0;
    }
}
