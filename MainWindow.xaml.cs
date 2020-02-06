using AmbiTroubleShooting.Telas;
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

namespace AmbiTroubleShooting
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

       
        private void Entrar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var sup = cbb_Usuario.SelectedItem.ToString();
            var senha = "1234";
            if (String.Equals(sup, "System.Windows.Controls.ComboBoxItem: SUPERVISOR"))
            {
                if (txb_Senha.Password.Equals(senha))
                {
                    TelaInicial tela = new TelaInicial();
                    tela.Show();
                    Close();
                }
                else 
                {
                    MessageBox.Show("Senha Incorreta", "Atenção");
                }

            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
