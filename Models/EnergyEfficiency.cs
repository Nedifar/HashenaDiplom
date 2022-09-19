using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class EnergyEfficiency
    {
        [Key]
        public int idEnergyEfficiency { get; set; }
        public string name { get; set; }
        public virtual List<Product> Products { get; set; } = new List<Product>();
    }
}
