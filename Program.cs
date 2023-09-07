using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static BankaHesabıKapsülleme.Program;
using static System.Net.Mime.MediaTypeNames;
//Banka hesabı tanımla içinde bakiye olsun çekince azalsın yatırınca artsın
//limitinden fazla para çekmek isteyince de uyarı versin kapsüllemeyle yapacaksın
namespace BankaHesabıKapsülleme
{
    internal class Program
    {
        public class HesapBilgileri
        {
            private String KullaniciAdi;
            private int Sifre;
            private int GirisHakki;

            public string KullaniciAd
            {
                get { return KullaniciAdi; }
                set { KullaniciAdi = value; }
            }
            public int KisiSifre
            {
                get { return Sifre; }
                set { Sifre = value; }
            }

            public int Giris
            {
                get { return GirisHakki; }
                set { GirisHakki = value; }
            }
        }

        public class BankaHesabi // Banka hesabı adında bir sınıf oluşturduk.
        {
            public double Bakiye = 10.000;// bakiye ve limit tanımladık bu sınıfa bunu da double yaptık ondalik sayı olursa diye ki olur zaten.
            public double Limit = 54;// buraya sadece bakiye ve limit tanımlama nedeni banka hesabında bir bakiye olur bir de limit. Şuanki uyg için söylüyorum 

            public void ParaYatirma(double tutar) // para yatırma diye bir metot oluşturduk ve içine tutar değişkeni tanımladık.
            {
                tutar = Convert.ToDouble(tutar);// burada string bir değer olarak aldığı için double a çevirdik.
                if (tutar > 0) //eğer tutar sıfırdan büyükse 
                {
                    Bakiye += tutar; // Yatırılan tutarı bakiyeye ekle
                    Console.WriteLine($"{tutar} TL yatırıldı.\nYeni bakiye: {Bakiye} TL"); // ekrana yazdırdık.
                }

            }
            public void ParaCekme(double miktar)
            {
               
                miktar = Convert.ToDouble(miktar);//string girilen değeri double dönüştürdük.
                if (miktar < Bakiye)// eğer miktar bakiyeden küçükse.
                {
                    Limit= Bakiye -= miktar; //bakiyeden çekilen tutarı düş
                    Console.WriteLine($"{miktar} TL çekildi. \nYeni bakiye: {Bakiye} TL"); // sonrada bunu ekrana bastır.
                }
                else
                {
                    Console.WriteLine($"Yetersiz bakiye. \nİzin verilen limit: {Limit} TL");// eğer çekilecek para bakiyeden büyükse bu kadar türkçem yetmedi.
                }
            }


        }
        public double Bakiye
        {
            get { return Bakiye; } //Bakiyeyi okumak için get i kullandık.
            set { Bakiye = value; } //Bakiyeyi güncellemek için de burada seti kullandık.
        }

        public double Limit
        {
            get { return Limit; }
            set { Limit = value; }
        }



        public double tutar
        {
            get { return tutar; }
            set { tutar = value; }
        }


        public double miktar
        {
            get { return miktar; }
            set { miktar = value; }
        }
    }
    class MyClass
    {
        public static void Main()
        {
            BankaHesabi hesap = new BankaHesabi();
            hesap.Bakiye = 1000;

            HesapBilgileri obj = new HesapBilgileri();
            obj.KullaniciAd = "Esma";
            obj.KisiSifre = 1234;
            obj.Giris = 3;

            Console.WriteLine("Sayın Esmanur Karataş Lütfen Kullanıcı Adınızı Giriniz:");

            Console.Write("Kullanıcı Adı:");
            obj.KullaniciAd = Console.ReadLine();
            Console.Write("Kullanıcı Şifre:");
            obj.KisiSifre = Convert.ToInt32(Console.ReadLine());

            if (obj.KullaniciAd == "Esma" && obj.KisiSifre == 1234)
            {
                Console.WriteLine("Giriş başarılı.");

                while (true) // Sonsuz döngü
                {
                    Console.WriteLine("Lütfen Yapmak İstediğiniz İşlemi Seçiniz: \n1: Bakiye Sorgulama \n2: Para Yatırma \n3: Para Çekme \n4: Çıkış Yap");
                    int islem = Convert.ToInt32(Console.ReadLine());

                    switch (islem)
                    {
                        case 1:
                            Console.WriteLine($"Bakiyeniz: {hesap.Bakiye}");
                            break;
                        case 2:
                            Console.Write($"Yatıracağınız Tutar:");
                            double tutar = Convert.ToDouble(Console.ReadLine());
                            hesap.ParaYatirma(tutar);
                            break;
                        case 3:
                            Console.Write($"Çekeceğiniz Tutar:");
                            double miktar = Convert.ToDouble(Console.ReadLine());
                            hesap.ParaCekme(miktar);
                            break;
                            case 4:
                            Console.WriteLine("Çıkış Yapılıyor. Lütfen Kartınızı Çekmeyiniz.");
                            Thread.Sleep(1000); // ekrana yazıyı yazdıktan 3 çokmuş 1 sn yaptık sonra uygulamadan çıkış yapar.
                            Environment.Exit(0); // Programı kapatmak için kullandık.
                            //Application.Exit();
                            break;
                            
                        default:
                            Console.Write("Yanlış değer Girdiniz!");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Kullanıcı adı veya şifre yanlış.");
            }
        }
    }

}


