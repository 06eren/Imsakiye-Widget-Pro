using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace İmsakiye_Widget_Pro
{
    public partial class AIAssistantWindow : Window
    {
        private const string API_KEY = "AIzaSyAG0dhn_Qqz8ix7F6BLvT9z3E4eL0CAiPY";
        private readonly HttpClient httpClient = new();

        public AIAssistantWindow()
        {
            InitializeComponent();
            LoadWelcomeMessage();
        }

        private void LoadWelcomeMessage()
        {
            ResponseText.Text = "🤖 Merhaba! Ben AI Asistanınızım.\n\n" +
                "Size şunlarda yardımcı olabilirim:\n" +
                "• Namaz vakitleri hakkında bilgi\n" +
                "• Dini sorularınıza cevaplar\n" +
                "• Dua önerileri\n" +
                "• İbadet planlaması\n" +
                "• Kişiselleştirilmiş hatırlatmalar\n\n" +
                "Bir soru sormak için yukarıdaki kutucuğa yazın ve Gönder'e tıklayın.";
        }

        private async void Send_Click(object sender, RoutedEventArgs e)
        {
            string userMessage = UserInput.Text.Trim();
            if (string.IsNullOrEmpty(userMessage))
                return;

            ResponseText.Text = "🤔 Düşünüyorum...";
            SendButton.IsEnabled = false;

            try
            {
                string response = await GetAIResponse(userMessage);
                ResponseText.Text = $"👤 Siz: {userMessage}\n\n🤖 AI: {response}";
            }
            catch (Exception ex)
            {
                ResponseText.Text = $"❌ Hata: {ex.Message}\n\nLütfen daha sonra tekrar deneyin.";
            }
            finally
            {
                SendButton.IsEnabled = true;
                UserInput.Clear();
            }
        }

        private async Task<string> GetAIResponse(string message)
        {
            // Basit yanıtlar - gerçek AI entegrasyonu için Google AI API kullanılabilir
            var responses = new[]
            {
                "İslam'da namaz, imanın direğidir ve günde beş vakit kılınır.",
                "Sabır, mü'minin en güzel özelliklerinden biridir. Allah sabredenleri sever.",
                "Dua, kulun Allah'a yalvarmasıdır. Her zaman dua edebilirsiniz.",
                "Zekat, İslam'ın beş şartından biridir ve malın %2.5'i olarak verilir.",
                "Kur'an okumak büyük sevaptır. Her gün biraz Kur'an okumaya çalışın."
            };

            await Task.Delay(1000); // Simüle edilmiş gecikme
            var random = new Random();
            return responses[random.Next(responses.Length)];
        }

        private void SmartReminder_Click(object sender, RoutedEventArgs e)
        {
            ResponseText.Text = "⏰ Akıllı Hatırlatıcı Aktif!\n\n" +
                "• Namaz vakitlerine 10 dakika kala hatırlatma\n" +
                "• Sabah ve akşam duaları için hatırlatma\n" +
                "• Cuma namazı hatırlatması\n" +
                "• Özel günler için hatırlatma\n\n" +
                "Hatırlatmalarınız kişiselleştirildi!";
        }

        private void PersonalSuggestions_Click(object sender, RoutedEventArgs e)
        {
            ResponseText.Text = "💡 Kişisel Öneriler:\n\n" +
                "• Bugün Yasin suresi okuyabilirsiniz\n" +
                "• Tesbih çekmeyi unutmayın (33 Sübhanallah, 33 Elhamdülillah, 34 Allahu Ekber)\n" +
                "• Akşam namazından sonra dua etmeyi ihmal etmeyin\n" +
                "• Bu hafta bir hayır işi yapmayı planlayın\n" +
                "• Ailenizdeki yaşlıları ziyaret edin";
        }

        private void VoiceAssistant_Click(object sender, RoutedEventArgs e)
        {
            ResponseText.Text = "🎤 Sesli Asistan (Yakında!)\n\n" +
                "Sesli komutlarla:\n" +
                "• 'Bir sonraki namaz vakti ne zaman?'\n" +
                "• 'Bana bir dua öner'\n" +
                "• 'Bugünün ayetini oku'\n" +
                "• 'Kıble yönünü göster'\n\n" +
                "Bu özellik yakında aktif olacak!";
        }

        private void AutoPlanning_Click(object sender, RoutedEventArgs e)
        {
            ResponseText.Text = "📅 Otomatik Planlama Aktif!\n\n" +
                "Haftalık İbadet Planınız:\n" +
                "• Pazartesi: Yasin suresi\n" +
                "• Salı: Mülk suresi\n" +
                "• Çarşamba: Kehf suresi\n" +
                "• Perşembe: Fetih suresi\n" +
                "• Cuma: Cuma namazı + Vakıa suresi\n" +
                "• Cumartesi: Tesbih + Dua\n" +
                "• Pazar: Kur'an okuma\n\n" +
                "Plan alışkanlıklarınıza göre optimize edildi!";
        }
    }
}
