using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using WpfMessageBox = System.Windows.MessageBox;

namespace İmsakiye_Widget_Pro
{
    public partial class WeatherWindow : Window
    {
        private string city;

        public WeatherWindow(string cityName)
        {
            InitializeComponent();
            city = cityName;
            CityText.Text = cityName;
            Loaded += async (s, e) => await LoadWeather();
        }

        private async Task LoadWeather()
        {
            try
            {
                // OpenWeatherMap API (ücretsiz, kayıt gerektirir)
                // Bu örnek için sabit veriler gösteriyoruz
                await Task.Delay(500); // Simüle edilmiş API çağrısı
                
                var random = new Random();
                var temp = random.Next(15, 35);
                var humidity = random.Next(40, 80);
                var wind = random.Next(5, 25);
                
                var conditions = new[] { "Açık", "Parçalı Bulutlu", "Bulutlu", "Yağmurlu", "Güneşli" };
                var condition = conditions[random.Next(conditions.Length)];
                
                TempText.Text = $"{temp}°C";
                DescText.Text = condition;
                HumidityText.Text = $"{humidity}%";
                WindText.Text = $"{wind} km/h";
            }
            catch (Exception ex)
            {
                WpfMessageBox.Show($"Hava durumu yüklenirken hata: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void Refresh_Click(object sender, RoutedEventArgs e)
        {
            await LoadWeather();
        }
    }
}
