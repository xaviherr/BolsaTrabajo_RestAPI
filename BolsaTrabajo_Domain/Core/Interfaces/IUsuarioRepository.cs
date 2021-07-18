using BolsaTrabajo_Domain.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BolsaTrabajo_Domain.Infrastructure.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<bool> DeleteUsuario(int id);
        Task<IEnumerable<Usuario>> GetUsuario();
        Task<Usuario> GetUsuarioById(int id);
        Task InsertUsuario(Usuario usuario);
        Task<bool> UpdateUsuario(Usuario usuario);
    }
}