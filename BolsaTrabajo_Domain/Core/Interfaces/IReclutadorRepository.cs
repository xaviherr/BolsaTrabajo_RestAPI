using BolsaTrabajo_Domain.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BolsaTrabajo_Domain.Core.Interfaces
{
    public interface IReclutadorRepository
    {
        Task<bool> DeleteReclutador(int id);
        Task<IEnumerable<Reclutador>> GetReclutador();
        Task<Reclutador> GetReclutadorById(int id);
        Task InsertReclutador(Reclutador reclutador);
        Task<bool> UpdateReclutador(Reclutador reclutador);
    }
}