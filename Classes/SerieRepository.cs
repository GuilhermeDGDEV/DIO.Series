using System.Collections.Generic;
using DIO.Series.Interfaces;
using System.Linq;

namespace DIO.Series
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();

        public List<Serie> Lista()
        {
            return listaSerie.Where(serie => serie.GetAtivo()).ToList();
        }

        public Serie RetornoPorId(int id)
        {
            return listaSerie[id];
        }

        public void Insere(Serie serie)
        {
            listaSerie.Add(serie);
        }

        public void Exclui(int id)
        {
            listaSerie[id].Exclui();
        }

        public void Atualiza(int id, Serie serie)
        {
            listaSerie[id] = serie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }
    }
}