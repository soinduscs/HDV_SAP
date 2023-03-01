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
    public partial class frmCalidadMPA4 : Form
    {
        public frmCalidadMPA4()
        {
            InitializeComponent();
        }

        private void frmCalidadMPA4_Load(object sender, EventArgs e)
        {


            int id_docentry;

            try
            {
                id_docentry = VariablesGlobales.glb_id_calidad;
            }
            catch
            {
                id_docentry = 0;
            }

            if (id_docentry > 0)
            {
                t_idromana.Text = id_docentry.ToString();
            }

            carga_grilla();
            //Carga_imagen();

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
                clsCalidad objproducto = new clsCalidad();
                objproducto.cls_Consultar_Calidad_x_Lista_Imagen(nBaseEntry);

                this.dataGridView2.DataSource = objproducto.cResultado;
                this.dataGridView2.RowHeadersWidth = 10;
                this.dataGridView2.Columns[0].Visible = false;
                this.dataGridView2.Columns[1].Visible = false;
                this.dataGridView2.Columns[2].Visible = false;
                this.dataGridView2.Columns[3].HeaderText = "#";
                this.dataGridView2.Columns[3].Width = 40;
                this.dataGridView2.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridView2.Columns[4].HeaderText = "Fecha de Registro";
                this.dataGridView2.Columns[4].Width = 160;
                this.dataGridView2.Columns[5].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Carga_imagen()
        {
            int id_docentry;

            //VariablesGlobales.glb_LineId = 0;

            try
            {
                id_docentry = VariablesGlobales.glb_id_calidad;
            }
            catch
            {
                id_docentry = 0;
            }

            if (id_docentry > 0)
            {

                clsCalidad objproducto = new clsCalidad();
                objproducto.cls_Consultar_Calidad_x_Imagen(id_docentry, 0);

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
            //var filepath = string.Format("\"{0}\"", "C:/Temp/" + nom_archivo);

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

            int id_docentry, id_lineid; 

            try
            {
                id_docentry = int.Parse(t_idromana.Text);
            }
            catch
            {
                id_docentry = 0;
            }

            try
            {
                id_lineid = int.Parse(t_idlinea.Text);
            }
            catch
            {
                id_lineid = -1;
            }

            if (id_docentry > 0)
            {
                if (ruta_imagen != "")
                {
                    String mensaje1 = clsCalidad.SAPB1_ORCAL5(0, id_docentry, id_lineid, ruta_imagen);

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

        public Image resizeImage(Image img, int width, int height)
        {
            Bitmap b = new Bitmap(width, height);
            Graphics g = Graphics.FromImage((Image)b);

            g.DrawImage(img, 0, 0, width, height);
            g.Dispose();

            return (Image)b;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            int fila;

            try
            {
                fila = dataGridView2.CurrentCell.RowIndex;

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

            t_idlinea.Text = dataGridView2[3, fila].Value.ToString();

            Byte[] img = (Byte[])dataGridView2[5, fila].Value;
            MemoryStream ms = new MemoryStream(img);
            pictureBox1.Image = Image.FromStream(ms);

        }

        private void button3_Click(object sender, EventArgs e)
        {

            t_idlinea.Text = "";
            pictureBox1.Image.Dispose();
            pictureBox1.Image = null;

        }

    }

}
