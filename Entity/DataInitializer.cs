using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BCS.MvcWeb.Entity
{
    public class DataInitializer:DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var kategoriler = new List<Category>()
            {
                new Category() {Name = "Kamera", Description = "Kamera Ürünleri"},
                new Category() {Name = "Bilgisayar", Description = "Bilgisayar Ürünleri"},
                new Category() {Name = "Elektronik", Description = "Elektronik Ürünleri"},
                new Category() {Name = "Telefon", Description = "Telefon Ürünleri"},
                new Category() {Name = "Beyaz Eşya", Description = "Beyaz Eşya Ürünleri"}
            };

            foreach (var kategori in kategoriler)
            {
                context.Categories.Add(kategori);
            }

            context.SaveChanges();

            var urunler = new List<Product>()
            {
                new Product(){ Name ="Canon Eos 1200D 18-55 mm DC Profesyonel Dijital Fotoğraf Makinesi",Description = "Canon Kamera",Price =1200 ,Stock =50 ,IsApproved =true ,CategoryId =1,IsHome = true ,Image = "1.jpg"},
                new Product(){ Name ="Canon EOS 2000D + EF-S 18-55mm f/3.5-5.6 DC III Fotoğraf Makinesi (Canon Eurasia Garantili)",Description = "Canon Kamera",Price =2000 ,Stock =40,IsApproved =true ,CategoryId =1,IsHome = true ,Image = "2.jpg"},
                new Product(){ Name ="Canon Eos 700D 18-55 mm DC Profesyonel Dijital Fotoğraf Makinesi",Description = "Canon Kamera",Price =1050 ,Stock =30 ,IsApproved =false ,CategoryId =1 ,Image = "3.jpg"},
                new Product(){ Name ="Canon Eos 100D 18-55 mm DC Profesyonel Dijital Fotoğraf Makinesi",Description = "Canon Kamera",Price =700 ,Stock =100 ,IsApproved =false ,CategoryId = 1 ,Image = "4.jpg"},
                new Product(){ Name ="Canon EOS 250D + EF-S 18-55mm f/3.5-5.6 DC III Siyah Fotoğraf Makinesi (Canon Eurasia Garantili)",Description = "Canon Kamera",Price =3000 ,Stock =75 ,IsApproved = true,CategoryId =1 ,Image = "5.jpg"},

                new Product(){ Name ="Lenovo IdeaPad S145-15API AMD Athlon 300U 8GB 256GB SSD 15.6",Description = "Lenovo IdeaPad",Price = 4500,Stock =40 ,IsApproved = true,CategoryId =2 ,Image = "1.jpg"},
                new Product(){ Name ="Asus FX505DT-BQ030 AMD Ryzen 7 3750H 8GB 512GB SSD GTX1650 Freedos 15.6",Description = "Asus Bilgisayar",Price =6500 ,Stock =50 ,IsApproved = true,CategoryId =2,IsHome = true ,Image = "2.jpg"},
                new Product(){ Name ="HP 15-DA2033NT Intel Core i5 10210U 4GB 256GB SSD Windows 10 Home 15.6",Description = "HP Bilgisayar",Price =5500 ,Stock =70 ,IsApproved =true ,CategoryId =2 ,Image = "3.jpg"},
                new Product(){ Name ="HP 15-DW3017NT Intel Core I3 1115G4 4GB 256 GB SSD Freedos 15.6 ",Description = "HP Bilgisayar",Price =3000 ,Stock =25 ,IsApproved =false ,CategoryId =2 ,Image = "4.jpg"},
                new Product(){ Name ="Acer Aspire Gaming 7 A715-75G Intel Core i5 10300H 8GB 256GB SSD GTX 1650 Linux 15.6",Description = "Acer Bilgisayar",Price =9000 ,Stock =80 ,IsApproved =true ,CategoryId =2,IsHome = true ,Image = "5.jpg"},

                new Product(){ Name ="Bakay Nodemcu Esp32 Esp-32S Modülü",Description = "Modül",Price =65 ,Stock =100 ,IsApproved =true ,CategoryId =3 ,Image = "1.jpg"},
                new Product(){ Name ="Arduino L293D Motor Sürücü Entegresi",Description = "Arduino Sürücü Entegresi",Price =16 ,Stock =80 ,IsApproved =false ,CategoryId =3 ,Image = "2.jpg"},
                new Product(){ Name ="China Arduino Sensör Seti - 37 Parça",Description = "China Arduino Sensör Seti ",Price =120 ,Stock =200 ,IsApproved =true ,CategoryId =3,IsHome = true ,Image = "3.jpg"},
                new Product(){ Name ="Oyunlarla Fen 10 'lu Dc Motor Için Deney Motoru Pervanesi Mini Plastik Pervane",Description = "DC Moturlu Pervane",Price =25 ,Stock =45 ,IsApproved =false ,CategoryId =3 ,Image = "4.jpg"},
                new Product(){ Name ="Çift Fanlı Soğutucu Raspberry Pi",Description = "Soğutucu ",Price =60 ,Stock =100 ,IsApproved =true ,CategoryId =3 ,Image = "5.jpg"},

                new Product(){ Name ="Samsung Galaxy A21s 64 GB (Samsung Türkiye Garantili)",Description = "Samsung Telefon",Price =2500 ,Stock =100 ,IsApproved =true ,CategoryId =4 ,Image = "1.jpg"},
                new Product(){ Name ="Xiaomi Redmi Note 10S 128 GB 6 GB Ram (Xiaomi Türkiye Garantili)",Description = "Xiaomi Redmi Telefon",Price =3600 ,Stock =80 ,IsApproved = true,CategoryId = 4 ,Image = "2.jpg"},
                new Product(){ Name ="Oppo Realme C25 64 GB (Oppo Realme Türkiye Garantili)",Description = "Oppo Telefon",Price =2000 ,Stock =40 ,IsApproved =true ,CategoryId =4 ,Image = "3.jpg"},
                new Product(){ Name ="Samsung Galaxy A51 256 GB (Samsung Türkiye Garantili)",Description = "Samsung Telefon",Price =3750 ,Stock =120 ,IsApproved = true,CategoryId =4,IsHome = true ,Image = "4.jpg"},
                new Product(){ Name ="Black Shark 4 12/256 GB (Resmi Distribütör Garantili)",Description = "Black Shark Telefon",Price =6500 ,Stock =60 ,IsApproved =true ,CategoryId =4,IsHome = true ,Image = "5.jpg"},

                new Product(){ Name ="Profilo OP16P6B10D Siyah Doğalgazlı Cam Ankastre Ocak",Description = "Profilo Ocak",Price =3700 ,Stock = 90,IsApproved =false ,CategoryId =5 ,Image = "1.jpg"},
                new Product(){ Name ="Vestel 20263685 NF48001 Buzdolabı",Description = "Vestel Buzdolap",Price =3800 ,Stock =70 ,IsApproved =false ,CategoryId =5 ,Image = "2.jpg"},
                new Product(){ Name ="Bosch WGA142X1TR 9 kg 1200 Devir Çamaşır Makinesi",Description = "Bosch Çamaşır Makinası",Price =4000 ,Stock =55 ,IsApproved = true,CategoryId =5,IsHome = true,Image = "3.jpg" },
                new Product(){ Name ="Samsung RB50RS334WW/TR 543 lt No-Frost Buzdolabı",Description = "Samsung No-Frost Buzdolabı",Price =6500 ,Stock =65 ,IsApproved =true ,CategoryId =5,IsHome = true,Image = "4.jpg" },
                new Product(){ Name ="Pratikko Mini Çamaşır Makinesi",Description = "Mini Çamaşır Makinesi",Price =400 ,Stock =20 ,IsApproved =false ,CategoryId =5 ,Image = "5.jpg"}
            };

            foreach (var urun in urunler)
            {
                context.Products.Add(urun);
            }

            context.SaveChanges();


            base.Seed(context);
        }
    }
}