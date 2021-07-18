using BolsaTrabajo_Domain.Core.Entities;
using BolsaTrabajo_Domain.Infrastructure.Data;
using BolsaTrabajo_Domain.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaTrabajo_Domain.Infrastructure.Repositories
{
    public class ReferenciaLaboralRepository : IReferenciaLaboralRepository
    {
        private readonly PostulacionesDBContext _context;

        public ReferenciaLaboralRepository(PostulacionesDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReferenciaLaboral>> GetReferenciaLaboral()
        {
            return await _context.ReferenciaLaboral.ToListAsync();
        }

        public async Task<ReferenciaLaboral> GetReferenciaLaboralById(int id)
        {
            return await _context.ReferenciaLaboral.Where(x => x.IdReferencia == id).FirstOrDefaultAsync();
        }

        public async Task InsertReferenciaLaboral(ReferenciaLaboral referencia)
        {
            _context.ReferenciaLaboral.Add(referencia);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateReferenciaLaboral(ReferenciaLaboral referencia)
        {
            var referenciaNow = await _context.ReferenciaLaboral.Where(x => x.IdReferencia == referencia.IdReferencia).FirstOrDefaultAsync();

            if (referenciaNow == null)
                return false;

            referenciaNow.Nombre = referencia.Nombre;
            referenciaNow.Organizacion = referencia.Organizacion;
            referenciaNow.Puesto = referencia.Puesto;
            referenciaNow.Correo = referencia.Correo;
            referenciaNow.Celular = referencia.Celular;

            int countRows = await _context.SaveChangesAsync();

            return (countRows > 0);
        }

        public async Task<bool> DeleteReferenciaLaboral(int id)
        {
            var referenciaNow = await _context.ReferenciaLaboral.Where(x => x.IdReferencia == id).FirstOrDefaultAsync();

            if (referenciaNow == null)
                return false;

            _context.ReferenciaLaboral.Remove(referenciaNow);

            int countRows = await _context.SaveChangesAsync();

            return (countRows > 0);
        }
    }
}