using BolsaTrabajo_Domain.Infrastructure.Data;
using BolsaTrabajo_Domain.Infrastructure.Interfaces;
using BolsaTrabajo_Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaTrabajo_Domain.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly PostulacionesDBContext _context;

        public UsuarioRepository(PostulacionesDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetUsuario()
        {
            return await _context.Usuario.ToListAsync();
        }

        public async Task<Usuario> GetUsuarioById(int id)
        {
            return await _context.Usuario.Where(x => x.IdUsuario == id).FirstOrDefaultAsync();
        }

        public async Task InsertUsuario(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateUsuario(Usuario usuario)
        {
            var usuarioNow = await _context.Usuario.Where(x => x.IdUsuario == usuario.IdUsuario).FirstOrDefaultAsync();

            if (usuarioNow == null)
                return false;

            usuarioNow.Correo = usuario.Correo;
            usuarioNow.Password = usuario.Password;


            int countRows = await _context.SaveChangesAsync();

            return (countRows > 0);
        }

        public async Task<bool> DeleteUsuario(int id)
        {
            var usuarioNow = await _context.Usuario.Where(x => x.IdUsuario == id).FirstOrDefaultAsync();

            if (usuarioNow == null)
                return false;

            _context.Usuario.Remove(usuarioNow);

            int countRows = await _context.SaveChangesAsync();

            return (countRows > 0);
        }
    }

}
