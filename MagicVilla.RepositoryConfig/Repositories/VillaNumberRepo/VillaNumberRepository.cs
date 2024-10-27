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
    public class VillaNumberRepository : Repository<VillaNumber>, IVillaNumberRepository
    {
        private readonly MagicVillaDbContext _magicVillaDbContext;
        public VillaNumberRepository(MagicVillaDbContext magicVillaDbContext) : base(magicVillaDbContext)
        {
            _magicVillaDbContext = magicVillaDbContext;
        }

        public void Update(VillaNumber villaNumbers)
        {
            _magicVillaDbContext.Update(villaNumbers);
        }

        public void UpdateRange(List<VillaNumber> villaNumbers)
        {
            _magicVillaDbContext.UpdateRange(villaNumbers);
        }
    }
}
