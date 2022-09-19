using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Employee
    {
        [Key]
        public int idEmployee { get; set; }
        public string operationCode { get; set; }
        public int idDepartament { get; set; }
        public virtual Departament Departament { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string midlleName { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public virtual List<Order> Orders { get; set; } = new List<Order>();
        public virtual List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
        public string fullName
        {
            get
            {
                return lastName + " " + firstName + " " + midlleName;
            }
        }
        public string getProductsList
        {
            get
            {
                if (Orders.Count() != 0)
                {
                    return Orders.Count() + " заказов";
                }
                else
                    return "Нет заказов";
            }
        }
    }
}
