using BolsaTrabajo_Domain.Core.Entities;
using BolsaTrabajo_Domain.Core.Interfaces;
using BolsaTrabajo_Domain.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaTrabajo_Domain.Infrastructure.Repositories
{
    public class ReclutadorRepository : IReclutadorRepository
    {
        private readonly PostulacionesDBContext _context;

        public ReclutadorRepository(PostulacionesDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reclutador>> GetReclutador()
        {
            return await _context.Reclutador.ToListAsync();
        }

        public async Task<Reclutador> GetReclutadorById(int id)
        {
            return await _context.Reclutador.Where(x => x.Dni == id).FirstOrDefaultAsync();
        }

        public async Task InsertReclutador(Reclutador reclutador)
        {
            _context.Reclutador.Add(reclutador);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateReclutador(Reclutador reclutador)
        {
            var reclutadorNow = await _context.Reclutador.Where(x => x.Dni == reclutador.Dni).FirstOrDefaultAsync();

            if (reclutadorNow == null)
                return false;

            reclutadorNow.Dni = reclutador.Dni;
            reclutadorNow.Ruc = reclutador.Ruc;
            reclutadorNow.Nombre = reclutador.Nombre;
            reclutadorNow.Correo = reclutador.Correo;

            int countRows = await _context.SaveChangesAsync();

            return (countRows > 0);
        }

        public async Task<bool> DeleteReclutador(int id)
        {
            var reclutadorNow = await _context.Reclutador.Where(x => x.Dni == id).FirstOrDefaultAsync();

            if (reclutadorNow == null)
                return false;

            _context.Reclutador.Remove(reclutadorNow);

            int countRows = await _context.SaveChangesAsync();

            return (countRows > 0);
        }
    }
}
