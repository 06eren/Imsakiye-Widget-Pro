# 🕌 İmsakiye Widget Pro v2.0

Modern ve özellik dolu namaz vakitleri widget uygulaması. Türkiye'deki tüm şehirler için güncel namaz vakitlerini gösterir.

## ✨ 65+ Özellik ile Tam Donanımlı!

### 🎯 Temel Özellikler
- ✅ Türkiye'deki 81 şehir için namaz vakitleri
- ✅ Gerçek zamanlı geri sayım
- ✅ Otomatik ezan çalma
- ✅ Vakit bildirimleri
- ✅ Sistem tepsisi desteği
- ✅ Sürüklenebilir widget

### 📱 12 Farklı Modül
1. **🧭 Kıble Yönü** - Animasyonlu pusula
2. **📿 Tesbih** - Dijital sayaç (33/99/100)
3. **🤲 Dualar** - 7 günlük dua
4. **📅 Özel Günler** - Ramazan, Kurban geri sayımı
5. **📋 Kaza Takibi** - 5 vakit kayıt sistemi
6. **✨ Esma-ül Hüsna** - 99 isim
7. **🌟 Zikir** - 10 zikir listesi
8. **🌤️ Hava Durumu** - Şehir bazlı
9. **📖 Kur'an** - 114 sure (arama özellikli)
10. **🌙 Oruç Takvimi** - Nafile oruçlar
11. **📊 İstatistikler** - Detaylı veriler
12. **⚙️ Ayarlar** - Gelişmiş panel

### ⚙️ Gelişmiş Ayarlar
- 🎨 Tema (Koyu/Açık/Renkli)
- 🔊 Ezan sesi seçimi
- ⏰ Vakit öncesi hatırlatıcı (0-30 dk)
- 📏 Widget boyutu (Küçük/Normal/Büyük)
- 🎨 Şeffaflık (%30-100)
- 🚀 Windows ile başlat
- 📌 Her zaman üstte

### ⌨️ Klavye Kısayolları
- `Ctrl + M` → Menü
- `Ctrl + S` → Ayarlar
- `Ctrl + H` → Gizle
- `Ctrl + Q` → Kapat

## 🚀 Kurulum

### Gereksinimler
- Windows 10/11
- .NET 10.0 Runtime

### Çalıştırma
```bash
# Build
dotnet build

# Çalıştır
dotnet run --project "İmsakiye-Widget-Pro/İmsakiye-Widget-Pro.csproj"

# Veya exe'yi çalıştır
cd İmsakiye-Widget-Pro/bin/Debug/net10.0-windows
./İmsakiye-Widget-Pro.exe
```

## 📖 Dokümantasyon

- **[KULLANIM_KILAVUZU.md](KULLANIM_KILAVUZU.md)** - Detaylı kullanım kılavuzu
- **[FEATURES.md](FEATURES.md)** - 65+ özellik listesi
- **[CHANGELOG.md](CHANGELOG.md)** - Versiyon geçmişi

## 🎨 Görsel Özellikler

- Modern gradient tasarım
- Glow efektleri
- Renkli vakit kartları
- Hover animasyonları
- Responsive arayüz

## 🔧 Teknoloji

- WPF + .NET 10.0
- MahApps.Metro UI
- NAudio (ses)
- Hardcodet.NotifyIcon (sistem tepsisi)
- Aladhan API (vakitler)

## 💾 Veri Yönetimi

Otomatik kayıt:
```
%AppData%\ImsakiyeWidgetPro\
├── settings.json
├── missed_prayers.json
└── statistics.json
```

## 🔔 Bildirimler

- Vakit girişi
- Vakit öncesi hatırlatıcı
- Ezan çalma
- Sistem tepsisi

## 🐛 Sorun Giderme

**Widget görünmüyor?**
- Sistem tepsisi → Sağ tık → Widget'ı Göster

**Vakitler güncellenmiyor?**
- Kontrol Paneli → Vakitleri Yenile

**Ezan çalmıyor?**
- Ayarlar → Ezan Sesi → "Sessiz" olmamalı

## 📝 Lisans

Eğitim amaçlıdır.

## 🙏 Teşekkürler

- **Aladhan API** - Namaz vakitleri
- **MahApps.Metro** - Modern UI
- **NAudio** - Ses kütüphanesi

---

**Not:** Vakitler Diyanet metoduyla hesaplanır. Kesin vakitler için yerel müdürlüğe danışın.

**Hayırlı kullanımlar! 🕌**

*v2.0.0 | 19 Şubat 2026*
