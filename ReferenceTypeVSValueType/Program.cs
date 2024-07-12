using System;

namespace ReferenceVsValueTypes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            int a = 9;
            int b = a;  
            b = 10;

            Console.WriteLine("Contoh Hasil Value Types:");
            Console.WriteLine($"a = {a}");  
            Console.WriteLine($"b = {b}");  

            Marga marga1 = new Marga { Nama = "Ginting" };
            Marga marga2 = marga1;  
            marga2.Nama = "Meliala";

            Console.WriteLine("\n Contoh Hasil Reference Types:");
            Console.WriteLine($"person1.Name = {marga1.Nama}");  
            Console.WriteLine($"person2.Name = {marga2.Nama}");  

            Console.ReadKey();
        }
    }

    public class Marga
    {
        public string Nama { get; set; }
    }
}
