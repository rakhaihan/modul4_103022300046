using System;

namespace modul4_103022300046
{
    static void Main(string[] args)
    {
        //soal 1 table driven
        Console.Write("Masukkan nama produk elektronik: ");
        string inputElektronik = Console.ReadLine();

        KodeProduk.Elektronik elektronik;
        bool isValidElektronik = Enum.TryParse(inputElektronik, true, out elektronik);

        if (isValidElektronik)
        {
            string kodeProduk = KodeProduk.getKodeProduk(elektronik);
            Console.WriteLine($"Kode produk untuk {inputElektronik} : {kodeProduk}")s;
        }
        else
        {
            Console.WriteLine("produsk elektronik tidak ada");
        }


    }
}