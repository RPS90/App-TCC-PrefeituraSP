using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmConsultaFornecedor : Form
    {
        public int codigo = 0;
        public frmConsultaFornecedor()
        {
            InitializeComponent();
        }
        private void btLocalizar_Click(object sender, EventArgs e)
        {
            CADConexao cx = new CADConexao(DadosDaConexao.StringDeConexao);
            BLLFornecedor bll = new BLLFornecedor(cx);
            dgvDados.DataSource = bll.Localizar(txtValor.Text);
        }     
        private void frmConsultaFornecedor_Load(object sender, EventArgs e)
        {
            btLocalizar_Click(sender, e);
            dgvDados.Columns[0].HeaderText = "Código";
            dgvDados.Columns[0].Width = 50;
            dgvDados.Columns[1].HeaderText = "Fornecedor";
            dgvDados.Columns[1].Width = 300;
        }
        private void dgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {//armazena o código da categoria selecionada e fecha o formulário
                this.codigo = Convert.ToInt32(dgvDados.Rows[e.RowIndex].Cells[0].Value);
                this.Close();
            }
        }





    }
}
