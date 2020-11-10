using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Instancia_Evaluativa_22
{
    public partial class Soporte : Form
    {
        public Soporte()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            txtSoporte.Text = "";
            this.Close();
            
            if(txtSoporte.Text != "")
            {
                MessageBox.Show($"Comentario enviado con éxito", "Confirmar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            
        }
    }
}
