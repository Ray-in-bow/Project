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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace School_Project
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        public Menu()
        {
            InitializeComponent();
            var indicators = DbaseEntities.GetContext().Datainfo.ToList();
            Console.WriteLine(indicators);
        }
        private void Info_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Info());
        }

        private void User_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new User());
        }
    }
}
