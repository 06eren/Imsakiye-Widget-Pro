using System;
using System.IO;
using System.Text.Json;

namespace İmsakiye_Widget_Pro
{
    public class AppSettings
    {
        public string SelectedCity { get; set; } = "Ankara";
        public bool NotificationsEnabled { get; set; } = true;
        public bool AlwaysOnTop { get; set; } = true;
        public bool AutoStart { get; set; } = false;
        public double Opacity { get; set; } = 0.95;
        public string Theme { get; set; } = "Dark";
        public string Language { get; set; } = "Türkçe";
        public string AdhanSound { get; set; } = "AksamEzani.mp3";
        public int ReminderMinutes { get; set; } = 10;
        public bool ShowWeather { get; set; } = true;
        public string WidgetSize { get; set; } = "Normal";
        public double WidgetX { get; set; } = 100;
        public double WidgetY { get; set; } = 100;
        public string AIApiKey { get; set; } = "AIzaSyAG0dhn_Qqz8ix7F6BLvT9z3E4eL0CAiPY";

        private static string SettingsPath => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "ImsakiyeWidgetPro",
            "settings.json"
        );

        public static AppSettings Load()
        {
            try
            {
                if (File.Exists(SettingsPath))
                {
                    var json = File.ReadAllText(SettingsPath);
                    return JsonSerializer.Deserialize<AppSettings>(json) ?? new AppSettings();
                }
            }
            catch { }
            return new AppSettings();
        }

        public void Save()
        {
            try
            {
                var directory = Path.GetDirectoryName(SettingsPath);
                if (directory != null && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                var json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(SettingsPath, json);
            }
            catch { }
        }
    }

    public static class TurkishCities
    {
        public static readonly string[] Cities = new[]
        {
            "Adana", "Adıyaman", "Afyonkarahisar", "Ağrı", "Aksaray", "Amasya", "Ankara", "Antalya",
            "Ardahan", "Artvin", "Aydın", "Balıkesir", "Bartın", "Batman", "Bayburt", "Bilecik",
            "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankırı", "Çorum",
            "Denizli", "Diyarbakır", "Düzce", "Edirne", "Elazığ", "Erzincan", "Erzurum", "Eskişehir",
            "Gaziantep", "Giresun", "Gümüşhane", "Hakkari", "Hatay", "Iğdır", "Isparta", "İstanbul",
            "İzmir", "Kahramanmaraş", "Karabük", "Karaman", "Kars", "Kastamonu", "Kayseri", "Kilis",
            "Kırıkkale", "Kırklareli", "Kırşehir", "Kocaeli", "Konya", "Kütahya", "Malatya", "Manisa",
            "Mardin", "Mersin", "Muğla", "Muş", "Nevşehir", "Niğde", "Ordu", "Osmaniye",
            "Rize", "Sakarya", "Samsun", "Şanlıurfa", "Siirt", "Sinop", "Şırnak", "Sivas",
            "Tekirdağ", "Tokat", "Trabzon", "Tunceli", "Uşak", "Van", "Yalova", "Yozgat", "Zonguldak"
        };
    }
}
