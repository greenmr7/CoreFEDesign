using API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Interface
{
    public interface ICar
    {
        Task<IEnumerable<CarVM>> getAll();
        CarVM getID(int id);
        int Create(CarVM carVM);
        int Update(CarVM carVM, int id);
        int Delete(int id);
    }
}
