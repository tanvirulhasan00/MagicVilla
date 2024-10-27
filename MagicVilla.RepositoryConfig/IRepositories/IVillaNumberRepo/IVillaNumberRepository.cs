using MagicVilla.Models.VillaDbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicVilla.RepositoryConfig.IRepositories.IVillaRepo
{
    public interface IVillaNumberRepository : IRepository<VillaNumber>
    {
        void Update(VillaNumber villaNumbers);
        void UpdateRange(List<VillaNumber> villaNumbers);
    }
}
