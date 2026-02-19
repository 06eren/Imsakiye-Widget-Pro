using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfColor = System.Windows.Media.Color;
using WpfColorConverter = System.Windows.Media.ColorConverter;
using System.Windows.Media;

namespace İmsakiye_Widget_Pro
{
    public partial class QuranWindow : Window
    {
        private readonly List<(int Number, string Arabic, string Turkish, int Verses, string Type)> surahs = new()
        {
            (1, "الفاتحة", "Fatiha", 7, "Mekki"),
            (2, "البقرة", "Bakara", 286, "Medeni"),
            (3, "آل عمران", "Âl-i İmran", 200, "Medeni"),
            (4, "النساء", "Nisa", 176, "Medeni"),
            (5, "المائدة", "Maide", 120, "Medeni"),
            (6, "الأنعام", "En'am", 165, "Mekki"),
            (7, "الأعراف", "A'raf", 206, "Mekki"),
            (8, "الأنفال", "Enfal", 75, "Medeni"),
            (9, "التوبة", "Tevbe", 129, "Medeni"),
            (10, "يونس", "Yunus", 109, "Mekki"),
            (11, "هود", "Hud", 123, "Mekki"),
            (12, "يوسف", "Yusuf", 111, "Mekki"),
            (13, "الرعد", "Ra'd", 43, "Medeni"),
            (14, "ابراهيم", "İbrahim", 52, "Mekki"),
            (15, "الحجر", "Hicr", 99, "Mekki"),
            (16, "النحل", "Nahl", 128, "Mekki"),
            (17, "الإسراء", "İsra", 111, "Mekki"),
            (18, "الكهف", "Kehf", 110, "Mekki"),
            (19, "مريم", "Meryem", 98, "Mekki"),
            (20, "طه", "Taha", 135, "Mekki"),
            (21, "الأنبياء", "Enbiya", 112, "Mekki"),
            (22, "الحج", "Hacc", 78, "Medeni"),
            (23, "المؤمنون", "Mü'minun", 118, "Mekki"),
            (24, "النور", "Nur", 64, "Medeni"),
            (25, "الفرقان", "Furkan", 77, "Mekki"),
            (26, "الشعراء", "Şuara", 227, "Mekki"),
            (27, "النمل", "Neml", 93, "Mekki"),
            (28, "القصص", "Kasas", 88, "Mekki"),
            (29, "العنكبوت", "Ankebut", 69, "Mekki"),
            (30, "الروم", "Rum", 60, "Mekki"),
            (31, "لقمان", "Lokman", 34, "Mekki"),
            (32, "السجدة", "Secde", 30, "Mekki"),
            (33, "الأحزاب", "Ahzab", 73, "Medeni"),
            (34, "سبإ", "Sebe", 54, "Mekki"),
            (35, "فاطر", "Fatır", 45, "Mekki"),
            (36, "يس", "Yasin", 83, "Mekki"),
            (37, "الصافات", "Saffat", 182, "Mekki"),
            (38, "ص", "Sad", 88, "Mekki"),
            (39, "الزمر", "Zümer", 75, "Mekki"),
            (40, "غافر", "Mü'min", 85, "Mekki"),
            (41, "فصلت", "Fussilet", 54, "Mekki"),
            (42, "الشورى", "Şura", 53, "Mekki"),
            (43, "الزخرف", "Zuhruf", 89, "Mekki"),
            (44, "الدخان", "Duhan", 59, "Mekki"),
            (45, "الجاثية", "Casiye", 37, "Mekki"),
            (46, "الأحقاف", "Ahkaf", 35, "Mekki"),
            (47, "محمد", "Muhammed", 38, "Medeni"),
            (48, "الفتح", "Fetih", 29, "Medeni"),
            (49, "الحجرات", "Hucurat", 18, "Medeni"),
            (50, "ق", "Kaf", 45, "Mekki"),
            (51, "الذاريات", "Zariyat", 60, "Mekki"),
            (52, "الطور", "Tur", 49, "Mekki"),
            (53, "النجم", "Necm", 62, "Mekki"),
            (54, "القمر", "Kamer", 55, "Mekki"),
            (55, "الرحمن", "Rahman", 78, "Medeni"),
            (56, "الواقعة", "Vakıa", 96, "Mekki"),
            (57, "الحديد", "Hadid", 29, "Medeni"),
            (58, "المجادلة", "Mücadele", 22, "Medeni"),
            (59, "الحشر", "Haşr", 24, "Medeni"),
            (60, "الممتحنة", "Mümtehine", 13, "Medeni"),
            (61, "الصف", "Saff", 14, "Medeni"),
            (62, "الجمعة", "Cuma", 11, "Medeni"),
            (63, "المنافقون", "Münafikun", 11, "Medeni"),
            (64, "التغابن", "Teğabun", 18, "Medeni"),
            (65, "الطلاق", "Talak", 12, "Medeni"),
            (66, "التحريم", "Tahrim", 12, "Medeni"),
            (67, "الملك", "Mülk", 30, "Mekki"),
            (68, "القلم", "Kalem", 52, "Mekki"),
            (69, "الحاقة", "Hakka", 52, "Mekki"),
            (70, "المعارج", "Mearic", 44, "Mekki"),
            (71, "نوح", "Nuh", 28, "Mekki"),
            (72, "الجن", "Cin", 28, "Mekki"),
            (73, "المزمل", "Müzzemmil", 20, "Mekki"),
            (74, "المدثر", "Müddessir", 56, "Mekki"),
            (75, "القيامة", "Kıyame", 40, "Mekki"),
            (76, "الانسان", "İnsan", 31, "Medeni"),
            (77, "المرسلات", "Mürselat", 50, "Mekki"),
            (78, "النبإ", "Nebe", 40, "Mekki"),
            (79, "النازعات", "Naziat", 46, "Mekki"),
            (80, "عبس", "Abese", 42, "Mekki"),
            (81, "التكوير", "Tekvir", 29, "Mekki"),
            (82, "الإنفطار", "İnfitar", 19, "Mekki"),
            (83, "المطففين", "Mutaffifin", 36, "Mekki"),
            (84, "الإنشقاق", "İnşikak", 25, "Mekki"),
            (85, "البروج", "Buruc", 22, "Mekki"),
            (86, "الطارق", "Tarık", 17, "Mekki"),
            (87, "الأعلى", "A'la", 19, "Mekki"),
            (88, "الغاشية", "Ğaşiye", 26, "Mekki"),
            (89, "الفجر", "Fecr", 30, "Mekki"),
            (90, "البلد", "Beled", 20, "Mekki"),
            (91, "الشمس", "Şems", 15, "Mekki"),
            (92, "الليل", "Leyl", 21, "Mekki"),
            (93, "الضحى", "Duha", 11, "Mekki"),
            (94, "الشرح", "İnşirah", 8, "Mekki"),
            (95, "التين", "Tin", 8, "Mekki"),
            (96, "العلق", "Alak", 19, "Mekki"),
            (97, "القدر", "Kadir", 5, "Mekki"),
            (98, "البينة", "Beyyine", 8, "Medeni"),
            (99, "الزلزلة", "Zilzal", 8, "Medeni"),
            (100, "العاديات", "Adiyat", 11, "Mekki"),
            (101, "القارعة", "Karia", 11, "Mekki"),
            (102, "التكاثر", "Tekasür", 8, "Mekki"),
            (103, "العصر", "Asr", 3, "Mekki"),
            (104, "الهمزة", "Hümeze", 9, "Mekki"),
            (105, "الفيل", "Fil", 5, "Mekki"),
            (106, "قريش", "Kureyş", 4, "Mekki"),
            (107, "الماعون", "Maun", 7, "Mekki"),
            (108, "الكوثر", "Kevser", 3, "Mekki"),
            (109, "الكافرون", "Kafirun", 6, "Mekki"),
            (110, "النصر", "Nasr", 3, "Medeni"),
            (111, "المسد", "Mesed", 5, "Mekki"),
            (112, "الإخلاص", "İhlas", 4, "Mekki"),
            (113, "الفلق", "Felak", 5, "Mekki"),
            (114, "الناس", "Nas", 6, "Mekki")
        };

        private List<(int Number, string Arabic, string Turkish, int Verses, string Type)> filteredSurahs;

        public QuranWindow()
        {
            InitializeComponent();
            filteredSurahs = surahs;
            LoadSurahs();
        }

        private void LoadSurahs()
        {
            SurahPanel.Children.Clear();

            var colors = new[] { "#00b894", "#00cec9", "#fdcb6e", "#e17055", "#fd79a8", "#6c5ce7", "#0984e3", "#a29bfe" };

            foreach (var surah in filteredSurahs)
            {
                var border = new Border
                {
                    Background = new SolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString("#2d3436")!),
                    CornerRadius = new CornerRadius(10),
                    Padding = new Thickness(15),
                    Margin = new Thickness(0, 0, 0, 10),
                    BorderBrush = new SolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString(colors[(surah.Number - 1) % colors.Length])!),
                    BorderThickness = new Thickness(0, 0, 0, 3)
                };

                var grid = new Grid();
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

                var number = new Border
                {
                    Background = new SolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString(colors[(surah.Number - 1) % colors.Length])!),
                    Width = 50,
                    Height = 50,
                    CornerRadius = new CornerRadius(25),
                    Margin = new Thickness(0, 0, 15, 0)
                };

                var numberText = new TextBlock
                {
                    Text = surah.Number.ToString(),
                    FontSize = 20,
                    FontWeight = FontWeights.Bold,
                    Foreground = new SolidColorBrush(System.Windows.Media.Colors.White),
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };

                number.Child = numberText;

                var stack = new StackPanel();

                var arabic = new TextBlock
                {
                    Text = surah.Arabic,
                    FontSize = 20,
                    FontWeight = FontWeights.Bold,
                    Foreground = new SolidColorBrush(System.Windows.Media.Colors.White),
                    Margin = new Thickness(0, 0, 0, 5)
                };

                var turkish = new TextBlock
                {
                    Text = surah.Turkish,
                    FontSize = 16,
                    Foreground = new SolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString("#dfe6e9")!)
                };

                stack.Children.Add(arabic);
                stack.Children.Add(turkish);

                var info = new StackPanel
                {
                    VerticalAlignment = VerticalAlignment.Center
                };

                var verses = new TextBlock
                {
                    Text = $"{surah.Verses} Ayet",
                    FontSize = 14,
                    Foreground = new SolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString("#b2bec3")!),
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Right,
                    Margin = new Thickness(0, 0, 0, 5)
                };

                var type = new TextBlock
                {
                    Text = surah.Type,
                    FontSize = 12,
                    Foreground = new SolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString(colors[(surah.Number - 1) % colors.Length])!),
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Right
                };

                info.Children.Add(verses);
                info.Children.Add(type);

                Grid.SetColumn(number, 0);
                Grid.SetColumn(stack, 1);
                Grid.SetColumn(info, 2);

                grid.Children.Add(number);
                grid.Children.Add(stack);
                grid.Children.Add(info);
                border.Child = grid;
                SurahPanel.Children.Add(border);
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = SearchBox.Text.ToLower();
            if (string.IsNullOrWhiteSpace(searchText))
            {
                filteredSurahs = surahs;
            }
            else
            {
                filteredSurahs = surahs.Where(s => 
                    s.Turkish.ToLower().Contains(searchText) || 
                    s.Number.ToString().Contains(searchText)).ToList();
            }
            LoadSurahs();
        }
    }
}
