using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WpfColor = System.Windows.Media.Color;
using WpfColorConverter = System.Windows.Media.ColorConverter;
using WpfSolidColorBrush = System.Windows.Media.SolidColorBrush;

namespace İmsakiye_Widget_Pro
{
    public partial class EducationWindow : Window
    {
        public EducationWindow()
        {
            InitializeComponent();
            LoadPrayerTutorial();
        }

        private void PrayerTutorial_Click(object sender, RoutedEventArgs e)
        {
            LoadPrayerTutorial();
        }

        private void AblutionGuide_Click(object sender, RoutedEventArgs e)
        {
            LoadAblutionGuide();
        }

        private void DuaLearning_Click(object sender, RoutedEventArgs e)
        {
            LoadDuaLearning();
        }

        private void ArabicBasics_Click(object sender, RoutedEventArgs e)
        {
            LoadArabicBasics();
        }

        private void LoadPrayerTutorial()
        {
            ContentPanel.Children.Clear();
            AddTitle("🕌 Namaz Kılma Rehberi");
            AddContent("1. Niyet", "Kalbinizden hangi namazı kılacağınıza niyet edin.");
            AddContent("2. İftitah Tekbiri", "Ellerinizi kaldırarak 'Allahu Ekber' deyin.");
            AddContent("3. Fatiha Suresi", "Fatiha suresini okuyun.");
            AddContent("4. Rükû", "Eğilerek 'Sübhane Rabbiyel Azim' deyin.");
            AddContent("5. Secde", "İki kez secde yapın, 'Sübhane Rabbiyel A'la' deyin.");
            AddContent("6. Teşehhüd", "Oturarak teşehhüd ve salavat okuyun.");
            AddContent("7. Selam", "Sağa ve sola selam vererek namazı tamamlayın.");
        }

        private void LoadAblutionGuide()
        {
            ContentPanel.Children.Clear();
            AddTitle("💧 Abdest Alma Rehberi");
            AddContent("1. Niyet", "Abdest almaya niyet edin.");
            AddContent("2. Besmele", "Besmele çekerek başlayın.");
            AddContent("3. Eller", "Ellerinizi bileklere kadar üç kez yıkayın.");
            AddContent("4. Ağız", "Ağzınızı üç kez çalkalayın.");
            AddContent("5. Burun", "Burnunuza üç kez su çekin.");
            AddContent("6. Yüz", "Yüzünüzü üç kez yıkayın.");
            AddContent("7. Kollar", "Kollarınızı dirseklere kadar üç kez yıkayın.");
            AddContent("8. Mesh", "Başınızı mesh edin.");
            AddContent("9. Ayaklar", "Ayaklarınızı topuklara kadar üç kez yıkayın.");
        }

        private void LoadDuaLearning()
        {
            ContentPanel.Children.Clear();
            AddTitle("🤲 Dua Öğrenme");
            AddContent("Sabah Duası", "Allahümme bike esbehnâ ve bike emsaynâ...");
            AddContent("Akşam Duası", "Allahümme bike emsaynâ ve bike esbehnâ...");
            AddContent("Yemek Duası", "Bismillahi ve alâ berekâtillah");
            AddContent("Yolculuk Duası", "Sübhanellezi sehhara lenâ hâzâ...");
            AddContent("Uyku Duası", "Allahümme bismike emûtü ve ahyâ");
        }

        private void LoadArabicBasics()
        {
            ContentPanel.Children.Clear();
            AddTitle("📖 Arapça Temel Bilgiler");
            AddContent("Elif (ا)", "A harfi");
            AddContent("Be (ب)", "B harfi");
            AddContent("Te (ت)", "T harfi");
            AddContent("Se (ث)", "S harfi");
            AddContent("Cim (ج)", "C harfi");
            AddContent("Ha (ح)", "H harfi");
            AddContent("Dal (د)", "D harfi");
        }

        private void AddTitle(string title)
        {
            var titleBlock = new TextBlock
            {
                Text = title,
                FontSize = 22,
                FontWeight = FontWeights.Bold,
                Foreground = new WpfSolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString("#0984e3")),
                Margin = new Thickness(0, 0, 0, 20)
            };
            ContentPanel.Children.Add(titleBlock);
        }

        private void AddContent(string heading, string text)
        {
            var border = new Border
            {
                Background = new WpfSolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString("#2d3436")),
                CornerRadius = new CornerRadius(12),
                Padding = new Thickness(20),
                Margin = new Thickness(0, 0, 0, 12)
            };

            var stack = new StackPanel();
            
            var headingBlock = new TextBlock
            {
                Text = heading,
                FontSize = 16,
                FontWeight = FontWeights.Bold,
                Foreground = new WpfSolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString("#00b894")),
                Margin = new Thickness(0, 0, 0, 5)
            };
            
            var textBlock = new TextBlock
            {
                Text = text,
                FontSize = 14,
                Foreground = new WpfSolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString("#dfe6e9")),
                TextWrapping = TextWrapping.Wrap
            };

            stack.Children.Add(headingBlock);
            stack.Children.Add(textBlock);
            border.Child = stack;
            ContentPanel.Children.Add(border);
        }
    }
}
