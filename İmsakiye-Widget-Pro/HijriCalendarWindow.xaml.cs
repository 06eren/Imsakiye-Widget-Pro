using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using WpfColor = System.Windows.Media.Color;
using WpfColorConverter = System.Windows.Media.ColorConverter;
using WpfSolidColorBrush = System.Windows.Media.SolidColorBrush;

namespace İmsakiye_Widget_Pro
{
    public partial class HijriCalendarWindow : Window
    {
        private readonly List<(int Month, int Day, string Event)> islamicEvents = new()
        {
            (1, 1, "Hicri Yılbaşı"),
            (1, 10, "Aşure Günü"),
            (3, 12, "Mevlid Kandili"),
            (7, 27, "Regaib Kandili"),
            (8, 15, "Berat Kandili"),
            (9, 1, "Ramazan Başlangıcı"),
            (9, 27, "Kadir Gecesi"),
            (10, 1, "Ramazan Bayramı"),
            (12, 10, "Kurban Bayramı")
        };

        public HijriCalendarWindow()
        {
            InitializeComponent();
            LoadHijriDate();
            LoadUpcomingEvents();
        }

        private void LoadHijriDate()
        {
            var hijriCalendar = new HijriCalendar();
            var today = DateTime.Now;
            
            int year = hijriCalendar.GetYear(today);
            int month = hijriCalendar.GetMonth(today);
            int day = hijriCalendar.GetDayOfMonth(today);
            
            string[] monthNames = { "Muharrem", "Safer", "Rebiülevvel", "Rebiülahir", "Cemaziyelevvel", 
                                   "Cemaziyelahir", "Recep", "Şaban", "Ramazan", "Şevval", "Zilkade", "Zilhicce" };
            
            HijriDateText.Text = $"{day} {monthNames[month - 1]} {year}";
            GregorianDateText.Text = $"({today:dd MMMM yyyy})";
        }

        private void LoadUpcomingEvents()
        {
            EventsPanel.Children.Clear();
            
            var title = new TextBlock
            {
                Text = "📅 Yaklaşan Özel Günler",
                FontSize = 20,
                FontWeight = FontWeights.Bold,
                Foreground = new WpfSolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString("#fdcb6e")),
                Margin = new Thickness(0, 0, 0, 20)
            };
            EventsPanel.Children.Add(title);

            foreach (var evt in islamicEvents)
            {
                AddEventCard(evt.Event, $"{evt.Day} {GetMonthName(evt.Month)}");
            }
        }

        private string GetMonthName(int month)
        {
            string[] monthNames = { "Muharrem", "Safer", "Rebiülevvel", "Rebiülahir", "Cemaziyelevvel", 
                                   "Cemaziyelahir", "Recep", "Şaban", "Ramazan", "Şevval", "Zilkade", "Zilhicce" };
            return monthNames[month - 1];
        }

        private void AddEventCard(string eventName, string date)
        {
            var border = new Border
            {
                Background = new WpfSolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString("#2d3436")),
                CornerRadius = new CornerRadius(12),
                Padding = new Thickness(20),
                Margin = new Thickness(0, 0, 0, 12)
            };

            var grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            var nameBlock = new TextBlock
            {
                Text = $"✨ {eventName}",
                FontSize = 16,
                FontWeight = FontWeights.Bold,
                Foreground = new WpfSolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString("#dfe6e9")),
                VerticalAlignment = VerticalAlignment.Center
            };

            var dateBlock = new TextBlock
            {
                Text = date,
                FontSize = 14,
                Foreground = new WpfSolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString("#fdcb6e")),
                VerticalAlignment = VerticalAlignment.Center
            };

            Grid.SetColumn(nameBlock, 0);
            Grid.SetColumn(dateBlock, 1);
            
            grid.Children.Add(nameBlock);
            grid.Children.Add(dateBlock);
            border.Child = grid;
            EventsPanel.Children.Add(border);
        }
    }
}
