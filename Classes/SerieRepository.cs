using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();

        public List<Serie> Lista()
        {
            return listaSerie;
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