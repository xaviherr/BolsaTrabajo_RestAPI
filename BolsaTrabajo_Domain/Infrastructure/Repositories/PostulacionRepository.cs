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
    public class PostulacionRepository : IPostulacionRepository
    {
        private readonly PostulacionesDBContext _context;

        public PostulacionRepository(PostulacionesDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Postulacion>> GetPostulacion()
        {
            return await _context.Postulacion.ToListAsync();
        }

        public async Task<Postulacion> GetPostulacionById(int id)
        {
            return await _context.Postulacion.Where(x => x.IdPostulacion == id).FirstOrDefaultAsync();
        }

        public async Task InsertPostulacion(Postulacion postulacion)
        {
            _context.Postulacion.Add(postulacion);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePostulacion(Postulacion postulacion)
        {
            var postulacionNow = await _context.Postulacion.Where(x => x.IdPostulacion == postulacion.IdPostulacion).FirstOrDefaultAsync();

            if (postulacionNow == null)
                return false;

            postulacionNow.Dni = postulacion.Dni;
            postulacionNow.Fecha = postulacion.Fecha;

            int countRows = await _context.SaveChangesAsync();

            return (countRows > 0);
        }

        public async Task<bool> DeletePostulacion(int id)
        {
            var postulacionNow = await _context.Postulacion.Where(x => x.IdPostulacion == id).FirstOrDefaultAsync();

            if (postulacionNow == null)
                return false;

            _context.Postulacion.Remove(postulacionNow);

            int countRows = await _context.SaveChangesAsync();

            return (countRows > 0);
        }

    }
}
