using Fulbolchi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futbolchi1.Services.IRepository
{
    public interface IFutbolchiRepository
    {
        public Task AddAsync(Futbolchi futbolchi);

        public Task<IList<Futbolchi>> GetAllAsync();

        public Task UpdateAsync(int id, Futbolchi futbolchi);

        public Task DeleteAsync(int id);


        
    }
}
