# 📖 İmsakiye Widget Pro - Kullanım Kılavuzu

## 🚀 Başlangıç

### Uygulamayı Çalıştırma

```bash
# Komut satırından
dotnet run --project "İmsakiye-Widget-Pro/İmsakiye-Widget-Pro.csproj"

# Veya build edip exe'yi çalıştırın
dotnet build
cd İmsakiye-Widget-Pro/bin/Debug/net10.0-windows
./İmsakiye-Widget-Pro.exe
```

### İlk Açılış
- Uygulama açıldığında otomatik olarak **Kontrol Paneli** ve **Widget** açılır
- Sistem tepsisinde 🕌 ikonu görünür
- Widget varsayılan olarak Ankara için namaz vakitlerini gösterir

---

## 🎯 Ana Özellikler

### 1. 📱 Widget (Ana Ekran)

Widget üzerinde:
- **Sonraki vakit** ve **geri sayım** gösterilir
- **6 vakit** (İmsak, Güneş, Öğle, İkindi, Akşam, Yatsı) listelenir
- Renkli kartlar ile görsel ayrım

#### Widget Butonları
- **📱 Menü** - Ana menüyü açar
- **⚙ Ayarlar** - Kontrol panelini açar
- **− Gizle** - Widget'ı sistem tepsisine gizler
- **✕ Kapat** - Uygulamayı kapatır

#### Klavye Kısayolları
- `Ctrl + M` - Menü
- `Ctrl + S` - Ayarlar
- `Ctrl + H` - Gizle
- `Ctrl + Q` - Kapat

#### Widget Özellikleri
- Sürükleyerek taşıyabilirsiniz
- Pozisyon otomatik kaydedilir
- Şeffaflık ayarlanabilir
- Boyut değiştirilebilir (Küçük/Normal/Büyük)

---

### 2. 📱 Ana Menü

Menüde 12 farklı modül bulunur:

#### 🧭 Kıble Yönü
- Animasyonlu pusula
- Otomatik konum hesaplama
- Kabe'ye olan açı gösterimi

#### 📿 Tesbih Sayacı
- Dijital sayaç
- 33, 99, 100 hedef seçenekleri
- Sıfırlama özelliği
- Hedef tamamlama bildirimi

#### 🤲 Günlük Dualar
- 7 farklı günlük dua
- Sabah, akşam, yemek duaları
- Arapça okunuş + Türkçe anlamı

#### 📅 Özel Günler
- Ramazan, Kurban Bayramı
- Kandil geceleri
- Geri sayım sayacı
- Geçmiş/gelecek göstergesi

#### 📋 Kaza Namazı Takibi
- 5 vakit için ayrı sayaç
- Artır/azalt butonları
- Toplam hesaplama
- Otomatik kaydetme

#### ✨ Esma-ül Hüsna
- Allah'ın 99 ismi
- Arapça + Türkçe
- Renkli kart tasarımı
- Numara ile gösterim

#### 🌟 Zikir Listesi
- 10 farklı zikir
- Önerilen sayılar
- Arapça + Türkçe

#### 🌤️ Hava Durumu
- Seçili şehir için hava durumu
- Sıcaklık, nem, rüzgar
- Yenileme butonu

#### 📖 Kur'an-ı Kerim Sureleri
- 114 sure listesi
- Arapça + Türkçe isimler
- Ayet sayısı
- Mekki/Medeni bilgisi
- Arama özelliği

#### 🌙 Oruç Takvimi
- Pazartesi-Perşembe oruçları
- Beyaz günler (13-14-15)
- Aşure günü
- Arefe günü
- Şevval oruçları
- Yaklaşan oruç günleri

#### 📊 İstatistikler
- Günlük vakit takibi
- Aylık istatistikler
- Uygulama kullanım süresi
- Açılış sayısı
- Vakit detayları

#### ⚙️ Ayarlar
- Kontrol panelini açar

---

### 3. ⚙️ Kontrol Paneli

#### Şehir Seçimi
1. Arama kutusuna şehir adı yazın
2. Listeden şehri seçin
3. "💾 Kaydet" butonuna tıklayın
4. Vakitler otomatik güncellenir

#### Widget Ayarları

**📌 Her Zaman Üstte**
- Açık: Widget diğer pencerelerin üstünde kalır
- Kapalı: Normal pencere davranışı

**🚀 Windows ile Başlat**
- Açık: Windows açılışında otomatik başlar
- Kapalı: Manuel başlatma

**🔔 Vakit Bildirimleri**
- Açık: Vakit girdiğinde bildirim gösterir
- Kapalı: Sessiz mod

**⏰ Vakit Öncesi Hatırlatıcı**
- 0-30 dakika arası ayarlanabilir
- 0: Kapalı
- Örnek: 10 dakika seçilirse, vakitten 10 dk önce hatırlatır

**🎨 Tema Seçimi**
- Koyu Tema (varsayılan)
- Açık Tema
- Renkli Tema
- Not: Yeniden başlatma gerektirir

**🔊 Ezan Sesi**
- Akşam Ezanı (varsayılan)
- Sabah Ezanı
- Sessiz

**📏 Widget Boyutu**
- Küçük: %80 boyut
- Normal: %100 boyut (varsayılan)
- Büyük: %120 boyut

**🎨 Widget Şeffaflığı**
- %30 - %100 arası ayarlanabilir
- Kaydırıcı ile ayarlayın

#### Diğer Özellikler

**🔄 Vakitleri Yenile**
- Manuel olarak vakitleri günceller
- Gece yarısı otomatik güncellenir

**Bugünün Namaz Vakitleri**
- Tüm vakitler renkli kartlarla gösterilir
- Anlık durum görüntülenir

---

## 🔔 Bildirimler

### Vakit Bildirimleri
- Vakit girdiğinde otomatik bildirim
- Ezan çalma (ayarlanabilir)
- Pencere öne gelir

### Vakit Öncesi Hatırlatıcı
- Ayarlarda belirlenen süre kadar önce hatırlatır
- Örnek: 10 dakika seçiliyse, vakitten 10 dk önce bildirim

### Sistem Tepsisi
- Uygulama arka planda çalışır
- Sağ tık ile menü
- Sol tık ile widget göster/gizle

---

## 💾 Veri Yönetimi

### Otomatik Kaydetme
Tüm ayarlar ve veriler otomatik kaydedilir:
- Widget pozisyonu
- Şehir seçimi
- Tüm ayarlar
- Kaza namazı sayıları
- İstatistikler

### Kayıt Konumu
```
C:\Users\[KullanıcıAdı]\AppData\Roaming\ImsakiyeWidgetPro\
├── settings.json          # Ayarlar
├── missed_prayers.json    # Kaza namazı
└── statistics.json        # İstatistikler
```

---

## 🎨 Görsel Özelleştirme

### Renkler
Her vakit için farklı renk:
- 🌙 İmsak: Yeşil
- 🌅 Güneş: Turkuaz
- ☀️ Öğle: Sarı
- 🌤️ İkindi: Turuncu
- 🌆 Akşam: Pembe
- 🌃 Yatsı: Mor

### Efektler
- Gradient arka planlar
- Glow efektleri
- Yumuşak gölgeler
- Hover animasyonları

---

## 🔧 Sorun Giderme

### Widget Görünmüyor
1. Sistem tepsisindeki ikona tıklayın
2. "Widget'ı Göster" seçeneğini seçin
3. Veya `Ctrl + M` ile menüyü açın

### Vakitler Güncellenmiyor
1. Kontrol panelini açın
2. "🔄 Vakitleri Yenile" butonuna tıklayın
3. İnternet bağlantınızı kontrol edin

### Ezan Çalmıyor
1. Ayarlar > Ezan Sesi kontrol edin
2. "Sessiz" seçili olmamalı
3. Ses dosyası eksik olabilir

### Uygulama Açılmıyor
1. .NET 10.0 Runtime yüklü olmalı
2. Windows 10/11 gereklidir
3. Komut satırından çalıştırıp hata mesajını kontrol edin

---

## 📱 Sistem Gereksinimleri

- **İşletim Sistemi:** Windows 10/11
- **Framework:** .NET 10.0 Runtime
- **RAM:** Minimum 512 MB
- **Disk:** 50 MB boş alan
- **İnternet:** Vakit güncellemeleri için gerekli

---

## 🎯 İpuçları

1. **Hızlı Erişim:** Sistem tepsisinden çift tıklama ile widget'ı göster/gizle
2. **Klavye Kısayolları:** `Ctrl + M` ile menüye hızlı erişim
3. **Pozisyon:** Widget'ı istediğiniz yere sürükleyin, otomatik kaydedilir
4. **Şeffaflık:** Arka planı görmek için şeffaflığı artırın
5. **Hatırlatıcı:** Vakit öncesi hatırlatıcıyı 10-15 dakika yapın
6. **Tesbih:** Tesbih sayacını günlük zikirleriniz için kullanın
7. **Kaza Takibi:** Kaza namazlarınızı düzenli takip edin
8. **Oruç Takvimi:** Nafile oruç günlerini takip edin

---

## 🆘 Destek

Sorun yaşarsanız:
1. README.md dosyasını okuyun
2. FEATURES.md dosyasında özellik listesini kontrol edin
3. GitHub'da issue açın

---

**Not:** Bu uygulama namaz vakitlerini Aladhan API kullanarak Diyanet metoduyla hesaplamaktadır. Vakitler yaklaşık olup, kesin vakitler için yerel Diyanet İşleri Müdürlüğü'ne danışınız.

---

## 📝 Versiyon Geçmişi

### v2.0.0 (Şubat 2026)
- ✅ 12 yeni modül eklendi
- ✅ Sistem tepsisi desteği
- ✅ Klavye kısayolları
- ✅ Vakit öncesi hatırlatıcı
- ✅ Widget pozisyon kaydetme
- ✅ Tema desteği
- ✅ Gelişmiş ayarlar
- ✅ 65+ özellik

### v1.0.0 (İlk Sürüm)
- ✅ Temel namaz vakitleri
- ✅ Geri sayım
- ✅ Ezan çalma
- ✅ Şehir seçimi

---

**Hayırlı kullanımlar dileriz! 🕌**
