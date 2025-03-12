using System;

namespace modul4_103022300046
{

    class Program
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
                Console.WriteLine($"Kode produk untuk {inputElektronik} : {kodeProduk}");
            }
            else
            {
                Console.WriteLine("produk elektronik tidak ada");
            }



            //soal 2 state based
            FanLaptop fanLaptop = new FanLaptop();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine($"State saat ini: {fanLaptop.currentState}");
                Console.WriteLine("masukkan trigger: Mode_down, Mode_up, Turbo_shortcut, exit");
                string inputFan = Console.ReadLine();

                switch (inputFan)
                {
                    case "Mode_up":
                        if (fanLaptop.currentState == FanLaptop.State.Quiet)
                        {
                            Console.WriteLine("Fan Quiet berubah menjadi Balanced");
                            fanLaptop.activate(FanLaptop.Trigger.Mode_up);
                        }
                        else if (fanLaptop.currentState == FanLaptop.State.Balanced)
                        {
                            Console.WriteLine("Fan Balanced berubah menjadi Performance");
                            fanLaptop.activate(FanLaptop.Trigger.Mode_up);
                        }
                        else if (fanLaptop.currentState == FanLaptop.State.Performance)
                        {
                            Console.WriteLine("Fan Performance berubah menjadi Turbo");
                            fanLaptop.activate(FanLaptop.Trigger.Mode_up);
                        }
                        //fanLaptop.activate(FanLaptop.Trigger.Mode_up);
                        break;

                    case "Mode_down":
                        if (fanLaptop.currentState == FanLaptop.State.Balanced)
                        {
                            Console.WriteLine("Fan Balanced berubah menjadi Quiet");
                        }
                        else if (fanLaptop.currentState == FanLaptop.State.Performance)
                        {
                            Console.WriteLine("Fan Performance berubah menjadi Balanced");
                        }
                        else if (fanLaptop.currentState == FanLaptop.State.Turbo)
                        {
                            Console.WriteLine("Fan Turbo berubah menjadi Performance");
                        }
                        else if (fanLaptop.currentState == FanLaptop.State.Quiet)
                        {
                            Console.WriteLine("Fan Quiet berubah menjadi Balance");
                        }
                        fanLaptop.activate(FanLaptop.Trigger.Mode_down);

                        break;

                    case "Turbo_shortcut":
                        if (fanLaptop.currentState == FanLaptop.State.Quiet)
                        {
                            Console.WriteLine("Fan Quiet berubah menjadi Turbo");
                        }
                        else if (fanLaptop.currentState == FanLaptop.State.Turbo)
                        {
                            Console.WriteLine("Fan Turbo berubah menjadi Quiet");
                        }

                        fanLaptop.activate(FanLaptop.Trigger.Turbo_shortcut);
                        break;

                    case "exit":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("perintah tidak valid");
                        break;
                }

            }

        }

    }
}