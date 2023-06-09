﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Login
{
    public partial class Form1 : Form
    {
        List<Pessoa> pessoas;
        public Form1()
        {
            InitializeComponent();

            pessoas = new List<Pessoa>();

            comboEC.Items.Add("Solteiro");
            comboEC.Items.Add("Casado");
            comboEC.Items.Add("Viuvo");
            comboEC.Items.Add("Separado");
            comboEC.SelectedIndex = 0;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Cadastrar 
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            int index = -1;

            foreach (Pessoa P in pessoas)
            {
                if(P.Nome == txtNome.Text)
                {
                    index = pessoas.IndexOf(P);
                }
            }
            if(txtNome.Text == "")
            {
                MessageBox.Show("Preencha o campo nome.");
                txtNome.Focus();
                return;
            }
            if (txtTelefone.Text == "(  )      -")
            {
                MessageBox.Show("Preencha o campo telefone.");
                txtNome.Focus();
                return;
            }
            char sexo;

            if(radioM.Checked == true)
            {
                sexo = 'M';
            }
            else if (radioF.Checked == true)
            {
                sexo = 'F';
            }
            else
            {
                sexo = 'O';
            }

            Pessoa p = new Pessoa();
            p.Nome = txtNome.Text;
            p.DataNascimento = txtData.Text;
            p.EstadoCivil = comboEC.SelectedItem.ToString();
            p.Telefone = txtTelefone.Text;
            p.CasaPropia = checkCasa.Checked;
            p.Veiculo = checkVeiculo.Checked;
            p.Sexo = sexo;

            if(index < 0)
            {
                pessoas.Add(p);
            }
            else
            {
                pessoas[index] = p;
            }

            btnLimpar_Click(btnLimpar, EventArgs.Empty);

            Listar();
        }

        // Excluir
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int index = Lista.SelectedIndex;
            pessoas.RemoveAt(index);
            Listar();
        }

        // Limpar campo
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtData.Text = "";
            comboEC.SelectedIndex = 0;
            txtTelefone.Text = "";
            checkCasa.Checked = false;
            checkVeiculo.Checked = false;
            radioM.Checked = true;
            radioF.Checked = false;
            radioO.Checked = false;
            txtNome.Focus();

        }

        // Listar as pessoas criadas no listbox
        private void Listar()
        {
            Lista.Items.Clear();

            foreach (Pessoa p in pessoas)
            {
                Lista.Items.Add(p.Nome);
            }
        }

        // Recuperar as informaçoes no inputBox
        private void Lista_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = Lista.SelectedIndex;
            Pessoa p = pessoas[index];

            txtNome.Text = p.Nome;
            txtData.Text = p.DataNascimento;
            comboEC.SelectedItem = p.EstadoCivil;
            txtTelefone.Text = p.Telefone;
            checkCasa.Checked = p.CasaPropia;
            checkVeiculo.Checked = p.Veiculo;

            switch(p.Sexo)
            {
                case 'M':
                    radioM.Checked = true;
                    break;
                case 'F':
                    radioF.Checked = true;
                    break;
                default:
                    radioO.Checked = true;
                    break;
            }
        }
    }
}
