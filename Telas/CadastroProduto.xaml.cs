using AmbiTroubleShooting.DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Lógica interna para CadastroProduto.xaml
    /// </summary>
    public partial class CadastroProduto : Window
    {
        TRI_PDV_GUIDEPRODATIVOSDataTable produ_DataTable = new TRI_PDV_GUIDEPRODATIVOSDataTable();
        TRI_PDV_GUIDEPRODUTOSDataTable produtos_DataTable = new TRI_PDV_GUIDEPRODUTOSDataTable();


        public CadastroProduto()
        {
            InitializeComponent();
            Window_Loaded();
            PreencherComboboxProdutos();
            PreencherComboboxMarca();

        }

        public static List<string> ProdutoOC = new List<string>();
        public static List<string> MarcaOC = new List<string>();

        private void Window_Loaded()
        {
            using (var prod = new TRI_PDV_GUIDEPRODATIVOSTableAdapter()) 
            {
                string i = "";
                var pro = prod.FillByAtivos(produ_DataTable);
                foreach (DataSet.TRI_PDV_GUIDEPRODATIVOSRow row in produ_DataTable)
                {
                    string ProduTemporario = row.PRODUTO;

                    if (i != ProduTemporario)
                    {
                        ProdutoOC.Add(row.PRODUTO);
                    }
                    else
                    { 
                    }
                    i = row.PRODUTO;
                }
                //sP_TRI_LISTADEPRODUDataGrid.ItemsSource = Prod;
            }
            using (var prod = new TRI_PDV_GUIDEPRODUTOSTableAdapter())
            {
                string i = "";
                var pro = prod.FillProdu(produtos_DataTable);
                foreach (DataSet.TRI_PDV_GUIDEPRODUTOSRow row in produtos_DataTable)
                {
                    string MarcaTemporaria = row.MARCA;

                    if (i != MarcaTemporaria)
                    {
                        MarcaOC.Add(row.MARCA);
                    }
                    else 
                    {
                    
                    }
                    i = row.MARCA;
                }
                //sP_TRI_LISTADEPRODUDataGrid.ItemsSource = Prod;
            }

        }
        private void PreencherComboboxProdutos()
        {
            //Produto_txb.Items.Clear();
            foreach (var item in ProdutoOC)
            {
                Produto_cxb.Items.Add(item);
            }
        }

        private void PreencherComboboxMarca()
        {
            //Produto_txb.Items.Clear();
            foreach (var item in MarcaOC)
            {
                Marca_cxb.Items.Add(item);
            }
        }

        private void Cadastrar_but_Click(object sender, RoutedEventArgs e)
        {
            
            using (var Cad = new TRI_PDV_GUIDEPRODATIVOSTableAdapter()) 
            {
                string status;
                string cbx_status = Status_cbx.SelectedItem.ToString();
                if (cbx_status.Equals("System.Windows.Controls.ComboBoxItem: Ativo"))
                {
                    status = "A";
                }
                else
                {
                    status = "I";
                }
                try
                {
                    using (var prod = new TRI_PDV_GUIDEPRODATIVOSTableAdapter())
                    {
                        int count = (int)prod.FillByAtivosNR(Produto_cxb.Text.ToUpper());
                        if (count == 0) 
                        {
                            Cad.SP_TRI_INSEREGUIDEPRODUTO(Produto_cxb.Text.ToUpper(), status, Marca_cxb.Text.ToUpper(), Versao_txb.Text.ToUpper(), Modelo_txb.Text.ToUpper());
                        }
                        else 
                        {
                            Cad.SP_TRI_INSEREGUIDEPRODUTOMN(Produto_cxb.Text.ToUpper(), Marca_cxb.Text.ToUpper(), Versao_txb.Text.ToUpper(), Modelo_txb.Text.ToUpper());
                        }                     
                    }
                        MessageBox.Show("Produto Gravado com sucesso!\n Reinicie o programa para atualizar os dados.","Atenção",MessageBoxButton.OK,MessageBoxImage.Information);
                }
                catch(Exception ex) 
                {
                    MessageBox.Show(ex.Message);
                }
                var result = MessageBox.Show("Deseja continuar cadastrando produtos?", "Atenção", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (result == MessageBoxResult.Yes)
                {
                    Produto_cxb.Text = "";
                    Marca_cxb.Text = "";
                    Versao_txb.Text = "";
                    Modelo_txb.Text = "";
                }
                else {
                    ProdutoOC.Clear();
                    MarcaOC.Clear();
                    Close();
                }
            }
        }

        private void Cancelar_but_Click(object sender, RoutedEventArgs e)
        {
            ProdutoOC.Clear();
            MarcaOC.Clear();
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
   /* public class FocusableAutoCompleteBox : AutoCompleteBox
    {
        public new void Focus()
        {
            if (Template.FindName("Text", this) is TextBox textbox)
            {
                textbox.Focus();
            }
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.F4)
            {
                return;
            }
            else if (e.Key == Key.Escape && (Text != "" || Text != String.Empty))
            {
                Text = "";
                e.Handled = true;
            }
            else
            {
                base.OnKeyDown(e);
            }
        }
    }*///Controle da caixa autocompletável.
}

