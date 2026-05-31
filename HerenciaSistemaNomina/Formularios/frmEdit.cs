using HerenciaSistemaNomina.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HerenciaSistemaNomina.Formularios
{
    public partial class frmEdit : Form
    {
        public frmEdit()
        {
            InitializeComponent();
        }

        Contratado ocont = null;
        Comisionado ocd = null;
        Fijo of = null;
        Comision ocm = null;

        public bool ValidarDatos()
        {
            bool value = true;
            if (textBox1.Text.Trim().Length == 0 && textBox2.Text.Trim().Length == 0 &&
                textBox3.Text.Trim().Length == 0 && comboBox1.SelectedIndex > 0 && comboBox2.SelectedIndex > 0)
            {
                value = false;
            }
            return value;
        }

        public void Guardar()
        {
            try
            {
                if (ValidarDatos())
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                    MessageBox.Show("Los campos con (*) son obligatorios");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Persona CrearObjeto()
        {
            string idCodigo = textBox1.Text.Trim();
            string cedula = textBox2.Text.Trim();
            string nombre = textBox3.Text.Trim();
            string apellidos = textBox4.Text.Trim();
            DateTime fechaNacimiento = dateTimePicker1.Value;
            char sexo = comboBox1.SelectedItem.ToString()[0];
            string estadoCivil = comboBox2.SelectedItem.ToString();
            string direccion = textBox5.Text.Trim();
            string telefono = textBox6.Text.Trim();
            string tipo = comboBox3.SelectedItem.ToString().Trim();
            double v1 = double.Parse(textBox7.Text.Trim());
            double v2 = double.Parse(textBox8.Text.Trim());
            double v3 = double.Parse(textBox9.Text.Trim());

            if (tipo == "Contratado")
            {
                label12.Text = "Hora: ";
                label13.Text = "Costo: ";
                label14.Text = "Iess: ";
                ocont = new Contratado(idCodigo, cedula, nombre, apellidos, fechaNacimiento, sexo, estadoCivil, direccion, telefono, tipo,v1, v2, v3);
                return ocont;
            }
            else if(tipo == "Comisionado")
            {
                label12.Text = "Ventas: ";
                label13.Text = "Porcentaje: ";
                label14.Text = "Salario: ";
                ocd = new Comisionado(idCodigo, cedula, nombre, apellidos, fechaNacimiento, sexo, estadoCivil, direccion, telefono, tipo, v1, v2, v3);
                return ocd;
            }
            else if(tipo == "Fijo")
            {
                label12.Text = "Salario: ";
                label13.Text = "Iess: ";
                label14.Text = "Anticipo: ";
                of = new Fijo(idCodigo, cedula, nombre, apellidos, fechaNacimiento, sexo, estadoCivil, direccion, telefono, tipo, v1, v2, v3);
                return of;
            }
            else if(tipo == "Comision")
            {
                label12.Text = "Ventas: ";
                label13.Text = "Porcentaje: ";
                label14.Text = "...";
                ocm = new Comision(idCodigo, cedula, nombre, apellidos, fechaNacimiento, sexo, estadoCivil, direccion, telefono, tipo, v1, v2);
                return ocm;
            }

            return null;
        }

        public void setDatos(Persona persona)
        {
            textBox1.Text = persona.IdCodigo;
            textBox2.Text = persona.Cedula;
            textBox3.Text = persona.Nombre;
            textBox4.Text = persona.Apellidos;
            dateTimePicker1.Value = persona.FechaNacimiento;
            comboBox1.SelectedItem = persona.Sexo.ToString();
            comboBox2.SelectedItem = persona.EstadoCivil;
            textBox5.Text = persona.Direccion;
            textBox6.Text = persona.Telefono;
            comboBox3.Text = persona.Tipo;

            if (persona is Contratado)
            {
                Contratado c = (Contratado)persona;

                comboBox3.SelectedItem = "Contratado";

                label12.Text = "Hora: ";
                label13.Text = "Costo: ";
                label14.Text = "Iess: ";

                textBox7.Text = c.Hora.ToString();
                textBox8.Text = c.Costo.ToString();
                textBox9.Text = c.Iess.ToString();
            }
            else if (persona is Comisionado)
            {
                Comisionado c = (Comisionado)persona;

                comboBox3.SelectedItem = "Comisionado";

                label12.Text = "Ventas: ";
                label13.Text = "Porcentaje: ";
                label14.Text = "Salario: ";

                textBox7.Text = c.Ventas.ToString();
                textBox8.Text = c.Porcentage.ToString();
                textBox9.Text = c.Salario.ToString();
            }
            else if (persona is Comision)
            {
                Comision c = (Comision)persona;

                comboBox3.SelectedItem = "Comision";

                label12.Text = "Ventas: ";
                label13.Text = "Porcentaje: ";
                label14.Text = "...";

                textBox7.Text = c.Ventas.ToString();
                textBox8.Text = c.Porcentage.ToString();
                textBox9.Text = "";
            }
            else if (persona is Fijo)
            {
                Fijo f = (Fijo)persona;

                comboBox3.SelectedItem = "Fijo";

                label12.Text = "Salario: ";
                label13.Text = "Iess: ";
                label14.Text = "Anticipo: ";

                textBox7.Text = f.Salario.ToString();
                textBox8.Text = f.Iess.ToString();
                textBox9.Text = f.Anticipo.ToString();
            }
        }


        private void frmEdit_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem.ToString() == "Contratado")
            {
                label12.Text = "Hora: ";
                label13.Text = "Costo: ";
                label14.Text = "Iess: ";
                
            }
            else if (comboBox3.SelectedItem.ToString() == "Comisionado")
            {
                label12.Text = "Ventas: ";
                label13.Text = "Porcentaje: ";
                label14.Text = "Salario: ";
                
            }
            else if (comboBox3.SelectedItem.ToString() == "Fijo")
            {
                label12.Text = "Salario: ";
                label13.Text = "Iess: ";
                label14.Text = "Anticipo: ";
                
            }
            else if (comboBox3.SelectedItem.ToString() == "Comision")
            {
                label12.Text = "Ventas: ";
                label13.Text = "Porcentaje: ";
                label14.Text = "...";
                
            }
        }
    }
}
