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
    public class OfertaRepository : IOfertaRepository
    {
        private readonly PostulacionesDBContext _context;

        public OfertaRepository(PostulacionesDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Oferta>> GetOferta()
        {
            return await _context.Oferta.ToListAsync();
        }

        public async Task<Oferta> GetOfertaById(int id)
        {
            return await _context.Oferta.Where(x => x.IdOferta == id).FirstOrDefaultAsync();
        }

        public async Task InsertOferta(Oferta oferta)
        {
            _context.Oferta.Add(oferta);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateOferta(Oferta oferta)
        {
            var ofertaNow = await _context.Oferta.Where(x => x.IdOferta == oferta.IdOferta).FirstOrDefaultAsync();

            if (ofertaNow == null)
                return false;

            ofertaNow.Dni = oferta.Dni;
            ofertaNow.Titulo = oferta.Titulo;
            ofertaNow.Descripcion = oferta.Descripcion;
            ofertaNow.Salario = oferta.Salario;

            int countRows = await _context.SaveChangesAsync();

            return (countRows > 0);
        }

        public async Task<bool> DeleteOferta(int id)
        {
            var ofertaNow = await _context.Oferta.Where(x => x.IdOferta == id).FirstOrDefaultAsync();

            if (ofertaNow == null)
                return false;

            _context.Oferta.Remove(ofertaNow);

            int countRows = await _context.SaveChangesAsync();

            return (countRows > 0);
        }



    }
}
