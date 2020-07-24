using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Tbl_Car")]
    public class Car
    {
        [Key]
        public int id_car { get; set; }
        public string nm_car { get; set; }
        public string transmition { get; set; }
        public int year { get; set; }
        public Merk merk { get; set; }
    }
}
