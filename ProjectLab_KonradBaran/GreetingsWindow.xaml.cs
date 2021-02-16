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
    /// Logika interakcji dla klasy GreetingsWindow.xaml
    /// </summary>
    public partial class GreetingsWindow : Window
    {

        ShopMenegmentDBEntities _db = new ShopMenegmentDBEntities();
        public GreetingsWindow()
        {
            InitializeComponent();
        }

        private void startBtn_Click(object sender, RoutedEventArgs e)
        {
            ShopManagmentSystemWPF mainPage = new ShopManagmentSystemWPF();
            mainPage.ShowDialog();
            this.Hide();
        }
    }
}
