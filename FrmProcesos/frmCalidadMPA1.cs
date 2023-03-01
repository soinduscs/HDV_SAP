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

namespace FrmProcesos
{
    public partial class frmCalidadMPA1 : Form
    {
        public frmCalidadMPA1()
        {
            InitializeComponent();
        }

        private void frmCalidadMPA1_Load(object sender, EventArgs e)
        {

            t_DocEntry.Text = VariablesGlobales.glb_id_calidad.ToString();
            t_Lote.Text = VariablesGlobales.glb_Lote.ToString();
            
            carga_grilla();
        }

        private void carga_grilla()
        {

            try
            {

                clsCalidad objproducto = new clsCalidad();
                objproducto.cls_Consulta_Reg_Auditoria_Registros_Inspeccion(int.Parse(t_DocEntry.Text), t_Lote.Text);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                string cResponsable, cAccion;

                DateTime fecha;

                int fila;

                fila = 0;

                Grid1.Rows.Clear();

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        fila = int.Parse(dTable.Rows[i]["LineId"].ToString());
                    }
                    catch
                    {
                        fila = 0;

                    }
                    
                    try
                    {
                        fecha = DateTime.Parse(dTable.Rows[i]["U_Fecha"].ToString());

                    }
                    catch
                    {
                        fecha = DateTime.Parse("01/01/1900");

                    }

                    try
                    {
                        cResponsable = dTable.Rows[i]["U_NAME"].ToString();
                    }
                    catch
                    {
                        cResponsable = "";

                    }

                    try
                    {
                        cAccion = dTable.Rows[i]["U_Accion"].ToString();
                    }
                    catch
                    {
                        cAccion = "";

                    }


                    grilla[0] = t_DocEntry.Text;
                    grilla[1] = (i + 1).ToString(); // fila.ToString();
                    grilla[2] = cResponsable;
                    grilla[3] = fecha.ToString("dd/MM/yyyy HH:mm");
                    grilla[4] = cAccion;

                    Grid1.Rows.Add(grilla);

                }

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
    }

}
