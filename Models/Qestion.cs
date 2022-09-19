using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Qestion
    {
        [Key]
        public int idQestion { get; set; }
        public int idBuyer { get; set; }
        public virtual Buyer Buyer { get; set; }
        public string main { get; set; }
        public string message { get; set; }
        public string request { get; set; }
        public string status { get; set; }
    }
}
