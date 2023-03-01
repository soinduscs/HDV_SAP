using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using System.IO;
using System.Windows;

namespace FrmProcesos
{
    public partial class frmPorteria2 : Form
    {
        public frmPorteria2()
        {
            InitializeComponent();
        }

        private void frmPorteria2_Load(object sender, EventArgs e)
        {

            Carga_imagen();

            if (VariablesGlobales.glb_Referencia2 == "S")
            {
                btn_escanear.Enabled = true;
                //btn_imprimir.Enabled = true;
            }
            else
            {
                btn_escanear.Enabled = false;
                //btn_imprimir.Enabled = false;
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

        private void btn_escanear_Click(object sender, EventArgs e)
        {

            Random rnd = new Random();

            int var_archivo;
            string nom_archivo;

            var_archivo = rnd.Next(10000, 99999);

            nom_archivo = "Img" + Convert.ToString(var_archivo) + ".png";

            try
            {
                WIA.CommonDialog dialog = new WIA.CommonDialog();

                // var dialog = new WIA.CommonDialogClass();
                var scannedImage = dialog.ShowAcquireImage(WIA.WiaDeviceType.ScannerDeviceType) as WIA.ImageFile;
                if (scannedImage != null)
                {
                    if (System.IO.File.Exists("C:/Temp/" + nom_archivo))
                        System.IO.File.Delete("C:/Temp/" + nom_archivo);
                    scannedImage.SaveFile("C:/Temp/" + nom_archivo);
                    t_imagen.Text = "C:/Temp/" + nom_archivo;

                }
            }
            catch
            {
                MessageBox.Show("Error en la digitalización del documento", "Control de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                t_imagen.Text = "C:/Temp/sheet_white.png";

            }

            if (t_imagen.Text != "")
            {
                pictureBox1.Image = Image.FromFile(t_imagen.Text);

                pictureBox2.Image = resizeImage(pictureBox1.Image, 700, 900);



            }


            string CardCode = "solo_imagen";
            string ruta_imagen = t_imagen.Text;

            int id_acceso;

            try
            {
                id_acceso = VariablesGlobales.glb_id_acceso;

            }
            catch
            {
                id_acceso = 0;

            }

            if (id_acceso > 0)
            {
                if (ruta_imagen != "")
                {
                    String mensaje1 = clsPorteria.SAPB1_ACCESO(id_acceso, CardCode, "", 0, "", 0, "", "", "", ruta_imagen,"","","");

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

            Carga_imagen();

        }

        private void Carga_imagen()
        {
            int id_acceso;

            try
            {
                id_acceso = VariablesGlobales.glb_id_acceso;

            }
            catch
            {
                id_acceso = 0;

            }

            if (id_acceso > 0)
            {

                clsPorteria objproducto = new clsPorteria();
                objproducto.cls_Consultar_Accesos_x_Imagen(id_acceso);

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

        private void frmPorteria2_SizeChanged(object sender, EventArgs e)
        {
            int Height1 = this.Height;

            btn_cancelar.Top = Height1 - 60;
            btn_escanear.Top = Height1 - 60;
            btn_subir_imagen.Top = Height1 - 60;
            btn_imprimir.Top = Height1 - 60;

        }

        public Image resizeImage(Image img, int width, int height)
        {
            Bitmap b = new Bitmap(width, height);
            Graphics g = Graphics.FromImage((Image)b);

            g.DrawImage(img, 0, 0, width, height);
            g.Dispose();

            return (Image)b;
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            VariablesGlobales.glb_DocEntry = VariablesGlobales.glb_id_acceso;

            frmPorteria5 f2 = new frmPorteria5();
            DialogResult res = f2.ShowDialog();

            VariablesGlobales.glb_DocEntry = 0;

        }

        private void btn_subir_imagen_Click(object sender, EventArgs e)
        {
            VariablesGlobales.glb_DocEntry = VariablesGlobales.glb_id_acceso;

            frmPorteria6 f2 = new frmPorteria6();
            DialogResult res = f2.ShowDialog();

            VariablesGlobales.glb_DocEntry = 0;
        }
    }
}
