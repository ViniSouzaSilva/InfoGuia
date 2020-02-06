using AmbiTroubleShooting.DataSetTableAdapters;
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
using static AmbiTroubleShooting.DataSet;

namespace AmbiTroubleShooting.Telas
{
    /// <summary>
    /// Lógica interna para TelaInicial.xaml
    /// </summary>
    public partial class TelaInicial : Window
    {
        DataSet.TRI_PDV_GUIDEPRODATIVOSDataTable PRODATIVOS = new DataSet.TRI_PDV_GUIDEPRODATIVOSDataTable();

        public TelaInicial()
        {
            InitializeComponent();
            TelaInicial_Load();
        }
        private void TelaInicial_Load()
        {
            using (var ATIVOS = new TRI_PDV_GUIDEPRODATIVOSTableAdapter())
            {
                ATIVOS.FillByAtivos(PRODATIVOS);
                foreach (TRI_PDV_GUIDEPRODATIVOSRow item in PRODATIVOS)
                {
                    var nome = item.PRODUTO.ToString();

                    var but = new Button()
                    {
                        Content = item.PRODUTO.Replace(' ', '\n'),

                        Margin = (new Thickness(5d, 5d, 5d, 5d)),
                        FontSize = 20,
                        Width = 150,
                        Height = 60,
                        HorizontalContentAlignment = HorizontalAlignment.Center,

                    };
                    but.Click += But_Click;
                    Stack2.Children.Add(but);





                }
            }
        }

        private void But_Click(object sender, RoutedEventArgs e)
        {
            Button _sender = (Button)sender;
            AbreProxJanela(_sender.Content);
            return;
        }

        private void AbreProxJanela(object produ)
        {
            TelaModelos tela = new TelaModelos(produ.ToString());
            Hide();
            tela.ShowDialog();
            this.Show();


        }

        private void Stack_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CadastroProduto tela = new CadastroProduto();
            tela.ShowDialog();
            
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    } 
}
