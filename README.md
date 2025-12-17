
# 🧠 Human or AI – Metin Analizi Uygulaması

Bu proje, girilen bir metnin **insan tarafından mı yoksa yapay zekâ tarafından mı yazıldığını** tespit etmeyi amaçlayan, **makine öğrenmesi destekli web tabanlı bir analiz sistemidir**.

Proje, **ASP.NET MVC** tabanlı bir kullanıcı arayüzü ile **Python (Flask)** tabanlı makine öğrenmesi servisinin **API üzerinden haberleşmesi** prensibiyle geliştirilmiştir.

---

## 🎯 Projenin Amacı

Günümüzde yapay zekâ tarafından üretilen metinlerin artmasıyla birlikte, bu metinlerin tespiti önemli bir problem haline gelmiştir.  
Bu proje kapsamında:

- Kullanıcıdan alınan metin analiz edilir
- Farklı makine öğrenmesi modelleri ile değerlendirilir
- Sonuçlar yüzdelik oranlar halinde kullanıcıya sunulur

Amaç; **çoklu model yaklaşımı** kullanarak daha güvenilir ve karşılaştırmalı sonuçlar elde etmektir.

---

## ⚙️ Kullanılan Teknolojiler

### 🌐 Web Tarafı
- ASP.NET MVC
- Razor Pages
- HTML / CSS / Bootstrap

### 🤖 Makine Öğrenmesi & API
- Python
- Flask
- Scikit-learn
- TF-IDF Vectorizer

### 🧪 Test & Yönetim
- NUnit (White-box testler)
- GitHub (Versiyon kontrol)
- Trello (Scrum / görev takibi)

---

## 📊 Kullanılan Makine Öğrenmesi Modelleri

- Logistic Regression
- Support Vector Machine (SVM)
- Random Forest

Her model, girilen metin için **İnsan (%)** ve **AI (%)** olmak üzere ayrı ayrı tahmin üretmektedir.

---

## 🔄 Sistem Mimarisi

1. Kullanıcı metni web arayüzünden girer  
2. ASP.NET uygulaması metni Python API’ye gönderir  
3. Flask API, ML modelleri ile analizi yapar  
4. Sonuçlar JSON formatında web uygulamasına döner  
5. Analiz sonuçları kullanıcıya tablo halinde gösterilir  

---

## 🧪 Test Süreci

Proje kapsamında:
- White-box testler ile servis ve controller metodları test edilmiştir
- Black-box (sınama) testleri ile kullanıcı senaryoları değerlendirilmiştir
- API ve web katmanı arasındaki entegrasyon test edilmiştir

---

## 👥 Proje Ekibi

- **Web Geliştirme:** ASP.NET MVC
- **Makine Öğrenmesi:** Python & Scikit-learn
- **Test & Dokümantasyon:** White-box / Black-box testler

---

## 📌 Not

Bu proje eğitim amaçlı geliştirilmiştir ve akademik bir çalışma kapsamında hazırlanmıştır.

