using BolsaTrabajo_Domain.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BolsaTrabajo_Domain.Core.Interfaces
{
    interface IOfertaRepository
    {
        Task<bool> DeleteOferta(int id);
        Task<IEnumerable<Oferta>> GetOferta();
        Task<Oferta> GetOfertaById(int id);
        Task InsertOferta(Oferta oferta);
        Task<bool> UpdateOferta(Oferta oferta);
    }
}