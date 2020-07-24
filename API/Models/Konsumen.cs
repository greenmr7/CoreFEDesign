using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Tbl_Konsumen")]
    public class Konsumen
    {
        [Key]
        public int id_konsumen { get; set; }
        public string nama { get; set; }
        public string alamat { get; set; }
        public string tlp { get; set; }
    }
}
