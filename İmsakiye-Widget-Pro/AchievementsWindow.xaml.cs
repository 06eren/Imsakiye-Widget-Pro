using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WpfColor = System.Windows.Media.Color;
using WpfColorConverter = System.Windows.Media.ColorConverter;
using WpfSolidColorBrush = System.Windows.Media.SolidColorBrush;

namespace İmsakiye_Widget_Pro
{
    public partial class AchievementsWindow : Window
    {
        private readonly List<(string Icon, string Name, string Description, bool Unlocked)> achievements = new()
        {
            ("🌟", "İlk Adım", "İlk namazını kıldın", true),
            ("📿", "Tesbih Ustası", "1000 tesbih çektin", true),
            ("📖", "Kur'an Okuyucusu", "İlk cüzü tamamladın", true),
            ("🕌", "Cami Ziyaretçisi", "10 farklı cami ziyaret ettin", false),
            ("⏰", "Erken Kalkan", "7 gün üst üste sabah namazını kıldın", true),
            ("🌙", "Ramazan Kahramanı", "Ramazan'ı tamamladın", false),
            ("💰", "Zekat Veren", "İlk zekatını verdin", true),
            ("🎯", "Hedef Odaklı", "Tüm günlük görevleri tamamladın", false),
            ("🏆", "Şampiyon", "100 rozet topladın", false)
        };

        public AchievementsWindow()
        {
            InitializeComponent();
            LoadAchievements();
        }

        private void LoadAchievements()
        {
            foreach (var achievement in achievements)
            {
                AddAchievementCard(achievement.Icon, achievement.Name, achievement.Description, achievement.Unlocked);
            }
        }

        private void AddAchievementCard(string icon, string name, string description, bool unlocked)
        {
            var border = new Border
            {
                Background = new WpfSolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString(unlocked ? "#2d3436" : "#1a1f24")),
                CornerRadius = new CornerRadius(15),
                Padding = new Thickness(20),
                Margin = new Thickness(10),
                Opacity = unlocked ? 1.0 : 0.5
            };

            var stack = new StackPanel
            {
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center
            };
            
            var iconBlock = new TextBlock
            {
                Text = icon,
                FontSize = 48,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                Margin = new Thickness(0, 0, 0, 10)
            };
            
            var nameBlock = new TextBlock
            {
                Text = name,
                FontSize = 16,
                FontWeight = FontWeights.Bold,
                Foreground = new WpfSolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString(unlocked ? "#00b894" : "#636e72")),
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                Margin = new Thickness(0, 0, 0, 5)
            };
            
            var descBlock = new TextBlock
            {
                Text = description,
                FontSize = 12,
                Foreground = new WpfSolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString("#dfe6e9")),
                TextWrapping = TextWrapping.Wrap,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                TextAlignment = TextAlignment.Center
            };

            var statusBlock = new TextBlock
            {
                Text = unlocked ? "✓ Kazanıldı" : "🔒 Kilitli",
                FontSize = 11,
                Foreground = new WpfSolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString(unlocked ? "#00b894" : "#636e72")),
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                Margin = new Thickness(0, 10, 0, 0),
                FontWeight = FontWeights.Bold
            };

            stack.Children.Add(iconBlock);
            stack.Children.Add(nameBlock);
            stack.Children.Add(descBlock);
            stack.Children.Add(statusBlock);
            border.Child = stack;
            AchievementsPanel.Children.Add(border);
        }
    }
}
