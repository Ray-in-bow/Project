using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
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
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace School_Project
{
    /// <summary>
    /// Логика взаимодействия для User.xaml
    /// </summary>
    public partial class User : Page
    {
        string g = "";
        DbaseEntities db;

        public User()
        {
            InitializeComponent();
            db = new DbaseEntities();
            db.UserTable.Load();
            DataGridUser.ItemsSource = db.UserTable.Local.ToBindingList();
            
            DataContext = this;

            GraphComboBox.ItemsSource = new Graph_Built[]
{
                new Graph_Built { graph_built = "MCH"},
                new Graph_Built { graph_built = "MCHC"},
                new Graph_Built { graph_built = "MCV"},
                new Graph_Built { graph_built = "RDW"},
                new Graph_Built { graph_built = "Базофилы(абс.)"},
                new Graph_Built { graph_built = "Базофилы(отн.)"},
                new Graph_Built { graph_built = "Гематокрит"},
                new Graph_Built { graph_built = "Гемоглобин"},
                new Graph_Built { graph_built = "Лейкоциты"},
                new Graph_Built { graph_built = "Лимфоциты(абс.)"},
                new Graph_Built { graph_built = "Лимфоциты(отн.)"},
                new Graph_Built { graph_built = "Моноциты(абс.)"},
                new Graph_Built { graph_built = "Моноциты(отн.)"},
                new Graph_Built { graph_built = "Нейтрофилы(абс.)"},
                new Graph_Built { graph_built = "Нейтрофилы(отн.)"},
                new Graph_Built { graph_built = "СОЭ"},
                new Graph_Built { graph_built = "Эозинофилы(абс.)"},
                new Graph_Built { graph_built = "Эозинофилы(отн.)"},
                new Graph_Built { graph_built = "Эритроциты"}
};
        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            var removingline = DataGridUser.SelectedItems.Cast<UserTable>().ToList();
            if (DataGridUser.SelectedItem != null)
            {
                if (MessageBox.Show("Вы действительно хотите удалить выбранные строки?", "Удаление строки", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    MessageBox.Show("Удалено!");
                    db.UserTable.RemoveRange(removingline);
                    db.SaveChanges();
                }
            }
           

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                db.SaveChanges();

            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    Console.WriteLine("Object: " + validationError.Entry.Entity.ToString());
                    Console.WriteLine("");
                        foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        Console.WriteLine(err.ErrorMessage + "");
                        }
                }
            }
            MessageBox.Show("Сохранено!");
        }

        private void Graph_Click(object sender, RoutedEventArgs e)
        {
            if (g != "") {
                Window graph = new Graph(g);
                graph.Show();
            }
            else
            {
                MessageBox.Show("Выберите индикатор");
            }
        }
        private void Return_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Menu());
        }
        private void GraphComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GraphComboBox.SelectedItem is Graph_Built graph)
            {
                string gr = graph.graph_built;
                g = gr.ToString().Replace("(", "").Replace(")", "").Replace(".", "");
            }
        }

    }
    public class Graph_Built
    {
        public string graph_built { get; set; } = "";
        public override string ToString() => graph_built;
    }
}
