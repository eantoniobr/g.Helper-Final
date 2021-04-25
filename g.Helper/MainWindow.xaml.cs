using System.Threading;
using System.Windows;
using System.Windows.Input;
using Memory;
using System.ComponentModel;
using System.Windows.Media;
using System;



namespace g.Helper
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public Mem m = new Mem();
        private BackgroundWorker BGW = new BackgroundWorker();
        double auxdistancia = 0, auxterreno2, distmaisterreno = 0, pbaux = 0, pbaux2 = 0, pbaux3 =0, auxpba = 0, auxpba2 = 0;
        public bool penis;

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/sj3qEva7");
            System.Diagnostics.Process.Start("https://github.com/lbarceloss");
        }

        private void Hyperlink_RequestNavigate_1(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/leonardo.barcelos.5454/");
            System.Diagnostics.Process.Start("https://github.com/lbarceloss");
        }

        public string spinauto { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            InitializeComponent();
            BGW.DoWork += BGW_DoWork;
            BGW.RunWorkerCompleted += BGW_RunWorkerCompleted;
            BGW.ProgressChanged += BGW_ProgressChanged;
            BGW.WorkerReportsProgress = true;
            BGW.WorkerSupportsCancellation = true;
        }
        bool Aberto = false;
        private void BGW_DoWork(object sender, DoWorkEventArgs e)
        {
            Aberto = m.OpenProcess("ProjectG");
            if (!Aberto)
            {
                Thread.Sleep(1000);
                return;
            }

            Thread.Sleep(200);
            BGW.ReportProgress(0);
        }
        private void BGW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (Aberto)
                processo.Content = "Pangya Brasil";
            processo.Foreground = Brushes.Green;
        }
        private void BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BGW.RunWorkerAsync();

            #region Spin (100%)
            float spin = m.ReadFloat("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24");
            if (spin < 0)
            {
                spin = spin * -1;
            }
            spintext.Text = Convert.ToString(spin);
            #endregion
            #region Curve (100%)
            float curve = m.ReadFloat("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20");
            if (curve < 0)
            {
                curve = curve * -1;
            }
            curvatext.Text = Convert.ToString(curve);
            #endregion
            #region Inclinação (Desativado para fase de teste da calculadora)
            float eixox = m.ReadFloat("ProjectG.exe+007229D8,0x1C,0x20,0x3C,0x0,0x0,0x1C4,0x24");
            float eixoy = m.ReadFloat("ProjectG.exe+007229D8,0x9C,0x28,0x20,0x18,0x0,0x1C4,0x1C");
            // Infelizmente não consegui trazer para uma forma mais simples, então so tera na versão PRO.
            #endregion
            #region Altura (100%)
            float altura = m.ReadFloat("ProjectG.exe+007229D8,0x1C,0x20,0x18,0x0,0x1C0,0x0,0x20");
            alturatext.Text = Convert.ToString(altura);
            #endregion
            #region Terreno (100%)
            int terreno = m.ReadInt("ProjectG.exe+007229D8,0x1C,0x20,0x10,0x0,0x0,0x1C4,0x84");
            terreno = 100 - terreno;
            terrenotext.Text = Convert.ToString(terreno + "%");
            #endregion
            #region Nome (100%)
            var nomes = m.ReadString("ProjectG.exe+006A002C,0xFA8");
            Nome.Content = nomes;
            #endregion
            #region Angulo (Para entendimento do funcionamento)
            
            double minangulo = -0.9998719096;
            double maxangulo = 0.9998719096;
            double angulo = m.ReadFloat("ProjectG.exe+007229D8,0x1C,0x20,0x10,0x0,0x0,0x1DC,0x68", "", false);  //Seno
            double angulo2 = m.ReadFloat("ProjectG.exe+007229D8,0x1C,0x10,0x10,0x30,0x0,0x1DC,0x70", "", false); //Cosseno
            if (angulo > maxangulo)
            {
                angulotext.Text = "90";
            }
            else
            {
                if (angulo < minangulo)
                {
                    angulotext.Text = "90";
                }
                else
                {
                    double auxangulo = angulo, auxangulo2 = 0;
                    if (auxangulo < 0)
                    {
                        auxangulo = auxangulo * -1;
                    }
                    auxangulo2 = Math.Asin(auxangulo) * 182 / 3.145;
                    auxangulo2 = Math.Round(auxangulo2, 2);
                    angulotext.Text = Convert.ToString(auxangulo2);
                }
            }
            
            #endregion
            #region Força do Vento (100%)
            string vento = m.ReadString("ProjectG.exe+007229D8,0x1C,0x20,0x18,0x0,0x1C8,0x14,0x0", "");
            if (vento == "1m" || vento == "2m" || vento == "3m" || vento == "4m" || vento == "5m" || vento == "6m" || vento == "7m" || vento == "8m" || vento == "9m")
            {
                ventotext.Text = Convert.ToString(vento);
            }
            else
            {
                ventotext.Text = "0";
            }
            #endregion 
            #region Distancia (100%)
            float distancia = m.ReadFloat("ProjectG.exe+007229D8,0x1C,0x18,0x14,0x14,0x0,0x0,0x1C0,0x0,0x34,0x18", "", false);
            double distancia2 = Math.Round(distancia, 2);
            distanciatext.Text = Convert.ToString(distancia2);
            #endregion
            #region Checagem de Toma & Dunk (100%)
            auxdistancia = Convert.ToDouble(distancia2);
            if (terrenotext.Text == "100%")
            {
                var auxterreno = terrenotext.Text.Substring(0, 3);
                auxterreno2 = Convert.ToDouble(auxterreno);
            }
            else
            {
                var auxterreno = terrenotext.Text.Substring(0, 2);
                auxterreno2 = Convert.ToDouble(auxterreno);
            }
            distmaisterreno = ((auxdistancia * (auxterreno2 / 100)) - altura);
            if (distmaisterreno > 236 && distmaisterreno < 300) //1W TOMA
            {
                tomacheck1w.Background = Brushes.Green;
            }
            if (distmaisterreno > 215 && distmaisterreno < 280) //2W TOMA
            {
                tomacheck2w.Background = Brushes.Green;
            }
            if (distmaisterreno > 192 && distmaisterreno < 260) //3W TOMA
            {
                tomacheck3w.Background = Brushes.Green;
            }
            if (distmaisterreno > 100 && distmaisterreno < 260) //1W DUNK
            {
                dunkcheck1w.Background = Brushes.Green;
            }
            if (distmaisterreno > 182 && distmaisterreno < 250) //2W DUNK
            {
                dunkcheck2w.Background = Brushes.Green;
            }
            if (distmaisterreno > 175 && distmaisterreno < 210) //3W DUNK
            {
                dunkcheck3w.Background = Brushes.Green;
            }
            #endregion
            #region Chat (100%)
            string chat = m.ReadString("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "", 12);
            #endregion
            #region Comandos Dunk Front
            if (chat == "/dunk 1w" || chat == "/d1")
            {
                if (angulo > 0 && angulo2 > 0 || angulo < 0 && angulo2 > 0) 
                { 
                    Window10 dunk1w = new Window10();
                    dunk1w.altura2 = alturatext.Text;
                    dunk1w.terreno2 = terrenotext.Text;
                    dunk1w.angulo2 = angulotext.Text;
                    dunk1w.vento2 = ventotext.Text;
                    dunk1w.distancia2 = distanciatext.Text;
                    dunk1w.quebra2 = quebratext.Text;
                    dunk1w.Show();
                    m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
                    pbresultado.Text = dunk1w.pbfront2.Text;
                    pbaux = Convert.ToDouble(pbresultado.Text);
                    pbaux2 = Math.Ceiling(pbaux) / 8.86836027;
                    pbaux3 = pbaux % (1.92 / 0.2165);
                    pbaux3 = Math.Round(pbaux3, 2);
                    if (pbaux2 < 1)
                    {
                        pbaux2 = 0;
                    }
                    else if (pbaux2 < 2 && pbaux2 > 1)
                    {
                        pbaux2 = 1;
                    }
                    else if (pbaux2 < 3 && pbaux2 > 2)
                    {
                        pbaux2 = 2;
                    }
                    else if (pbaux2 < 4 && pbaux2 > 3)
                    {
                        pbaux2 = 3;
                    }
                    else if (pbaux2 < 5 && pbaux2 > 4)
                    {
                        pbaux2 = 4;
                    }
                    else if (pbaux2 < 6 && pbaux2 > 5)
                    {
                        pbaux2 = 5;
                    }
                    else if (pbaux2 < 7 && pbaux2 > 6)
                    {
                        pbaux2 = 6;
                    }
                    clickresultado.Text = Convert.ToString(pbaux2);
                    restoresultado.Text = Convert.ToString(pbaux3);
                    porcentagemresultado.Text = dunk1w.ffpercent.Text;
                    spinresultado.Text = dunk1w.spinfront2.Text;
                    calibradorresultado.Text = dunk1w.forcafront2.Text;
                    spinauto = dunk1w.spinfront2.Text;
                    double setspin = Convert.ToDouble(spinauto);
                    if (setspin == 9)
                    {
                        m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "9");
                    }
                    else
                    {
                        m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "8");
                    }
                }
                else
                {
                    Window10 dunk1w = new Window10();
                    dunk1w.altura2 = alturatext.Text;
                    dunk1w.terreno2 = terrenotext.Text;
                    dunk1w.angulo2 = angulotext.Text;
                    dunk1w.vento2 = ventotext.Text;
                    dunk1w.distancia2 = distanciatext.Text;
                    dunk1w.quebra2 = quebratext.Text;
                    dunk1w.Show();
                    m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
                    pbresultado.Text = dunk1w.pbback2.Text;
                    pbaux = Convert.ToDouble(pbresultado.Text);
                    pbaux2 = Math.Ceiling(pbaux) / 8.86836027;
                    pbaux3 = pbaux % (1.92 / 0.2165);
                    pbaux3 = Math.Round(pbaux3, 2);
                    if (pbaux2 < 1)
                    {
                        pbaux2 = 0;
                    }
                    else if (pbaux2 < 2 && pbaux2 > 1)
                    {
                        pbaux2 = 1;
                    }
                    else if (pbaux2 < 3 && pbaux2 > 2)
                    {
                        pbaux2 = 2;
                    }
                    else if (pbaux2 < 4 && pbaux2 > 3)
                    {
                        pbaux2 = 3;
                    }
                    else if (pbaux2 < 5 && pbaux2 > 4)
                    {
                        pbaux2 = 4;
                    }
                    else if (pbaux2 < 6 && pbaux2 > 5)
                    {
                        pbaux2 = 5;
                    }
                    else if (pbaux2 < 7 && pbaux2 > 6)
                    {
                        pbaux2 = 6;
                    }
                    clickresultado.Text = Convert.ToString(pbaux2);
                    restoresultado.Text = Convert.ToString(pbaux3);
                    porcentagemresultado.Text = dunk1w.fbpercent.Text;
                    spinresultado.Text = dunk1w.spinback2.Text;
                    calibradorresultado.Text = dunk1w.forcaback2.Text;
                    spinauto = dunk1w.spinback2.Text;
                    double setspin = Convert.ToDouble(spinauto);
                    if (setspin == 9)
                    {
                        m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "9");
                    }
                    else
                    {
                        m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "8");
                    }
                }
            }
            if (chat == "/dunk 2w" || chat == "/d2")
            {
                if (angulo > 0 && angulo2 > 0 || angulo < 0 && angulo2 > 0)
                {
                    Window8 dunk2w = new Window8();
                    dunk2w.altura2 = alturatext.Text;
                    dunk2w.terreno2 = terrenotext.Text;
                    dunk2w.angulo2 = angulotext.Text;
                    dunk2w.vento2 = ventotext.Text;
                    dunk2w.distancia2 = distanciatext.Text;
                    dunk2w.quebra2 = quebratext.Text;
                    dunk2w.Show();
                    m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
                    pbresultado.Text = dunk2w.pbfront2.Text;
                    pbaux = Convert.ToDouble(pbresultado.Text);
                    pbaux2 = Math.Ceiling(pbaux) / 8.86836027;
                    pbaux3 = pbaux % (1.92 / 0.2165);
                    pbaux3 = Math.Round(pbaux3, 2);
                    if (pbaux2 < 1)
                    {
                        pbaux2 = 0;
                    }
                    else if (pbaux2 < 2 && pbaux2 > 1)
                    {
                        pbaux2 = 1;
                    }
                    else if (pbaux2 < 3 && pbaux2 > 2)
                    {
                        pbaux2 = 2;
                    }
                    else if (pbaux2 < 4 && pbaux2 > 3)
                    {
                        pbaux2 = 3;
                    }
                    else if (pbaux2 < 5 && pbaux2 > 4)
                    {
                        pbaux2 = 4;
                    }
                    else if (pbaux2 < 6 && pbaux2 > 5)
                    {
                        pbaux2 = 5;
                    }
                    else if (pbaux2 < 7 && pbaux2 > 6)
                    {
                        pbaux2 = 6;
                    }
                    clickresultado.Text = Convert.ToString(pbaux2);
                    restoresultado.Text = Convert.ToString(pbaux3);
                    porcentagemresultado.Text = dunk2w.ffpercent.Text;
                    spinresultado.Text = dunk2w.spinfront2.Text;
                    calibradorresultado.Text = dunk2w.forcafront2.Text;
                    spinauto = dunk2w.spinfront2.Text;
                    double setspin = Convert.ToDouble(spinauto);
                    if (setspin == 9)
                    {
                        m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "9");
                    }
                    else
                    {
                        m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "8");
                    }

                }
                else
                {
                    Window8 dunk2w = new Window8();
                    dunk2w.altura2 = alturatext.Text;
                    dunk2w.terreno2 = terrenotext.Text;
                    dunk2w.angulo2 = angulotext.Text;
                    dunk2w.vento2 = ventotext.Text;
                    dunk2w.distancia2 = distanciatext.Text;
                    dunk2w.quebra2 = quebratext.Text;
                    dunk2w.Show();
                    m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
                    pbresultado.Text = dunk2w.pbback2.Text;
                    pbaux = Convert.ToDouble(pbresultado.Text);
                    pbaux2 = Math.Ceiling(pbaux) / 8.86836027;
                    pbaux3 = pbaux % (1.92 / 0.2165);
                    pbaux3 = Math.Round(pbaux3, 2);
                    if (pbaux2 < 1)
                    {
                        pbaux2 = 0;
                    }
                    else if (pbaux2 < 2 && pbaux2 > 1)
                    {
                        pbaux2 = 1;
                    }
                    else if (pbaux2 < 3 && pbaux2 > 2)
                    {
                        pbaux2 = 2;
                    }
                    else if (pbaux2 < 4 && pbaux2 > 3)
                    {
                        pbaux2 = 3;
                    }
                    else if (pbaux2 < 5 && pbaux2 > 4)
                    {
                        pbaux2 = 4;
                    }
                    else if (pbaux2 < 6 && pbaux2 > 5)
                    {
                        pbaux2 = 5;
                    }
                    else if (pbaux2 < 7 && pbaux2 > 6)
                    {
                        pbaux2 = 6;
                    }
                    clickresultado.Text = Convert.ToString(pbaux2);
                    restoresultado.Text = Convert.ToString(pbaux3);
                    porcentagemresultado.Text = dunk2w.fbpercent.Text;
                    spinresultado.Text = dunk2w.spinback2.Text;
                    calibradorresultado.Text = dunk2w.forcaback2.Text;
                    spinauto = dunk2w.spinback2.Text;
                    double setspin = Convert.ToDouble(spinauto);
                    if (setspin == 9)
                    {
                        m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "9");
                    }
                    else
                    {
                        m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "8");
                    }
                }
            }
            if (chat == "/dunk 3w" || chat == "/d3")
            {
                if (angulo > 0 && angulo2 > 0 || angulo < 0 && angulo2 > 0)
                {
                    Window9 dunk3w = new Window9();
                    dunk3w.altura2 = alturatext.Text;
                    dunk3w.terreno2 = terrenotext.Text;
                    dunk3w.angulo2 = angulotext.Text;
                    dunk3w.vento2 = ventotext.Text;
                    dunk3w.distancia2 = distanciatext.Text;
                    dunk3w.quebra2 = quebratext.Text;
                    dunk3w.Show();
                    m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
                    pbresultado.Text = dunk3w.pbfront2.Text;
                    pbaux = Convert.ToDouble(pbresultado.Text);
                    pbaux2 = Math.Ceiling(pbaux) / 8.86836027;
                    pbaux3 = pbaux % (1.92 / 0.2165);
                    pbaux3 = Math.Round(pbaux3, 2);
                    if (pbaux2 < 1)
                    {
                        pbaux2 = 0;
                    }
                    else if (pbaux2 < 2 && pbaux2 > 1)
                    {
                        pbaux2 = 1;
                    }
                    else if (pbaux2 < 3 && pbaux2 > 2)
                    {
                        pbaux2 = 2;
                    }
                    else if (pbaux2 < 4 && pbaux2 > 3)
                    {
                        pbaux2 = 3;
                    }
                    else if (pbaux2 < 5 && pbaux2 > 4)
                    {
                        pbaux2 = 4;
                    }
                    else if (pbaux2 < 6 && pbaux2 > 5)
                    {
                        pbaux2 = 5;
                    }
                    else if (pbaux2 < 7 && pbaux2 > 6)
                    {
                        pbaux2 = 6;
                    }
                    clickresultado.Text = Convert.ToString(pbaux2);
                    restoresultado.Text = Convert.ToString(pbaux3);
                    porcentagemresultado.Text = dunk3w.ffpercent.Text;
                    spinresultado.Text = dunk3w.spinfront2.Text;
                    calibradorresultado.Text = dunk3w.forcafront2.Text;
                    spinauto = dunk3w.spinfront2.Text;
                    double setspin = Convert.ToDouble(spinauto);
                    if (setspin == 9)
                    {
                        m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "9");
                    }
                    else
                    {
                        m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "8");
                    }
                }
                else
                {
                    Window9 dunk3w = new Window9();
                    dunk3w.altura2 = alturatext.Text;
                    dunk3w.terreno2 = terrenotext.Text;
                    dunk3w.angulo2 = angulotext.Text;
                    dunk3w.vento2 = ventotext.Text;
                    dunk3w.distancia2 = distanciatext.Text;
                    dunk3w.quebra2 = quebratext.Text;
                    dunk3w.Show();
                    m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
                    pbresultado.Text = dunk3w.pbback2.Text;
                    pbaux = Convert.ToDouble(pbresultado.Text);
                    pbaux2 = Math.Ceiling(pbaux) / 8.86836027;
                    pbaux3 = pbaux % (1.92 / 0.2165);
                    pbaux3 = Math.Round(pbaux3, 2);
                    if (pbaux2 < 1)
                    {
                        pbaux2 = 0;
                    }
                    else if (pbaux2 < 2 && pbaux2 > 1)
                    {
                        pbaux2 = 1;
                    }
                    else if (pbaux2 < 3 && pbaux2 > 2)
                    {
                        pbaux2 = 2;
                    }
                    else if (pbaux2 < 4 && pbaux2 > 3)
                    {
                        pbaux2 = 3;
                    }
                    else if (pbaux2 < 5 && pbaux2 > 4)
                    {
                        pbaux2 = 4;
                    }
                    else if (pbaux2 < 6 && pbaux2 > 5)
                    {
                        pbaux2 = 5;
                    }
                    else if (pbaux2 < 7 && pbaux2 > 6)
                    {
                        pbaux2 = 6;
                    }
                    clickresultado.Text = Convert.ToString(pbaux2);
                    restoresultado.Text = Convert.ToString(pbaux3);
                    porcentagemresultado.Text = dunk3w.fbpercent.Text;
                    spinresultado.Text = dunk3w.spinback2.Text;
                    calibradorresultado.Text = dunk3w.forcaback2.Text;
                    spinauto = dunk3w.spinback2.Text;
                    double setspin = Convert.ToDouble(spinauto);
                    if (setspin == 9)
                    {
                        m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "9");
                    }
                    else
                    {
                        m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "8");
                    }
                }
            }
            #endregion
            #region Comandos Toma
            if (chat == "/toma 1w" || chat == "/t1")
            {
                if (angulo > 0 && angulo2 > 0 || angulo < 0 && angulo2 > 0)
                {
                    Window7 toma1 = new Window7();
                    toma1.altura2 = alturatext.Text;
                    toma1.terreno2 = terrenotext.Text;
                    toma1.angulo2 = angulotext.Text;
                    toma1.vento2 = ventotext.Text;
                    toma1.distancia2 = distanciatext.Text;
                    toma1.quebra2 = quebratext.Text;
                    toma1.Show();
                    m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
                    pbresultado.Text = toma1.pbfront2.Text;
                    pbaux = Convert.ToDouble(pbresultado.Text);
                    pbaux2 = Math.Ceiling(pbaux) / 8.86836027;
                    pbaux3 = pbaux % (1.92 / 0.2165);
                    pbaux3 = Math.Round(pbaux3, 2);
                    if (pbaux2 < 1)
                    {
                        pbaux2 = 0;
                    }
                    else if (pbaux2 < 2 && pbaux2 > 1)
                    {
                        pbaux2 = 1;
                    }
                    else if (pbaux2 < 3 && pbaux2 > 2)
                    {
                        pbaux2 = 2;
                    }
                    else if (pbaux2 < 4 && pbaux2 > 3)
                    {
                        pbaux2 = 3;
                    }
                    else if (pbaux2 < 5 && pbaux2 > 4)
                    {
                        pbaux2 = 4;
                    }
                    else if (pbaux2 < 6 && pbaux2 > 5)
                    {
                        pbaux2 = 5;
                    }
                    else if (pbaux2 < 7 && pbaux2 > 6)
                    {
                        pbaux2 = 6;
                    }
                    clickresultado.Text = Convert.ToString(pbaux2);
                    restoresultado.Text = Convert.ToString(pbaux3);
                    porcentagemresultado.Text = toma1.ffpercent.Text;
                    calibradorresultado.Text = toma1.forcafront2.Text;
                    m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
                    m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "7");
                }
                else
                {
                    Window7 toma1 = new Window7();
                    toma1.altura2 = alturatext.Text;
                    toma1.terreno2 = terrenotext.Text;
                    toma1.angulo2 = angulotext.Text;
                    toma1.vento2 = ventotext.Text;
                    toma1.distancia2 = distanciatext.Text;
                    toma1.quebra2 = quebratext.Text;
                    toma1.Show();
                    m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
                    pbresultado.Text = toma1.pbback2.Text;
                    pbaux = Convert.ToDouble(pbresultado.Text);
                    pbaux2 = Math.Ceiling(pbaux) / 8.86836027;
                    pbaux3 = pbaux % (1.92 / 0.2165);
                    pbaux3 = Math.Round(pbaux3, 2);
                    if (pbaux2 < 1)
                    {
                        pbaux2 = 0;
                    }
                    else if (pbaux2 < 2 && pbaux2 > 1)
                    {
                        pbaux2 = 1;
                    }
                    else if (pbaux2 < 3 && pbaux2 > 2)
                    {
                        pbaux2 = 2;
                    }
                    else if (pbaux2 < 4 && pbaux2 > 3)
                    {
                        pbaux2 = 3;
                    }
                    else if (pbaux2 < 5 && pbaux2 > 4)
                    {
                        pbaux2 = 4;
                    }
                    else if (pbaux2 < 6 && pbaux2 > 5)
                    {
                        pbaux2 = 5;
                    }
                    else if (pbaux2 < 7 && pbaux2 > 6)
                    {
                        pbaux2 = 6;
                    }
                    clickresultado.Text = Convert.ToString(pbaux2);
                    restoresultado.Text = Convert.ToString(pbaux3);
                    porcentagemresultado.Text = toma1.fbpercent.Text;
                    calibradorresultado.Text = toma1.forcaback2.Text;
                    m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
                    m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "7");
                }
            }
            if (chat == "/toma 2w" || chat == "/t2")
            {
                if (angulo > 0 && angulo2 > 0 || angulo < 0 && angulo2 > 0)
                {
                    Window6 toma3 = new Window6();
                    toma3.altura2 = alturatext.Text;
                    toma3.terreno2 = terrenotext.Text;
                    toma3.angulo2 = angulotext.Text;
                    toma3.vento2 = ventotext.Text;
                    toma3.distancia2 = distanciatext.Text;
                    toma3.quebra2 = quebratext.Text;
                    toma3.Show();
                    m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
                    pbresultado.Text = toma3.pbfront2.Text;
                    pbaux = Convert.ToDouble(pbresultado.Text);
                    pbaux2 = Math.Ceiling(pbaux) / 8.86836027;
                    pbaux3 = pbaux % (1.92 / 0.2165);
                    pbaux3 = Math.Round(pbaux3, 2);
                    if (pbaux2 < 1)
                    {
                        pbaux2 = 0;
                    }
                    else if (pbaux2 < 2 && pbaux2 > 1)
                    {
                        pbaux2 = 1;
                    }
                    else if (pbaux2 < 3 && pbaux2 > 2)
                    {
                        pbaux2 = 2;
                    }
                    else if (pbaux2 < 4 && pbaux2 > 3)
                    {
                        pbaux2 = 3;
                    }
                    else if (pbaux2 < 5 && pbaux2 > 4)
                    {
                        pbaux2 = 4;
                    }
                    else if (pbaux2 < 6 && pbaux2 > 5)
                    {
                        pbaux2 = 5;
                    }
                    else if (pbaux2 < 7 && pbaux2 > 6)
                    {
                        pbaux2 = 6;
                    }
                    clickresultado.Text = Convert.ToString(pbaux2);
                    restoresultado.Text = Convert.ToString(pbaux3);
                    porcentagemresultado.Text = toma3.ffpercent.Text;
                    calibradorresultado.Text = toma3.forcafront2.Text;
                    m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
                    m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "7");
                }
                else
                {
                    Window6 toma3 = new Window6();
                    toma3.altura2 = alturatext.Text;
                    toma3.terreno2 = terrenotext.Text;
                    toma3.angulo2 = angulotext.Text;
                    toma3.vento2 = ventotext.Text;
                    toma3.distancia2 = distanciatext.Text;
                    toma3.quebra2 = quebratext.Text;
                    toma3.Show();
                    m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
                    pbresultado.Text = toma3.pbback2.Text;
                    pbaux = Convert.ToDouble(pbresultado.Text);
                    pbaux2 = Math.Ceiling(pbaux) / 8.86836027;
                    pbaux3 = pbaux % (1.92 / 0.2165);
                    pbaux3 = Math.Round(pbaux3, 2);
                    if (pbaux2 < 1)
                    {
                        pbaux2 = 0;
                    }
                    else if (pbaux2 < 2 && pbaux2 > 1)
                    {
                        pbaux2 = 1;
                    }
                    else if (pbaux2 < 3 && pbaux2 > 2)
                    {
                        pbaux2 = 2;
                    }
                    else if (pbaux2 < 4 && pbaux2 > 3)
                    {
                        pbaux2 = 3;
                    }
                    else if (pbaux2 < 5 && pbaux2 > 4)
                    {
                        pbaux2 = 4;
                    }
                    else if (pbaux2 < 6 && pbaux2 > 5)
                    {
                        pbaux2 = 5;
                    }
                    else if (pbaux2 < 7 && pbaux2 > 6)
                    {
                        pbaux2 = 6;
                    }
                    clickresultado.Text = Convert.ToString(pbaux2);
                    restoresultado.Text = Convert.ToString(pbaux3);
                    porcentagemresultado.Text = toma3.fbpercent.Text;
                    calibradorresultado.Text = toma3.forcaback2.Text;
                    m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
                    m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "7");
                }
            }
            if (chat == "/toma 3w" || chat == "/t3")
            {
                {
                    if (angulo > 0 && angulo2 > 0 || angulo < 0 && angulo2 > 0)
                    {
                        Window4 toma4 = new Window4();
                        toma4.altura2 = alturatext.Text;
                        toma4.terreno2 = terrenotext.Text;
                        toma4.angulo2 = angulotext.Text;
                        toma4.vento2 = ventotext.Text;
                        toma4.distancia2 = distanciatext.Text;
                        toma4.quebra2 = quebratext.Text;
                        toma4.Show();
                        m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
                        pbresultado.Text = toma4.pbfront2.Text;
                        pbaux = Convert.ToDouble(pbresultado.Text);
                        pbaux2 = Math.Ceiling(pbaux) / 8.86836027;
                        pbaux3 = pbaux % (1.92 / 0.2165);
                        pbaux3 = Math.Round(pbaux3, 2);
                        if (pbaux2 < 1)
                        {
                            pbaux2 = 0;
                        }
                        else if (pbaux2 < 2 && pbaux2 > 1)
                        {
                            pbaux2 = 1;
                        }
                        else if (pbaux2 < 3 && pbaux2 > 2)
                        {
                            pbaux2 = 2;
                        }
                        else if (pbaux2 < 4 && pbaux2 > 3)
                        {
                            pbaux2 = 3;
                        }
                        else if (pbaux2 < 5 && pbaux2 > 4)
                        {
                            pbaux2 = 4;
                        }
                        else if (pbaux2 < 6 && pbaux2 > 5)
                        {
                            pbaux2 = 5;
                        }
                        else if (pbaux2 < 7 && pbaux2 > 6)
                        {
                            pbaux2 = 6;
                        }
                        clickresultado.Text = Convert.ToString(pbaux2);
                        restoresultado.Text = Convert.ToString(pbaux3);
                        porcentagemresultado.Text = toma4.ffpercent.Text;
                        calibradorresultado.Text = toma4.forcafront2.Text;
                        m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
                        m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "7");
                    }
                    else
                    {
                        Window4 toma4 = new Window4();
                        toma4.altura2 = alturatext.Text;
                        toma4.terreno2 = terrenotext.Text;
                        toma4.angulo2 = angulotext.Text;
                        toma4.vento2 = ventotext.Text;
                        toma4.distancia2 = distanciatext.Text;
                        toma4.quebra2 = quebratext.Text;
                        toma4.Show();
                        m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
                        pbresultado.Text = toma4.pbback2.Text;
                        pbaux = Convert.ToDouble(pbresultado.Text);
                        pbaux2 = Math.Ceiling(pbaux) / 8.86836027;
                        pbaux3 = pbaux % (1.92 / 0.2165);
                        pbaux3 = Math.Round(pbaux3, 2);
                        if (pbaux2 < 1)
                        {
                            pbaux2 = 0;
                        }
                        else if (pbaux2 < 2 && pbaux2 > 1)
                        {
                            pbaux2 = 1;
                        }
                        else if (pbaux2 < 3 && pbaux2 > 2)
                        {
                            pbaux2 = 2;
                        }
                        else if (pbaux2 < 4 && pbaux2 > 3)
                        {
                            pbaux2 = 3;
                        }
                        else if (pbaux2 < 5 && pbaux2 > 4)
                        {
                            pbaux2 = 4;
                        }
                        else if (pbaux2 < 6 && pbaux2 > 5)
                        {
                            pbaux2 = 5;
                        }
                        else if (pbaux2 < 7 && pbaux2 > 6)
                        {
                            pbaux2 = 6;
                        }
                        clickresultado.Text = Convert.ToString(pbaux2);
                        restoresultado.Text = Convert.ToString(pbaux3);
                        porcentagemresultado.Text = toma4.fbpercent.Text;
                        calibradorresultado.Text = toma4.forcaback2.Text;
                        m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
                        m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "7");
                    }
                }
            }
            #endregion
            #region Comandos Spin
            if (chat == "/spin 30")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "30");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin 29")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "29");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin 28")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "28");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin 27")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "27");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin 26")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "26");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin 25")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "25");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin 24")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "24");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin 23")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "23");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin 22")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "22");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin 21")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "21");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin 20")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "20");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin 19")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "19");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin 18")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "18");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin 17")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "17");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin 16")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "16");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin 15")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "15");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin 14")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "14");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin 13")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "13");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin 12")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "12");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin 11")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "11");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin 10")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "10");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin 9")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "9");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin 8")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "8");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin 7")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "7");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin 6")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "6");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin 5")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "5");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin 4")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "4");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin 3")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "3");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin 2")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "2");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin 1")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "1");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin -1")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "-1");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin -2")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "-2");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin -3")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "-3");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin -4")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "-4");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin -5")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "-5");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin -6")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "-6");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin -7")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "-7");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin -8")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "-8");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin -9")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "-9");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin -10")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "-10");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin -11")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "-11");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin -12")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "-12");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin -13")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "-13");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin -14")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "-14");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin -15")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "-15");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin -16")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "-16");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin -17")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "-17");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin -18")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "-18");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin -19")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "-19");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin -20")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "-20");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin -21")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "-21");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin -22")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "-22");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin -23")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "-23");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin -24")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "-24");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin -25")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "-25");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin -26")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "-26");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin -27")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "-27");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin -28")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "-28");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin -29")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "-29");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin -30")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "-30");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/spin 0")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x18,0x0,0x24", "float", "0");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            #endregion
            #region Comandos Curva
            if (chat == "/curve 30")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "30");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve 29")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "29");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve 28")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "28");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve 27")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "27");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve 26")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "26");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve 25")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "25");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve 24")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "24");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve 23")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "23");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve 22")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "22");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve 21")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "21");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve 20")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "20");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve 19")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "19");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve 18")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "18");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve 17")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "17");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve 16")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "16");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve 15")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "15");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve 14")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "14");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve 13")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "13");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve 12")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "12");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve 11")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "11");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve 10")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "10");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve 9")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "9");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve 8")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "8");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve 7")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "7");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve 6")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "6");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve 5")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "5");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve 4")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "4");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve 3")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "3");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve 2")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "2");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve 1")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "1");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve -1")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "-1");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve -2")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "-2");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve -3")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "-3");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve -4")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "-4");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve -5")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "-5");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve -6")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "-6");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve -7")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "-7");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve -8")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "-8");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve -9")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "-9");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve -10")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "-10");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve -11")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "-11");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve -12")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "-12");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve -13")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "-13");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve -14")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "-14");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve -15")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "-15");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve -16")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "-16");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve -17")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "-17");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve -18")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "-18");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve -19")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "-19");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve -20")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "-20");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve -21")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "-21");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve -22")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "-22");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve -23")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "-23");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve -24")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "-24");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve -25")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "-25");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve -26")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "-26");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve -27")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "-27");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve -28")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "-28");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve -29")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "-29");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve -30")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "-30");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            else if (chat == "/curve 0")
            {
                m.WriteMemory("ProjectG.exe+007229D8,0x1C,0x34,0x14,0x2C,0x30,0x0,0x20", "float", "0");
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            #endregion
            #region Comandos Regua
            if (chat == "/regua 640")
            {
                Window5 regua640 = new Window5();
                regua640.Show();
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            if (chat == "/regua 1024")
            {
                Window1 regua1024 = new Window1();
                regua1024.Show();
                m.WriteMemory("ProjectG.exe+007229D8,0x20,0xE8,0x10,0xEC,0x78,0x34,0xC0", "bytes", "00 00 00 00 00 00 00 00 00 00 00 00 00");
            }
            #endregion
            #region PBA (100%)
            auxpba = Convert.ToDouble(pbresultado.Text);
            auxpba2 = auxpba / 4;
            auxpba2 = Math.Round(auxpba2, 2);
            pbaresultado.Text = Convert.ToString(auxpba2);
            #endregion
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BGW.RunWorkerAsync();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
