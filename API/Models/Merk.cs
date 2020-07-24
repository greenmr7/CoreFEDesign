using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Tbl_Merk")]
    public class Merk
    {
        [Key]
        public int id_merk { get; set; }
        public string merk { get; set; }
    }
}
