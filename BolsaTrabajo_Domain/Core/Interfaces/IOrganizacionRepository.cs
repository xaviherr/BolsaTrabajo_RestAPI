using BolsaTrabajo_Domain.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BolsaTrabajo_Domain.Core.Interfaces
{
    public interface IOrganizacionRepository
    {
        Task<bool> DeleteOrganizacion(int id);
        Task<IEnumerable<Organizacion>> GetOrganizacion();
        Task<Organizacion> GetOrganizacionById(int id);
        Task InsertOrganizacion(Organizacion organizacion);
        Task<bool> UpdateOrganizacion(Organizacion organizacion);
    }
}