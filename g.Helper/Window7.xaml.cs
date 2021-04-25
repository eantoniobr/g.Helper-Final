using System;

using System.Linq;

using System.Windows;

using System.Windows.Input;


namespace g.Helper
{
    /// <summary>
    /// Lógica interna para Window7.xaml
    /// </summary>
    public partial class Window7 : Window
    {
        public string altura2 { get; set; }
        public string terreno2 { get; set; }
        public string angulo2 { get; set; }
        public string vento2 { get; set; }
        public string distancia2 { get; set; }
        public string quebra2 { get; set; }

        double[] forca = new double[] { 70.00, 70.28, 70.56, 70.83, 71.11, 71.39, 71.67, 71.94, 72.22, 72.50, 72.78, 73.06, 73.33, 73.61, 73.89, 74.17, 74.44, 74.72, 75.00, 75.28, 75.56, 75.83, 76.11, 76.39, 76.67, 76.94, 77.22, 77.50, 77.78, 78.06, 78.33, 78.61, 78.89, 79.17, 79.44, 79.72, 80.00, 80.28, 80.56, 80.83, 81.11, 81.39, 81.67, 81.94, 82.22, 82.50, 82.78, 83.06, 83.33, 83.61, 83.89, 84.17, 84.44, 84.72, 85.00, 85.28, 85.56, 85.83, 86.11, 86.39, 86.67, 86.94, 87.22, 87.50, 87.78, 88.06, 88.33, 88.61, 88.89, 89.17, 89.44, 89.72, 90.00, 90.28, 90.56, 90.83, 91.11, 91.39, 91.67, 91.94, 92.22, 92.50, 92.78, 93.06, 93.33, 93.61, 93.89, 94.17, 94.44, 94.72, 95.00, 95.28, 95.56, 95.83, 96.11, 96.39, 96.67, 96.94, 97.22, 97.50, 97.78, 98.06, 98.33, 98.61, 98.89, 99.17, 99.44, 99.72, 100.00 };
        string[] taco = new string[] { "207", "208", "209", "210L", "210R", "211", "212", "213", "214", "215L", "215R", "216", "217", "218", "219", "220L", "220R", "221", "222", "223", "224L", "224R", "225", "226", "227", "228", "229L", "229R", "230", "231", "232", "233", "234L", "234R", "235", "236", "237", "238L", "238R", "239", "240", "241", "242", "243L", "243R", "244", "245", "246", "247L", "247R", "248", "249", "250", "251", "252L", "252R", "253", "254", "255", "256", "257L", "257R", "258", "259", "260", "261L", "261R", "262", "263", "264", "265", "266L", "266R", "267", "268", "269", "270", "271L", "271R", "272", "273", "274", "275L", "275R", "276", "277", "278", "279", "280L", "280R", "281", "282", "283", "284L", "284R", "285", "286", "287", "288", "289L", "289R", "290", "291", "292", "293", "294L", "294R", "295", "296" };
        double terrenofloat = 0, B8 = 300.4, C8 = 266.9, D8 = 234, B9 = 2.8, C9 = 3, D9 = 3, B10 = 4, C10 = 4, D10 = 3, B112 = 300.4, C112 = 266.9, D112 = 234, B113 = 1.055, C113 = 0.755, D113 = 0.54, J124 = 1.0112, J125 = 1.011, K125 = 0.615, K124 = 0.680, C116 = 0.68, C117 = 0.68, C118 = 0.682, C122 = 0.615, C123 = 0.613, C124 = 0.610, M112 = 0, B116 = 1, B117 = 20, B118 = 40, B122 = -1, B123 = -20, B124 = -40, G119 = 0, M114 = 0, M115 = 0, G113 = 0, G114 = 0, G115 = 0, M116 = 0, F124 = 0, F125 = 0;
        string penis2;

        public Window7()
        {
            InitializeComponent();
        }
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
            double M112 = K124 * Math.Pow(J124, B112 - M117);
            double M113 = K125 * Math.Pow(J125, B112 - M117);
            double AO2 = Math.Sin(angulofloat * 3.14 / 180);
            double AO1 = Math.Cos(angulofloat * 3.14 / 180);
            double G112 = M111 * AO2 * ventofloat;
            double J113 = M111 * ventofloat * AO1;
            double AT1 = AO1;
            M116 = M111 / 4.4 * quebrafloat;
            double K121 = M117 + G119;
            double E9 = K121;
            double E8 = B9 * (E9 - C8) * (E9 - D8) / ((B8 - C8) * (B8 - D8)) + C9 * (E9 - B8) * (E9 - D8) / ((C8 - B8) * (C8 - D8)) + D9 * (E9 - B8) * (E9 - C8) / ((D8 - B8) * (D8 - C8));
            double E10 = B10 * (E9 - C8) * (E9 - D8) / ((B8 - C8) * (B8 - D8)) + C10 * (E9 - B8) * (E9 - D8) / ((C8 - B8) * (C8 - D8)) + D10 * (E9 - B8) * (E9 - C8) / ((D8 - B8) * (D8 - C8));
            double I124 = E8;
            double I125 = E10;
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
            // PEGANDO A PORRA DA POSIÇÃO DA DA PERCENTAGEM
            double numeroBase = F125;
            double numeroDaArray = forca.Aggregate((x, y) => Math.Abs(x - numeroBase) < Math.Abs(y - numeroBase) ? x : y);
            int indice = Array.IndexOf(forca, numeroDaArray);

            double numeroBase2 = F124;
            double numeroDaArray2 = forca.Aggregate((x, y) => Math.Abs(x - numeroBase2) < Math.Abs(y - numeroBase2) ? x : y);
            int indice2 = Array.IndexOf(forca, numeroDaArray2);
            //
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



