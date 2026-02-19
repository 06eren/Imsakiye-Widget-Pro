using System;
using System.IO;
using System.Text.Json;
using System.Windows;
using WpfMessageBox = System.Windows.MessageBox;

namespace İmsakiye_Widget_Pro
{
    public partial class MissedPrayersWindow : Window
    {
        private MissedPrayersData data = new();

        public MissedPrayersWindow()
        {
            InitializeComponent();
            LoadData();
            UpdateDisplay();
        }

        private void LoadData()
        {
            try
            {
                var path = GetDataPath();
                if (File.Exists(path))
                {
                    var json = File.ReadAllText(path);
                    data = JsonSerializer.Deserialize<MissedPrayersData>(json) ?? new MissedPrayersData();
                }
            }
            catch { }
        }

        private void SaveData()
        {
            try
            {
                var path = GetDataPath();
                var directory = Path.GetDirectoryName(path);
                if (directory != null && !Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(path, json);
            }
            catch { }
        }

        private string GetDataPath()
        {
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "ImsakiyeWidgetPro",
                "missed_prayers.json"
            );
        }

        private void UpdateDisplay()
        {
            FajrCount.Text = data.Fajr.ToString();
            DhuhrCount.Text = data.Dhuhr.ToString();
            AsrCount.Text = data.Asr.ToString();
            MaghribCount.Text = data.Maghrib.ToString();
            IshaCount.Text = data.Isha.ToString();
            TotalCount.Text = (data.Fajr + data.Dhuhr + data.Asr + data.Maghrib + data.Isha).ToString();
        }

        private void FajrAdd_Click(object sender, RoutedEventArgs e) { data.Fajr++; UpdateDisplay(); }
        private void FajrRemove_Click(object sender, RoutedEventArgs e) { if (data.Fajr > 0) data.Fajr--; UpdateDisplay(); }
        private void DhuhrAdd_Click(object sender, RoutedEventArgs e) { data.Dhuhr++; UpdateDisplay(); }
        private void DhuhrRemove_Click(object sender, RoutedEventArgs e) { if (data.Dhuhr > 0) data.Dhuhr--; UpdateDisplay(); }
        private void AsrAdd_Click(object sender, RoutedEventArgs e) { data.Asr++; UpdateDisplay(); }
        private void AsrRemove_Click(object sender, RoutedEventArgs e) { if (data.Asr > 0) data.Asr--; UpdateDisplay(); }
        private void MaghribAdd_Click(object sender, RoutedEventArgs e) { data.Maghrib++; UpdateDisplay(); }
        private void MaghribRemove_Click(object sender, RoutedEventArgs e) { if (data.Maghrib > 0) data.Maghrib--; UpdateDisplay(); }
        private void IshaAdd_Click(object sender, RoutedEventArgs e) { data.Isha++; UpdateDisplay(); }
        private void IshaRemove_Click(object sender, RoutedEventArgs e) { if (data.Isha > 0) data.Isha--; UpdateDisplay(); }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveData();
            WpfMessageBox.Show("Kaza namazı bilgileri kaydedildi!", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            var result = WpfMessageBox.Show("Tüm kaza namazı sayılarını sıfırlamak istediğinize emin misiniz?", 
                "Sıfırla", MessageBoxButton.YesNo, MessageBoxImage.Question);
            
            if (result == MessageBoxResult.Yes)
            {
                data = new MissedPrayersData();
                UpdateDisplay();
                SaveData();
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            SaveData();
            Close();
        }
    }

    public class MissedPrayersData
    {
        public int Fajr { get; set; }
        public int Dhuhr { get; set; }
        public int Asr { get; set; }
        public int Maghrib { get; set; }
        public int Isha { get; set; }
    }
}
