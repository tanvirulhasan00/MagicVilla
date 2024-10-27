using MagicVilla.DatabaseConfig.Data;
using MagicVilla.RepositoryConfig.IRepositories;
using MagicVilla.RepositoryConfig.IRepositories.IVillaRepo;
using MagicVilla.RepositoryConfig.Repositories.VillaRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicVilla.RepositoryConfig.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MagicVillaDbContext _magicVillaDbContext;
        public IVillaRepository Villa { get; private set; }
        public IVillaNumberRepository VillaNumber { get; private set; }
        public UnitOfWork(MagicVillaDbContext magicVillaDbContext)
        {
            _magicVillaDbContext = magicVillaDbContext;
            Villa = new VillaRepository(_magicVillaDbContext);
            VillaNumber = new VillaNumberRepository(_magicVillaDbContext);
        }
        public async Task<int> Save()
        {
            return await _magicVillaDbContext.SaveChangesAsync();
        }
    }
}
