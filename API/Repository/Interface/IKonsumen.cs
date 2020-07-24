using API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Interface
{
    public interface IKonsumen
    {
        Task<IEnumerable<KonsumenVM>> getAll();
        KonsumenVM getID(int id);
        int Create(KonsumenVM konsumenVM);
        int Update(KonsumenVM konsumenVM, int id);
        int Delete(int id);
    }
}
