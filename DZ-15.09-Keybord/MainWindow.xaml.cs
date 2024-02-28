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
using System.Windows.Threading;

namespace DZ_15._09_Keybord
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int tempTimer = 0;
        int fails = 0;
        Random rendChar = new Random();
        string baceString = "QWERTYUIOPASDFGHJKLZXCVBNM~!@#$%^&*()_+{}|:\"<>?1234567890[],./\\`-=;'qwertyuiopasdfghjklzxcvbnm";
        bool flagCapsLock = true;
        bool flagBackspase = true;
        bool mesStop = true;
        DispatcherTimer timer = null;

        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000);
        }

        private void CapitalLetters()
        {
            this.Q.Content = "Q";
            this.W.Content = "W";
            this.E.Content = "E";
            this.R.Content = "R";
            this.T.Content = "T";
            this.Y.Content = "Y";
            this.U.Content = "U";
            this.I.Content = "I";
            this.O.Content = "O";
            this.P.Content = "P";
            this.A.Content = "A";
            this.S.Content = "S";
            this.D.Content = "D";
            this.F.Content = "F";
            this.G.Content = "G";
            this.H.Content = "H";
            this.J.Content = "J";
            this.K.Content = "K";
            this.L.Content = "L";
            this.Z.Content = "Z";
            this.X.Content = "X";
            this.C.Content = "C";
            this.V.Content = "V";
            this.B.Content = "B";
            this.N.Content = "N";
            this.M.Content = "M";

        }
        private void LoverLetters()
        {
            this.Q.Content = "q";
            this.W.Content = "w";
            this.E.Content = "e";
            this.R.Content = "r";
            this.T.Content = "t";
            this.Y.Content = "y";
            this.U.Content = "u";
            this.I.Content = "i";
            this.O.Content = "o";
            this.P.Content = "p";
            this.A.Content = "a";
            this.S.Content = "s";
            this.D.Content = "d";
            this.F.Content = "f";
            this.G.Content = "g";
            this.H.Content = "h";
            this.J.Content = "j";
            this.K.Content = "k";
            this.L.Content = "l";
            this.Z.Content = "z";
            this.X.Content = "x";
            this.C.Content = "c";
            this.V.Content = "v";
            this.B.Content = "b";
            this.N.Content = "n";
            this.M.Content = "m";

        }
        private void CapitalSymbol()
        {
            this.Oem3.Content = "~";
            this.D1.Content = "!";
            this.D2.Content = "@";
            this.D3.Content = "#";
            this.D4.Content = "$";
            this.D5.Content = "%";
            this.D6.Content = "^";
            this.D7.Content = "&";
            this.D8.Content = "*";
            this.D9.Content = "(";
            this.D0.Content = ")";
            this.OemMinus.Content = "_";
            this.OemPlus.Content = "+";
            this.OemOpenBrackets.Content = "{";
            this.Oem6.Content = "}";
            this.Oem5.Content = "|";
            this.Oem1.Content = ":";
            this.OemQuotes.Content = "\"";
            this.OemComma.Content = "<";
            this.OemPeriod.Content = ">";
            this.OemQuestion.Content = "?";
        }
        private void LoverSymbol()
        {
            this.Oem3.Content = "`";
            this.D1.Content = "1";
            this.D2.Content = "2";
            this.D3.Content = "3";
            this.D4.Content = "4";
            this.D5.Content = "5";
            this.D6.Content = "6";
            this.D7.Content = "7";
            this.D8.Content = "8";
            this.D9.Content = "9";
            this.D0.Content = "0";
            this.OemMinus.Content = "-";
            this.OemPlus.Content = "=";
            this.OemOpenBrackets.Content = "[";
            this.Oem6.Content = "]";
            this.Oem5.Content = "\\";
            this.Oem1.Content = ";";
            this.OemQuotes.Content = "'";
            this.OemComma.Content = ",";
            this.OemPeriod.Content = ".";
            this.OemQuestion.Content = "/";
        }
        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            foreach (UIElement it in (this.Content as Grid).Children)
            {
                if (it is Grid)
                {
                    foreach (var item in (it as Grid).Children)
                    {
                        if (item is Button)
                        {
                            if ((item as Button).Name == e.Key.ToString())
                            {
                                (item as Button).Opacity = 0.5;
                                if (e.Key.ToString() == "LeftShift" || e.Key.ToString() == "RightShift")
                                {
                                    CapitalSymbol();
                                    if (flagCapsLock)
                                    {
                                        CapitalLetters();
                                    }
                                    else
                                    {
                                        LoverLetters();
                                    }
                                }
                                else if (e.Key.ToString() == "Capital")
                                {
                                    if (flagCapsLock)
                                    {
                                        CapitalLetters();
                                        flagCapsLock = false;
                                    }
                                    else
                                    {
                                        LoverLetters();
                                        flagCapsLock = true;
                                    }
                                }
                                else if (e.Key.ToString() == "Back")
                                {
                                    flagBackspase = false;
                                }
                                else
                                {
                                    flagBackspase = true;
                                }
                            }
                        }
                    }
                }
            }
        }
        private void Form_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            lineUser.Focus();
            foreach (UIElement it in (this.Content as Grid).Children)
            {
                if (it is Grid)
                {
                    foreach (var item in (it as Grid).Children)
                    {
                        if (item is Button)
                        {

                            if ((item as Button).Name == e.Key.ToString())
                            {
                                (item as Button).Opacity = 1;
                                if (e.Key.ToString() == "LeftShift" || e.Key.ToString() == "RightShift")
                                {
                                    LoverSymbol();
                                    if (!flagCapsLock)
                                    {
                                        CapitalLetters();
                                    }
                                    else
                                    {
                                        LoverLetters();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (!mesStop)
            {
                MessageBox.Show($"Задание завершенно!\n Количество символов {linePrograms.Text.Length}.\n Количество ошибок {Fails.Content}.\nДля завершения задания нажмите Stop.", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                mesStop = true;
            }
        }
        private void SliderDifficulty_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int num = 0;
            Slider s = sender as Slider;
            num = (int)s.Value;
            Difficulty.Content = num.ToString();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Start.IsEnabled = false;
            SliderDifficulty.IsEnabled = false;
            CaseSensitive.IsEnabled = false;
            Stop.IsEnabled = true;
            tempTimer = 0;
            timer.Start();
            CollectString(Convert.ToInt32(Difficulty.Content), baceString, !(bool)CaseSensitive.IsChecked);
            lineUser.IsReadOnly = false;
            lineUser.IsEnabled = true;
            lineUser.Focus();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tempTimer++;
            Speed();
        }

        private void CollectString(int countChar, string baceString, bool flagSensitive)
        {
            string carhs = "";
            int sensitive = (flagSensitive) ? 47 : 0;
            for (int i = 0; i < countChar; i++)
            {
                carhs += baceString[rendChar.Next(sensitive, baceString.Length)];
            }
            carhs += " ";
            int countString = (flagSensitive) ? 75 : 70;
            for (int i = 0; i < countString; i++)
            {
                linePrograms.Text += carhs[rendChar.Next(0, carhs.Length)];
            }
        }
        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            Start.IsEnabled = true;
            SliderDifficulty.IsEnabled = true;
            CaseSensitive.IsEnabled = true;
            Stop.IsEnabled = false;
            lineUser.Text = "";
            linePrograms.Text = "";
            Fails.Content = 0;
            SpeedChar.Content = 0;
            lineUser.IsReadOnly = true;
            lineUser.IsEnabled = false;
            timer.Stop();
            tempTimer = 0;
            fails = 0;
        }
        private void lineUser_TextChanged(object sender, TextChangedEventArgs e)
        {
            string str = linePrograms.Text.Substring(0, lineUser.Text.Length);
            if (lineUser.Text.Equals(str))
            {
                if (flagBackspase)
                {
                    Speed();
                }
                lineUser.Foreground = new SolidColorBrush(Colors.Black);
            }
            else
            {
                if (flagBackspase)
                {
                    fails++;
                }
                lineUser.Foreground = new SolidColorBrush(Colors.Red);
                Fails.Content = fails;
            }
            if (lineUser.Text.Length == linePrograms.Text.Length)
            {
                timer.Stop();
                Speed();
                lineUser.IsReadOnly = true;
                mesStop = false;
            }
        }
        private void CaseSensitive_Checked_1(object sender, RoutedEventArgs e)
        {
            SliderDifficulty.Maximum = 94;
        }
        private void CaseSensitive_Unchecked(object sender, RoutedEventArgs e)
        {
            SliderDifficulty.Maximum = 47;
        }
        void Speed()
        {
            SpeedChar.Content = Math.Round(((double)lineUser.Text.Length / tempTimer) * 60).ToString();
        }
    }
}
