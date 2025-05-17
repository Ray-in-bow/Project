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
using static System.Net.Mime.MediaTypeNames;

namespace School_Project
{
    /// <summary>
    /// Логика взаимодействия для Info.xaml
    /// </summary>
    public partial class Info : Page
    {
        string G = "";
        string A = "";
        School_Project.Datainfo information = DbaseEntities.GetContext().Datainfo.ToList()[0];
        Dictionary<string, int> rows = new Dictionary<string, int>()
            {
                {"MCH", 0}, {"MCHC", 1}, {"MCV", 2}, {"RDW", 3}, {"Базофилы абс", 4},
            {"Базофилы отн", 5}, {"Гематокрит", 6}, {"Гемоглобин", 7}, {"Лейкоциты", 8}, {"Лимфоциты абс", 9},
            {"Лимфоциты отн", 10}, {"Моноциты абс", 11}, {"Моноциты отн", 12}, {"Нейтрофилы абс", 13}, {"Нейтрофилы отн", 14},
            {"СОЭ", 15}, {"Тромбоциты", 16}, {"Эозинофилы абс", 17}, {"Эозинофилы отн", 18}, {"Эритроциты", 19},
            };

        public Info()
        {
            InitializeComponent();
            GenderComboBox.ItemsSource = new Gender[]
{
                new Gender { Name = "Мужской"},
                new Gender { Name = "Женский"}
};

            AgeComboBox.ItemsSource = new Age[]
            {
                new Age { Number = "1 день - 2 дня"},
                new Age { Number = "2 дня - 3 дня"},
                new Age { Number = "3 дня - 4 дня"},
                new Age { Number = "4 дня - 5 дней"},
                new Age { Number = "5 дней - 14 дней"},
                new Age { Number = "14 дней - 15 дней"},
                new Age { Number = "15 дней - 4 недели"},
                new Age { Number = "4 недели - 4.3 недели"},
                new Age { Number = "4.3 недели - 8.6 недель"},
                new Age { Number = "8.6 недель - 4 месяца"},
                new Age { Number = "4 месяца - 6 месяцев"},
                new Age { Number = "6 месяцев - 9 месяцев"},
                new Age { Number = "9 месяцев - 12 месяцев"},
                new Age { Number = "12 месяцев - 2 года"},
                new Age { Number = "2 года - 3 года"},
                new Age { Number = "3 года - 4 года"},
                new Age { Number = "4 года - 5 лет"},
                new Age { Number = "5 лет - 6 лет"},
                new Age { Number = "6 лет - 7 лет"},
                new Age { Number = "7 лет - 9 лет"},
                new Age { Number = "9 лет - 10 лет"},
                new Age { Number = "10 лет - 11 лет"},
                new Age { Number = "11 лет - 12 лет"},
                new Age { Number = "12 лет - 15 лет"},
                new Age { Number = "15 лет - 16 лет"},
                new Age { Number = "16 лет - 18 лет"},
                new Age { Number = "18 лет - 21 год"},
                new Age { Number = "21 год - 45 лет"},
                new Age { Number = "45 лет - 50 лет"},
                new Age { Number = "50 лет - 65 лет"},
                new Age { Number = "65 лет - 120 лет"}
            };
        }
        private void GenderComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GenderComboBox.SelectedItem is Gender gender)
            {
                string gen = gender.Name;
                G = Char.ToString(gen[0]);
            }
        }
        private void AgeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AgeComboBox.SelectedItem is Age age)
            {
                string num = age.Number;
                string[] nums = num.Split(new char[] { ' ' });
                string[] arr = new string[5] { nums[0], Char.ToString(nums[1][0]), nums[2], nums[3], Char.ToString(nums[4][0]) };
                A = string.Join("", arr);
            }
        }
        private string Get_Cell(string row, string column, float num)
        {
            if (A == "" & G == "")
            {
                MessageBox.Show("ВВЕДИТЕ ПОЛ И ВОЗРАСТ");
                return null;
            }
            else if (A == "")
            {
                MessageBox.Show("ВВЕДИТЕ ВОЗРАСТ");
                return null;
            }
            else if (G == "")
            {
                MessageBox.Show("ВВЕДИТЕ ПОЛ");
                return null;
            }
            else {
                var indicators = DbaseEntities.GetContext().Indicators.ToList();
                column = column.Replace("-", "_");
                column = column.Replace(".", "_");
                column = "C" + column;
                int r = rows[row];
                string res = "";
                if (column == "C1д_2дЖ") res = indicators[r].C1д_2дЖ.ToString();
                if (column == "C1д_2дМ") res = indicators[r].C1д_2дМ.ToString();
                if (column == "C2д_3дЖ") res = indicators[r].C2д_3дЖ.ToString();
                if (column == "C2д_3дМ") res = indicators[r].C2д_3дМ.ToString();
                if (column == "C3д_4дЖ") res = indicators[r].C3д_4дЖ.ToString();
                if (column == "C3д_4дМ") res = indicators[r].C3д_4дМ.ToString();
                if (column == "C4д_5дЖ") res = indicators[r].C4д_5дЖ.ToString();
                if (column == "C4д_5дМ") res = indicators[r].C4д_5дМ.ToString();
                if (column == "C5д_14дЖ") res = indicators[r].C5д_14дЖ.ToString();
                if (column == "C5д_14дМ") res = indicators[r].C5д_14дМ.ToString();
                if (column == "C14д_15дЖ") res = indicators[r].C14д_15дЖ.ToString();
                if (column == "C14д_15дМ") res = indicators[r].C14д_15дМ.ToString();
                if (column == "C15д_4нЖ") res = indicators[r].C15д_4нЖ.ToString();
                if (column == "C15д_4нМ") res = indicators[r].C15д_4нМ.ToString();
                if (column == "C4н_4_3нЖ") res = indicators[r].C4н_4_3нЖ.ToString();
                if (column == "C4н_4_3нМ") res = indicators[r].C4н_4_3нМ.ToString();
                if (column == "C4_3н_8_6нЖ") res = indicators[r].C4_3н_8_6нЖ.ToString();
                if (column == "C4_3н_8_6нМ") res = indicators[r].C4_3н_8_6нМ.ToString();
                if (column == "C8_6н_4мЖ") res = indicators[r].C8_6н_4мЖ.ToString();
                if (column == "C8_6н_4мМ") res = indicators[r].C8_6н_4мЖ.ToString();
                if (column == "C4м_6мЖ") res = indicators[r].C4м_6мЖ.ToString();
                if (column == "C4м_6мМ") res = indicators[r].C4м_6мМ.ToString();
                if (column == "C6м_9мЖ") res = indicators[r].C6м_9мЖ.ToString();
                if (column == "C6м_9мМ") res = indicators[r].C6м_9мМ.ToString();
                if (column == "C9м_12мЖ") res = indicators[r].C9м_12мЖ.ToString();
                if (column == "C9м_12мМ") res = indicators[r].C9м_12мМ.ToString();
                if (column == "C12м_2гЖ") res = indicators[r].C12м_2гЖ.ToString();
                if (column == "C12м_2гМ") res = indicators[r].C12м_2гМ.ToString();
                if (column == "C2л_3гЖ") res = indicators[r].C2л_3гЖ.ToString();
                if (column == "C2л_3гМ") res = indicators[r].C2л_3гМ.ToString();
                if (column == "C3г_4гЖ") res = indicators[r].C3г_4гЖ.ToString();
                if (column == "C3г_4гМ") res = indicators[r].C3г_4гМ.ToString();
                if (column == "C4г_5лЖ") res = indicators[r].C4г_5лЖ.ToString();
                if (column == "C4г_5лМ") res = indicators[r].C4г_5лМ.ToString();
                if (column == "C5л_6лЖ") res = indicators[r].C5л_6лЖ.ToString();
                if (column == "C5л_6лМ") res = indicators[r].C5л_6лМ.ToString();
                if (column == "C6л_7лМ" | column == "C6л_7лЖ") res = indicators[r].C6л_7л.ToString();
                if (column == "C7л_9лМ" | column == "C7л_9лЖ") res = indicators[r].C7л_9л.ToString();
                if (column == "C9л_10лМ" | column == "C9л_10лЖ") res = indicators[r].C9л_10л.ToString();
                if (column == "C10л_11лМ" | column == "C10л_11лЖ") res = indicators[r].C10л_11л.ToString();
                if (column == "C11л_12лМ" | column == "C11л_12лЖ") res = indicators[r].C11л_12л.ToString();
                if (column == "C12л_15лЖ") res = indicators[r].C12л_15лЖ.ToString();
                if (column == "C12л_15лМ") res = indicators[r].C12л_15лМ.ToString();
                if (column == "C15л_16лЖ") res = indicators[r].C15л_16лЖ.ToString();
                if (column == "C15л_16лМ") res = indicators[r].C15л_16лМ.ToString();
                if (column == "C16л_18лЖ") res = indicators[r].C16л_18лЖ.ToString();
                if (column == "C16л_18лМ") res = indicators[r].C16л_18лМ.ToString();
                if (column == "C18л_21гЖ") res = indicators[r].C18л_21гЖ.ToString();
                if (column == "C18л_21гМ") res = indicators[r].C18л_21гМ.ToString();
                if (column == "C21г_45лЖ") res = indicators[r].C21г_45лЖ.ToString();
                if (column == "C21г_45лМ") res = indicators[r].C21г_45лМ.ToString();
                if (column == "C45л_50лЖ") res = indicators[r].C45л_50лЖ.ToString();
                if (column == "C45л_50лМ") res = indicators[r].C45л_50лМ.ToString();
                if (column == "C50л_65лЖ") res = indicators[r].C50л_65лЖ.ToString();
                if (column == "C50л_65лМ") res = indicators[r].C50л_65лМ.ToString();
                if (column == "C65л_120лЖ") res = indicators[r].C65л_120лЖ.ToString();
                if (column == "C65л_120лМ") res = indicators[r].C65л_120лМ.ToString();
                res = res.Replace('.', ',');
                string[] Res = res.Split('-');
                float a = Convert.ToSingle(Res[0]);
                float b = Convert.ToSingle(Res[1]);
                if ((num <= b) & (num >= a)) return "норма";
                else if (num > b) return "выше нормы";
                else return "ниже нормы";
            }
            
        }
        // Обработка индикаторов

        // MCH
        private void MCHButton_Click(object sender, RoutedEventArgs e)
        {
            if (MCH.Text == "")
            {
                MessageBox.Show("ВВЕДИТЕ ДАННЫЕ");
            }
            else if (float.TryParse(MCH.Text, out float number))
            {
                string mch = MCH.Text;
                float num = Convert.ToSingle(mch);
                string res = Get_Cell("MCH", A + G, num);
                if (res != null) {
                    MCHLabel.Content = "MCH: " + res;
                    MessageBox.Show("Статус показателя: " + res);
                }
            }
            else
            {
                MessageBox.Show("ВВЕДЕННЫЕ ДАННЫЕ НЕ ЯВЛЯЮТСЯ ЧИСЛОМ");
            }
        }

        private void MCH_Click(object sender, RoutedEventArgs e)
        {
            Window dop_information = new Indicators_information(information.MCH.ToString().Split('#'));
            dop_information.Show();
        }

        // MCHC

        private void MCHCButton_Click(object sender, RoutedEventArgs e)
        {
            if (MCHC.Text == "")
            {
                MessageBox.Show("ВВЕДИТЕ ДАННЫЕ");
            }
            else if (float.TryParse(MCHC.Text, out float number))
            {
                string mch = MCHC.Text;
                float num = Convert.ToSingle(mch);
                string res = Get_Cell("MCHC", A + G, num);
                MCHCLabel.Content = $"MCHC: {res}";
                MessageBox.Show("Статус показателя: " + res);
            }
            else
            {
                MessageBox.Show("ВВЕДЕННЫЕ ДАННЫЕ НЕ ЯВЛЯЮТСЯ ЧИСЛОМ");
            }
        }

        private void MCHC_Click(object sender, RoutedEventArgs e)
        {
            Window dop_information = new Indicators_information(information.MCHC.ToString().Split('#'));
            dop_information.Show();
        }

        // MCV

        private void MCVButton_Click(object sender, RoutedEventArgs e)
        {
            if (MCV.Text == "")
            {
                MessageBox.Show("ВВЕДИТЕ ДАННЫЕ");
            }
            else if (float.TryParse(MCV.Text, out float number))
            {
                string mch = MCV.Text;
                float num = Convert.ToSingle(mch);
                string res = Get_Cell("MCV", A + G, num);
                MCVLabel.Content = $"MCV: {res}";
                MessageBox.Show("Статус показателя: " + res);
            }
            else
            {
                MessageBox.Show("ВВЕДЕННЫЕ ДАННЫЕ НЕ ЯВЛЯЮТСЯ ЧИСЛОМ");
            }
        }

        private void MCV_Click(object sender, RoutedEventArgs e)
        {
            Window dop_information = new Indicators_information(information.MCV.ToString().Split('#'));
            dop_information.Show();
        }

        //RDW

        private void RDWButton_Click(object sender, RoutedEventArgs e)
        {
            if (RDW.Text == "")
            {
                MessageBox.Show("ВВЕДИТЕ ДАННЫЕ");
            }
            else if (float.TryParse(RDW.Text, out float number))
            {
                string mch = RDW.Text;
                float num = Convert.ToSingle(mch);
                string res = Get_Cell("RDW", A + G, num);
                RDWLabel.Content = $"RDW: {res}";
                MessageBox.Show("Статус показателя: " + res);
            }
            else
            {
                MessageBox.Show("ВВЕДЕННЫЕ ДАННЫЕ НЕ ЯВЛЯЮТСЯ ЧИСЛОМ");
            }
        }

        private void RDW_Click(object sender, RoutedEventArgs e)
        {
            Window dop_information = new Indicators_information(information.RDW.ToString().Split('#'));
            dop_information.Show();
        }

        // Leukosytes

        private void LeukocytesButton_Click(object sender, RoutedEventArgs e)
        {
            if (Leukocytes.Text == "")
            {
                MessageBox.Show("ВВЕДИТЕ ДАННЫЕ");
            }
            else if (float.TryParse(Leukocytes.Text, out float number))
            {
                string mch = Leukocytes.Text;
                float num = Convert.ToSingle(mch);
                string res = Get_Cell("Лейкоциты", A + G, num);
                LeukocytesLabel.Content = $"ЛЕЙКОЦИТЫ: {res}";
                MessageBox.Show("Статус показателя: " + res);
            }
            else
            {
                MessageBox.Show("ВВЕДЕННЫЕ ДАННЫЕ НЕ ЯВЛЯЮТСЯ ЧИСЛОМ");
            }
        }
        private void Leukocytes_Click(object sender, RoutedEventArgs e)
        {
            Window dop_information = new Indicators_information(information.Лейкоциты.ToString().Split('#'));
            dop_information.Show();
        }

        // BasophilsAbs

        private void BasophilsAbsButton_Click(object sender, RoutedEventArgs e)
        {
            if (BasophilsAbs.Text == "")
            {
                MessageBox.Show("ВВЕДИТЕ ДАННЫЕ");
            }
            else if (float.TryParse(BasophilsAbs.Text, out float number))
            {
                string mch = BasophilsAbs.Text;
                float num = Convert.ToSingle(mch);
                string res = Get_Cell("Базофилы абс", A + G, num);
                BasophilsAbsLabel.Content = $"БАЗОФИЛЫ(абс): {res}";
                MessageBox.Show("Статус показателя: " + res);
            }
            else
            {
                MessageBox.Show("ВВЕДЕННЫЕ ДАННЫЕ НЕ ЯВЛЯЮТСЯ ЧИСЛОМ");
            }
        }

        private void BasophilsAbs_Click(object sender, RoutedEventArgs e)
        {
            Window dop_information = new Indicators_information(information.Базофилыабс.ToString().Split('#'));
            dop_information.Show();

        }

        // BasophilsRel

        private void BasophilsRelButton_Click(object sender, RoutedEventArgs e)
        {
            if (BasophilsRel.Text == "")
            {
                MessageBox.Show("ВВЕДИТЕ ДАННЫЕ");
            }
            else if (float.TryParse(BasophilsRel.Text, out float number))
            {
                string mch = BasophilsRel.Text;
                float num = Convert.ToSingle(mch);
                string res = Get_Cell("Базофилы отн", A + G, num);
                BasophilsRelLabel.Content = $"БАЗОФИЛЫ(отн): {res}";
                MessageBox.Show("Статус показателя: " + res);
            }
            else
            {
                MessageBox.Show("ВВЕДЕННЫЕ ДАННЫЕ НЕ ЯВЛЯЮТСЯ ЧИСЛОМ");
            }
        }
        private void BasophilsRel_Click(object sender, RoutedEventArgs e)
        {
            Window dop_information = new Indicators_information(information.Базофилыабс.ToString().Split('#'));
            dop_information.Show();
        }

        // Hematocrit

        private void HematocritButton_Click(object sender, RoutedEventArgs e)
        {
            if (Hematocrit.Text == "")
            {
                MessageBox.Show("ВВЕДИТЕ ДАННЫЕ");
            }
            else if (float.TryParse(Hematocrit.Text, out float number))
            {
                string mch = Hematocrit.Text;
                float num = Convert.ToSingle(mch);
                string res = Get_Cell("Гематокрит", A + G, num);
                HematocritLabel.Content = $"ГЕМАТОКРИТ: {res}";
                MessageBox.Show("Статус показателя: " + res);
            }
            else
            {
                MessageBox.Show("ВВЕДЕННЫЕ ДАННЫЕ НЕ ЯВЛЯЮТСЯ ЧИСЛОМ");
            }
        }

        private void Hematocrit_Click(object sender, RoutedEventArgs e)
        {
            Window dop_information = new Indicators_information(information.Гематокрит.ToString().Split('#'));
            dop_information.Show();

        }

        // Hemoglobin

        private void HemoglobinButton_Click(object sender, RoutedEventArgs e)
        {
            if (Hemoglobin.Text == "")
            {
                MessageBox.Show("ВВЕДИТЕ ДАННЫЕ");
            }
            else if (float.TryParse(Hemoglobin.Text, out float number))
            {
                string mch = Hemoglobin.Text;
                float num = Convert.ToSingle(mch);
                string res = Get_Cell("Гемоглобин", A + G, num);
                HemoglobinLabel.Content = $"ГЕМОГЛОБИН: {res}";
                MessageBox.Show("Статус показателя: " + res);
            }
            else
            {
                MessageBox.Show("ВВЕДЕННЫЕ ДАННЫЕ НЕ ЯВЛЯЮТСЯ ЧИСЛОМ");
            }
        }
        private void Hemoglobin_Click(object sender, RoutedEventArgs e)
        {
            Window dop_information = new Indicators_information(information.Гемоглобин.ToString().Split('#'));
            dop_information.Show();
        }
        // Platelets

        private void PlateletsButton_Click(object sender, RoutedEventArgs e)
        {
            if (Platelets.Text == "")
            {
                MessageBox.Show("ВВЕДИТЕ ДАННЫЕ");
            }
            else if (float.TryParse(Platelets.Text, out float number))
            {
                string mch = Platelets.Text;
                float num = Convert.ToSingle(mch);
                string res = Get_Cell("Тромбоциты", A + G, num);
                PlateletsLabel.Content = $"ТРОМБОЦИТЫ: {res}";
                MessageBox.Show("Статус показателя: " + res);
            }
            else
            {
                MessageBox.Show("ВВЕДЕННЫЕ ДАННЫЕ НЕ ЯВЛЯЮТСЯ ЧИСЛОМ");
            }
        }
        private void Platelets_Click(object sender, RoutedEventArgs e)
        {
            Window dop_information = new Indicators_information(information.Тромбоцитыабс.ToString().Split('#'));
            dop_information.Show();
        }
        // LymphocytesAbs

        private void LymphocytesAbsButton_Click(object sender, RoutedEventArgs e)
        {
            if (LymphocytesAbs.Text == "")
            {
                MessageBox.Show("ВВЕДИТЕ ДАННЫЕ");
            }
            else if (float.TryParse(LymphocytesAbs.Text, out float number))
            {
                string mch = LymphocytesAbs.Text;
                float num = Convert.ToSingle(mch);
                string res = Get_Cell("Лимфоциты абс", A + G, num);
                LymphocytesAbsLabel.Content = $"ЛИМФОЦИТЫ(абс): {res}";
                MessageBox.Show("Статус показателя: " + res);
            }
            else
            {
                MessageBox.Show("ВВЕДЕННЫЕ ДАННЫЕ НЕ ЯВЛЯЮТСЯ ЧИСЛОМ");
            }
        }
        private void LymphocytesAbs_Click(object sender, RoutedEventArgs e)
        {
            Window dop_information = new Indicators_information(information.Лимфоцитыабс.ToString().Split('#'));
            dop_information.Show();
        }
        // LymphocytesRel

        private void LymphocytesRelButton_Click(object sender, RoutedEventArgs e)
        {
            if (LymphocytesRel.Text == "")
            {
                MessageBox.Show("ВВЕДИТЕ ДАННЫЕ");
            }
            else if (float.TryParse(LymphocytesRel.Text, out float number))
            {
                string mch = LymphocytesRel.Text;
                float num = Convert.ToSingle(mch);
                string res = Get_Cell("Лимфоциты отн", A + G, num);
                LymphocytesRelLabel.Content = $"ЛИМФОЦИТЫ(отн): {res}";
                MessageBox.Show("Статус показателя: " + res);
            }
            else
            {
                MessageBox.Show("ВВЕДЕННЫЕ ДАННЫЕ НЕ ЯВЛЯЮТСЯ ЧИСЛОМ");
            }
        }
        private void LymphocytesRel_Click(object sender, RoutedEventArgs e)
        {
            Window dop_information = new Indicators_information(information.Лимфоцитыабс.ToString().Split('#'));
            dop_information.Show();

        }

        // MonocytesAbs

        private void MonocytesAbsButton_Click(object sender, RoutedEventArgs e)
        {
            if (MonocytesAbs.Text == "")
            {
                MessageBox.Show("ВВЕДИТЕ ДАННЫЕ");
            }
            else if (float.TryParse(MonocytesAbs.Text, out float number))
            {
                string mch = MonocytesAbs.Text;
                float num = Convert.ToSingle(mch);
                string res = Get_Cell("Моноциты абс", A + G, num);
                MonocytesAbsLabel.Content = $"МОНОЦИТЫ(абс): {res}";
                MessageBox.Show("Статус показателя: " + res);
            }
            else
            {
                MessageBox.Show("ВВЕДЕННЫЕ ДАННЫЕ НЕ ЯВЛЯЮТСЯ ЧИСЛОМ");
            }
        }
        private void MonocytesAbs_Click(object sender, RoutedEventArgs e)
        {
            Window dop_information = new Indicators_information(information.Моноцитыабс.ToString().Split('#'));
            dop_information.Show();

        }

        // MonocytesRel

        private void MonocytesRelButton_Click(object sender, RoutedEventArgs e)
        {
            if (MonocytesRel.Text == "")
            {
                MessageBox.Show("ВВЕДИТЕ ДАННЫЕ");
            }
            else if (float.TryParse(MonocytesRel.Text, out float number))
            {
                string mch = MonocytesRel.Text;
                float num = Convert.ToSingle(mch);
                string res = Get_Cell("Моноциты отн", A + G, num);
                MonocytesRelLabel.Content = $"МОНОЦИТЫ(отн): {res}";
                MessageBox.Show("Статус показателя: " + res);
            }
            else
            {
                MessageBox.Show("ВВЕДЕННЫЕ ДАННЫЕ НЕ ЯВЛЯЮТСЯ ЧИСЛОМ");
            }
        }
        private void MonocytesRel_Click(object sender, RoutedEventArgs e)
        {
            Window dop_information = new Indicators_information(information.Моноцитыабс.ToString().Split('#'));
            dop_information.Show();

        }

        // ESR

        private void ESRButton_Click(object sender, RoutedEventArgs e)
        {
            if (ESR.Text == "")
            {
                MessageBox.Show("ВВЕДИТЕ ДАННЫЕ");
            }
            else if (float.TryParse(ESR.Text, out float number))
            {
                string mch = ESR.Text;
                float num = Convert.ToSingle(mch);
                string res = Get_Cell("СОЭ", A + G, num);
                ESRLabel.Content = $"СОЭ: {res}";
                MessageBox.Show("Статус показателя: " + res);
            }
            else
            {
                MessageBox.Show("ВВЕДЕННЫЕ ДАННЫЕ НЕ ЯВЛЯЮТСЯ ЧИСЛОМ");
            }
        }
        private void ESR_Click(object sender, RoutedEventArgs e)
        {
            Window dop_information = new Indicators_information(information.СОЭ.ToString().Split('#'));
            dop_information.Show();

        }

        // NeutrophilsAbs

        private void NeutrophilsAbsButton_Click(object sender, RoutedEventArgs e)
        {
            if (NeutrophilsAbs.Text == "")
            {
                MessageBox.Show("ВВЕДИТЕ ДАННЫЕ");
            }
            else if (float.TryParse(NeutrophilsAbs.Text, out float number))
            {
                string mch = NeutrophilsAbs.Text;
                float num = Convert.ToSingle(mch);
                string res = Get_Cell("Нейтрофилы абс", A + G, num);
                NeutrophilsAbsLabel.Content = $"НЕЙТРОФИЛЫ(абс): {res}";
                MessageBox.Show("Статус показателя: " + res);
            }
            else
            {
                MessageBox.Show("ВВЕДЕННЫЕ ДАННЫЕ НЕ ЯВЛЯЮТСЯ ЧИСЛОМ");
            }
        }
        private void NeutrophilsAbs_Click(object sender, RoutedEventArgs e)
        {
            Window dop_information = new Indicators_information(information.Нейтрофилыабс.ToString().Split('#'));
            dop_information.Show();

        }

        // NeutrophilsRel

        private void NeutrophilsRelButton_Click(object sender, RoutedEventArgs e)
        {
            if (NeutrophilsRel.Text == "")
            {
                MessageBox.Show("ВВЕДИТЕ ДАННЫЕ");
            }
            else if (float.TryParse(NeutrophilsRel.Text, out float number))
            {
                string mch = NeutrophilsRel.Text;
                float num = Convert.ToSingle(mch);
                string res = Get_Cell("Нейтрофилы отн", A + G, num);
                NeutrophilsRelLabel.Content = $"НЕЙТРОФИЛЫ(отн): {res}";
                MessageBox.Show("Статус показателя: " + res);
            }
            else
            {
                MessageBox.Show("ВВЕДЕННЫЕ ДАННЫЕ НЕ ЯВЛЯЮТСЯ ЧИСЛОМ");
            }
        }
        private void NeutrophilsRel_Click(object sender, RoutedEventArgs e)
        {
            Window dop_information = new Indicators_information(information.Нейтрофилыабс.ToString().Split('#'));
            dop_information.Show();

        }

        // EosinophilsAbs

        private void EosinophilsAbsButton_Click(object sender, RoutedEventArgs e)
        {
            if (EosinophilsAbs.Text == "")
            {
                MessageBox.Show("ВВЕДИТЕ ДАННЫЕ");
            }
            else if (float.TryParse(EosinophilsAbs.Text, out float number))
            {
                string mch = EosinophilsAbs.Text;
                float num = Convert.ToSingle(mch);
                string res = Get_Cell("Эозинофилы абс", A + G, num);
                EosinophilsAbsLabel.Content = $"ЭОЗИНОФИЛЫ(абс): {res}";
                MessageBox.Show("Статус показателя: " + res);
            }
            else
            {
                MessageBox.Show("ВВЕДЕННЫЕ ДАННЫЕ НЕ ЯВЛЯЮТСЯ ЧИСЛОМ");
            }
        }
        private void EosinophilsAbs_Click(object sender, RoutedEventArgs e)
        {
            Window dop_information = new Indicators_information(information.Эозинофилыабс.ToString().Split('#'));
            dop_information.Show();

        }

        // EosinophilsRel

        private void EosinophilsRelButton_Click(object sender, RoutedEventArgs e)
        {
            if (EosinophilsRel.Text == "")
            {
                MessageBox.Show("ВВЕДИТЕ ДАННЫЕ");
            }
            else if (float.TryParse(EosinophilsRel.Text, out float number))
            {
                string mch = EosinophilsRel.Text;
                float num = Convert.ToSingle(mch);
                string res = Get_Cell("Эозинофилы отн", A + G, num);
                EosinophilsRelLabel.Content = $"ЭОЗИНОФИЛЫ(отн): {res}";
                MessageBox.Show("Статус показателя: " + res);
            }
            else
            {
                MessageBox.Show("ВВЕДЕННЫЕ ДАННЫЕ НЕ ЯВЛЯЮТСЯ ЧИСЛОМ");
            }
        }
        private void EosinophilsRel_Click(object sender, RoutedEventArgs e)
        {
            Window dop_information = new Indicators_information(information.Эозинофилыабс.ToString().Split('#'));
            dop_information.Show();

        }

        // Erythrocytes

        private void ErythrocytesButton_Click(object sender, RoutedEventArgs e)
        {
            if (Erythrocytes.Text == "")
            {
                MessageBox.Show("ВВЕДИТЕ ДАННЫЕ");
            }
            else if (float.TryParse(Erythrocytes.Text, out float number))
            {
                string mch = Erythrocytes.Text;
                float num = Convert.ToSingle(mch);
                string res = Get_Cell("Эритроциты", A + G, num);
                ErythrocytesLabel.Content = $"ЭРИТРОЦИТЫ: {res}";
                MessageBox.Show("Статус показателя: " + res);
            }
            else
            {
                MessageBox.Show("ВВЕДЕННЫЕ ДАННЫЕ НЕ ЯВЛЯЮТСЯ ЧИСЛОМ");
            }
        }
        private void Erythrocytes_Click(object sender, RoutedEventArgs e)
        {
            Window dop_information = new Indicators_information(information.Эритроциты.ToString().Split('#'));
            dop_information.Show();

        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Menu());
        }
    }
    public class Gender
    {
        public string Name { get; set; } = "";
        public override string ToString() => Name;
    }

    public class Age
    {
        public string Number { get; set; } = "";
        public override string ToString() => Number;

    }
}
