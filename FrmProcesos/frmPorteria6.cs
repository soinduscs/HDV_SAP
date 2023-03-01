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

namespace FrmProcesos
{
    public partial class frmPorteria6 : Form
    {
        public frmPorteria6()
        {
            InitializeComponent();
        }

        private void frmPorteria6_Load(object sender, EventArgs e)
        {
            Carga_imagen();

            int id_docentry;

            try
            {
                id_docentry = VariablesGlobales.glb_id_acceso;
            }
            catch
            {
                id_docentry = 0;
            }

            if (id_docentry > 0)
            {
                t_idromana.Text = id_docentry.ToString();
            }

        }

        private void Carga_imagen()
        {
            int id_docentry;

            //VariablesGlobales.glb_LineId = 0;

            try
            {
                id_docentry = VariablesGlobales.glb_id_acceso;
            }
            catch
            {
                id_docentry = 0;
            }

            if (id_docentry > 0)
            {

                clsPorteria objproducto = new clsPorteria();
                objproducto.cls_Consultar_Accesos_x_Imagen(id_docentry);

                this.Dock = DockStyle.Fill;
                this.dataGridView1.DataSource = objproducto.cResultado;
                try
                {
                    DataGridViewImageCell cell = dataGridView1.CurrentRow.Cells[0] as DataGridViewImageCell;
                    byte[] imagen = (byte[])cell.Value;
                    pictureBox1.Image = byteArrayToImage(imagen);
                }
                catch
                {

                }

            }

        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
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

        public Image resizeImage(Image img, int width, int height)
        {
            Bitmap b = new Bitmap(width, height);
            Graphics g = Graphics.FromImage((Image)b);

            g.DrawImage(img, 0, 0, width, height);
            g.Dispose();

            return (Image)b;
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
                MessageBox.Show("Error en la digitalización del documento", "Control de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                t_imagen.Text = "C:/Temp/sheet_white.png";

            }

            try
            {
                Process.Start("C:/Temp/" + nom_archivo);
            }
            catch
            {

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = resizeImage(pictureBox1.Image, 500, 700);

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
            string CardCode = "solo_imagen";

            int id_docentry;

            try
            {
                id_docentry = int.Parse(t_idromana.Text);
            }
            catch
            {
                id_docentry = 0;
            }

            if (id_docentry > 0)
            {
                if (ruta_imagen != "")
                {
                    String mensaje1 = clsPorteria.SAPB1_ACCESO(id_docentry, CardCode, "", 0, "", 0, "", "", "", ruta_imagen, "", "", "");

                    if (mensaje1 == "Y")
                    {
                        MessageBox.Show("Registro Grabado", "Control de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show(mensaje1, "Control de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }

        }
    }
}
