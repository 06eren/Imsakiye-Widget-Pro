using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WpfColor = System.Windows.Media.Color;
using WpfColorConverter = System.Windows.Media.ColorConverter;
using WpfSolidColorBrush = System.Windows.Media.SolidColorBrush;

namespace İmsakiye_Widget_Pro
{
    public partial class HadithLibraryWindow : Window
    {
        private readonly List<(string Text, string Reference, string Topic)> hadiths = new()
        {
            ("İman, yetmiş küsur şubedir. En üstünü 'Lâ ilâhe illallah' demek, en aşağısı yoldan ezayı kaldırmaktır. Hayâ da imandandır.", "Buhari, Müslim", "İman"),
            ("Müslüman, elinden ve dilinden Müslümanların emin olduğu kimsedir.", "Buhari", "Ahlak"),
            ("Mü'minin işi ne güzeldir! Onun bütün işleri hayırlıdır. Kendisine bir sevinç gelirse şükreder, bu onun için hayırlıdır. Başına bir sıkıntı gelirse sabreder, bu da onun için hayırlıdır.", "Müslim", "Sabır"),
            ("Allah'a ve ahiret gününe iman eden ya hayır söylesin ya da sussun.", "Buhari, Müslim", "Ahlak"),
            ("İnsanların en hayırlısı, insanlara faydalı olandır.", "Taberani", "Hayır"),
            ("Bir kimse Allah için sever, Allah için buğzeder, Allah için verir ve Allah için vermezse imanını tamamlamış olur.", "Ebu Davud", "İman"),
            ("Güçlü olan, güreşte rakibini yenen değil, öfkelendiği zaman nefsine hakim olan kimsedir.", "Buhari, Müslim", "Öfke"),
            ("Sizden biriniz, kendisi için istediğini kardeşi için de istemedikçe iman etmiş olmaz.", "Buhari, Müslim", "Kardeşlik"),
            ("Allah katında amellerin en sevimli olanı, az da olsa devamlı yapılanıdır.", "Buhari, Müslim", "İbadet"),
            ("Bir kimse bir müslümanın dünya sıkıntılarından birini giderirse, Allah da onun kıyamet günü sıkıntılarından birini giderir.", "Müslim", "Yardımlaşma")
        };

        public HadithLibraryWindow()
        {
            InitializeComponent();
            LoadFortyHadith();
        }

        private void FortyHadith_Click(object sender, RoutedEventArgs e)
        {
            LoadFortyHadith();
        }

        private void DailyHadith_Click(object sender, RoutedEventArgs e)
        {
            HadithPanel.Children.Clear();
            var random = new Random(DateTime.Now.DayOfYear);
            var hadith = hadiths[random.Next(hadiths.Count)];
            AddHadithCard(hadith.Text, hadith.Reference, hadith.Topic);
        }

        private void ByTopic_Click(object sender, RoutedEventArgs e)
        {
            LoadFortyHadith();
        }

        private void LoadFortyHadith()
        {
            HadithPanel.Children.Clear();
            for (int i = 0; i < hadiths.Count; i++)
            {
                AddHadithCard($"{i + 1}. {hadiths[i].Text}", hadiths[i].Reference, hadiths[i].Topic);
            }
        }

        private void AddHadithCard(string text, string reference, string topic)
        {
            var border = new Border
            {
                Background = new WpfSolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString("#2d3436")),
                CornerRadius = new CornerRadius(15),
                Padding = new Thickness(25),
                Margin = new Thickness(0, 0, 0, 20)
            };

            var stack = new StackPanel();
            
            var topicBlock = new TextBlock
            {
                Text = $"📌 {topic}",
                FontSize = 14,
                Foreground = new WpfSolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString("#00b894")),
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(0, 0, 0, 10)
            };
            
            var textBlock = new TextBlock
            {
                Text = text,
                FontSize = 16,
                Foreground = new WpfSolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString("#dfe6e9")),
                TextWrapping = TextWrapping.Wrap,
                LineHeight = 24,
                Margin = new Thickness(0, 0, 0, 10)
            };
            
            var refBlock = new TextBlock
            {
                Text = $"({reference})",
                FontSize = 14,
                Foreground = new WpfSolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString("#fdcb6e")),
                FontStyle = FontStyles.Italic
            };

            stack.Children.Add(topicBlock);
            stack.Children.Add(textBlock);
            stack.Children.Add(refBlock);
            border.Child = stack;
            HadithPanel.Children.Add(border);
        }
    }
}
