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
    public class PostulanteRepository : IPostulanteRepository
    {
        private readonly PostulacionesDBContext _context;

        public PostulanteRepository(PostulacionesDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Postulante>> GetPostulante()
        {
            return await _context.Postulante.ToListAsync();
        }

        public async Task<Postulante> GetPostulanteById(int id)
        {
            return await _context.Postulante.Where(x => x.Dni == id).FirstOrDefaultAsync();
        }

        public async Task InsertPostulante(Postulante postulante)
        {
            _context.Postulante.Add(postulante);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatPostulante(Postulante postulante)
        {
            var postulanteNow = await _context.Postulante.Where(x => x.Dni == postulante.Dni).FirstOrDefaultAsync();

            if (postulanteNow == null)
                return false;

            postulanteNow.Dni = postulante.Dni;
            postulanteNow.Nombres = postulante.Nombres;
            postulanteNow.Apellidos = postulante.Apellidos;
            postulanteNow.FechaNac = postulante.FechaNac;

            int countRows = await _context.SaveChangesAsync();

            return (countRows > 0);
        }

        public async Task<bool> DeletePostulante(int id)
        {
            var postulanteNow = await _context.Postulante.Where(x => x.Dni == id).FirstOrDefaultAsync();

            if (postulanteNow == null)
                return false;

            _context.Postulante.Remove(postulanteNow);

            int countRows = await _context.SaveChangesAsync();

            return (countRows > 0);
        }

    }
}
