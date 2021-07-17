using BolsaTrabajo_Domain.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BolsaTrabajo_Domain.Core.Interfaces
{
    public interface IExperienciaLaboralRepository
    {
        Task<bool> DeleteExperienciaLaboral(int id);
        Task<ExperienciaLaboral> GetExperienciaLaboralById(int id);
        Task<IEnumerable<ExperienciaLaboral>> GetExperienciasLaborales();
        Task InsertExperienciaLaboral(ExperienciaLaboral experiencia);
        Task<bool> UpdateExperienciaLaboral(ExperienciaLaboral experiencia);
    }
}