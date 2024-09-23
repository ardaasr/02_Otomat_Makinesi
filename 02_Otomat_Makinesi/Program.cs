namespace _02_Otomat_Makinesi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool admin = false; // adminin true mu yoksa false mu olduğunu kontrol eder.
            string pass = "-1";
            string[] products = { "Cips", "Cola", "Bisküvi", "Soğuk Kahve" };
            double[] prices = { 25, 20, 15, 35 };

            while (true)
            {
                int choice = 0;
                Console.Clear();
                try
                {
                    for (int i = 0; i < products.Length; i++)
                    {
                        Console.WriteLine($"{i}-{products[i]}:{prices[i]}");
                    }

                    Console.WriteLine("Ürün Numarası Seçiniz:");
                    int productNo = Convert.ToInt32(Console.ReadLine());

                    if (productNo == -1)
                    {
                        admin = true;
                        Console.Clear();
                        break;
                    }

                    Console.WriteLine("Para Girişi Yapınız:");
                    choice = Convert.ToInt32(Console.ReadLine());

                    if (choice >= prices[productNo])
                    {
                        Console.WriteLine("Ürünü alınız.\nAfiyet Olsun.\nPara Üstü:" + (choice - prices[productNo]));
                        Thread.Sleep(2000);
                        choice = 0;
                        Console.Clear();
                    }

                    else
                    {
                        while (true)
                        {
                            Console.WriteLine("Yetersiz Bakiye!");
                            Console.WriteLine("Para Ekle-1\nPara İade-2");
                            int secim = Convert.ToInt32(Console.ReadLine());
                            if (secim == 1)
                            {
                                Console.WriteLine("Para Ekle:");
                                choice += Convert.ToInt32(Console.ReadLine());

                                if (choice >= prices[productNo])
                                {
                                    Console.WriteLine("Ürünü alınız.\nAfiyet Olsun.\nPara Üstü:" + (choice - prices[productNo]));
                                    Thread.Sleep(2000);
                                    choice = 0;
                                    Console.Clear();
                                    break;
                                }

                            }

                            else if (secim == 2)
                            {
                                Console.WriteLine("Para iade edildi.");
                                choice = 0;
                                Console.Clear();
                                break;
                            }

                            else { Console.WriteLine("Hatalı tuşlama!"); }

                        }

                    }



                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Lütfen rakam tuşlayınız!");

                }

                catch (IndexOutOfRangeException)
                {
                    Console.Clear();
                    Console.WriteLine("Lütfen ekrandaki sayılardan birini tuşlayınız!");
                }

            }


            if (admin)
            {
                Console.WriteLine("Yönetici Paneline Erişmek için Şifre Giriniz:");
                string password = "ab18";
                int hak = 3;
                while (hak > 0)
                {
                    string entry = Console.ReadLine();
                    if (entry == password)
                    {
                        hak = 3;
                        Console.WriteLine("Giriş Başarılı");
                        Thread.Sleep(2000);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Şifre Yanlış!!\nTekrar Deneyiniz.");
                        hak--;
                        if (hak == 0)
                        {
                            Console.WriteLine("3 kez yanlış şifre girdiniz. Cihaz kitlendi");
                            Thread.Sleep(6000);
                            break;
                        }
                    }
                }
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("------Admin Panel Yöneticisi------");
                    Console.WriteLine("1-Ürün Ekle\n2-Ürün Güncelle\n3-Ürün Sil\n4-Ürün Listesi\n5-Çıkış\nSeçiminiz:");
                    int secim = Convert.ToInt32(Console.ReadLine());

                    if (secim == 1)
                    {
                        Console.WriteLine("Ürün Adı:");
                        string urunAd = Console.ReadLine();
                        Console.WriteLine("Ürün Fiyatı:");
                        double fiyat = Convert.ToDouble(Console.ReadLine());

                        Array.Resize(ref products, products.Length + 1);
                        Array.Resize(ref prices, prices.Length + 1);

                        products[products.Length - 1] = urunAd;
                        prices[prices.Length - 1] = fiyat;
                    }

                    else if (secim == 2)
                    {
                        for (int i = 0; i < products.Length; i++)
                        {
                            Console.WriteLine($"{i}-{products[i]}:{prices[i]}");
                        }

                        Console.WriteLine("Güncellenecek ürün numarasi:");
                        int guncellenecekNo = Convert.ToInt32(Console.ReadLine());

                        if (guncellenecekNo >= products.Length)
                        {
                            Console.WriteLine("Yanlış ürün seçimi");
                            Thread.Sleep(2000);
                        }

                        else
                        {
                            Console.WriteLine("Ürün Adı:");
                            string urunAd = Console.ReadLine();
                            Console.WriteLine("Ürün Fiyatı:");
                            double fiyat = Convert.ToDouble(Console.ReadLine());

                            products[guncellenecekNo] = urunAd;
                            prices[guncellenecekNo] = fiyat;
                        }

                    }
                    else if (secim == 3)
                    {
                        for (int i = 0; i < products.Length; i++)
                        {
                            Console.WriteLine($"{i}-{products[i]}:{prices[i]}");
                        }

                        Console.WriteLine("Silienecek ürün numarasi:");
                        int silienecekNo = Convert.ToInt32(Console.ReadLine());

                        if (silienecekNo >= products.Length)
                        {
                            Console.WriteLine("Yanlış ürün seçimi");
                            Thread.Sleep(2000);
                        }

                        else
                        {
                            Array.Clear(products, silienecekNo, 1);
                            Array.Clear(prices, silienecekNo, 1);
                        }

                    }
                    else if (secim == 4)
                    {
                        for (int i = 0; i < products.Length; i++)
                        {
                            Console.WriteLine($"{i}-{products[i]}:{prices[i]}");
                        }
                        Thread.Sleep(2000);
                    }

                    else if (secim == 5)
                    {
                        break;
                    }

                }
            }

        }
    }
}

