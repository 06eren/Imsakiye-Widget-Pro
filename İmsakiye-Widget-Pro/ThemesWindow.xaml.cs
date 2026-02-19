using System.Windows;
using System.Windows.Controls;
using WpfButton = System.Windows.Controls.Button;

namespace İmsakiye_Widget_Pro
{
    public partial class ThemesWindow : Window
    {
        public ThemesWindow()
        {
            InitializeComponent();
        }

        private void Theme_Click(object sender, RoutedEventArgs e)
        {
            if (sender is WpfButton button && button.Tag is string theme)
            {
                var settings = AppSettings.Load();
                settings.Theme = theme;
                settings.Save();
                
                // Tema değişikliğini uygula
                ApplyTheme(theme);
            }
        }

        private void ApplyTheme(string theme)
        {
            // Tema değişikliği uygulanacak
            // Widget ve diğer pencerelere tema renkleri uygulanabilir
        }
    }
}
