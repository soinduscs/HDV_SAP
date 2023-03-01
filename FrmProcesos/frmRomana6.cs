using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CapaNegocio;
using System.Diagnostics;
//using System.ComponentModel;

namespace FrmProcesos
{
    public partial class frmRomana6 : Form
    {
        public frmRomana6()
        {
            InitializeComponent();
        }

        private void frmRomana6_Load(object sender, EventArgs e)
        {
            t_idromana.Text = VariablesGlobales.glb_id_romana1.ToString();
            t_idlinea.Text = "._.";

            carga_grilla();

            t_idlinea.Text = "";

        }

        private void carga_grilla()
        {
            int nBaseEntry;

            try
            {
                nBaseEntry = int.Parse(t_idromana.Text);
            }
            catch
            {
                nBaseEntry = 0;
            }

            try
            {
                clsRomana objproducto = new clsRomana();
                objproducto.cls_Consulta_Imagenes_de_Romana(nBaseEntry);

                this.dataGridView1.DataSource = objproducto.cResultado;
                this.dataGridView1.RowHeadersWidth = 10;
                this.dataGridView1.Columns[0].Visible = false;
                this.dataGridView1.Columns[1].HeaderText = "Tipo de Pesaje";
                this.dataGridView1.Columns[1].Width = 180;
                this.dataGridView1.Columns[2].Visible = false;
                this.dataGridView1.Columns[3].HeaderText = "#";
                this.dataGridView1.Columns[3].Width = 40;
                this.dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridView1.Columns[4].HeaderText = "Fecha de Registro";
                this.dataGridView1.Columns[4].Width = 160;
                this.dataGridView1.Columns[5].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string imagen = openFileDialog1.FileName;
                    pictureBox1.Image = Image.FromFile(imagen);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            cbb_tipo.Enabled = true;

            t_idlinea.Text = "";
            pictureBox1.Image.Dispose();
            pictureBox1.Image = null;

        }
      
        private void btn_pegar_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = Clipboard.GetImage();
            }
            catch
            {

            } 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = resizeImage(pictureBox1.Image, 1080, 600);

            Random rnd = new Random();

            int var_archivo;
            string nom_archivo;

            var_archivo = rnd.Next(10000, 99999);

            nom_archivo = "Img" + Convert.ToString(var_archivo) + ".png";

            try
            {
                pictureBox2.Image.Save("C:/Temp/" + nom_archivo);
                t_imagen.Text = "C:/Temp/" + nom_archivo;
            }
            catch
            {
                MessageBox.Show("Error en la digitalización del documento", "Control de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                t_imagen.Text = "C:/Temp/sheet_white.png";

            }

            string ruta_imagen = t_imagen.Text;

            int id_romana, nLineId, nTipoFoto;

            try
            {
                id_romana = int.Parse(t_idromana.Text);
            }
            catch
            {
                id_romana = 0;
            }

            try
            {
                nLineId= int.Parse(t_idlinea.Text);
            }
            catch
            {
                nLineId = -1;
            }

            try
            {
                nTipoFoto = cbb_tipo.SelectedIndex;
            }
            catch
            {
                nTipoFoto = -1;
            } 

            if (nTipoFoto == -1)
            {
                MessageBox.Show("Error en la digitalización del documento", "Control de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (id_romana > 0)
            {
                if (ruta_imagen != "")
                {
                    String mensaje1 = clsPorteria.SAPB1_ACCESO1(0, id_romana, nLineId, nTipoFoto, ruta_imagen, "100100");

                    if (mensaje1 == "Y")
                    {
                        MessageBox.Show("Registro Grabado", "Control de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        t_idlinea.Text = "._.";

                        carga_grilla();

                        t_idlinea.Text = "";

                    }
                    else
                    {
                        MessageBox.Show(mensaje1, "Control de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int fila, nTipo;

            try
            {
                fila = dataGridView1.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            if (fila < 0)
            {
                return;
            }

            if (t_idlinea.Text == "._.")
            {
                return;
            }

            try
            {
                nTipo = int.Parse(dataGridView1[2, fila].Value.ToString());
            }
            catch
            {
                nTipo = -1;
            }

            t_tipo.Text = dataGridView1[2, fila].Value.ToString();
            t_idlinea.Text = dataGridView1[3, fila].Value.ToString();

            if (nTipo>=0)
            {
                cbb_tipo.SelectedIndex = nTipo;
            }
            else
            {
                cbb_tipo.SelectedIndex = 0;
            }

            cbb_tipo.Enabled = false;

            Byte[] img = (Byte[])dataGridView1[5, fila].Value;
            MemoryStream ms = new MemoryStream(img);
            pictureBox1.Image = Image.FromStream(ms);

        }

        private void btn_exportar_Click(object sender, EventArgs e)
        {

            Random rnd = new Random();

            int var_archivo;
            string nom_archivo;

            var_archivo = rnd.Next(10000, 99999);

            nom_archivo = "Img" + Convert.ToString(var_archivo) + ".png";

            try
            {
                pictureBox1.Image.Save("C:/Temp/" + nom_archivo);
                t_imagen.Text = "C:/Temp/" + nom_archivo;
            }
            catch
            {
                MessageBox.Show("Error en la digitalización del documento", "Control de Pesaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                t_imagen.Text = "C:/Temp/sheet_white.png";

            }

            //var filepath = string.Format("\"{0}\"", "C:/Temp/" + nom_archivo);
            Process.Start("C:/Temp/" + nom_archivo);

        }

        public Image resizeImage(Image img, int width, int height)
        {
            Bitmap b = new Bitmap(width, height);
            Graphics g = Graphics.FromImage((Image)b);

            g.DrawImage(img, 0, 0, width, height);
            g.Dispose();

            return (Image)b;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            int id_romana, nLineId; //, nTipoFoto;

            try
            {
                id_romana = int.Parse(t_idromana.Text);
            }
            catch
            {
                id_romana = 0;
            }

            try
            {
                nLineId = int.Parse(t_idlinea.Text);
            }
            catch
            {
                nLineId = -1;
            }

            if (id_romana > 0)
            {

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                DialogResult result;

                result = MessageBox.Show("Esta Seguro de Eliminar la imagen Asociada", "Control de Pesaje", buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    String mensaje1 = clsPorteria.SAPB1_ACCESO2(0, id_romana, nLineId, "100100");

                    if (mensaje1 == "Y")
                    {
                        MessageBox.Show("Registro Grabado", "Control de Pesaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        t_idlinea.Text = "._.";

                        carga_grilla();

                        t_idlinea.Text = "";

                    }
                    else
                    {
                        MessageBox.Show(mensaje1, "Control de Pesaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }


            }

        }

    }

}
