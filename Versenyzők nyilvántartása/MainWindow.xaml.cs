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

namespace Versenyzők_nyilvántartása
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

        private void btnFelvesz_Click(object sender, RoutedEventArgs e)
        {
            foreach(var item in lbNevLista.Items) 
            {
                if (item.ToString().StartsWith(txtVersenyzo.Text))
                {

                 MessageBox.Show("Ilyen névvel már szerepel adat!");
                    txtVersenyzo.Text = "";
                    txtVersenyzo.Focus();
                    return;

                }

            }
            
            string ujVersenyzo = txtVersenyzo.Text  +"(" + Convert.ToInt32(sliMagassag.Value) + "cm)";
               lbNevLista.Items.Add(ujVersenyzo);
               txtVersenyzo.Text = "";
               txtVersenyzo.Focus();
               lbVersenyzokSzama.Content = lbNevLista.Items.Count;

        }

        private void btnTorol_Click(object sender, RoutedEventArgs e)
        {
            if (lbNevLista.SelectedIndex == -1)
            {
                MessageBox.Show("Válasszon egy nevet a listából.");
            }
            else
            {
                lbNevLista.Items.RemoveAt(lbNevLista.SelectedIndex);
                lbVersenyzokSzama.Content = lbNevLista.Items.Count;
            }
        }

        private void btnUrit_Click(object sender, RoutedEventArgs e)
        {
            lbNevLista.Items.Clear();
            lbVersenyzokSzama.Content = lbNevLista.Items.Count;
        }

        private void txtVersenyzo_IsStylusCapturedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }

        private void btnOsszead_Click(object sender, RoutedEventArgs e)
        {
            lbOsszead.Content = Convert.ToDouble(txtEgyikSzam.Text) + Convert.ToDouble(txtMasikSzam.Text);
        }
    }
}
