using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zzMedya.Shared;
using System.Net.Http;

namespace zzMedya.Views
{
    public partial class CustomerView : Form
    {
        public CustomerView()
        {
            InitializeComponent();
        }
        
        private async void btnGetAll_Click(object sender, EventArgs e)
        {
            var responce = await RestHelper.GetALL();
            txtResponce.Text = RestHelper.BeautifyJson(responce);
        }

        private async void btnPost_Click(object sender, EventArgs e)
        {
            var responce = await RestHelper.Post(txtId.Text, txtName.Text, txtJob.Text);
            txtResponce.Text = RestHelper.BeautifyJson(responce);
        }

        private async void btnGet_Click(object sender, EventArgs e)
        {
            var responce = await RestHelper.Get(txtId.Text);
            txtResponce.Text = RestHelper.BeautifyJson(responce);
        }

        private async void btnPut_Click(object sender, EventArgs e)
        {
            var responce = await RestHelper.PUT(txtId.Text, txtName.Text, txtJob.Text);
            txtResponce.Text = RestHelper.BeautifyJson(responce);
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var responce = await Delete(txtId.Text);
            txtResponce.Text = responce;
        }

        private async Task<string> Delete(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.DeleteAsync("https://reqres.in/api/users/" + id))
                {
                    using (HttpContent content = res.Content)
                    {
                        MessageBox.Show(((int)res.StatusCode).ToString() + "-" + res.StatusCode.ToString());
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;
                        }
                    }
                }
            }
            return string.Empty;
        }
    }
}
