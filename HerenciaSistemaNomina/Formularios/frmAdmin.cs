using HerenciaSistemaNomina.Controlador;
using HerenciaSistemaNomina.Entidades;
using System;
using System.Collections;
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
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }

        public void Datos()
        {
            TLista.lista.Add(new Fijo("001", "1723456789", "Juan", "Perez", new DateTime(1990, 5, 15), 'M', "Soltero", "Av. Siempre Viva 123", "0998765432", "Fijo", 1200, 9.35, 200));
            TLista.lista.Add(new Fijo("002", "1723456789", "Maria", "Gomez", new DateTime(1985, 8, 20), 'F', "Casado", "Calle Falsa 456", "0987654321", "Fijo", 1500, 12.5, 300));
            TLista.lista.Add(new Contratado("003", "1723456789", "Carlos", "Lopez", new DateTime(1992, 4, 10), 'M', "Soltero", "Av. Siempre Viva 789", "0991234567", "Contratado", 10, 20, 160));
            TLista.lista.Add(new Comisionado("004", "1723456789", "Ana", "Martinez", new DateTime(1988, 12, 5), 'F', "Casado", "Calle Falsa 321", "0981234567", "Comisionado", 5000, 15, 750));
            TLista.lista.Add(new Comision("005", "1723456789", "Luis", "Ramirez", new DateTime(1990, 7, 15), 'M', "Soltero", "Av. Siempre Viva 456", "0998765432", "Comision", 6000, 20));

        }

        public void ListarFijo()
        {
            dataGridView1.DataSource = TLista.ListarFijos();
        }

        public void ListarContratado()
        {
            dataGridView1.DataSource = TLista.ListarContratados();
        }

        public void ListarComisionado()
        {
            dataGridView1.DataSource = TLista.ListarComisionado();
        }

        public void ListarComision()
        {
            dataGridView1.DataSource = TLista.ListarComision();
        }

        public void ListarPorTipo()
        {
            if (comboBox1.SelectedItem == null) return;

            string tipo = comboBox1.SelectedItem.ToString();

            if (tipo == "Fijo")
            {
                ListarFijo();
            }   
            else if (tipo == "Contratado")
            {
                ListarContratado();
            } 
            else if (tipo == "Comisionado")
            {
                ListarComisionado();
            }
            else if (tipo == "Comision")
            {
                ListarComision();
            }
            else
            {
                ListarTodos();
            }
        }

        public void ListarTodos()
        {
            dataGridView1.DataSource = TLista.lista;
        }

        public void Nuevo()
        {
            try
            {
                frmEdit frm = new frmEdit();
                frm.Text = "Insertar Persona";
                frm.label1.Text = "Registro Persona";
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    Persona op = frm.CrearObjeto();

                    if (op is Fijo)
                        ControllerFijo.Agregar((Fijo)op);
                    else if (op is Contratado)
                    {
                        ControllerContratado.Agregar((Contratado)op);
                    }  
                    else if (op is Comisionado)
                    {
                        ControllerComisionado.Agregar((Comisionado)op);
                    } 
                    else if (op is Comision)
                    {
                        ControllerComision.Agregar((Comision)op);
                    }
                    ListarPorTipo();
                    MessageBox.Show("Persona ingresada");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar Persona: " + ex.Message);
            }
        }

        public void Modificar()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    frmEdit frm = new frmEdit();

                    Persona op = dataGridView1.CurrentRow.DataBoundItem as Persona;

                    frm.setDatos(op);
                    frm.ShowDialog();

                    if (frm.DialogResult == DialogResult.OK)
                    {
                        Persona nuevo = frm.CrearObjeto();

                        if (nuevo is Fijo)
                        {
                            int pos = ControllerFijo.Buscar(nuevo.IdCodigo);
                            ControllerFijo.Modificar(pos, (Fijo)nuevo);
                        }
                        else if (nuevo is Contratado)
                        {
                            int pos = ControllerContratado.Buscar(nuevo.IdCodigo);
                            ControllerContratado.Modificar(pos, (Contratado)nuevo);
                        }
                        else if (nuevo is Comisionado)
                        {
                            int pos = ControllerComisionado.Buscar(nuevo.IdCodigo);
                            ControllerComisionado.Modificar(pos, (Comisionado)nuevo);
                        }
                        else if (nuevo is Comision)
                        {
                            int pos = ControllerComision.Buscar(nuevo.IdCodigo);
                            ControllerComision.Modificar(pos, (Comision)nuevo);
                        }

                        ListarPorTipo();
                        MessageBox.Show("Actualizado correctamente");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message);
            }
        }

        public void Eliminar()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var res = MessageBox.Show("¿Está seguro de eliminar?", "Eliminar", MessageBoxButtons.YesNo);

                    if (res == DialogResult.Yes)
                    {
                        Persona op = dataGridView1.CurrentRow.DataBoundItem as Persona;

                        if (op is Fijo)
                        {
                            ControllerFijo.Eliminar(ControllerFijo.Buscar(op.IdCodigo));
                        }
                            
                        else if (op is Contratado)
                        {
                            ControllerContratado.Eliminar(ControllerContratado.Buscar(op.IdCodigo));
                        }
                            
                        else if (op is Comisionado)
                        {
                            ControllerComisionado.Eliminar(ControllerComisionado.Buscar(op.IdCodigo));
                        }
                            
                        else if (op is Comision)
                        {
                            ControllerComision.Eliminar(ControllerComision.Buscar(op.IdCodigo));
                        }    
                    }

                    ListarPorTipo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }



        private void frmAdminFijo_Load(object sender, EventArgs e)
        {
            Datos();
            ListarTodos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           ListarPorTipo();
        }
    }
}
