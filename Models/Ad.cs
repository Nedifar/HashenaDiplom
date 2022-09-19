using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Ad
    {
        [Key]
        public int idAd { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }
        public int idDepartament { get; set; }
        public virtual Departament Departament { get; set; }
        public bool isActive
        {
            get
            {
                if (date.AddDays(7) >= DateTime.Now || date >= DateTime.Now.AddDays(7))
                {
                    return true;
                }
                else
                    return false;
            }
        }
    }
}
