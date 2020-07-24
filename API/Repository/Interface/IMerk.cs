using API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Interface
{
    public interface IMerk
    {
        Task<IEnumerable<MerkVM>> getAll();
        MerkVM getID(int id);
        int Create(MerkVM merkVM);
        int Update(MerkVM merkVM, int id);
        int Delete(int id);
    }
}
