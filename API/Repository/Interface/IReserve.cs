using API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Interface
{
    public interface IReserve
    {
        Task<IEnumerable<ReserveVM>> getAll();
        ReserveVM getID(int id);
        int Create(ReserveVM reserveVM);
        int Update(ReserveVM reserveVM, int id);
        int Delete(int id);
    }
}
