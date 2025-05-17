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
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveCharts;
using System.Globalization;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Collections;

namespace School_Project
{
    /// <summary>
    /// Логика взаимодействия для Graph.xaml
    /// </summary>
    public partial class Graph : Window
    {
       
        public Graph(string g)
        {
            InitializeComponent();
            ChartValues<float> nums = new ChartValues<float>();

            List<DateTime> dates = new List<DateTime>();
            Dictionary<DateTime, float> dates_nums = new Dictionary<DateTime, float>();

            foreach (var row in DbaseEntities.GetContext().UserTable)
            {
                if (g == "MCH") dates_nums[Convert.ToDateTime(row.Дата.Trim())] = Convert.ToSingle(row.MCH);
                if (g == "MCHC") dates_nums[Convert.ToDateTime(row.Дата.Trim())] = Convert.ToSingle(row.MCHC);
                if (g == "MCV") dates_nums[Convert.ToDateTime(row.Дата.Trim())] = Convert.ToSingle(row.MCV);
                if (g == "RDW") dates_nums[Convert.ToDateTime(row.Дата.Trim())] = Convert.ToSingle(row.RDW);
                if (g == "Базофилыабс") dates_nums[Convert.ToDateTime(row.Дата.Trim())] = Convert.ToSingle(row.Базофилыабс);
                if (g == "Базофилыотн") dates_nums[Convert.ToDateTime(row.Дата.Trim())] = Convert.ToSingle(row.Баззофилыотн);
                if (g == "Гематокрит") dates_nums[Convert.ToDateTime(row.Дата.Trim())] = Convert.ToSingle(row.Гематокрит);
                if (g == "Гемоглобин") dates_nums[Convert.ToDateTime(row.Дата.Trim())] = Convert.ToSingle(row.Гемоглобин);
                if (g == "Лейкоциты") dates_nums[Convert.ToDateTime(row.Дата.Trim())] = Convert.ToSingle(row.Лейкоциты);
                if (g == "Лимфоцитыабс") dates_nums[Convert.ToDateTime(row.Дата.Trim())] = Convert.ToSingle(row.Лимфоцитыабс);
                if (g == "Лимфоцитыотн") dates_nums[Convert.ToDateTime(row.Дата.Trim())] = Convert.ToSingle(row.Лимфоцитыотн);
                if (g == "Моноцитыабс") dates_nums[Convert.ToDateTime(row.Дата.Trim())] = Convert.ToSingle(row.Моноцитыабс);
                if (g == "Моноцитыотн") dates_nums[Convert.ToDateTime(row.Дата.Trim())] = Convert.ToSingle(row.Моноцитыотн);
                if (g == "Нетйрофилыабс") dates_nums[Convert.ToDateTime(row.Дата.Trim())] = Convert.ToSingle(row.Нейтрофилыабс);
                if (g == "Нейтрофилыотн") dates_nums[Convert.ToDateTime(row.Дата.Trim())] = Convert.ToSingle(row.Нейтрофилыотн);
                if (g == "СОЭ") dates_nums[Convert.ToDateTime(row.Дата.Trim())] = Convert.ToSingle(row.СОЭ);
                if (g == "Тромбоциты") dates_nums[Convert.ToDateTime(row.Дата.Trim())] = Convert.ToSingle(row.Тромбоциты);
                if (g == "Эозинофилыабс") dates_nums[Convert.ToDateTime(row.Дата.Trim())] = Convert.ToSingle(row.Эозинофилыабс);
                if (g == "Эозинофилыотн") dates_nums[Convert.ToDateTime(row.Дата.Trim())] = Convert.ToSingle(row.Эозинофилыотн);
                if (g == "Эритроциты") dates_nums[Convert.ToDateTime(row.Дата.Trim())] = Convert.ToSingle(row.Эритроциты);


                dates.Add(Convert.ToDateTime(row.Дата.Trim()));

            }
            dates.Sort();
            List<string> new_dates = new List<string>();
            for (int i = 0; i < dates.Count; i++) { 
                new_dates.Add(dates[i].ToShortDateString());
            }
            foreach (string date in new_dates)
            {
                nums.Add(dates_nums[Convert.ToDateTime(date)]);
            }
            cartesianChart.AxisX.Add(new Axis()
            {
                Title = "Даты",
                Labels = new_dates
            });


            LineSeries line = new LineSeries();
            line.Title = g;
            line.Values = nums;

            SeriesCollection series = new SeriesCollection();
            series.Add(line);
            cartesianChart.Series = series;

            cartesianChart.LegendLocation = LegendLocation.Bottom;
        }
    }
}
