using BolsaTrabajo_Domain.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BolsaTrabajo_Domain.Core.Interfaces
{
    public interface ILocalidadRepository
    {
        Task<bool> DeleteLocalidad(int id);
        Task<IEnumerable<Localidad>> GetCapacitaciones();
        Task<Localidad> GetLocalidadById(int id);
        Task InsertLocalidad(Localidad localidad);
        Task<bool> UpdateLocalidad(Localidad localidad);
    }
}