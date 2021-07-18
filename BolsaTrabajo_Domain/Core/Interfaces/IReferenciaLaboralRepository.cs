using BolsaTrabajo_Domain.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BolsaTrabajo_Domain.Infrastructure.Interfaces
{
    public interface IReferenciaLaboralRepository
    {
        Task<bool> DeleteReferenciaLaboral(int id);
        Task<IEnumerable<ReferenciaLaboral>> GetReferenciaLaboral();
        Task<ReferenciaLaboral> GetReferenciaLaboralById(int id);
        Task InsertReferenciaLaboral(ReferenciaLaboral referencia);
        Task<bool> UpdateReferenciaLaboral(ReferenciaLaboral referencia);
    }
}