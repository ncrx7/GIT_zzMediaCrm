using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zzMedya.Views
{
    public interface ICustomerView
    {
       //Fields- Proporties
       string CustomerId { get; set; }
       string CustomerName { get; set; }
       string CustomerAdress { get; set; }
       string CustomerCounselor { get; set; }

       string SearchValue { get; set; }
       bool isEdit { get; set; }
       bool isSuccesful { get; set; }
       string Message { get; set; }

        //Events
        event EventHandler SearchEvent;
        event EventHandler AddNewElement;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;

        //Methods
        void SetCustomerListBindingSource(BindingSource customerList);
        void Show();//optional

    }
}
