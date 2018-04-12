using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlamningsuppgift3
{
    class City
    {
        private string name;
        private int invanare;
        private int bnp;
        private int antal_turister;
        private List<Accommodation> accomm;
        private int antal_accomm;
        private double medelkostnad;

        // Konstruktor
        public City(string Name, int Invanare, int Bnp, int Antal_turister, List<Accommodation> Accomm)
        {
            this.name = Name;
            this.invanare = Invanare;
            this.bnp = Bnp;
            this.antal_turister = Antal_turister;
            this.accomm = Accomm;

            antal_accomm = accomm.Count;
            medelkostnad = accomm.Average(x => x.Price);
        }

        public string Name { get => name; set => name = value; }
        public int Invanare { get => invanare; set => invanare = value; }
        public int Bnp { get => bnp; set => bnp = value; }
        public int Antal_turister { get => antal_turister; set => antal_turister = value; }
        internal List<Accommodation> Accomm { get => accomm; set => accomm = value; }
        public int Antal_accomm { get => antal_accomm; set => antal_accomm = value; }
        public double Medelkostnad { get => medelkostnad; set => medelkostnad = value; }
    }
}
