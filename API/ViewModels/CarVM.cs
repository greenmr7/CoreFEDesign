using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModels
{
    public class CarVM
    {
        public int id_car { get; set; }
        public string nm_car { get; set; }
        public string transmition { get; set; }
        public int year { get; set; }
        public int merkID { get; set; }
        public string merkName { get; set; }
    }
}
