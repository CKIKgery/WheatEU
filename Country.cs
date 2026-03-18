using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheatEU
{
    internal class Country
    {
        private string name;
        private Dictionary<string, double> data;

        public Country(string name, Dictionary<string, double> data)
        {
            this.Name = name;
            this.Data = data;
        }

        public string Name { get => name; set => name = value; }
        public Dictionary<string, double> Data { get => data; set => data = value; }
    }
}
