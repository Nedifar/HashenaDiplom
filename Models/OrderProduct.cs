using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class OrderProduct
    {
        [Key]
        public int idOrderProduct { get; set; }
        public int idOrder { get; set; }
        public virtual Order Order { get; set; }
        public int idProduct { get; set; }
        public virtual Product Product { get; set; }
    }
}
