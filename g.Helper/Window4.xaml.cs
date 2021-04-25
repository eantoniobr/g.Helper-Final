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

namespace g.Helper
{
    /// <summary>
    /// Lógica interna para Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
        }
        public string altura2 { get; set; }
        public string terreno2 { get; set; }
        public string angulo2 { get; set; }
        public string vento2 { get; set; }
        public string distancia2 { get; set; }
        public string quebra2 { get; set; }

        double[] forca = new double[] { 70.00, 70.28, 70.56, 70.83, 71.11, 71.39, 71.67, 71.94, 72.22, 72.50, 72.78, 73.06, 73.33, 73.61, 73.89, 74.17, 74.44, 74.72, 75.00, 75.28, 75.56, 75.83, 76.11, 76.39, 76.67, 76.94, 77.22, 77.50, 77.78, 78.06, 78.33, 78.61, 78.89, 79.17, 79.44, 79.72, 80.00, 80.28, 80.56, 80.83, 81.11, 81.39, 81.67, 81.94, 82.22, 82.50, 82.78, 83.06, 83.33, 83.61, 83.89, 84.17, 84.44, 84.72, 85.00, 85.28, 85.56, 85.83, 86.11, 86.39, 86.67, 86.94, 87.22, 87.50, 87.78, 88.06, 88.33, 88.61, 88.89, 89.17, 89.44, 89.72, 90.00, 90.28, 90.56, 90.83, 91.11, 91.39, 91.67, 91.94, 92.22, 92.50, 92.78, 93.06, 93.33, 93.61, 93.89, 94.17, 94.44, 94.72, 95.00, 95.28, 95.56, 95.83, 96.11, 96.39, 96.67, 96.94, 97.22, 97.50, 97.78, 98.06, 98.33, 98.61, 98.89, 99.17, 99.44, 99.72, 100.00 };
        string[] taco = new string[] { "179", "180", "181L", "181R", "182", "183L", "183R", "184", "185", "186L", "186R", "187", "188L", "188R", "189", "190", "191L", "191R", "192", "193L", "193R", "194", "195", "196L", "196R", "197", "198L", "198R", "199", "200", "201L", "201R", "202", "203L", "203R", "204", "205", "206L", "206R", "207", "208L", "208R", "209", "210L", "210R", "211", "212", "213L", "213R", "214", "215L", "215R", "216", "217", "218L", "218R", "219", "220L", "220R", "221", "222", "223L", "223R", "224", "225L", "225R", "226", "227", "228L", "228R", "229", "230L", "230R", "231", "232", "233L", "233R", "234", "235L", "235R", "236", "237", "238L", "238R", "239", "240L", "240R", "241", "242L", "242R", "243", "244", "245L", "245R", "246", "247L", "247R", "248", "249", "250L", "250R", "251", "252L", "252R", "253", "254", "255L", "255R", "256" };
        double terrenofloat = 0, B112 = 268.34, C112 = 240.5, D112 = 213, B113 = 1.215, C113 = 0.907, D113 = 0.67, J124 = 1.0109, J125 = 1.013, K125 = 0.48, C116 = 0.62, C117 = 0.62, C118 = 0.62, C122 = 0.49, C123 = 0.484, C124 = 0.478, M112 = 0, I124 = 3, I125 = 2.75, B116 = 1, B117 = 20, B118 = 40, B122 = -1, B123 = -20, B124 = -40, G119 = 0, M114 = 0, M115 = 0, G113 = 0, G114 = 0, G115 = 0, M116 = 0, F124 = 0, F125 = 0;
        string penis2;

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            double quebrafloat = Convert.ToDouble(quebra2);
            double M117 = Convert.ToDouble(distancia2);
            var penis = vento2.Substring(0, 1);
            double ventofloat = Convert.ToDouble(penis);
            double alturafloat = Convert.ToDouble(altura2);
            #region Terreno Dunk
            if (terreno2 != "100%")
            {
                penis2 = terreno2.Substring(0, 2);
                terrenofloat = Convert.ToDouble(penis2);
            }
            else
            {
                penis2 = terreno2.Substring(0, 3);
                terrenofloat = Convert.ToDouble(penis2);
            }
            if (terrenofloat == 100)
            {
                M117 = M117 + 0;
            }
            else if (terrenofloat == 98)
            {
                M117 = M117 + 1.5;
            }
            else if (terrenofloat == 97)
            {
                M117 = M117 + 2.1;
            }
            else if (terrenofloat == 95)
            {
                M117 = M117 + 3.7;
            }
            else if (terrenofloat == 92)
            {
                M117 = M117 + 5.9;
            }
            else if (terrenofloat == 90)
            {
                M117 = M117 + 7.5;
            }
            else if (terrenofloat == 85)
            {
                M117 = M117 + 11.5;
            }
            else if (terrenofloat == 80)
            {
                M117 = M117 + 16;
            }
            else if (terrenofloat == 75)
            {
                M117 = M117 + 20.75;
            }
            else if (terrenofloat == 70)
            {
                M117 = M117 + 24.75;
            }
            #endregion
            double angulofloat = Convert.ToDouble(angulo2);
            double B125 = alturafloat, B119 = alturafloat;
            double M111 = B113 * (M117 - C112) * (M117 - D112) / ((B112 - C112) * (B112 - D112)) + C113 * (M117 - B112) * (M117 - D112) / ((C112 - B112) * (C112 - D112)) + D113 * (M117 - B112) * (M117 - C112) / ((D112 - B112) * (D112 - C112));
            double C119 = C116 * (B119 - B117) * (B119 - B118) / ((B116 - B117) * (B116 - B118)) + C117 * (B119 - B116) * (B119 - B118) / ((B117 - B116) * (B117 - B118)) + C118 * (B119 - B116) * (B119 - B117) / ((B118 - B116) * (B118 - B117));
            double C125 = C122 * (B125 - B123) * (B125 - B124) / ((B122 - B123) * (B122 - B124)) + C123 * (B125 - B122) * (B125 - B124) / ((B123 - B122) * (B123 - B124)) + C124 * (B125 - B122) * (B125 - B123) / ((B124 - B122) * (B124 - B123));
            double K124 = C119;
            double M112 = K124 * Math.Pow(J124, B112 - M117);
            double M113 = K125 * Math.Pow(J125, B112 - M117);
            //double AO2 = Math.sin(Calculadora!B4*PI()/180)
            double AO2 = Math.Sin(angulofloat * 3.14 / 180);
            double AO1 = Math.Cos(angulofloat * 3.14 / 180);
            double G112 = M111 * AO2 * ventofloat;
            double J113 = M111 * ventofloat * AO1;
            double AT1 = AO1;
            M116 = M111 / 4.4 * quebrafloat;
            if (alturafloat > 0)
            {
                G119 = alturafloat * M112;
            }
            else
            {
                G119 = alturafloat * M113;
            }
            if (M117 > 0)
            {
                M114 = (100 + (G119 / -I124)) / 100;
            }
            if (M117 > 0)
            {
                M115 = (100 + (G119 / -I125)) / 100;
            }
            if (G119 > 0)
            {
                G113 = G112 * M114;
            }
            else
            {
                G113 = G112 * M115;
            }
            double J115 = AT1 * ventofloat * M111 * 1 * (1 - (G119 * 0.016));
            double J116 = AT1 * ventofloat * M111 * 1.25 * (1 - (G119 * 0.016));
            double J117 = (100 + (J115 * 2.75 / -4)) / 100;
            double J118 = (100 + (J116 * 4 / -6.25)) / 100;
            double J120 = M117 + G119 - J115;
            double J121 = M117 + G119 + J116;
            double G114 = G113 * J117;
            double G115 = G113 / J118;
            double G124 = G114 + M116;
            double G125 = G115 + M116;

            if (J120 <= C112)
            {
                F124 = 80 + (J120 - D112) / ((C112 - D112) / 10);
            }
            else
            {
                F124 = 90 + (J120 - C112) / ((B112 - C112) / 10);
            }
            if (J121 <= C112)
            {
                F125 = 80 + (J121 - D112) / ((C112 - D112) / 10);
            }
            else
            {
                F125 = 90 + (J121 - C112) / ((B112 - C112) / 10);
            }
            double numeroBase = F125;
            double numeroDaArray = forca.Aggregate((x, y) => Math.Abs(x - numeroBase) < Math.Abs(y - numeroBase) ? x : y);
            int indice = Array.IndexOf(forca, numeroDaArray);

            double numeroBase2 = F124;
            double numeroDaArray2 = forca.Aggregate((x, y) => Math.Abs(x - numeroBase2) < Math.Abs(y - numeroBase2) ? x : y);
            int indice2 = Array.IndexOf(forca, numeroDaArray2);

            string forcafront = taco[indice];
            string forcaback = taco[indice2];

            forcaback2.Text = forcafront;
            forcafront2.Text = forcaback;
            G125 = G125 / 0.2165;
            G124 = G124 / 0.2165;
            G124 = Math.Round(G124, 2);
            G125 = Math.Round(G125, 2);
            F124 = Math.Round(F124, 2);
            F125 = Math.Round(F125, 2);
            ffpercent.Text = Convert.ToString(F124 + "%");
            fbpercent.Text = Convert.ToString(F125 + "%");
            pbfront2.Text = Convert.ToString(G124);
            pbback2.Text = Convert.ToString(G125);
            Close();
        }
    }
}
