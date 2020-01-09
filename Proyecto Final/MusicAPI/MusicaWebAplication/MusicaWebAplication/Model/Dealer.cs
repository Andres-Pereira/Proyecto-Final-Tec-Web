using ArmasWebAplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Model
{
    public class Dealer
    {
        public string url { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pais { get; set; }
       public IEnumerable<Arma> ListaArmas { get; set;  }
    }
}
