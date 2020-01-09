using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArmasWebAplication.Model;
using MoviesAPI.Model;

namespace ArmasAPI.Data.Repository
{
    public class ArmasRepository : IArmasRepository
    {
        private List<Arma> Armas;
        private List<Dealer> Dealers;
        public ArmasRepository()
        {
            Armas = new List<Arma>() {
                new Arma() {
                 Id = 1,
                 Name= "Revolver M17",
                 Category="Arma corta",
                 Type= "Automatica",
                 Producer="ArmaLite",
                 Calibre=9,
                 DealerId= 1
                },
                new Arma() {
                 Id = 2,
                 Name= "Rifle SpringField",
                 Category="Arma larga",
                 Type= "Semi-automatico",
                 Producer="Diamondback Firearms",
                 Calibre=11,
                 DealerId= 2
                },
                new Arma() {
                 Id = 3,
                 Name= "RPK-74",
                 Category="Arma larga",
                 Type= "Rafaga",
                 Producer="Colt's Manufacturing Company",
                 Calibre=48,
                 DealerId= 1
                }
            };

            Dealers = new List<Dealer>() {
                new Dealer() {
                 url="https://pbs.twimg.com/profile_images/1178894930384740353/lR-aJWWQ_400x400.jpg",
                 Id = 1,
                 Name= "El Loco ",
                 Pais="Suecia"
                },
                new Dealer() {
                url="https://www.tn8.tv/media/cache/ce/26/ce26f0cd3033429cfe31b203c8b3d343.jpg",
                 Id = 2,
                 Name= "Rolo",
                Pais="Albania"
                },
                
            };
        }
        public void addArma(Arma Arma)
        {
            var nextId = Armas.Last();
            var newId = nextId == null ? 1 : nextId.Id + 1;
            Arma.Id = newId;
            Armas.Add(Arma);
        }

        public void addDealer(Dealer Dealer)
        {
            var nextId = Dealers.Last();
            var newId = nextId == null ? 1 : nextId.Id + 1;
            Dealer.Id = newId;
            Dealers.Add(Dealer);
        }

        public bool deleteArma(string Name)
        {
            var ArmaToDelete = Armas.Single(m=>m.Name == Name);
            return (Armas.Remove(ArmaToDelete));
        }

        public bool deleteDealer(string Name)
        {
            var DealerToDelete = Dealers.Single(m => m.Name == Name);
            return (Dealers.Remove(DealerToDelete));
        }

        public Arma getArma(int id)
        {
            return Armas.SingleOrDefault(m => m.Id == id);
        }

        public Dealer GetDealer(int id, bool showArmas)
        {
            Dealer x= Dealers.SingleOrDefault(m => m.Id == id);
            var dealers = Dealers;
            foreach(var dealer in dealers) {
                if (showArmas)
                { dealer.ListaArmas = getArmas().Where(v => v.DealerId == dealer.Id); }
                else
                { dealer.ListaArmas = null; }

            }

            return x;
        }

        public IEnumerable<Arma> getArmas()
        {
            return Armas;
        }
        public IEnumerable<Dealer> getDealers(bool showArmas)
        {
            var dealers = Dealers;
            foreach (var dealer in dealers)
            {
                if (showArmas)
                { dealer.ListaArmas = getArmas().Where(v => v.DealerId == dealer.Id); }
                else
                { dealer.ListaArmas = null; }

            }
            return Dealers;
        }

        public Arma updateArma(int id, Arma m)
        {
            var ArmaToUpdate = getArma(id);
            ArmaToUpdate.Name = m.Name;
            ArmaToUpdate.Category = m.Category;
            ArmaToUpdate.Type = m.Type;
            ArmaToUpdate.Producer = m.Producer;
            ArmaToUpdate.Calibre = m.Calibre;
            return ArmaToUpdate;
        }

        public Dealer updateDealer(int id, Dealer m)
        {
            var DealerToUpdate = GetDealer(id,true);
            DealerToUpdate.Name = m.Name;
            DealerToUpdate.Pais = m.Pais;
            return DealerToUpdate;
        }

        public List<Arma> GetByDealer(int dealer)
        {

            return getArmas().Where(v => v.DealerId == dealer).ToList();
        }

        public List<Arma> GetByCalibre(int Cali)
        {
            return getArmas().Where(v => v.Calibre == Cali).ToList();

        }
    }
}
