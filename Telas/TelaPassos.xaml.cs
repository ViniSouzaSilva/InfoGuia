using AmbiTroubleShooting.Objetos;
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

namespace AmbiTroubleShooting.Telas
{
    /// <summary>
    /// Lógica interna para TelaPassos.xaml
    /// </summary>
    public partial class TelaPassos : Window
    {
        int Id_prob;
        public bool Finalizou { get; set; }
        bool state = false;
        public TelaPassos(int ID_PROBLEMA)
        {
            Id_prob = ID_PROBLEMA;
            InitializeComponent();
            TelaPassos_Load();
        }

        public TelaPassos()
        {
          
        }

        private void TelaPassos_Load()
        {
            
            using (var passos = new DataSetTableAdapters.TRI_PDV_GUIDEPASSOSTableAdapter())
            {
                var model = passos.SP_TRI_LISTADEPASSOS(Id_prob);
                foreach (DataSet.TRI_PDV_GUIDEPASSOSRow item in passos.SP_TRI_LISTADEPASSOS(Id_prob).Rows)
                {
                    var checker = new CheckBox()
                    {
                        Content = item.TITULO_PASSO,

                        Margin = (new Thickness(3d, 3d, 3d, 3d)),
                        FontSize = 10,
                        Width = 150,
                        Height = 60,
                        HorizontalContentAlignment = HorizontalAlignment.Left
                        
                    };
                    var texter = new TextBlock()
                    {
                        Text = item.DESCRICAO_PASSO,
                        //IsReadOnly = true,
                        Margin = (new Thickness(5d, 5d, 5d, 5d)),
                        FontSize = 10,
                        Width = 300,
                        Height = 60,
                       // HorizontalContentAlignment = HorizontalAlignment.Left,
                        TextWrapping = TextWrapping.Wrap,
                       // VerticalScrollBarVisibility = ScrollBarVisibility.Visible
                    };
                    
                    Stack1.Children.Add(checker);
                    Stack2.Children.Add(texter);
                }


            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            state = true;
            Botao_Finalizado();
            Close();
        }
        public bool Botao_Finalizado()
        {
            return state;
        }

    }
}
