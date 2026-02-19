using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WpfColor = System.Windows.Media.Color;
using WpfColorConverter = System.Windows.Media.ColorConverter;
using System.Windows.Media;

namespace İmsakiye_Widget_Pro
{
    public partial class DhikrWindow : Window
    {
        private readonly List<(string Arabic, string Turkish, string Count)> dhikrs = new()
        {
            ("سُبْحَانَ اللهِ", "Sübhanallah", "33x"),
            ("الْحَمْدُ لِلَّهِ", "Elhamdülillah", "33x"),
            ("اللَّهُ أَكْبَرُ", "Allahu Ekber", "34x"),
            ("لَا إِلَهَ إِلَّا اللَّهُ", "La ilahe illallah", "100x"),
            ("أَسْتَغْفِرُ اللَّهَ", "Estağfirullah", "100x"),
            ("سُبْحَانَ اللَّهِ وَبِحَمْدِهِ", "Sübhanallahi ve bihamdihi", "100x"),
            ("سُبْحَانَ اللَّهِ الْعَظِيمِ", "Sübhanallahil azim", "Sınırsız"),
            ("لَا حَوْلَ وَلَا قُوَّةَ إِلَّا بِاللَّهِ", "La havle vela kuvvete illa billah", "Sınırsız"),
            ("حَسْبُنَا اللَّهُ وَنِعْمَ الْوَكِيلُ", "Hasbünallahu ve ni'mel vekil", "Sınırsız"),
            ("اللَّهُمَّ صَلِّ عَلَى مُحَمَّدٍ", "Allahumme salli ala Muhammed", "Sınırsız")
        };

        public DhikrWindow()
        {
            InitializeComponent();
            LoadDhikrs();
        }

        private void LoadDhikrs()
        {
            var colors = new[] { "#00b894", "#00cec9", "#fdcb6e", "#e17055", "#fd79a8", "#6c5ce7", "#0984e3", "#a29bfe" };
            int index = 0;

            foreach (var dhikr in dhikrs)
            {
                var border = new Border
                {
                    Background = new SolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString("#2d3436")!),
                    CornerRadius = new CornerRadius(10),
                    Padding = new Thickness(20),
                    Margin = new Thickness(0, 0, 0, 15),
                    BorderBrush = new SolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString(colors[index % colors.Length])!),
                    BorderThickness = new Thickness(0, 0, 0, 3)
                };

                var grid = new Grid();
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

                var stack = new StackPanel();

                var arabic = new TextBlock
                {
                    Text = dhikr.Arabic,
                    FontSize = 24,
                    FontWeight = FontWeights.Bold,
                    Foreground = new SolidColorBrush(System.Windows.Media.Colors.White),
                    Margin = new Thickness(0, 0, 0, 8)
                };

                var turkish = new TextBlock
                {
                    Text = dhikr.Turkish,
                    FontSize = 16,
                    Foreground = new SolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString("#dfe6e9")!)
                };

                stack.Children.Add(arabic);
                stack.Children.Add(turkish);

                var count = new TextBlock
                {
                    Text = dhikr.Count,
                    FontSize = 20,
                    FontWeight = FontWeights.Bold,
                    Foreground = new SolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString(colors[index % colors.Length])!),
                    VerticalAlignment = VerticalAlignment.Center
                };

                Grid.SetColumn(stack, 0);
                Grid.SetColumn(count, 1);

                grid.Children.Add(stack);
                grid.Children.Add(count);
                border.Child = grid;
                DhikrPanel.Children.Add(border);
                index++;
            }
        }
    }
}
