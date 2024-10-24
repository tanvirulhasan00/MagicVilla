using MagicVilla.Models.VillaDbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicVilla.RepositoryConfig.IRepositories.IVillaRepo
{
    public interface IVillaRepository : IRepository<Villa>
    {
        void Update(Villa villa);
        void UpdateRange(List<Villa> villas);
    }
}
