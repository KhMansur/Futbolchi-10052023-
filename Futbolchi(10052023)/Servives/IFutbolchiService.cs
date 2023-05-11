using Fulbolchi.Data.Models;
using Futbolchi_10052023_.DTOs;

namespace Futbolchi_10052023_.Servives
{
    public interface IFutbolchiService
    {

        public Task AddAsync(AddFutbolchiDTO futbolchiDTO);

        public Task<IList<Futbolchi>> GetAllAsync();

        public Task UpdateAsync(int id, AddFutbolchiDTO futbolchiDTO);

        public Task DeleteAsync(int id);
    }
}
