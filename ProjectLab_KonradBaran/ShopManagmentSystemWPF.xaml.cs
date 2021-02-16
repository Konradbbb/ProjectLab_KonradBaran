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
    }
}
