class Program
    {
        class Block
        {
            public int data;
            public Block next;
            public Block prev;
        }
        class Btree
        {
            public int data;
            public Btree right;
            public Btree left;
        }
        class BPlustree
        {
            public int[] data = new int[100];
            public BPlustree[] link = new BPlustree[101];
            
        }
        static int[] btree = new int[100];

        static string[] hash = new string[100];
        static Block[] collision = new Block[100];

    
        static void Main(string[] args)
        {
            //Searching --> Arama 
            /* Çok sık kullanılır bilgisayarın yegane olma sebebi budur. 
             * Arama: Bilgi yığınından istenilen verinin olup olmadığını araştırmasıdır.
             * 
             * Doğruluk
             * Performans, hızlı olmalı!
             * 
             * Search nasıl gerçekleşiyor?
             * 
             * 1- SEQUENTIAL SEARCH ( Sıralı Arama )
             * Bir veri kümesinden arama yapılacak burada herhangi bir sort ya da index yoktur
             * (Yani arama yaptığımız yerde bir düzen sıra yoktur. Bu sebepten ötürü tüm elemanlar tek tek kontrol edilir çok maliyetli ve kötüdür.)
             * 
             * Bir kişiyi bulma maliyeti N eleman arasından N/2 dir.
             * Bütün yazılımlar 3 kritere göre test edilir
             * 
             * a-) Best Case -En iyi durum 
             * b-) Worst Case -En kötü durum
             * c-) Normal Case - Average Case -Normal durum
             * 
             * 2- BINARY SEARCH 
             * Sort edilmiş (sıralanmış) veriler içerisinde arama yapar.
             * 
             * Int division yapıldığında yukarı yuvarlama olacak (Normalde aşağı yuvarlanır)
             * 
             * Binary Search ün en kötü durumu Log(n)
             * Maliyeti Log(n)
             * En iyi durumu 1
             * 
             * 3- INDEXLI SEARCH
             * B+ Tree
             * en sağlam ve hızlı searchlerden biridir
             * 
             * Full text search ARAŞTIRABİLİRSİN
             * 
             *-------------------*----------------------*---------- 
             *
             * HASHING en hızlı olmaya aday 
             * Diziler ile implement edilir.
             * 
             * x[55]
             * 
             * Saklayacağımız verilere bir değer oluştururuz. 
             * Sayısal ifadeye dönüşür
             * Sayısal ifade, dizimizin indisi olur
             * Ve hemen o dizinin belirlenen indisine gideriz.
             * 
             * Örnek) Değer belirleyelim 
             * TC No, AD SOYAD gibi
             * Bunları sayısallaştıracağız  
             * İndis bizim dizimizin sınırları içerisinde olmalı
             * Sayısallaştırmada bir basit matematiksel formül vardır, en sonunda bu formül bir mod ile tamamlanır
             * HASH 100 elemanlı 
             * ADSOYAD
             * Formül: 100 Elemanlı modunu alacağız. 
             * Her harfin ASCII değerini alalım. Ve toplayalım.
             * 
             * ALİ 
             * A 65 + L 70 + İ 90 = 225 (100 elemanlı bir dizide patlar bu yüzden)
             * 225 = 25(mod100)
             * 
             * Değer --> Sayısallaşttırdık ve modunu aldık --> Çıkan değer bizim Dizimizin elemanı oldu 
             * 
             * HASH FONKSİYONU 
             * 1-) Basit olmalı.
             * 2-) Düzgün dağılmalı.
             * 3-) Mod kullanılmalıdır.
             * 
             * !HASH FONKİSYONU ÇAKIŞABİLİR!
             * Ali = 25 
             * İla = 25         Collision ( ÇAKIŞMA, ÇARPIŞMA )
             * 
             * 
             * 
             * 
             *
             */

            int a = 0;
            int b = btree.Length - 1;

            int aranan = 0;
            bool search = true;

            //a ile b farklı olduğu durumda while çalışacak şekilde bir koşul belirmek en doğru çözüm.
            while (search)
            {
                int ortalama = (a + b) / 2;
                if (btree[ortalama] == aranan) { search = false; break; }
                if (btree[ortalama] > aranan) b = ortalama;
                else a = ortalama;
            }
 

            //--------------HASHING----------------

            hash[hashfunc("AHMET")] = "AHMET";
            hash[hashfunc("VELİ")] = "VELİ";
            hash[hashfunc("SENA")] = "SENA";
            hash[hashfunc("RÜMEYSA")] = "RÜMEYSA";
            hash[hashfunc("ALİ")] = "ALİ";
            hash[hashfunc("İLA")] = "İLA";
            //Çakışanlar için ayrı bir Hash Dizini ve Funct. olacak --> Perfect Hashing
            //Çakışmalar için Linked List kullanılabilir
            //En ekonomik olan çakışma varsa bi sonrakine bak boşsa oraya yaz. 

            Console.WriteLine(Find("AHMET"));
        }





        static int hashfunc(string s)
        {
            int value = 0;
            for (int i = 0; i < s.Length; i++)
            {
                value = value + (byte)s[i];
            }
            return value % 100;
        }
        static int hashfuncInt(int s)
        {
            
            return s % 100;
        }
        static bool find(string s)
        {
            int hf = hashfunc(s);
            //if (hash[hf] == s) return true;
            //else return false;
            return hash[hf] == s ? true : false;
        }

        static void Ekle(string s)
        {
            int indis = hashfunc(s);
            if (hash[indis] == null) { hash[indis] = s; return; }
            for(int i = 1; i < hash.Length-1; i++)
            {
                if (hash[indis + i % hash.Length] == null)
                {
                    hash[indis + i % hash.Length] = s; return;
                }
            }
        }

        static bool Find(string s)
        {
            int hf = hashfunc(s);
            if (hash[hf] == s) return true;
            for (int i = 1; i < hash.Length-1; i++)
            {
                if (hash[hf + i % hash.Length] == s) return true;
            }
            return false;
        }
    }
