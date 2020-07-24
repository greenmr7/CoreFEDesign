using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Tbl_Reserve")]
    public class Reserve
    {
        [Key]
        public int id_reserve { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public string status { get; set; }
        public int total { get; set; }
        public DateTime tgl_bayar { get; set; }
        public Car car { get; set; }
        public Konsumen konsumen { get; set; }
    }
}
