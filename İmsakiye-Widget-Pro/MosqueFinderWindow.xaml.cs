using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WpfColor = System.Windows.Media.Color;
using WpfColorConverter = System.Windows.Media.ColorConverter;
using WpfSolidColorBrush = System.Windows.Media.SolidColorBrush;

namespace İmsakiye_Widget_Pro
{
    public partial class MosqueFinderWindow : Window
    {
        private readonly List<(string Name, string Address, string Distance)> mosques = new()
        {
            ("Kocatepe Camii", "Kocatepe Mah. Ankara", "2.5 km"),
            ("Hacı Bayram Camii", "Ulus, Ankara", "3.1 km"),
            ("Ahmet Hamdi Akseki Camii", "Çankaya, Ankara", "1.8 km"),
            ("Maltepe Camii", "Maltepe, Ankara", "4.2 km"),
            ("Ahi Elvan Camii", "Ulus, Ankara", "3.5 km")
        };

        public MosqueFinderWindow()
        {
            InitializeComponent();
            LoadNearbyMosques();
        }

        private void LoadNearbyMosques()
        {
            MosquePanel.Children.Clear();
            foreach (var mosque in mosques)
            {
                AddMosqueCard(mosque.Name, mosque.Address, mosque.Distance);
            }
        }

        private void AddMosqueCard(string name, string address, string distance)
        {
            var border = new Border
            {
                Background = new WpfSolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString("#2d3436")),
                CornerRadius = new CornerRadius(15),
                Padding = new Thickness(20),
                Margin = new Thickness(0, 0, 0, 15)
            };

            var grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            var stack = new StackPanel();
            
            var nameBlock = new TextBlock
            {
                Text = $"🕌 {name}",
                FontSize = 18,
                FontWeight = FontWeights.Bold,
                Foreground = new WpfSolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString("#00b894")),
                Margin = new Thickness(0, 0, 0, 8)
            };
            
            var addressBlock = new TextBlock
            {
                Text = $"📍 {address}",
                FontSize = 14,
                Foreground = new WpfSolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString("#dfe6e9"))
            };

            stack.Children.Add(nameBlock);
            stack.Children.Add(addressBlock);

            var distanceBlock = new TextBlock
            {
                Text = distance,
                FontSize = 16,
                FontWeight = FontWeights.Bold,
                Foreground = new WpfSolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString("#fdcb6e")),
                VerticalAlignment = VerticalAlignment.Center
            };

            Grid.SetColumn(stack, 0);
            Grid.SetColumn(distanceBlock, 1);
            
            grid.Children.Add(stack);
            grid.Children.Add(distanceBlock);
            border.Child = grid;
            MosquePanel.Children.Add(border);
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            LoadNearbyMosques();
        }
    }
}
