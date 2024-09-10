using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_1_DSIV
{
    public partial class Form1 : Form
    {
        decimal salarioBruto;
        public Form1()
        {
            InitializeComponent();
        }

        private decimal CalcularSalarioNeto(decimal salarioBruto)
        {
            decimal deduccionImpuestos = salarioBruto * 0.10m;
            decimal salarioNeto = salarioBruto - deduccionImpuestos;

            return Math.Round(salarioNeto,2);
        }



        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El campo Nombre no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("El campo Apellido no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCedula.Text))
            {
                MessageBox.Show("El campo Cédula no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSalario.Text))
            {
                MessageBox.Show("El campo Salario Bruto no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nombre = txtNombre.Text.ToUpper();
            txtNombre.Text = nombre;

            string apellido = txtApellido.Text.ToUpper();
            txtApellido.Text = apellido;


            string cedula = txtCedula.Text;

            if (!decimal.TryParse(txtSalario.Text, out salarioBruto))
            {
                MessageBox.Show("Por favor, ingrese un valor válido para el salario bruto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            decimal salarioNeto = CalcularSalarioNeto(salarioBruto);

 
            Form2 form2 = new Form2(nombre, apellido, cedula,salarioNeto);
            form2.ShowDialog();
            this.Hide();
        }
    }
}

