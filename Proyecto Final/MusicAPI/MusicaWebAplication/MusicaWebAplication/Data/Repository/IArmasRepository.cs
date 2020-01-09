using ArmasWebAplication.Model;
using MoviesAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmasAPI.Data.Repository
{
    public interface IArmasRepository   
    {
        //armas
        Arma getArma(int id);
        IEnumerable<Arma> getArmas();
        void addArma(Arma Arma);
        bool deleteArma(string ArmaName);
        Arma updateArma(int id, Arma Arma);
        List<Arma> GetByDealer(int dealer);
        List<Arma> GetByCalibre(int Cali);



        //dealers

        Dealer GetDealer(int id,bool showArmas);
        IEnumerable<Dealer> getDealers(bool showArmas);
        void addDealer(Dealer Dealer);
        bool deleteDealer(string DealerName);
        Dealer updateDealer(int id, Dealer Dealer);
    }
}
