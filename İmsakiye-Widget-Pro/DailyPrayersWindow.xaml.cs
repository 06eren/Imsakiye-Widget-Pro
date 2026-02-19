using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WpfColor = System.Windows.Media.Color;
using WpfColorConverter = System.Windows.Media.ColorConverter;
using WpfColors = System.Windows.Media.Colors;
using System.Windows.Media;

namespace İmsakiye_Widget_Pro
{
    public partial class DailyPrayersWindow : Window
    {
        private readonly Dictionary<string, string> prayers = new()
        {
            { "Sabah Duası", "Allahümme bike esbahnâ ve bike emsaynâ ve bike nahyâ ve bike nemûtü ve ileyke'n-nüşûr." },
            { "Akşam Duası", "Allahümme bike emsaynâ ve bike esbahnâ ve bike nahyâ ve bike nemûtü ve ileyke'l-masîr." },
            { "Yemek Öncesi", "Bismillahi ve alâ berekâtillâh." },
            { "Yemek Sonrası", "Elhamdülillâhillezî et'amenâ ve sekānâ ve ceale'nâ müslimîn." },
            { "Yolculuk Duası", "Sübhânellezî sehhara lenâ hâzâ ve mâ künnâ lehû mukrinîn. Ve innâ ilâ rabbinâ lemünkalibûn." },
            { "Uyku Öncesi", "Allahümme bismike emûtü ve ahyâ." },
            { "Uyanınca", "Elhamdülillâhillezî ahyânâ ba'de mâ emâtenâ ve ileyhi'n-nüşûr." }
        };

        public DailyPrayersWindow()
        {
            InitializeComponent();
            LoadPrayers();
        }

        private void LoadPrayers()
        {
            foreach (var prayer in prayers)
            {
                var border = new Border
                {
                    Background = new SolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString("#2d3436")!),
                    CornerRadius = new CornerRadius(10),
                    Padding = new Thickness(15),
                    Margin = new Thickness(0, 0, 0, 15),
                    BorderBrush = new SolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString("#fdcb6e")!),
                    BorderThickness = new Thickness(0, 0, 0, 3)
                };

                var stack = new StackPanel();
                
                var title = new TextBlock
                {
                    Text = prayer.Key,
                    FontSize = 18,
                    FontWeight = FontWeights.Bold,
                    Foreground = new SolidColorBrush(WpfColors.White),
                    Margin = new Thickness(0, 0, 0, 10)
                };

                var content = new TextBlock
                {
                    Text = prayer.Value,
                    FontSize = 14,
                    Foreground = new SolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString("#dfe6e9")!),
                    TextWrapping = TextWrapping.Wrap,
                    LineHeight = 22
                };

                stack.Children.Add(title);
                stack.Children.Add(content);
                border.Child = stack;
                PrayersPanel.Children.Add(border);
            }
        }
    }
}
