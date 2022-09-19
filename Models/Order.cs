using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Order
    {
        [Key]
        public int idOrder { get; set; }
        public int? idEmployee { get; set; }
        public virtual Employee Employee { get; set; }
        public int idService { get; set; }
        public virtual Service Service { get; set; }
        public int idBuyer { get; set; }
        public string status { get; set; }
        public DateTime? dateCreated { get; set; }
        public DateTime? dateClosed { get; set; }
        public double fullPrice { get; set; }
        public double plan { get; set; }
        public virtual Buyer Buyer { get; set; }
        public virtual List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
        public string effective
        {
            get
            {
                if (dateCreated.HasValue && dateClosed.HasValue)
                    return 100*Math.Ceiling((dateClosed.Value.TimeOfDay - dateCreated.Value.TimeOfDay).TotalMinutes)/plan + "%";
                else
                    return "Еще не завершено";
            }
        }
        public string getProductsList
        {
            get
            {
                if (OrderProducts.Count() != 0)
                {
                    string products = "Список изделий: \n";
                    foreach (var prod in OrderProducts)
                    {
                        products += prod.Product.name + "\n ";
                    }
                    return products;
                }
                else
                    return "Только услуга";
            }
        }
    }
}
