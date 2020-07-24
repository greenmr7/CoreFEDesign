using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModels
{
    public class ReserveVM
    {
        public int id_reserve { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public string status { get; set; }
        public int total { get; set; }
        public string tgl_bayar { get; set; }
        public int carID { get; set; }
        public String carName { get; set; }
        public String carTransmition { get; set; }
        public String carYear { get; set; }
        public String carMerk { get; set; }
        public int konsumenID { get; set; }
        public String konsumenName { get; set; }
        public String konsumenAlamat { get; set; }
        public String konsumenPhone { get; set; }
    }
}
