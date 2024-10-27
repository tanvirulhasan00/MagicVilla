using MagicVilla.RepositoryConfig.IRepositories.IVillaRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicVilla.RepositoryConfig.IRepositories
{
    public interface IUnitOfWork
    {
        IVillaRepository Villa { get; }
        IVillaNumberRepository VillaNumber { get; }
        Task<int> Save();
    }
}
