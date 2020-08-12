using Cliente.Domain.Infra.Contexts;
using Cliente.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Domain.Infra.Repositories
{
    public class ClienteRepository : IClientRepository
    {
        private readonly ClienteDataContext _context;

        public ClienteRepository(ClienteDataContext context)
        {
            _context = context;
        }

        public async Task Create(Entities.Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Entities.Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Entities.Cliente>> Get()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Entities.Cliente> Get(Guid id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task Update(Entities.Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
