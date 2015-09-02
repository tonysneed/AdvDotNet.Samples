using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IOAsync.Entities;

namespace IOAsync.Client
{
    public partial class MainForm : Form
    {
        private readonly Uri _baseAddress = new Uri("http://localhost:57986/api/");

        public MainForm()
        {
            InitializeComponent();
        }

        private void categoriesButton_Click(object sender, EventArgs e)
        {
            // Get categories from web api service (non-responsive)
            var client = new HttpClient {BaseAddress = _baseAddress};
            string url = "category";
            HttpResponseMessage response = client.GetAsync(url).Result;

            // Check for response error
            if (!response.IsSuccessStatusCode)
            {
                var message = string.Format("Error requesting categories: {0}",
                    response.StatusCode);
                MessageBox.Show(message, "Request Error");
                return;
            }

            // Get content and bind to drop down (non-responsive)
            var categores = response.Content.ReadAsAsync<List<Category>>().Result;
            categoryBindingSource.DataSource = categores;
        }

        private void productsButton_Click(object sender, EventArgs e)
        {
            // Get selected category
            var category = categoryBindingSource.Current as Category;
            if (category == null) return;

            // Get products for this category from web api service (non-responsive)
            var client = new HttpClient { BaseAddress = _baseAddress };
            string url = "product?categoryid=" + category.CategoryId;
            HttpResponseMessage response = client.GetAsync(url).Result;

            // Check for response error
            if (!response.IsSuccessStatusCode)
            {
                var message = string.Format("Error requesting categories: {0}",
                    response.StatusCode);
                MessageBox.Show(message, "Request Error");
                return;
            }

            // Get content and bind to grid (non-responsive)
            var products = response.Content.ReadAsAsync<List<Product>>().Result;
            productBindingSource.DataSource = products;
        }
    }
}
