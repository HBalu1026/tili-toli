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

namespace tilitoli
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int lysor = 0;
        int lyoszl = 0;
        Button[,] tomb = new Button[10,10];

        public MainWindow()
        {
            InitializeComponent();
        
        }

        private void meretallitas()
        {
            if (cbMeret.SelectedItem!= null)
            {
                // Töröljük az összes meglévő sort és oszlopot a gPalya gridben
                gPalya.RowDefinitions.Clear();
                gPalya.ColumnDefinitions.Clear();
                gPalya.Children.Clear();
                // Az új sorok és oszlopok számát az lbMeret kiválasztott elemének indexe adja
                int selectedIndex = cbMeret.SelectedIndex + 2;

                // Hozzáadjuk az új sorokat és oszlopokat a gPalya gridhez
                for (int i = 0; i < selectedIndex; i++)
                {
                    gPalya.RowDefinitions.Add(new RowDefinition());
                    gPalya.ColumnDefinitions.Add(new ColumnDefinition());
                }

                // Most, ha szükséges, hozzáadhatjuk az új tartalmakat a gridhez (pl. gombok, elemek stb.)
                // Például: minden sorban és oszlopban egy-egy gomb létrehozása
                int felirat = 1;
                tomb = new Button[selectedIndex, selectedIndex];
                for (int i = 0; i < selectedIndex; i++)
                {
                    for (int j = 0; j < selectedIndex; j++)
                    {
                        if (i == selectedIndex - 1 && j == selectedIndex - 1)
                        {
                            //TextBox ures = new TextBox();
                            //Grid.SetRow(ures, i);
                            //Grid.SetColumn(ures, j);
                            //gPalya.Children.Add(ures);
                            tomb[i, j] = new Button
                            {
                                Content = felirat,
                                Margin = new Thickness(5),
                                Tag=i+"_"+j
                            };
                            tomb[i, j].Click += mozgatas;
                            tomb[i, j].Visibility = Visibility.Hidden;
                            Grid.SetRow(tomb[i, j], i);
                            Grid.SetColumn(tomb[i, j], j);
                            gPalya.Children.Add(tomb[i, j]);
                            felirat++;
                        }
                        else
                        {
                            tomb[i, j] = new Button
                            {
                                Content = felirat,
                                Margin = new Thickness(5),
                                Tag = i + "_" + j
                            };
                            tomb[i, j].Click += mozgatas;
                            Grid.SetRow(tomb[i, j], i);
                            Grid.SetColumn(tomb[i, j], j);
                            gPalya.Children.Add(tomb[i, j]);
                            felirat++;
                        }

                    }
                }
            }
            lysor = gPalya.RowDefinitions.Count - 1;
            lyoszl = gPalya.ColumnDefinitions.Count - 1;
        }


        private void cbMeret_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            meretallitas();
        }

        private void btnUjJatek_Click(object sender, RoutedEventArgs e)
        {
            meretallitas();
        }
        private void mozgatas(object sender, RoutedEventArgs e)
        {
            string hol = (sender as Button).Tag.ToString();
            string[] splitelt = hol.Split('_');
            int sor = Convert.ToInt16(splitelt[0]);
            int oszl = Convert.ToInt16(splitelt[1]);
            if ((sor == lysor && Math.Abs(oszl - lyoszl) == 1) || (oszl == lyoszl && Math.Abs(sor - lysor) == 1))
            {
                string csere = tomb[sor, oszl].Content.ToString();
                tomb[sor, oszl].Content = tomb[lysor, lyoszl].Content.ToString();
                tomb[sor, oszl].Visibility = Visibility.Hidden;
                tomb[lysor, lyoszl].Content = csere;
                tomb[lysor, lyoszl].Visibility = Visibility.Visible;
                lysor = sor;
                lyoszl = oszl;

            }
        }
        private void btnKeveres_Click(object sender, RoutedEventArgs e)
        {
            int kever = 1;
            while (kever <= 2) 
            {
                Random rnd = new Random();
                rnd.Next(1, 5);

            }
        }
    }
}