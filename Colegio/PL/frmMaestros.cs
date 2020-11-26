using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Colegio.DAL;
using Colegio.BLL;

namespace Colegio.PL
{
    public partial class frmMaestros : Form
    {
        MaestrosDAL oMaestrosDAL;
        public frmMaestros()
        {
            oMaestrosDAL = new MaestrosDAL();
            InitializeComponent();
            this.ActualizarDatos();
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            oMaestrosDAL.Agregar(RecuperarInformacion());
            MessageBox.Show(RecuperarInformacion().apellido + " " + RecuperarInformacion().nombre + " Has been Added as a new teacher");
            this.LimpiarControles();
            this.ActualizarDatos();
        }

        private MaestrosBLL RecuperarInformacion()
        {
            MaestrosBLL oMaestrosBLL = new MaestrosBLL();
            int ID = 0; int.TryParse(txtID.Text, out ID);
            oMaestrosBLL.ID = ID;
            oMaestrosBLL.apellido = txtApellido.Text;
            oMaestrosBLL.nombre = txtNombre.Text;

            return oMaestrosBLL;
        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;
            txtID.Text = dgvMaestros.Rows[indice].Cells[0].Value.ToString();
            txtApellido.Text = dgvMaestros.Rows[indice].Cells[1].Value.ToString();
            txtNombre.Text = dgvMaestros.Rows[indice].Cells[2].Value.ToString();
            btnAdd.Enabled = false;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {

            string message = "Do you want to eliminate this teacher ? ";
            string caption = "Delete Teacher";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Error);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                oMaestrosDAL.Eliminar(RecuperarInformacion());
                this.LimpiarControles();
                this.ActualizarDatos();
            }
            

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string message = "Do you want to update this teacher ? ";
            string caption = "Update Teacher";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                oMaestrosDAL.Modificar(RecuperarInformacion());
                this.LimpiarControles();
                this.ActualizarDatos();
            }

        }


        private void LimpiarControles()
        {
            txtID.ResetText();
            txtApellido.ResetText();
            txtNombre.ResetText();
        }

        private void ActualizarDatos() {
            dgvMaestros.DataSource = oMaestrosDAL.MostrarMaestros().Tables[0];
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            btnAdd.Enabled = true;
        }
    }


}
