using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace g.Helper
{
    /// <summary>
    /// Lógica interna para Window8.xaml
    /// </summary>
    public partial class Window8 : Window
    {
        public Window8()
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
        string[] taco = new string[] { "182", "183L", "183R", "184", "185", "186L", "186R", "187", "188L", "188R", "189", "190", "191L", "191R", "192", "193", "194L", "194R", "195", "196L", "196R", "197", "198", "199L", "199R", "200", "201L", "201R", "202", "203", "204L", "204R", "205", "206", "207L", "207R", "208", "209L", "209R", "210", "211", "212L", "212R", "213", "214L", "214R", "215", "216", "217L", "217R", "218", "219", "220L", "220R", "221", "222L", "222R", "223", "224", "225L", "225R", "226", "227L", "227R", "228", "229", "230L", "230R", "231", "232", "233L", "233R", "234", "235L", "235R", "236", "237", "238L", "238R", "239", "240L", "240R", "241", "242", "243L", "243R", "244", "245", "246L", "246R", "247", "248L", "248R", "249", "250", "251L", "251R", "252", "253L", "253R", "254", "255", "256L", "256R", "257", "258", "259L", "259R", "260" };
        double terrenofloat = 0, B76 = 232.84, C76 = 202.5, D76 = 173.4, B77 = 1.08, C77 = 0.77, D77 = 0.54, C80 = 0.715, C81 = 0.715, C82 = 0.715, C86 = 0.64, C87 = 0.620, C88 = 0.600, B80 = 1, B81 = 20, B82 = 40, B86 = -1, B87 = -20, B88 = -40, J88 = 2.4, J89 = 3.5, K88 = 1.01268, K89 = 1.0118, K90 = 1.0118, L90 = 0.6, M77 = 0, G83 = 0, M78 = 0, M79 = 0, M80 = 0, G76 = 0, G77 = 0, G78 = 0, G79 = 0, J77 = 0, J79 = 0, J80 = 0, J81 = 0, J82 = 0, J84 = 0, J85 = 0, F88 = 0, F89 = 0, G88 = 0, G89 = 0, M84 = 0, M85 = 0, M86 = 0, N84 = 0, N85 = 0, N86 = 0, N88 = 0, N89 = 0, O88 = 0, O89 = 0;
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
            double M81 = Convert.ToDouble(distancia2);
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
                M81 = M81 + 0;
            }
            else if (terrenofloat == 98)
            {
                M81 = M81 + 1.5;
            }
            else if (terrenofloat == 97)
            {
                M81 = M81 + 2.1;
            }
            else if (terrenofloat == 95)
            {
                M81 = M81 + 3.7;
            }
            else if (terrenofloat == 92)
            {
                M81 = M81 + 5.9;
            }
            else if (terrenofloat == 90)
            {
                M81 = M81 + 7.5;
            }
            else if (terrenofloat == 85)
            {
                M81 = M81 + 11.5;
            }
            else if (terrenofloat == 80)
            {
                M81 = M81 + 16;
            }
            else if (terrenofloat == 75)
            {
                M81 = M81 + 20.75;
            }
            else if (terrenofloat == 70)
            {
                M81 = M81 + 24.75;
            }
            #endregion
            double angulofloat = Convert.ToDouble(angulo2);
            double B83 = alturafloat, B89 = alturafloat;
            double C83 = C80 * (B83 - B81) * (B83 - B82) / ((B80 - B81) * (B80 - B82)) + C81 * (B83 - B80) * (B83 - B82) / ((B81 - B80) * (B81 - B82)) + C82 * (B83 - B80) * (B83 - B81) / ((B82 - B80) * (B82 - B81));
            double L88 = C83;
            double C89 = C86 * (B89 - B87) * (B89 - B88) / ((B86 - B87) * (B86 - B88)) + C87 * (B89 - B86) * (B89 - B88) / ((B87 - B86) * (B87 - B88)) + C88 * (B89 - B86) * (B89 - B87) / ((B88 - B86) * (B88 - B87));
            double L89 = C89;
            double M75 = B77 * (M81 - C76) * (M81 - D76) / ((B76 - C76) * (B76 - D76)) + C77 * (M81 - B76) * (M81 - D76) / ((C76 - B76) * (C76 - D76)) + D77 * (M81 - B76) * (M81 - C76) / ((D76 - B76) * (D76 - C76));
            double M76 = L88 * Math.Pow(K88, (B76 - M81));
            M80 = M75 / 4.25 * quebrafloat;
            double AO2 = Math.Sin(angulofloat * 3.14 / 180);
            double AO1 = Math.Cos(angulofloat * 3.14 / 180);
            double AT1 = AO1;
            //=SE(Calculadora!B62>-30;L89*POTÊNCIA(K89;(B76-M81));L90*POTÊNCIA(K90;(B76-M81)))
            double B62 = 0;
            if (B62 > -30)
            {
                M77 = L89 * Math.Pow(K89, (B76 - M81));
            }
            else
            {
                M77 = L90 * Math.Pow(K90, (B76 - M81));
            }
            //=SE(Calculadora!$B$2>0;Calculadora!$B$2*M76;Calculadora!$B$2*M77)
            if (alturafloat > 0)
            {
                G83 = alturafloat * M76;
            }
            else
            {
                G83 = alturafloat * M77;
            }
            //=SE((M81>0);((100+(G83/-J88))/100))
            if (M81 > 0)
            {
                M78 = ((100 + (G83 / -J88)) / 100);
            }
            //=SE((M81>0);((100+(G83/-J89))/100))
            if (M81 > 0)
            {
                M79 = ((100 + (G83 / -J89)) / 100);
            }
            G76 = M75 * AO2 * ventofloat;
            //=SE(G83>0;G76*M78;G76*M79)
            if (G83 > 0)
            {
                G77 = G76 * M78;
            }
            else
            {
                G77 = G76 * M79;
            }
            J77 = M75 * ventofloat * AO1;
            //=$AT$1*Calculadora!$B$3*M75*1*(1-(G83*0,016))
            J79 = AT1 * ventofloat * M75 * 1 * (1 - (G83 * 0.016));
            //=$AT$1*Calculadora!$B$3*M75*1,25*(1-(G83*0,016))
            J80 = AT1 * ventofloat * M75 * 1.25 * (1 - (G83 * 0.016));
            J81 = (100 + (J79 * 2.75 / -4)) / 100;
            J82 = (100 + (J80 * 4 / -6.25)) / 100;
            J84 = M81 + G83 - J79;
            J85 = M81 + G83 + J80;
            G78 = G77 * J81;
            G79 = G77 / J82;
            //=SE(J84<=C76;80+(J84-D76)/((C76-D76)/10);90+(J84-C76)/((B76-C76)/10))
            if (J84 < C76)
            {
                F88 = 80 + (J84 - D76) / ((C76 - D76) / 10);
            }
            else
            {
                F88 = 90 + (J84 - C76) / ((B76 - C76) / 10);
            }
            //= SE(J85 <= C76; 80 + (J85 - D76) / ((C76 - D76) / 10); 90 + (J85 - C76) / ((B76 - C76) / 10))
            if (J85 <= C76)
            {
                F89 = 80 + (J85 - D76) / ((C76 - D76) / 10);
            }
            else
            {
                F89 = 90 + (J85 - C76) / ((B76 - C76) / 10);
            }
            G88 = G78 + M80;
            G89 = G79 + M80;
            M84 = F88 % 0.27777777777;
            M85 = M84 / 0.27777777777;
            //=SE(M85<0,288;ARREDONDAR.PARA.BAIXO(M85;0);ARREDONDAR.PARA.CIMA(M85;0))
            if (M85 < 0.288)
            {
                M86 = Math.Floor(M85);
            }
            else
            {
                M86 = Math.Ceiling(M85);
            }
            N84 = F89 % 0.27777777777;
            N85 = N84 / 0.27777777777;
            //=SE(N85<0,288;ARREDONDAR.PARA.BAIXO(N85;0);ARREDONDAR.PARA.CIMA(N85;0))
            if (N85 < 0.288)
            {
                N86 = Math.Floor(N85);
            }
            else
            {
                N86 = Math.Ceiling(N85);
            }
            //=SE(M84>(20/72)-0,08;9;8)
            if (M84 > 0.27777777777 - 0.08)
            {
                N89 = 9;
            }
            else
            {
                N89 = 8;
            }
            //=SE(M84<0,08;9;N89)
            if (M84 < 0.08)
            {
                N88 = 9;
            }
            else
            {
                N88 = N89;
            }
            //=SE(N84>(20/72)-0,08;9;8)
            if (N84 > 0.27777777777 - 0.08)
            {
                O89 = 9;
            }
            else
            {
                O89 = 8;
            }
            //=SE(N84<0,08;9;O89)
            if (N84 < 0.08)
            {
                O88 = 9;
            }
            else
            {
                O88 = O89;
            }
            double numeroBase = F89;
            double numeroDaArray = forca.Aggregate((x, y) => Math.Abs(x - numeroBase) < Math.Abs(y - numeroBase) ? x : y);
            int indice = Array.IndexOf(forca, numeroDaArray);

            double numeroBase2 = F88;
            double numeroDaArray2 = forca.Aggregate((x, y) => Math.Abs(x - numeroBase2) < Math.Abs(y - numeroBase2) ? x : y);
            int indice2 = Array.IndexOf(forca, numeroDaArray2);

            string forcafront = taco[indice];
            string forcaback = taco[indice2];

            forcaback2.Text = forcafront;
            forcafront2.Text = forcaback;
            G89 = G89 / 0.2165; //back
            G88 = G88 / 0.2165; //front
            G88 = Math.Round(G88, 2); //front
            G89 = Math.Round(G89, 2); //back
            F88 = Math.Round(F88, 2); //front
            F89 = Math.Round(F89, 2); //back
            ffpercent.Text = Convert.ToString(F88 + "%");
            fbpercent.Text = Convert.ToString(F89 + "%");
            pbfront2.Text = Convert.ToString(G88);
            pbback2.Text = Convert.ToString(G89);
            spinfront2.Text = Convert.ToString(N88);
            spinback2.Text = Convert.ToString(O88);
            Close();
        }
    }
}
