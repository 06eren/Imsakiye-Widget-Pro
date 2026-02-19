using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WpfColor = System.Windows.Media.Color;
using WpfColorConverter = System.Windows.Media.ColorConverter;
using System.Windows.Media;

namespace İmsakiye_Widget_Pro
{
    public partial class FastingCalendarWindow : Window
    {
        private readonly Dictionary<string, List<DateTime>> fastingDays = new();

        public FastingCalendarWindow()
        {
            InitializeComponent();
            InitializeFastingDays();
            LoadFastingCalendar();
        }

        private void InitializeFastingDays()
        {
            var year = DateTime.Now.Year;
            
            // Pazartesi ve Perşembe oruçları
            fastingDays["Pazartesi-Perşembe"] = new List<DateTime>();
            for (var date = new DateTime(year, 1, 1); date.Year == year; date = date.AddDays(1))
            {
                if (date.DayOfWeek == DayOfWeek.Monday || date.DayOfWeek == DayOfWeek.Thursday)
                {
                    fastingDays["Pazartesi-Perşembe"].Add(date);
                }
            }
            
            // Aşure günü (Muharrem 10)
            fastingDays["Aşure"] = new List<DateTime> { new DateTime(2026, 7, 6) };
            
            // Arefe günü
            fastingDays["Arefe"] = new List<DateTime> { new DateTime(2026, 5, 26) };
            
            // Beyaz günler (Her ayın 13, 14, 15)
            fastingDays["Beyaz Günler"] = new List<DateTime>();
            for (int month = 1; month <= 12; month++)
            {
                fastingDays["Beyaz Günler"].Add(new DateTime(year, month, 13));
                fastingDays["Beyaz Günler"].Add(new DateTime(year, month, 14));
                fastingDays["Beyaz Günler"].Add(new DateTime(year, month, 15));
            }
            
            // Şevval oruçları (Ramazan bayramından sonra 6 gün)
            fastingDays["Şevval Oruçları"] = new List<DateTime>();
            var ramadanEnd = new DateTime(2026, 3, 20);
            for (int i = 1; i <= 6; i++)
            {
                fastingDays["Şevval Oruçları"].Add(ramadanEnd.AddDays(i));
            }
        }

        private void LoadFastingCalendar()
        {
            var colors = new[] { "#00b894", "#00cec9", "#fdcb6e", "#e17055", "#fd79a8", "#6c5ce7" };
            int colorIndex = 0;

            foreach (var category in fastingDays)
            {
                var border = new Border
                {
                    Background = new SolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString("#2d3436")!),
                    CornerRadius = new CornerRadius(12),
                    Padding = new Thickness(20),
                    Margin = new Thickness(0, 0, 0, 20),
                    BorderBrush = new SolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString(colors[colorIndex % colors.Length])!),
                    BorderThickness = new Thickness(0, 0, 0, 3)
                };

                var stack = new StackPanel();

                var title = new TextBlock
                {
                    Text = $"🌙 {category.Key}",
                    FontSize = 20,
                    FontWeight = FontWeights.Bold,
                    Foreground = new SolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString(colors[colorIndex % colors.Length])!),
                    Margin = new Thickness(0, 0, 0, 15)
                };

                stack.Children.Add(title);

                var today = DateTime.Now.Date;
                var upcomingDays = new List<DateTime>();
                
                foreach (var day in category.Value)
                {
                    if (day >= today)
                    {
                        upcomingDays.Add(day);
                        if (upcomingDays.Count >= 5) break;
                    }
                }

                if (upcomingDays.Count == 0)
                {
                    var noData = new TextBlock
                    {
                        Text = "Bu yıl için yaklaşan oruç günü yok",
                        FontSize = 14,
                        Foreground = new SolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString("#b2bec3")!)
                    };
                    stack.Children.Add(noData);
                }
                else
                {
                    foreach (var day in upcomingDays)
                    {
                        var dayBorder = new Border
                        {
                            Background = new SolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString("#1e272e")!),
                            CornerRadius = new CornerRadius(8),
                            Padding = new Thickness(12),
                            Margin = new Thickness(0, 0, 0, 8)
                        };

                        var dayGrid = new Grid();
                        dayGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                        dayGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

                        var dateText = new TextBlock
                        {
                            Text = day.ToString("dd MMMM yyyy dddd"),
                            FontSize = 14,
                            Foreground = new SolidColorBrush(System.Windows.Media.Colors.White),
                            VerticalAlignment = VerticalAlignment.Center
                        };

                        var daysUntil = (day - today).Days;
                        var countdownText = new TextBlock
                        {
                            Text = daysUntil == 0 ? "Bugün" : $"{daysUntil} gün sonra",
                            FontSize = 14,
                            FontWeight = FontWeights.Bold,
                            Foreground = new SolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString(colors[colorIndex % colors.Length])!),
                            VerticalAlignment = VerticalAlignment.Center
                        };

                        Grid.SetColumn(dateText, 0);
                        Grid.SetColumn(countdownText, 1);

                        dayGrid.Children.Add(dateText);
                        dayGrid.Children.Add(countdownText);
                        dayBorder.Child = dayGrid;
                        stack.Children.Add(dayBorder);
                    }
                }

                border.Child = stack;
                FastingPanel.Children.Add(border);
                colorIndex++;
            }
        }
    }
}
