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
    public class OrganizacionRepository : IOrganizacionRepository
    {
        private readonly PostulacionesDBContext _context;

        public OrganizacionRepository(PostulacionesDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Organizacion>> GetOrganizacion()
        {
            return await _context.Organizacion.ToListAsync();
        }

        public async Task<Organizacion> GetOrganizacionById(int id)
        {
            return await _context.Organizacion.Where(x => x.Ruc == id).FirstOrDefaultAsync();
        }

        public async Task InsertOrganizacion(Organizacion organizacion)
        {
            _context.Organizacion.Add(organizacion);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateOrganizacion(Organizacion organizacion)
        {
            var organizacionNow = await _context.Organizacion.Where(x => x.Ruc == organizacion.Ruc).FirstOrDefaultAsync();

            if (organizacionNow == null)
                return false;

            organizacionNow.Ruc = organizacion.Ruc;
            organizacionNow.RazonSocial = organizacion.RazonSocial;
            organizacionNow.Descripcion = organizacion.Descripcion;
            organizacionNow.Direccion = organizacion.Direccion;

            int countRows = await _context.SaveChangesAsync();

            return (countRows > 0);
        }

        public async Task<bool> DeleteOrganizacion(int id)
        {
            var organizacionNow = await _context.Organizacion.Where(x => x.Ruc == id).FirstOrDefaultAsync();

            if (organizacionNow == null)
                return false;

            _context.Organizacion.Remove(organizacionNow);

            int countRows = await _context.SaveChangesAsync();

            return (countRows > 0);
        }
    }
}
