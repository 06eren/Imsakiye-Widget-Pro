using System.Windows;
using WpfApplication = System.Windows.Application;

namespace İmsakiye_Widget_Pro
{
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
        }

        private void QiblaDirection_Click(object sender, RoutedEventArgs e)
        {
            var qiblaWindow = new QiblaWindow();
            qiblaWindow.ShowDialog();
        }

        private void Tasbih_Click(object sender, RoutedEventArgs e)
        {
            var tasbihWindow = new TasbihWindow();
            tasbihWindow.ShowDialog();
        }

        private void Prayers_Click(object sender, RoutedEventArgs e)
        {
            var prayersWindow = new DailyPrayersWindow();
            prayersWindow.ShowDialog();
        }

        private void SpecialDays_Click(object sender, RoutedEventArgs e)
        {
            var specialDaysWindow = new SpecialDaysWindow();
            specialDaysWindow.ShowDialog();
        }

        private void MissedPrayers_Click(object sender, RoutedEventArgs e)
        {
            var missedPrayersWindow = new MissedPrayersWindow();
            missedPrayersWindow.ShowDialog();
        }

        private void NamesOfAllah_Click(object sender, RoutedEventArgs e)
        {
            var namesWindow = new NamesOfAllahWindow();
            namesWindow.ShowDialog();
        }

        private void Dhikr_Click(object sender, RoutedEventArgs e)
        {
            var dhikrWindow = new DhikrWindow();
            dhikrWindow.ShowDialog();
        }

        private void Statistics_Click(object sender, RoutedEventArgs e)
        {
            var statsWindow = new StatisticsWindow();
            statsWindow.ShowDialog();
        }

        private void Weather_Click(object sender, RoutedEventArgs e)
        {
            var settings = AppSettings.Load();
            var weatherWindow = new WeatherWindow(settings.SelectedCity);
            weatherWindow.ShowDialog();
        }

        private void Quran_Click(object sender, RoutedEventArgs e)
        {
            var quranWindow = new QuranWindow();
            quranWindow.ShowDialog();
        }

        private void Fasting_Click(object sender, RoutedEventArgs e)
        {
            var fastingWindow = new FastingCalendarWindow();
            fastingWindow.ShowDialog();
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in WpfApplication.Current.Windows)
            {
                if (window is ControlPanel controlPanel)
                {
                    controlPanel.Show();
                    controlPanel.WindowState = WindowState.Normal;
                    controlPanel.Activate();
                    Close();
                    return;
                }
            }
        }

        private void DailyVerse_Click(object sender, RoutedEventArgs e)
        {
            var dailyVerseWindow = new DailyVerseWindow();
            dailyVerseWindow.ShowDialog();
        }

        private void HadithLibrary_Click(object sender, RoutedEventArgs e)
        {
            var hadithWindow = new HadithLibraryWindow();
            hadithWindow.ShowDialog();
        }

        private void MosqueFinder_Click(object sender, RoutedEventArgs e)
        {
            var mosqueWindow = new MosqueFinderWindow();
            mosqueWindow.ShowDialog();
        }

        private void HijriCalendar_Click(object sender, RoutedEventArgs e)
        {
            var calendarWindow = new HijriCalendarWindow();
            calendarWindow.ShowDialog();
        }

        private void ZakatCalculator_Click(object sender, RoutedEventArgs e)
        {
            var zakatWindow = new ZakatCalculatorWindow();
            zakatWindow.ShowDialog();
        }

        private void Education_Click(object sender, RoutedEventArgs e)
        {
            var educationWindow = new EducationWindow();
            educationWindow.ShowDialog();
        }

        private void Themes_Click(object sender, RoutedEventArgs e)
        {
            var themesWindow = new ThemesWindow();
            themesWindow.ShowDialog();
        }

        private void AIAssistant_Click(object sender, RoutedEventArgs e)
        {
            var aiWindow = new AIAssistantWindow();
            aiWindow.ShowDialog();
        }

        private void RamadanSpecial_Click(object sender, RoutedEventArgs e)
        {
            var ramadanWindow = new RamadanSpecialWindow();
            ramadanWindow.ShowDialog();
        }

        private void Achievements_Click(object sender, RoutedEventArgs e)
        {
            var achievementsWindow = new AchievementsWindow();
            achievementsWindow.ShowDialog();
        }

        private void Library_Click(object sender, RoutedEventArgs e)
        {
            var libraryWindow = new LibraryWindow();
            libraryWindow.ShowDialog();
        }
    }
}
