using SISU_Sistema.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISU_Sistema.View.Aluno
{
    public partial class Alunoindex : Form
    {
        public Alunoindex()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "")
            {
                MessageBox.Show("Nome é obrigatório.");
                txtNome.BackColor = Color.Red;
            }

            if (txtIdade.Text == "")
            {
                MessageBox.Show("Idade é obrigatório.");
                txtIdade.BackColor = Color.Red;
            }

            if ((txtNome.Text != "") & (txtIdade.Text != ""))
            {
                listaAlunos.Items.Add(txtNome.Text + " " + txtIdade.Text);
                txtNome.BackColor = Color.White;
                txtIdade.BackColor = Color.White;
            }
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("Alunos.txt");

            foreach (ListViewItem item in listaAlunos.Items)
            {
                sw.WriteLine(item.Text);
            }
            sw.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //System.IO.FileNotFoundException
        }
        
        private void Alunoindex_Load(object sender, EventArgs e)
        {
            try
            {
                AlunoDAO dados = new AlunoDAO();
                List<Models.Aluno> alunos = dados.getTodosAlunos();

                foreach (var item in alunos)
                {
                    listaAlunos.Items.Add(item.Nome + "|" + item.Idade);
                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show("Erro de leitura de Arquivo. Arquivo não existe, o~u endereço inválido");
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
