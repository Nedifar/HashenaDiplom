using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Product
    {
        [Key]
        public int idProduct { get; set; }
        public string name { get; set; }
        public string photo { get; set; }
        public string enginePower { get; set; }
        public double voltage { get; set; }
        public double frequince { get; set; }
        public string technicalRequirements { get; set; }
        public int idEnergyEfficiency { get; set; }
        public virtual EnergyEfficiency EnergyEfficiency { get; set; }
        public double cost { get; set; }
        public virtual List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
        public string imagePath
        {
            get
            {
                if (photo == "" || photo == null)
                {
                    return $@"{AppDomain.CurrentDomain.BaseDirectory}images\images.jpg";
                }
                else
                    return $@"{AppDomain.CurrentDomain.BaseDirectory}images\{photo}";
            }
        }
    }
}
