using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WpfColor = System.Windows.Media.Color;
using WpfColorConverter = System.Windows.Media.ColorConverter;
using WpfSolidColorBrush = System.Windows.Media.SolidColorBrush;
using WpfButton = System.Windows.Controls.Button;
using WpfBrushes = System.Windows.Media.Brushes;

namespace İmsakiye_Widget_Pro
{
    public partial class LibraryWindow : Window
    {
        private readonly List<(string Title, string Author, string Type)> books = new()
        {
            ("Kur'an-ı Kerim Meali", "Diyanet İşleri Başkanlığı", "Kitap"),
            ("Riyazü's-Salihin", "İmam Nevevi", "Kitap"),
            ("Muhtasar İlmihal", "Ömer Nasuhi Bilmen", "Kitap"),
            ("İhya-u Ulumiddin", "İmam Gazali", "Kitap"),
            ("Kırk Hadis", "İmam Nevevi", "Kitap")
        };

        private readonly List<(string Title, string Topic)> articles = new()
        {
            ("Namaz Kılmanın Faydaları", "İbadet"),
            ("Zekat Nedir ve Nasıl Verilir?", "Zekat"),
            ("Ramazan Ayının Önemi", "Ramazan"),
            ("Hac İbadeti Rehberi", "Hac"),
            ("Kurban Kesmenin Hikmeti", "Kurban")
        };

        public LibraryWindow()
        {
            InitializeComponent();
            LoadBooks();
        }

        private void Books_Click(object sender, RoutedEventArgs e)
        {
            LoadBooks();
        }

        private void Articles_Click(object sender, RoutedEventArgs e)
        {
            LoadArticles();
        }

        private void Videos_Click(object sender, RoutedEventArgs e)
        {
            LoadVideos();
        }

        private void Podcasts_Click(object sender, RoutedEventArgs e)
        {
            LoadPodcasts();
        }

        private void LoadBooks()
        {
            ContentPanel.Children.Clear();
            foreach (var book in books)
            {
                AddLibraryItem("📖", book.Title, book.Author, "#00b894");
            }
        }

        private void LoadArticles()
        {
            ContentPanel.Children.Clear();
            foreach (var article in articles)
            {
                AddLibraryItem("📝", article.Title, article.Topic, "#0984e3");
            }
        }

        private void LoadVideos()
        {
            ContentPanel.Children.Clear();
            AddLibraryItem("🎥", "Namaz Nasıl Kılınır?", "Eğitim Videosu", "#e17055");
            AddLibraryItem("🎥", "Kur'an Öğreniyorum", "Eğitim Serisi", "#e17055");
            AddLibraryItem("🎥", "İslam Tarihi Belgeseli", "Belgesel", "#e17055");
            AddLibraryItem("🎥", "Peygamber Kıssaları", "Animasyon", "#e17055");
        }

        private void LoadPodcasts()
        {
            ContentPanel.Children.Clear();
            AddLibraryItem("🎧", "Günün Hadisi", "Günlük Podcast", "#6c5ce7");
            AddLibraryItem("🎧", "İslam ve Bilim", "Haftalık Podcast", "#6c5ce7");
            AddLibraryItem("🎧", "Dini Sohbetler", "Sohbet Serisi", "#6c5ce7");
            AddLibraryItem("🎧", "Kur'an Tefsiri", "Tefsir Dersleri", "#6c5ce7");
        }

        private void AddLibraryItem(string icon, string title, string subtitle, string color)
        {
            var border = new Border
            {
                Background = new WpfSolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString("#2d3436")),
                CornerRadius = new CornerRadius(15),
                Padding = new Thickness(20),
                Margin = new Thickness(0, 0, 0, 15)
            };

            var grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            var iconBlock = new TextBlock
            {
                Text = icon,
                FontSize = 32,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 0, 15, 0)
            };

            var stack = new StackPanel();
            
            var titleBlock = new TextBlock
            {
                Text = title,
                FontSize = 16,
                FontWeight = FontWeights.Bold,
                Foreground = new WpfSolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString(color)),
                Margin = new Thickness(0, 0, 0, 5)
            };
            
            var subtitleBlock = new TextBlock
            {
                Text = subtitle,
                FontSize = 14,
                Foreground = new WpfSolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString("#dfe6e9"))
            };

            stack.Children.Add(titleBlock);
            stack.Children.Add(subtitleBlock);

            var button = new WpfButton
            {
                Content = "Aç",
                Background = new WpfSolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString(color)),
                Foreground = WpfBrushes.White,
                BorderThickness = new Thickness(0),
                Padding = new Thickness(20, 8, 20, 8),
                FontSize = 14,
                FontWeight = FontWeights.Bold,
                VerticalAlignment = VerticalAlignment.Center
            };

            Grid.SetColumn(iconBlock, 0);
            Grid.SetColumn(stack, 1);
            Grid.SetColumn(button, 2);
            
            grid.Children.Add(iconBlock);
            grid.Children.Add(stack);
            grid.Children.Add(button);
            border.Child = grid;
            ContentPanel.Children.Add(border);
        }
    }
}
