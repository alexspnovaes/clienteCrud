
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cliente.Domain.Repositories
{
    public interface IClientRepository
    {
        Task Create(Entities.Cliente cliente);
        Task Update(Entities.Cliente cliente);
        Task Delete(Entities.Cliente cliente);
        Task<List<Entities.Cliente>> Get();
        Task<Entities.Cliente> Get(Guid id);
    }
}
