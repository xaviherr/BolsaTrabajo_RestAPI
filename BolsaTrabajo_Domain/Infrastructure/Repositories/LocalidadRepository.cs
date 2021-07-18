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
    public class LocalidadRepository : ILocalidadRepository
    {
        private readonly PostulacionesDBContext _context;

        public LocalidadRepository(PostulacionesDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Localidad>> GetCapacitaciones()
        {
            return await _context.Localidad.ToListAsync();
        }

        public async Task<Localidad> GetLocalidadById(int id)
        {
            return await _context.Localidad.Where(x => x.IdLocalidad == id).FirstOrDefaultAsync();
        }

        public async Task InsertLocalidad(Localidad localidad)
        {
            _context.Localidad.Add(localidad);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateLocalidad(Localidad localidad)
        {
            var localidadNow = await _context.Localidad.Where(x => x.IdLocalidad == localidad.IdLocalidad).FirstOrDefaultAsync();

            if (localidadNow == null)
                return false;

            localidadNow.Nombre = localidad.Nombre;


            int countRows = await _context.SaveChangesAsync();

            return (countRows > 0);
        }

        public async Task<bool> DeleteLocalidad(int id)
        {
            var localidadNow = await _context.Localidad.Where(x => x.IdLocalidad == id).FirstOrDefaultAsync();

            if (localidadNow == null)
                return false;

            _context.Localidad.Remove(localidadNow);

            int countRows = await _context.SaveChangesAsync();

            return (countRows > 0);
        }







    }
}
