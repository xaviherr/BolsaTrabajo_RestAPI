using BolsaTrabajo_Domain.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BolsaTrabajo_Domain.Core.Interfaces
{
    public interface IPostulacionRepository
    {
        Task<bool> DeletePostulacion(int id);
        Task<IEnumerable<Postulacion>> GetPostulacion();
        Task<Postulacion> GetPostulacionById(int id);
        Task InsertPostulacion(Postulacion postulacion);
        Task<bool> UpdatePostulacion(Postulacion postulacion);
    }
}