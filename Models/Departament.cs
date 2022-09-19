using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Departament
    {
        [Key]
        public int idDepartament { get; set; }
        public string name { get; set; }
        public virtual List<Employee> Employees { get; set; } = new List<Employee>();
        public virtual List<Service> Services { get; set; } = new List<Service>();
        public virtual List<Ad> Ads { get; set; } = new List<Ad>();
    }
}
