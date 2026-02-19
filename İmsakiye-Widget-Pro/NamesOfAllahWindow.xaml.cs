using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WpfColor = System.Windows.Media.Color;
using WpfColorConverter = System.Windows.Media.ColorConverter;
using WpfColors = System.Windows.Media.Colors;
using System.Windows.Media;

namespace İmsakiye_Widget_Pro
{
    public partial class NamesOfAllahWindow : Window
    {
        private readonly List<(string Arabic, string Turkish)> names = new()
        {
            ("الرَّحْمَنُ", "Er-Rahman"), ("الرَّحِيمُ", "Er-Rahim"), ("الْمَلِكُ", "El-Melik"),
            ("الْقُدُّوسُ", "El-Kuddüs"), ("السَّلاَمُ", "Es-Selam"), ("الْمُؤْمِنُ", "El-Mü'min"),
            ("الْمُهَيْمِنُ", "El-Müheymin"), ("الْعَزِيزُ", "El-Aziz"), ("الْجَبَّارُ", "El-Cebbar"),
            ("الْمُتَكَبِّرُ", "El-Mütekebbir"), ("الْخَالِقُ", "El-Halik"), ("الْبَارِئُ", "El-Bari"),
            ("الْمُصَوِّرُ", "El-Musavvir"), ("الْغَفَّارُ", "El-Gaffar"), ("الْقَهَّارُ", "El-Kahhar"),
            ("الْوَهَّابُ", "El-Vehhab"), ("الرَّزَّاقُ", "Er-Rezzak"), ("الْفَتَّاحُ", "El-Fettah"),
            ("اَلْعَلِيْمُ", "El-Alim"), ("الْقَابِضُ", "El-Kabız"), ("الْبَاسِطُ", "El-Basıt"),
            ("الْخَافِضُ", "El-Hafız"), ("الرَّافِعُ", "Er-Rafi"), ("الْمُعِزُّ", "El-Muizz"),
            ("المُذِلُّ", "El-Müzill"), ("السَّمِيعُ", "Es-Semi"), ("الْبَصِيرُ", "El-Basir"),
            ("الْحَكَمُ", "El-Hakem"), ("الْعَدْلُ", "El-Adl"), ("اللَّطِيفُ", "El-Latif"),
            ("الْخَبِيرُ", "El-Habir"), ("الْحَلِيمُ", "El-Halim"), ("الْعَظِيمُ", "El-Azim"),
            ("الْغَفُورُ", "El-Gafur"), ("الشَّكُورُ", "Eş-Şekur"), ("الْعَلِيُّ", "El-Aliyy"),
            ("الْكَبِيرُ", "El-Kebir"), ("الْحَفِيظُ", "El-Hafiz"), ("المُقيِت", "El-Mukit"),
            ("الْحسِيبُ", "El-Hasib"), ("الْجَلِيلُ", "El-Celil"), ("الْكَرِيمُ", "El-Kerim"),
            ("الرَّقِيبُ", "Er-Rakib"), ("الْمُجِيبُ", "El-Mucib"), ("الْوَاسِعُ", "El-Vasi"),
            ("الْحَكِيمُ", "El-Hakim"), ("الْوَدُودُ", "El-Vedud"), ("الْمَجِيدُ", "El-Mecid"),
            ("الْبَاعِثُ", "El-Bais"), ("الشَّهِيدُ", "Eş-Şehid"), ("الْحَقُّ", "El-Hakk"),
            ("الْوَكِيلُ", "El-Vekil"), ("الْقَوِيُّ", "El-Kaviyy"), ("الْمَتِينُ", "El-Metin"),
            ("الْوَلِيُّ", "El-Veliyy"), ("الْحَمِيدُ", "El-Hamid"), ("الْمُحْصِي", "El-Muhsi"),
            ("الْمُبْدِئُ", "El-Mübdi"), ("الْمُعِيدُ", "El-Muid"), ("الْمُحْيِي", "El-Muhyi"),
            ("اَلْمُمِيتُ", "El-Mümit"), ("الْحَيُّ", "El-Hayy"), ("الْقَيُّومُ", "El-Kayyum"),
            ("الْوَاجِدُ", "El-Vacid"), ("الْمَاجِدُ", "El-Macid"), ("الْواحِدُ", "El-Vahid"),
            ("اَلاَحَدُ", "El-Ehad"), ("الصَّمَدُ", "Es-Samed"), ("الْقَادِرُ", "El-Kadir"),
            ("الْمُقْتَدِرُ", "El-Muktedir"), ("الْمُقَدِّمُ", "El-Mukaddim"), ("الْمُؤَخِّرُ", "El-Muahhir"),
            ("الأوَّلُ", "El-Evvel"), ("الآخِرُ", "El-Ahir"), ("الظَّاهِرُ", "Ez-Zahir"),
            ("الْبَاطِنُ", "El-Batın"), ("الْوَالِي", "El-Vali"), ("الْمُتَعَالِي", "El-Müteali"),
            ("الْبَرُّ", "El-Berr"), ("التَّوَابُ", "Et-Tevvab"), ("الْمُنْتَقِمُ", "El-Müntakim"),
            ("العَفُوُّ", "El-Afüvv"), ("الرَّؤُوفُ", "Er-Rauf"), ("مَالِكُ الْمُلْكِ", "Malikül-Mülk"),
            ("ذُو الْجَلاَلِ وَالإكْرَامِ", "Zül-Celali vel-İkram"), ("الْمُقْسِطُ", "El-Muksit"),
            ("الْجَامِعُ", "El-Cami"), ("الْغَنِيُّ", "El-Ganiyy"), ("الْمُغْنِي", "El-Mugni"),
            ("اَلْمَانِعُ", "El-Mani"), ("الضَّارَّ", "Ed-Darr"), ("النَّافِعُ", "En-Nafi"),
            ("النُّورُ", "En-Nur"), ("الْهَادِي", "El-Hadi"), ("الْبَدِيعُ", "El-Bedi"),
            ("اَلْبَاقِي", "El-Baki"), ("الْوَارِثُ", "El-Varis"), ("الرَّشِيدُ", "Er-Reşid"),
            ("الصَّبُورُ", "Es-Sabur")
        };

        public NamesOfAllahWindow()
        {
            InitializeComponent();
            LoadNames();
        }

        private void LoadNames()
        {
            var colors = new[] { "#00b894", "#00cec9", "#fdcb6e", "#e17055", "#fd79a8", "#6c5ce7", "#0984e3", "#a29bfe" };
            int index = 0;

            foreach (var name in names)
            {
                var border = new Border
                {
                    Background = new SolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString("#2d3436")!),
                    CornerRadius = new CornerRadius(10),
                    Padding = new Thickness(15),
                    Margin = new Thickness(5),
                    Width = 130,
                    Height = 100,
                    BorderBrush = new SolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString(colors[index % colors.Length])!),
                    BorderThickness = new Thickness(0, 0, 0, 3)
                };

                var stack = new StackPanel
                {
                    VerticalAlignment = VerticalAlignment.Center
                };

                var number = new TextBlock
                {
                    Text = (index + 1).ToString(),
                    FontSize = 12,
                    Foreground = new SolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString("#b2bec3")!),
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                    Margin = new Thickness(0, 0, 0, 5)
                };

                var arabic = new TextBlock
                {
                    Text = name.Arabic,
                    FontSize = 18,
                    FontWeight = FontWeights.Bold,
                    Foreground = new SolidColorBrush(WpfColors.White),
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                    Margin = new Thickness(0, 0, 0, 5)
                };

                var turkish = new TextBlock
                {
                    Text = name.Turkish,
                    FontSize = 14,
                    Foreground = new SolidColorBrush((WpfColor)WpfColorConverter.ConvertFromString(colors[index % colors.Length])!),
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Center
                };

                stack.Children.Add(number);
                stack.Children.Add(arabic);
                stack.Children.Add(turkish);
                border.Child = stack;
                NamesPanel.Children.Add(border);
                index++;
            }
        }
    }
}
