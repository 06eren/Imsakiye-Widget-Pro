using System;
using System.Windows;
using WpfMessageBox = System.Windows.MessageBox;
using WpfMessageBoxButton = System.Windows.MessageBoxButton;
using WpfMessageBoxImage = System.Windows.MessageBoxImage;

namespace İmsakiye_Widget_Pro
{
    public partial class RamadanSpecialWindow : Window
    {
        private int tarawihCount = 15;
        private int juzCount = 12;

        public RamadanSpecialWindow()
        {
            InitializeComponent();
            UpdateCountdown();
        }

        private void UpdateCountdown()
        {
            var now = DateTime.Now;
            var iftar = new DateTime(now.Year, now.Month, now.Day, 18, 30, 0);
            
            if (now > iftar)
                iftar = iftar.AddDays(1);
            
            var remaining = iftar - now;
            IftarCountdown.Text = $"İftara Kalan: {remaining.Hours} saat {remaining.Minutes} dakika";
        }

        private void SetSahurAlarm_Click(object sender, RoutedEventArgs e)
        {
            WpfMessageBox.Show("Sahur alarmı kuruldu! Yarın sabah 04:30'da uyandırılacaksınız.", 
                "Alarm Kuruldu", WpfMessageBoxButton.OK, WpfMessageBoxImage.Information);
        }

        private void MarkTarawih_Click(object sender, RoutedEventArgs e)
        {
            if (tarawihCount < 30)
            {
                tarawihCount++;
                TarawihProgress.Text = $"Kılınan Teravih: {tarawihCount}/30";
                TarawihBar.Value = (tarawihCount / 30.0) * 100;
            }
            else
            {
                WpfMessageBox.Show("Tebrikler! Ramazan boyunca tüm teravihleri kıldınız!", 
                    "Başarı", WpfMessageBoxButton.OK, WpfMessageBoxImage.Information);
            }
        }

        private void MarkJuz_Click(object sender, RoutedEventArgs e)
        {
            if (juzCount < 30)
            {
                juzCount++;
                MukabeleProgress.Text = $"Okunan Cüz: {juzCount}/30";
                MukabeleBar.Value = (juzCount / 30.0) * 100;
            }
            else
            {
                WpfMessageBox.Show("Maşallah! Kur'an-ı Kerim'i hatmettiniz!", 
                    "Hatim Tamamlandı", WpfMessageBoxButton.OK, WpfMessageBoxImage.Information);
            }
        }
    }
}
