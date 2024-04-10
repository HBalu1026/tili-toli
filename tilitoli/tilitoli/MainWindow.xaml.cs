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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void meretallitas()
        {
            if (cbMeret.SelectedItem != null)
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
                Button[,] tomb = new Button[selectedIndex, selectedIndex];
                for (int i = 0; i < selectedIndex; i++)
                {
                    for (int j = 0; j < selectedIndex; j++)
                    {
                        if (i == selectedIndex - 1 && j == selectedIndex - 1)
                        {
                            TextBox ures = new TextBox();
                            Grid.SetRow(ures, i);
                            Grid.SetColumn(ures, j);
                            gPalya.Children.Add(ures);
                        }
                        else
                        {
                            tomb[i, j] = new Button
                            {
                                Content = felirat,
                                Margin = new Thickness(5)
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
            Button clickedButton = (Button)sender;
            string content = clickedButton.Content.ToString();
            int row = Grid.GetRow(clickedButton);
            int col = Grid.GetColumn(clickedButton);
            int selectedMeret = cbMeret.SelectedIndex + 2;

            //bal
            if (col - 1 >= 0 && gPalya.Children[row*selectedMeret+(col-1)] == null)
            {
                MessageBox.Show("van");
                Grid.SetColumn(clickedButton, col);
                Grid.SetRow(clickedButton, row);
                gPalya.Children.Remove(clickedButton);

                Button newButton = new Button
                {
                    Content = content,
                    Margin = new Thickness(5)
                };
                newButton.Click += mozgatas;
                Grid.SetColumn(newButton, col-1);
                gPalya.Children.Add(newButton);
            }
        }
        private void btnKeveres_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}