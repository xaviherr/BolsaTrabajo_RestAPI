using BolsaTrabajo_Domain.Core.Entities;
using BolsaTrabajo_Domain.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaTrabajo_Domain.Infrastructure.Repositories
{
    public class CapacitacionRepository : ICapacitacionRepository
    {
        private readonly PostulacionesDBContext _context;

        public CapacitacionRepository(PostulacionesDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Capacitacion>> GetCapacitaciones()
        {
            return await _context.Capacitacion.ToListAsync();
        }

        public async Task<Capacitacion> GetCapacitacionById(int id)
        {
            return await _context.Capacitacion.Where(x => x.IdCapacitacion == id).FirstOrDefaultAsync();
        }

        public async Task InsertCapacitacion(Capacitacion capacitacion)
        {
            _context.Capacitacion.Add(capacitacion);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateCapacitacion(Capacitacion capacitacion)
        {
            var capacitacionNow = await _context.Capacitacion.Where(x => x.IdCapacitacion == capacitacion.IdCapacitacion).FirstOrDefaultAsync();

            if (capacitacionNow == null)
                return false;

            capacitacionNow.Descripcion = capacitacion.Descripcion;
            capacitacionNow.FechaFin = capacitacion.FechaFin;
            capacitacionNow.FechaInicio = capacitacion.FechaInicio;

            int countRows = await _context.SaveChangesAsync();

            return (countRows > 0);
        }

        public async Task<bool> DeleteCapacitacion(int id)
        {
            var capacitacionNow = await _context.Capacitacion.Where(x => x.IdCapacitacion == id).FirstOrDefaultAsync();

            if (capacitacionNow == null)
                return false;

            _context.Capacitacion.Remove(capacitacionNow);

            int countRows = await _context.SaveChangesAsync();

            return (countRows > 0);
        }

    }
}
