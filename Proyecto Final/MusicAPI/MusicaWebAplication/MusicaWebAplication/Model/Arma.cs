using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmasWebAplication.Model
{
    public class Arma
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public string Producer { get; set; }
        public int Calibre { get; set; }
        public int DealerId { get; set; }
    }
}
