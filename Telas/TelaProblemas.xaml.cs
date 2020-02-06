using AmbiTroubleShooting.Objetos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace AmbiTroubleShooting.Telas
{
    /// <summary>
    /// Lógica interna para TelaProblemas.xaml
    /// </summary>
    public partial class TelaProblemas : Window
    {
        private Collection<Problema_DTO> Problem = new Collection<Problema_DTO>();
        int id_produto;
        int id_problem;
        bool state = false;
        bool RealState = false;
        public TelaProblemas(int ID_PRODUTO)
        {
            id_produto = ID_PRODUTO;
            InitializeComponent();
            TelaProblemas_Load();
        }  
            private void TelaProblemas_Load()
            {

                using (var problema = new DataSetTableAdapters.TRI_PDV_GUIDEPROBLEMASTableAdapter())
                {
                var model = problema.SP_TRI_GetLISTADEPROBLEMA(id_produto);
                    foreach (DataSet.TRI_PDV_GUIDEPROBLEMASRow row in problema.SP_TRI_GetLISTADEPROBLEMA(id_produto).Rows)
                    {
                        Problem.Add(new Problema_DTO() { ID_PROBLEMA = row.ID_PROBLEMA, DESCRICAO_PROBLEMA = row.DESCRICAO_PROBLEMA, ID_PRODUTO = row.ID_PRODUTO});


                    }


                sP_TRI_LISTADEPROBLEMDataGrid.ItemsSource = Problem;
                }

            }

        private void Row_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            var ID_PROBLEMA = ((Problema_DTO)sP_TRI_LISTADEPROBLEMDataGrid.SelectedItem).ID_PROBLEMA;
            TelaPassos tela = new TelaPassos(ID_PROBLEMA);
            Hide();
            tela.ShowDialog();
            


                if (tela.Botao_Finalizado() == true)
                {
                    RealState = true;
                    this.Close();
                }
                else
                {
                    ShowDialog();
                }
        }

        private void sP_TRI_LISTADEPROBLEMDataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void sP_TRI_LISTADEPROBLEMDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
          
            Hide();
            state = true;
            Botao_clicado();

        }
        public bool Botao_clicado() 
        {
              return state;
        }
        public bool Botao_FinalizadoDeVerdade()
        {
            return RealState;
        }
    }
    
}
