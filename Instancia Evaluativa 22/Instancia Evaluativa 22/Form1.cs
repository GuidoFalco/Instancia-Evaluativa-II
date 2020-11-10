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
using System.Xml;

namespace Instancia_Evaluativa_22
{
    public partial class Form1 : Form
    {
        Registro registrar = new Registro();

        private string nombre1;
        private int dni1;
        private string mail1;
        private float cantidad1;



        private Form formularioHijo;
        private Form formularioHijo2;
        public Form1()
        {
            InitializeComponent();
        }


        
        

        private void btnSubir_Click(object sender, EventArgs e)
        {
            

            try
            {



                nombre1 = txtnombre.Text;
                dni1 = System.Convert.ToInt32(txtdni.Text);
                mail1 = txtmail.Text;
                cantidad1 = System.Convert.ToInt32(txtcantidad.Text);



                registrar.nombre = nombre1;
                registrar.dni = System.Convert.ToString(dni1);
                registrar.mail = mail1;
                registrar.cantidad = System.Convert.ToString(cantidad1);






            

                lblRta.Text = "";
                if ((registrar.nombre != "" && registrar.nombre != "Nombre y Apellido") && (registrar.dni != "" && registrar.dni != "DNI") && (registrar.mail != "" && registrar.mail != "E-mail") && (registrar.cantidad != "" && registrar.cantidad != "Cantidad") && listBox1.SelectedItem != null)
                {
                    



                    

                    tabla.Rows.Add();
                    tabla.Rows[tabla.Rows.Count -1][0] = registrar.nombre;
                    tabla.Rows[tabla.Rows.Count -1][1] = registrar.dni;
                    tabla.Rows[tabla.Rows.Count -1][2] = registrar.mail;
                    tabla.Rows[tabla.Rows.Count -1][3] = registrar.cantidad;
                    tabla.Rows[tabla.Rows.Count -1][4] = listBox1.SelectedItem;





                }
                else
                {
                    lblRta.Text = "Hay algún campo vacío o datos no válidos!";
                }

            }catch(Exception)
            {
                MessageBox.Show(lblRta.Text = "Hay algún campo vacío o datos no válidos!", "Confirmar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            

            










        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
            }
            catch (Exception)
            {
                MessageBox.Show($"No hay elementos para eliminar!", "Confirmar", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }


            
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            
            lblRta.Text = "Datos registrados con éxito, se le enviará un mail con los detalles!";
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();

        }


        private void AbrirFormularioHijo(Form FormHijo)
        {
            if(formularioHijo != null)
            {
                formularioHijo.Close();
            }
            formularioHijo = FormHijo;
            FormHijo.Show();
        }

        private void AbrirFormularioHijo2(Form FormHijo2)
        {
            if (formularioHijo2 != null)
            {
                formularioHijo2.Close();
            }
            formularioHijo2 = FormHijo2;
            FormHijo2.Show();
        }



















        private void txtnombre_Click(object sender, EventArgs e)
        {
            txtnombre.Text = "";
        }

        private void txtdni_Click(object sender, EventArgs e)
        {
            txtdni.Text = "";
        }

        private void txtmail_Click(object sender, EventArgs e)
        {
            txtmail.Text = "";
        }

        private void txtcantidad_Click(object sender, EventArgs e)
        {
            txtcantidad.Text = "";
        }

        

        

        

        

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new RegistroUsuario());

            
        }

        

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo2(new Soporte());

        }

        

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            tabla.WriteXml(@"Lista.xml");
        }



        DataTable tabla = new DataTable();
        private void btnCrear_Click(object sender, EventArgs e)
        {
            tabla.TableName = "Lista";
            tabla.Columns.Add("Nombre y apellido", typeof(String));
            tabla.Columns.Add("DNI", typeof(int));
            tabla.Columns.Add("E-mail", typeof(String));
            tabla.Columns.Add("Cantidad", typeof(int));
            tabla.Columns.Add("Destinatario", typeof(String));

            dataGridView1.DataSource = tabla;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            tabla.ReadXml(@"Lista.xml");

            dataGridView1.DataSource = tabla;
        }
    }
}
