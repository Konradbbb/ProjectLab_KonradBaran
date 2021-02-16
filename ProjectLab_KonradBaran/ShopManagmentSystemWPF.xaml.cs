using System;
using System.Collections.Generic;
using System.Linq;
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

namespace ProjectLab_KonradBaran
{
    /// <summary>
    /// Logika interakcji dla klasy ShopManagmentSystemWPF.xaml
    /// </summary>
    public partial class ShopManagmentSystemWPF : Window
    {
        private int updateOrderId = 0;
        public ShopManagmentSystemWPF()
        {
            InitializeComponent();

            ShopMenegmentDBEntities _db = new ShopMenegmentDBEntities();

            var orders = from o in _db.Orders
                         select o;
                        


            foreach (var item in orders)
            {
                Console.WriteLine(item.CustomerName);
                Console.WriteLine(item.CustomerSurname);
                Console.WriteLine(item.Product);
            }

            this.gridOfOrders.ItemsSource = orders.ToList();
        }

        private void insertOrdBtn_Click(object sender, RoutedEventArgs e)
        {
            ShopMenegmentDBEntities _db = new ShopMenegmentDBEntities();

            Order newOrder = new Order()
            {
                CustomerName = txtName.Text,
                CustomerSurname = txtSurname.Text,
                Product = txtProduct.Text
            };

            _db.Orders.Add(newOrder);
            _db.SaveChanges();
        }

        private void reloadDataBtn_Click(object sender, RoutedEventArgs e)
        {
            ShopMenegmentDBEntities _db = new ShopMenegmentDBEntities();

            this.gridOfOrders.ItemsSource = _db.Orders.ToList();
        }

        
        private void gridOfOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(this.gridOfOrders.SelectedIndex >= 0)
            {
                if (this.gridOfOrders.SelectedItems.Count >= 0)
                {
                    if (this.gridOfOrders.SelectedItems[0].GetType() == typeof(Order))
                    {
                        Order newOrder = (Order)this.gridOfOrders.SelectedItems[0];
                        this.txtNameUpdate.Text = newOrder.CustomerName;
                        this.txtSurnameUpdate.Text = newOrder.CustomerSurname;
                        this.txtProductUpdate.Text = newOrder.Product;

                        this.updateOrderId = newOrder.Id;
                    }
                }
            }
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            ShopMenegmentDBEntities _db = new ShopMenegmentDBEntities();

            var r = from o in _db.Orders
                    where o.Id == this.updateOrderId
                    select o;

            Order order = r.SingleOrDefault();

           if(order != null)
            {
                order.CustomerName = this.txtNameUpdate.Text;
                order.CustomerSurname = this.txtSurnameUpdate.Text;
                order.Product = this.txtProductUpdate.Text;

                
            }
            _db.SaveChanges();

        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult msgBoxResult = MessageBox.Show("Do you want to delete order?", 
                "Order has been deleted", 
                MessageBoxButton.YesNo, 
                MessageBoxImage.Warning, 
                MessageBoxResult.No);

            if (msgBoxResult == MessageBoxResult.Yes)
            {

                ShopMenegmentDBEntities _db = new ShopMenegmentDBEntities();

                var r = from o in _db.Orders
                        where o.Id == this.updateOrderId
                        select o;

                Order order = r.SingleOrDefault();

                if (order != null)
                {
                    _db.Orders.Remove(order);
                    _db.SaveChanges();
                }
            }
            
        }
    }
}
