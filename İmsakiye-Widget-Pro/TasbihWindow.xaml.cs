using System.Windows;
using WpfColor = System.Windows.Media.Color;
using WpfColorConverter = System.Windows.Media.ColorConverter;
using System.Windows.Media;
using WpfMessageBox = System.Windows.MessageBox;

namespace İmsakiye_Widget_Pro
{
    public partial class TasbihWindow : Window
    {
        private int count = 0;
        private int target = 33;

        public TasbihWindow()
        {
            InitializeComponent();
            UpdateDisplay();
        }

        private void Count_Click(object sender, RoutedEventArgs e)
        {
            count++;
            UpdateDisplay();
            
            if (count == target)
            {
                CountButton.Background = new SolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString("#00b894")!);
                WpfMessageBox.Show($"Tebrikler! {target} tane tamamlandı! 🎉", "Hedef Tamamlandı", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void UpdateDisplay()
        {
            CountText.Text = count.ToString();
            TargetText.Text = $"Hedef: {target} ({target - count} kaldı)";
            
            if (count >= target)
            {
                CountText.Foreground = new SolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString("#00b894")!);
            }
            else
            {
                CountText.Foreground = new SolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString("#00b894")!);
            }
        }

        private void SetTarget33_Click(object sender, RoutedEventArgs e)
        {
            target = 33;
            UpdateDisplay();
        }

        private void SetTarget99_Click(object sender, RoutedEventArgs e)
        {
            target = 99;
            UpdateDisplay();
        }

        private void SetTarget100_Click(object sender, RoutedEventArgs e)
        {
            target = 100;
            UpdateDisplay();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            count = 0;
            UpdateDisplay();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
