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
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Collections.ObjectModel;
using AmbiTroubleShooting;
using AmbiTroubleShooting.Objetos;
using System.IO;
using Microsoft.Win32;
using System.Reflection;
using System.Data;

namespace AmbiTroubleShooting.Telas
{
    /// <summary>
    /// Lógica interna para TelaModelos.xaml
    /// </summary>
    public partial class TelaModelos : Window
    {
  


        private Collection<Produto_DTO> Produt = new Collection<Produto_DTO>();    
        string Produ;
        public TelaModelos(string produ)
        {
            Produ = produ;
            DataContext = this;
            InitializeComponent();
           TelaModelos_Load();
        }
      
        private void TelaModelos_Load()
        {

            using (var modelos = new DataSetTableAdapters.TRI_PDV_GUIDEPRODUTOSTableAdapter())
            {
                var model = modelos.SP_TRI_LISTADEPRODU(Produ);
                foreach (DataSet.TRI_PDV_GUIDEPRODUTOSRow row in modelos.SP_TRI_LISTADEPRODU(Produ).Rows)
                {
                    Produt.Add(new Produto_DTO() { ID_PRODUTO = row.ID_PRODUTO, MARCA = row.MARCA, MODELO = row.MODELO, VERSAO = row.VERSAO});
                 
                    
                }


               sP_TRI_LISTADEPRODUDataGrid.ItemsSource = Produt;
            } 
        
        }
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            

            var ID_PRODUTO = ((Produto_DTO)sP_TRI_LISTADEPRODUDataGrid.SelectedItem).ID_PRODUTO;
            TelaProblemas tela = new TelaProblemas(ID_PRODUTO);
            Hide();
            tela.ShowDialog();
            if (tela.Botao_clicado() == true)
            {
                //tela.Botao_clicado
                ShowDialog();
            }
            else
            {
                //TelaPassos VoltarTudo = new TelaPassos();
                
                if (tela.Botao_FinalizadoDeVerdade() == true)
                {
                    this.Close();
                }
                else
                {
                    ShowDialog();
                }
            }
        }

        private void sP_TRI_LISTADEPRODUDataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
           
        }
        public void sP_TRI_LISTADEPRODUDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           RetornaCaminho(sender, e);    
        }
        public void Row_Click(object sender, RoutedEventArgs e)
        {

        }
        private void RetornaCaminho(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Imagem.Visibility = Visibility.Visible;
                var ID_PRODUTO = ((Produto_DTO)sP_TRI_LISTADEPRODUDataGrid.SelectedItem).ID_PRODUTO;
                string path = (AppDomain.CurrentDomain.BaseDirectory + $"Resources\\{ID_PRODUTO}.png");

                Imagem.Source = new BitmapImage(new Uri(path));
                MsgFoto.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                MsgFoto.Visibility = Visibility.Visible;
                MsgFoto.Content = "Foto Não Cadastrada";
                Imagem.Visibility = Visibility.Collapsed;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
            Hide();
            //TelaInicial tela = new TelaInicial();
            //tela.ShowDialog();
        }
    }
}
