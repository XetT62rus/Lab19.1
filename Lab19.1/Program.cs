using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab19._1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PK> PK1 = new List<PK>()
            {
                new PK(){Code=1,NameBrand="LG",TypeProcessor="AMD",FrequencyProcessor=3000,RAM=5000,HardDisk=200000,VideoCard=2000,Cost=65000,Count=5},
                new PK(){Code=2,NameBrand="Philips",TypeProcessor="Intel",FrequencyProcessor=2500,RAM=8000,HardDisk=500000,VideoCard=3000,Cost=75000,Count=2},
                new PK(){Code=3,NameBrand="Samsung",TypeProcessor="AMD",FrequencyProcessor=2700,RAM=4000,HardDisk=1000000,VideoCard=1000,Cost=43000,Count=40},
                new PK(){Code=4,NameBrand="LG",TypeProcessor="Intel",FrequencyProcessor=2900,RAM=16000,HardDisk=250000,VideoCard=4000,Cost=150000,Count=15},
                new PK(){Code=5,NameBrand="Acer",TypeProcessor="AMD",FrequencyProcessor=2300,RAM=32000,HardDisk=500000,VideoCard=1000,Cost=160000,Count=7},
                new PK(){Code=6,NameBrand="MSI",TypeProcessor="Intel",FrequencyProcessor=2000,RAM=8000,HardDisk=500000,VideoCard=1000,Cost=50000,Count=5}
            };
            string A = Console.ReadLine();
            int B = Convert.ToInt32(Console.ReadLine());
            List<PK> Processors = (from p in PK1
                                   where p.TypeProcessor == A
                                   select p).ToList();
            List<PK> RAM = (from p in PK1
                            where p.RAM >= B
                            select p).ToList();
            List<PK> Cost = (from p in PK1
                             orderby p.Cost
                             select p).ToList();
            PK PK5 = PK1.OrderByDescending(x => x.Cost).FirstOrDefault();
            Console.WriteLine(PK5.NameBrand);
            PK PK6 = PK1.OrderByDescending(x => x.Cost).LastOrDefault();
            Console.WriteLine(PK6.NameBrand);
            Console.WriteLine(PK1.Any(x => x.Count > 30));
            IEnumerable<IGrouping<string, PK>> PK4 = PK1.GroupBy(p => p.TypeProcessor);
            foreach (IGrouping<string, PK> e in PK4)
            {
                Console.WriteLine($"{e.Key}");
                foreach (PK i in e)
                {
                    Console.WriteLine($"{i.Code} {i.NameBrand} {i.FrequencyProcessor} {i.TypeProcessor}");
                }
            }

            Print(Processors);
            Print(RAM);
            Print(Cost);

            Console.ReadKey();

        }
        static void Print(List<PK> PK1)
        {
            foreach (PK p in PK1)
            {
                Console.WriteLine($"{p.Code} {p.NameBrand} {p.TypeProcessor} {p.FrequencyProcessor} {p.RAM} {p.HardDisk} {p.VideoCard} {p.Cost} {p.Count}");
            }
            Console.WriteLine();
        }
    }
    class PK
    {
        public int Code { get; set; }
        public string NameBrand { get; set; }
        public string TypeProcessor { get; set; }
        public int FrequencyProcessor { get; set; }
        public int RAM { get; set; }
        public int HardDisk { get; set; }
        public int VideoCard { get; set; }
        public int Cost { get; set; }
        public int Count { get; set; }
    }

}
