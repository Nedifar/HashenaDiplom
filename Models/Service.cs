using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Service
    {
        [Key]
        public int idService { get; set; }
        public string name { get; set; }
        public int idDepartament { get; set; }
        public virtual Departament Departament { get; set; }
        public double Cost { get; set; }
        public virtual List<Order> Orders { get; set; } = new List<Order>();
    }
}
