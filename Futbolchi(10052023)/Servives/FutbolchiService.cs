using AutoMapper;
using Fulbolchi.Data.Models;
using Futbolchi_10052023_.DTOs;
using Futbolchi1.Services.IRepository;

namespace Futbolchi_10052023_.Servives
{
    public class FutbolchiService : IFutbolchiService
    {
        IFutbolchiRepository repository;
        IMapper mapper;

        public FutbolchiService(IFutbolchiRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task AddAsync(AddFutbolchiDTO futbolchiDTO)
        {
            var futbolchi = mapper.Map<Futbolchi>(futbolchiDTO);

            await repository.AddAsync(futbolchi);
        }

        public async Task DeleteAsync(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<IList<Futbolchi>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task UpdateAsync(int id, AddFutbolchiDTO futbolchiDTO)
        {
            var futbolchi = mapper.Map<Futbolchi>(futbolchiDTO);
            await repository.UpdateAsync(id, futbolchi);
        }
    }
}
