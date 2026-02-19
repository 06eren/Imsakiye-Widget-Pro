using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WpfColor = System.Windows.Media.Color;
using WpfColorConverter = System.Windows.Media.ColorConverter;
using System.Windows.Media;

namespace İmsakiye_Widget_Pro
{
    public partial class SpecialDaysWindow : Window
    {
        private readonly Dictionary<string, DateTime> specialDays = new()
        {
            { "🌙 Ramazan Başlangıcı", new DateTime(2026, 2, 18) },
            { "🌟 Kadir Gecesi", new DateTime(2026, 3, 14) },
            { "🎉 Ramazan Bayramı", new DateTime(2026, 3, 20) },
            { "🕋 Kurban Bayramı", new DateTime(2026, 5, 27) },
            { "📖 Mevlid Kandili", new DateTime(2026, 9, 24) },
            { "✨ Regaip Kandili", new DateTime(2026, 1, 29) },
            { "🌙 Miraç Kandili", new DateTime(2026, 2, 10) },
            { "💫 Berat Kandili", new DateTime(2026, 3, 5) }
        };

        public SpecialDaysWindow()
        {
            InitializeComponent();
            LoadSpecialDays();
        }

        private void LoadSpecialDays()
        {
            var today = DateTime.Now;
            var sortedDays = new List<KeyValuePair<string, DateTime>>(specialDays);
            sortedDays.Sort((a, b) => a.Value.CompareTo(b.Value));

            foreach (var day in sortedDays)
            {
                var daysUntil = (day.Value - today).Days;
                var isPast = daysUntil < 0;
                
                var border = new Border
                {
                    Background = new SolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString("#2d3436")!),
                    CornerRadius = new CornerRadius(10),
                    Padding = new Thickness(15),
                    Margin = new Thickness(0, 0, 0, 15),
                    BorderBrush = new SolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString(isPast ? "#636e72" : "#e17055")!),
                    BorderThickness = new Thickness(0, 0, 0, 3),
                    Opacity = isPast ? 0.5 : 1.0
                };

                var grid = new Grid();
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

                var stack = new StackPanel();
                var title = new TextBlock
                {
                    Text = day.Key,
                    FontSize = 18,
                    FontWeight = FontWeights.Bold,
                    Foreground = new SolidColorBrush(System.Windows.Media.Colors.White),
                    Margin = new Thickness(0, 0, 0, 5)
                };

                var date = new TextBlock
                {
                    Text = day.Value.ToString("dd MMMM yyyy"),
                    FontSize = 14,
                    Foreground = new SolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString("#b2bec3")!)
                };

                stack.Children.Add(title);
                stack.Children.Add(date);

                var countdown = new TextBlock
                {
                    Text = isPast ? "Geçti" : $"{daysUntil} gün",
                    FontSize = 24,
                    FontWeight = FontWeights.Bold,
                    Foreground = new SolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString(isPast ? "#636e72" : "#e17055")!),
                    VerticalAlignment = VerticalAlignment.Center
                };

                Grid.SetColumn(stack, 0);
                Grid.SetColumn(countdown, 1);

                grid.Children.Add(stack);
                grid.Children.Add(countdown);
                border.Child = grid;
                SpecialDaysPanel.Children.Add(border);
            }
        }
    }
}
