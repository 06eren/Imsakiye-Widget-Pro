using System;
using System.Windows;

namespace İmsakiye_Widget_Pro
{
    public partial class ZakatCalculatorWindow : Window
    {
        public ZakatCalculatorWindow()
        {
            InitializeComponent();
        }

        private void CalculateWealth_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(WealthAmount.Text, out double amount))
            {
                double zakat = amount * 0.025; // %2.5
                WealthResult.Text = $"Zekat Miktarı: {zakat:N2} TL";
            }
            else
            {
                WealthResult.Text = "Lütfen geçerli bir miktar girin!";
            }
        }

        private void CalculateGold_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(GoldGrams.Text, out double grams))
            {
                double nisab = 85; // gram
                if (grams >= nisab)
                {
                    double zakat = grams * 0.025;
                    GoldResult.Text = $"Zekat Miktarı: {zakat:N2} gram altın";
                }
                else
                {
                    GoldResult.Text = $"Nisab miktarına ({nisab}g) ulaşmamış.";
                }
            }
            else
            {
                GoldResult.Text = "Lütfen geçerli bir miktar girin!";
            }
        }

        private void CalculateSilver_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(SilverGrams.Text, out double grams))
            {
                double nisab = 595; // gram
                if (grams >= nisab)
                {
                    double zakat = grams * 0.025;
                    SilverResult.Text = $"Zekat Miktarı: {zakat:N2} gram gümüş";
                }
                else
                {
                    SilverResult.Text = $"Nisab miktarına ({nisab}g) ulaşmamış.";
                }
            }
            else
            {
                SilverResult.Text = "Lütfen geçerli bir miktar girin!";
            }
        }

        private void CalculateFitre_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(PersonCount.Text, out int count))
            {
                double fitrePerPerson = 100; // TL (örnek değer)
                double total = count * fitrePerPerson;
                FitreResult.Text = $"Toplam Fitre: {total:N2} TL\n(Kişi başı {fitrePerPerson} TL)";
            }
            else
            {
                FitreResult.Text = "Lütfen geçerli bir sayı girin!";
            }
        }
    }
}
