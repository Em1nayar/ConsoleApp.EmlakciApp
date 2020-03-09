   using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.EmlakciApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Ev evim = new Ev();
            Console.WriteLine("Oda Sayınızı Girin:");
            evim.SetOdasayisi(int.Parse(Console.ReadLine()));
            Console.WriteLine("Alan Giriniz:");
            evim.Alan = double.Parse(Console.ReadLine());
            Console.WriteLine("Semt Giriniz.");
            evim.Semt = Console.ReadLine();
            Console.WriteLine("Kat No giriniz:");
            evim.Katno = int.Parse(Console.ReadLine());

            //Console.WriteLine(bilgi);
            //Console.ReadKey();
            //Personel mehmet = new Personel();
            //Console.WriteLine("kaç yıldır çalışıyorsunuz:");
            //mehmet.SetCalismayili(int.Parse(Console.ReadLine()));
            //Console.WriteLine("tabanmaaş giriniz:");
            //mehmet.SetTabanaylik(int.Parse(Console.ReadLine()));
            //Console.WriteLine(mehmet.bilgiler());
            //Console.ReadKey();
            FileStream fs = new FileStream(@"D:\EV_BİLGİLERİ.txt",FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(evim.liste());
            fs.Flush();
            sw.Close();
            fs.Close();

        }


    }

}

    class Ev
    {
        double alan;
        int odasayisi;
        String semt;
        int katno;

    public double Alan { get => alan; set => alan = value; }

    public int GetOdasayisi()
    {
        return odasayisi;
    }

    public void SetOdasayisi(int value)
    {
        odasayisi = Math.Abs(value);
        if (value < 0)
        {
            FileStream hata = new FileStream(@"D:\hata.txt",FileMode.Create);
            StreamWriter pr = new StreamWriter(hata);
            pr.Write($"kullanıcı şu tarihte hatalı giriş yaptı:{DateTime.Now.ToLongDateString()} Girdiği değer:{this.odasayisi}={value}");
            hata.Flush();
            pr.Close();
            hata.Close();
        }
    }

    public string Semt { get => semt; set => semt = value; }
    public int Katno { get => katno; set => katno = value; }

    public String liste()
    {
        return $"alan:{this.alan}\noda sayısı:{this.odasayisi}\nSemt:{this.Semt}\nKat no:{this.Katno}";

    }

}

class Personel
{
    private int calismayili;
    int maas;
    int tabanaylik;

    public int GetTabanaylik()
    {
        return tabanaylik;
    }

    public void SetTabanaylik(int value)
    {
        tabanaylik = value;
    }

    public int GetCalismayili()
    {
        return calismayili;
    }

    public void SetCalismayili(int value)
    {
        
        calismayili = value;
    }

    public String bilgiler()
    {   
        return $"\ncalışmayılı:{this.GetCalismayili()}\nmaaş:{this.maas}\ntabanmaaş:{this.GetTabanaylik()}";
    }

}
