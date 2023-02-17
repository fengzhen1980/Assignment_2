using SmallShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Xml;
using System.Xml.Linq;

namespace SmallShopUI
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        HttpClient client = new HttpClient();

        public Admin()
        {
            client.BaseAddress = new Uri("https://localhost:7036/api/SmallShop/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );

            InitializeComponent();

            GetProductData();
            ProductIdTextBox.Clear();
            ProductNameTextBox.Clear();
            AmountTextBox.Clear();
            PriceTextBox.Clear();
        }

        private async void GetProductData()
        {
            Response response =  client.GetFromJsonAsync<Response>("GetAllProduct/").Result;

            //Response res = JsonConvert.DeserializeObject<Response>(response.ToString());
            //this.ServerStatus.Content = response..ToString();
            List<Product> listProduct = response.listProduct;

            DataTable dt = new DataTable();
            dt.Columns.Add("ProductId", typeof(int));
            dt.Columns.Add("ProductName", typeof(string));
            dt.Columns.Add("Amount", typeof(int));
            dt.Columns.Add("Price", typeof(double));

            for (int i = 0; i < listProduct.Count; i++)
            {
                DataRow row = dt.NewRow();
                row["ProductId"] = listProduct[i].ProductId;
                row["ProductName"] = listProduct[i].ProductName;
                row["Amount"] = listProduct[i].Amount;
                row["Price"] = listProduct[i].Price;
                dt.Rows.Add(row);
            }

            this.productView.ItemsSource = dt.DefaultView;
        }

        private void View_date_Click(object sender, RoutedEventArgs e)
        {
            GetProductData();
            ProductIdTextBox.Clear();
            ProductNameTextBox.Clear();
            AmountTextBox.Clear();
            PriceTextBox.Clear();
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            saveProduct();
            ProductIdTextBox.Clear();
            ProductNameTextBox.Clear();
            AmountTextBox.Clear();
            PriceTextBox.Clear();
        }

        private async void saveProduct()
        {
            Product product = new Product();
            product.ProductId = int.Parse(ProductIdTextBox.Text);
            product.ProductName = ProductNameTextBox.Text;
            product.Amount = int.Parse(AmountTextBox.Text);
            product.Price = float.Parse(PriceTextBox.Text);

            HttpResponseMessage response = await client.PostAsJsonAsync<Product>("AddProduct/", product);

            if(response.StatusCode.ToString().Equals("OK"))
            {
                MessageBox.Show("Inserted perfectly to the Database");
            }
            else
            {
                MessageBox.Show("Insert Fail!");
            }
            
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            updateProduct();
            ProductIdTextBox.Clear();
            ProductNameTextBox.Clear();
            AmountTextBox.Clear();
            PriceTextBox.Clear();
        }

        private async void updateProduct()
        {
            Product product = new Product();
            product.ProductId = int.Parse(ProductIdTextBox.Text);
            product.ProductName = ProductNameTextBox.Text;
            product.Amount = int.Parse(AmountTextBox.Text);
            product.Price = float.Parse(PriceTextBox.Text);

            HttpResponseMessage response = await client.PutAsJsonAsync<Product>("UpdateProduct/", product);

            if (response.StatusCode.ToString().Equals("OK"))
            {
                MessageBox.Show("Update Successfully");
            }
            else
            {
                MessageBox.Show("Update Fail!");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            deleteProduct();
            ProductIdTextBox.Clear();
            ProductNameTextBox.Clear();
            AmountTextBox.Clear();
            PriceTextBox.Clear();
        }

        private async void deleteProduct()
        {
            Product product = new Product();
            product.ProductId = int.Parse(ProductIdTextBox.Text);

            HttpResponseMessage response = await client.DeleteAsync("DeleteProduct/" + product.ProductId);

            if (response.StatusCode.ToString().Equals("OK"))
            {
                MessageBox.Show("Delete Successfully");
            }
            else
            {
                MessageBox.Show("Delete Fail!");
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            GetProductById();
        }

        private async void GetProductById()
        {
            string productId = ProductIdTextBox.Text;

            Response response = client.GetFromJsonAsync<Response>("GetProductByID/" + productId).Result;

            Product product = response.product;

            if(product != null)
            {
                ProductNameTextBox.Text = product.ProductName;
                AmountTextBox.Text = product.Amount.ToString();
                PriceTextBox.Text = product.Price.ToString();
            }

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MainWin = new MainWindow();
            this.Close();
            MainWin.Show();
        }
    }
}
