# WinFormAppWithSQL

**TR:** C# ve Windows Forms ile yaptığım, verileri SQL Server'da tutan basit bir otobüs bileti uygulaması. Kullanıcı kayıt olup giriş yapıyor, seferleri filtreleyip koltuk seçerek bilet alıyor. Admin sefer ekleyip silebiliyor ve güncelleyebiliyor.

**EN:** A simple bus ticket app I built with C# and Windows Forms, storing its data in SQL Server. Users can sign up, log in, filter trips and buy a ticket by picking a seat. An admin can add, delete and update trips.

## Teknolojiler / Technologies

- C# (.NET Framework 4.7.2)
- Windows Forms
- Microsoft SQL Server
- ADO.NET
- Visual Studio 2022

## Çalıştırmak için / How to run

**TR:**
1. SQL Server'da `SEFERLER` veritabanını oluşturun. Tablolar: `kullanicilar`, `Sefer_Listesi`, `Biletim` (depoda SQL betiği yok).
2. `ödevprojesi.sln` dosyasını Visual Studio'da açın.
3. Bağlantı dizesindeki sunucu adını (`DESKTOP-VV6EKJV`) kendi bilgisayarınıza göre değiştirin.
4. F5 ile çalıştırın.

**EN:**
1. Create the `SEFERLER` database in SQL Server with these tables: `kullanicilar`, `Sefer_Listesi`, `Biletim` (there is no SQL script in the repo).
2. Open `ödevprojesi.sln` in Visual Studio.
3. Change the server name in the connection string (`DESKTOP-VV6EKJV`) to your own.
4. Press F5 to run.

## Not / Note

**TR:** Ödev projesi olduğu için sorgular parametresiz yazıldı ve şifreler düz metin saklanıyor.

**EN:** This is a course project, so the queries are not parameterized and passwords are stored as plain text.
