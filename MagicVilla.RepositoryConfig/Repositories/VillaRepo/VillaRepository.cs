using MagicVilla.DatabaseConfig.Data;
using MagicVilla.Models.VillaDbModels;
using MagicVilla.RepositoryConfig.IRepositories;
using MagicVilla.RepositoryConfig.IRepositories.IVillaRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicVilla.RepositoryConfig.Repositories.VillaRepo
{
    public class VillaRepository : Repository<Villa>, IVillaRepository
    {
        private readonly MagicVillaDbContext _magicVillaDbContext;
        public VillaRepository(MagicVillaDbContext magicVillaDbContext) : base(magicVillaDbContext)
        {
            _magicVillaDbContext = magicVillaDbContext;
        }

        public void Update(Villa villa)
        {
            _magicVillaDbContext.Update(villa);
        }

        public void UpdateRange(List<Villa> villas)
        {
            _magicVillaDbContext.UpdateRange(villas);
        }
    }
}
