using Fulbolchi.Data.DbContexts;
using Fulbolchi.Data.Models;
using Futbolchi1.Services.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futbolchi3.Services.Repository
{
    public class FutbolchiRepository : IFutbolchiRepository

    {
        AppDbContext db;

        public FutbolchiRepository(AppDbContext db)
        {
            this.db = db;
        }

        public async Task AddAsync(Futbolchi futbolchi)
        {
           await db.Futbolchilar.AddAsync(futbolchi);
            await db.SaveChangesAsync();
            
        }

        public async Task DeleteAsync(int id)
        {
            var futbolchi =  await db.Futbolchilar.FirstOrDefaultAsync(f => f.Id == id);
            if (futbolchi != null)
            {
                db.Futbolchilar.Remove(futbolchi);
                await db.SaveChangesAsync();
            }
        }

        public async Task<IList<Futbolchi>> GetAllAsync()
        {
            return await db.Futbolchilar.ToListAsync(); 
        }

        public async Task UpdateAsync(int id, Futbolchi newFutbolchi)
        {
            var oldFutbolchi = await db.Futbolchilar.FirstOrDefaultAsync(f => f.Id == id);
            newFutbolchi.Id= id;
            db.Futbolchilar.Attach(oldFutbolchi).CurrentValues.SetValues(newFutbolchi);
            await db.SaveChangesAsync();
        }
    }
}
