using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlamningsuppgift3
{
    class Country
    {
        private string name;
        private int invanare;
        private int bnp;
        public List<City> cities;

        public Country(string Name, int Invanare, int Bnp, List<City> Cities)
        {
            this.name = Name;
            this.invanare = Invanare;
            this.bnp = Bnp;
            this.cities = Cities;
        }

        public string Name { get => name; set => name = value; }
        public int Invanare { get => invanare; set => invanare = value; }
        public int Bnp { get => bnp; set => bnp = value; }
        internal List<City> Cities { get => cities; set => cities = value; }
    }
}
