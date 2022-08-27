using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace zzMedya.Models
{
    public class CustomerModel
    { 
        //Fields
        private int id;
        private string name;
        private string adress;
        private string counselor;

        //Proporties - Validations
        [DisplayName("Customer ID")]
        public int Id { get => id; set => id = value; }
        [DisplayName("Customer Name")]
        [Required(ErrorMessage ="Name is required")]
        [StringLength(50, MinimumLength =3, ErrorMessage ="Name must be between 3 and 50 characters")]
        public string Name { get => name; set => name = value; }
        [DisplayName("Customer Adress")]
        [Required(ErrorMessage = "Adress is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Adress must be between 3 and 50 characters")]
        public string Adress { get => adress; set => adress = value; }
        [DisplayName("Customer Counselor")]
        [Required(ErrorMessage = "Counselor is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Counselor must be between 3 and 50 characters")]
        public string Counselor { get => counselor; set => counselor = value; }
    }
}
