using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace İmsakiye_Widget_Pro
{
    public partial class DailyVerseWindow : Window
    {
        private readonly List<(string Arabic, string Turkish, string Reference)> verses = new()
        {
            ("إِنَّ مَعَ الْعُسْرِ يُسْرًا", "Muhakkak ki her zorlukla beraber bir kolaylık vardır.", "İnşirah 6"),
            ("وَلَا تَيْأَسُوا مِن رَّوْحِ اللَّهِ", "Allah'ın rahmetinden ümit kesmeyin.", "Yusuf 87"),
            ("فَاذْكُرُونِي أَذْكُرْكُمْ", "Siz beni anın ki ben de sizi anayım.", "Bakara 152"),
            ("وَاصْبِرْ فَإِنَّ اللَّهَ لَا يُضِيعُ أَجْرَ الْمُحْسِنِينَ", "Sabret! Şüphesiz Allah, iyilik edenlerin mükâfatını zayi etmez.", "Hud 115"),
            ("رَبَّنَا آتِنَا فِي الدُّنْيَا حَسَنَةً وَفِي الْآخِرَةِ حَسَنَةً", "Rabbimiz! Bize dünyada da iyilik ver, ahirette de iyilik ver.", "Bakara 201")
        };

        private readonly List<(string Text, string Reference)> hadiths = new()
        {
            ("Müslüman, elinden ve dilinden Müslümanların emin olduğu kimsedir.", "Buhari"),
            ("Hayâ imandandır.", "Buhari, Müslim"),
            ("Mü'minin işi ne güzeldir! Onun bütün işleri hayırlıdır.", "Müslim"),
            ("Allah'a ve ahiret gününe iman eden ya hayır söylesin ya da sussun.", "Buhari, Müslim"),
            ("İnsanların en hayırlısı, insanlara faydalı olandır.", "Taberani")
        };

        public DailyVerseWindow()
        {
            InitializeComponent();
            LoadDailyContent();
        }

        private void LoadDailyContent()
        {
            var random = new Random(DateTime.Now.DayOfYear);
            
            var verse = verses[random.Next(verses.Count)];
            VerseArabic.Text = verse.Arabic;
            VerseTurkish.Text = verse.Turkish;
            VerseReference.Text = $"({verse.Reference})";
            
            var hadith = hadiths[random.Next(hadiths.Count)];
            HadithText.Text = hadith.Text;
            HadithReference.Text = $"({hadith.Reference})";
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            var random = new Random();
            
            var verse = verses[random.Next(verses.Count)];
            VerseArabic.Text = verse.Arabic;
            VerseTurkish.Text = verse.Turkish;
            VerseReference.Text = $"({verse.Reference})";
            
            var hadith = hadiths[random.Next(hadiths.Count)];
            HadithText.Text = hadith.Text;
            HadithReference.Text = $"({hadith.Reference})";
        }
    }
}
