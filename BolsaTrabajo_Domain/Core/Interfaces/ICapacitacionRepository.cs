using BolsaTrabajo_Domain.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BolsaTrabajo_Domain.Core.Interfaces
{
    public interface ICapacitacionRepository
    {
        Task<bool> DeleteCapacitacion(int id);
        Task<Capacitacion> GetCapacitacionById(int id);
        Task<IEnumerable<Capacitacion>> GetCapacitaciones();
        Task InsertCapacitacion(Capacitacion capacitacion);
        Task<bool> UpdateCapacitacion(Capacitacion capacitacion);
    }
}