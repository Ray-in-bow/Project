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

namespace School_Project
{
    /// <summary>
    /// Логика взаимодействия для Indicators_information.xaml
    /// </summary>
    public partial class Indicators_information : Window
    {
        public Indicators_information(string[] dop_information)
        {
            InitializeComponent();
            Name.Text = dop_information[0];
            text.Text = dop_information[1];
            Up.Text = dop_information[2];
            Up1.Text = "• " + dop_information[3].Split('&')[0];
            Up2.Text = "• " + dop_information[3].Split('&')[1];
            Up3.Text = "• " + dop_information[3].Split('&')[2];
            Up4.Text = "• " + dop_information[3].Split('&')[3];
            Up5.Text = "• " + dop_information[3].Split('&')[4];
            Up6.Text = "• " + dop_information[3].Split('&')[5];
            Dow.Text = dop_information[4];
            Down1.Text = "• " + dop_information[5].Split('&')[0];
            Down2.Text = "• " + dop_information[5].Split('&')[1];
            Down3.Text = "• " + dop_information[5].Split('&')[2];
        }
    }
}
