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

namespace LB6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            double P, Izd, T, Potp, Ilec, Ro, n, V1, V2, V3, V4, V5;
            double Cl, Kpaush, Clpaush;
            double Pper, Ppmg, Pro;
            try
            {
                P = Convert.ToDouble(tbP.Text);
                Izd = Convert.ToDouble(tbIzd.Text);
                Potp = Convert.ToDouble(tbPotp.Text);
                Ilec = Convert.ToDouble(tbIlec.Text);
                Ro = Convert.ToDouble(tbRo.Text);
                T = Convert.ToDouble(tbT.Text);
                n = Convert.ToDouble(tbn.Text);
                V1 = Convert.ToDouble(tbV1.Text);
                V2 = Convert.ToDouble(tbV2.Text);
                V3 = Convert.ToDouble(tbV3.Text);
                V4 = Convert.ToDouble(tbV4.Text);
                V5 = Convert.ToDouble(tbV5.Text);
                Cl = RaschCl(V1, V2, V3, V4, V5, Ro, Potp);
                listBox.Items.Add("ПАУШАЛЬНЫЙ:");
                listBox.Items.Add("-----------------------------------------");
                listBox.Items.Add("Расчетная цена лицензии за срок T");
                listBox.Items.Add("Цл=" + Cl + "р");
                Kpaush = RaschKpaush(T, n);
                Clpaush = Cl * Kpaush;
                listBox.Items.Add("Коэффициент паушальности");
                listBox.Items.Add("Кпауш=" + Kpaush);
                listBox.Items.Add("Расчетная цена лицензии при паушальном (единовременном) платеже");
                listBox.Items.Add("Цл.пауш=" + Clpaush + "р");
                listBox.Items.Add("-----------------------------------------");
                listBox.Items.Add("КОМБИНИРОВАННЫЙ:");
                listBox.Items.Add("-----------------------------------------");
                Pper = Cl*0.3;
                Ppmg = Cl * 0.2;
                Pro = Cl * 0.5;
                listBox.Items.Add("Первоначальный платеж");
                listBox.Items.Add("Ппер=" + Pper + "р");
                listBox.Items.Add("Минимально гарантированные платежи");
                listBox.Items.Add("Ппмг=" + Ppmg + "р");
                listBox.Items.Add("Сами платежи по роялти");
                listBox.Items.Add("Проял=" + Pro + "р");    

            }
            catch
            {
                MessageBox.Show("Ошибка расчетов");
            }
        }

        private double RaschKpaush(double t, double n)
        {
            return 1 * t * (n / 100);
        }

        private double RaschCl(double V1, double V2, double V3, double V4, double V5, double Ro, double Potp)
        {
            return (V1 + V2 + V3 + V4 + V5) * (Ro / 100) * Potp;
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
        //    double P2, P2seb, P2ot, V22, Izd2, T2;
        //    try
        //    {
        //        P2 = Convert.ToDouble(tbP2.Text);
        //        P2seb = Convert.ToDouble(tbP2seb.Text);
        //        P2ot = Convert.ToDouble(tbP2ot.Text);
        //        V22 = Convert.ToDouble(tbV22.Text);
        //        Izd2 = Convert.ToDouble(tbIzd2.Text);
        //        T2 = Convert.ToDouble(tbT2.Text);
               

        //    }
        //    catch
        //    {
        //        MessageBox.Show("Ошибка расчетов");
        //    }
        }
    }
}
