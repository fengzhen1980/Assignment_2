using SmallShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SmallShopUI
{
    /// <summary>
    /// Interaction logic for Sales.xaml
    /// </summary>
    public partial class Sales : Window
    {
        HttpClient client = new HttpClient();

        public string[] productNames { get; set; }
        public double totalAll { get; set; }
        public List<Product> productList = new List<Product>();

        public Sales()
        {
            client.BaseAddress = new Uri("https://localhost:7036/api/SmallShop/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );

            InitializeComponent();

            GetProductNames();
            DataContext = this;
        }

        private async void GetProductNames()
        {
            Response response = client.GetFromJsonAsync<Response>("GetAllProduct/").Result;

            //Response res = JsonConvert.DeserializeObject<Response>(response.ToString());
            //this.ServerStatus.Content = response..ToString();
            List<Product> listProduct = response.listProduct;

            productNames = new string[listProduct.Count];
            for (int i = 0; i < listProduct.Count; i++)
            {
                productNames[i] = listProduct[i].ProductName;
            }

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MainWin = new MainWindow();
            this.Close();
            MainWin.Show();
        }

        private void CheckOut_Click(object sender, RoutedEventArgs e)
        {
            CheckoutProduct();
        }

        private async void CheckoutProduct()
        {
            HttpResponseMessage response = await client.PutAsJsonAsync<List<Product>>("CheckoutProduct/", productList);

            productList.Clear();
            totalAll = 0;

            MessageBox.Show(this.BillTextBox.Text);
            this.BillTextBox.Clear();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            GetProductByName();
        }

        private async void GetProductByName()
        {
            if (this.productComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select product.");
                return;
            }
            if (this.AmountTextBox.Text.Length == 0)
            {
                MessageBox.Show("Please input amont.");
                return;
            }

            string productName = (string)productComboBox.SelectedItem;
            int amount = Convert.ToInt32(this.AmountTextBox.Text);

            // get total amount that is costumer asked
            int totalAmount = amount;
            for(int i = 0; i < productList.Count; i++)
            {
                if (productList[i].ProductName.Equals(productName))
                {
                    totalAmount = totalAmount + productList[i].Amount;
                }
            }

            // get product information
            Response response = client.GetFromJsonAsync<Response>("GetProductByName/" + productName).Result;

            Product product = response.product;

            int amountInventory = product.Amount;
            double price = product.Price;

            // check that sales must be less than inventory
            if (totalAmount > amountInventory)
            {
                MessageBox.Show("Stock is out, please re-enter amount.");
                return;
            }

            product.Amount = amount;

            productList.Add(product);

            // display bill
            double total = 0;
            total = amount * price;
            if (this.BillTextBox.Text.Length == 0)
            {
                this.BillTextBox.Text = productName.PadRight(18, ' ') + amount.ToString().PadRight(10, ' ') + "$" + total.ToString() + "\n";
                totalAll = totalAll + total;
                this.BillTextBox.Text = this.BillTextBox.Text + "total price: " + totalAll;
            }
            else
            {
                string tempStr = this.BillTextBox.Text;

                tempStr = tempStr.Substring(0, tempStr.Length - (tempStr.Length - tempStr.LastIndexOf("\n")));
                tempStr = tempStr + "\n";
                tempStr = tempStr + productName.PadRight(18, ' ') + amount.ToString().PadRight(10, ' ') + "$" + total.ToString() + "\n";
                totalAll = totalAll + total;

                this.BillTextBox.Text = tempStr + "total price: " + totalAll;

            }
            this.productComboBox.SelectedIndex = -1;
            this.AmountTextBox.Text = "";
        }
    }
}
