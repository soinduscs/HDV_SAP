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
    public partial class frmControlProductor : Form
    {
        public frmControlProductor()
        {
            InitializeComponent();
        }

        private void frmControlProductor_Load(object sender, EventArgs e)
        {
            carga_grilla();
            pinta_grilla();
        }

        private void carga_grilla()
        {

            Grid1.Rows.Clear();

            try
            {
                clsMaestros objproducto = new clsMaestros();
                objproducto.cls_Consulta_ControlProductor();

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    grilla[0] = dTable.Rows[i]["LotNumber"].ToString();
                    grilla[1] = dTable.Rows[i]["NomCli"].ToString();
                    grilla[2] = dTable.Rows[i]["MnfSerial"].ToString();
                    grilla[3] = dTable.Rows[i]["NomProd"].ToString();
                    grilla[4] = dTable.Rows[i]["PermiteAgrupar"].ToString(); 

                    Grid1.Rows.Add(grilla);

                    //Grid1[0, Grid1.Rows.Count - 1].Value = Image.FromFile(Application.StartupPath + "\\Resources\\16 (Box_unchecked).ico");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void pinta_grilla()
        {
            string cSiNo;

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {
                cSiNo = Grid1[4, i].Value.ToString();

                if (cSiNo=="SI")
                {
                    Grid1[1, i].Style.BackColor = Color.Empty;
                    Grid1[3, i].Style.BackColor = Color.Empty;
                    Grid1[4, i].Style.BackColor = Color.Empty;
                }
                else
                {
                    Grid1[1, i].Style.BackColor = Color.Yellow;
                    Grid1[3, i].Style.BackColor = Color.Yellow;
                    Grid1[4, i].Style.BackColor = Color.Yellow;
                }

            }

        }

        private void btn_aplica_Click(object sender, EventArgs e)
        {

            int fila;
            string cLotNumber, cMnfSerial, cSiNo;

            cLotNumber = "";
            cMnfSerial = "";

            try
            {
                fila = Grid1.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            if (fila >= 0)
            {
                try
                {
                    cLotNumber = Grid1[0, fila].Value.ToString().ToUpper();
                    cMnfSerial = Grid1[2, fila].Value.ToString().ToUpper();
                    cSiNo = Grid1[4, fila].Value.ToString().ToUpper();

                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                    DialogResult result;

                    result = MessageBox.Show("Esta Seguro de cambiar la condición de agrupación", "Control de Lotes por Productor / Servicios", buttons);

                    if (result == System.Windows.Forms.DialogResult.No)
                    {
                        return;

                    }

                    string Accion;

                    if (cSiNo == "SI")
                    {
                        Accion = "N";

                    }
                    else
                    {
                        Accion = "E";

                    }

                    if (Accion == "E")
                    {
                        VariablesGlobales.glb_User_Code_Autorizacion = "";

                        frmLoginSupervisor f5 = new frmLoginSupervisor();
                        DialogResult res5 = f5.ShowDialog();

                        if (VariablesGlobales.glb_User_Code_Autorizacion == "")
                        {
                            MessageBox.Show("Clave de Supervisor No valida, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;

                        }

                    }

                    /////////////////////////////////////////////////////////
                    // Debo validar que existe como registro de manera previa

                    String mensaje = clsMaestros.SAPB1_OCRX(Accion, cLotNumber, cMnfSerial , VariablesGlobales.glb_User_id , VariablesGlobales.glb_User_Code , VariablesGlobales.glb_User_Psw);

                    if (cSiNo == "SI")
                    {
                        Grid1[4, fila].Value = "NO";
                        Accion = "N";

                    }
                    else
                    {
                        Grid1[4, fila].Value = "SI";
                        Accion = "E";

                    }


                }
                catch
                {

                }

            }

            pinta_grilla();

        }

    }

}
