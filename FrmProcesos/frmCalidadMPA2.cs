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
    public partial class frmCalidadMPA2 : Form
    {
        public frmCalidadMPA2()
        {
            InitializeComponent();
        }

        private void frmCalidadMPA2_Load(object sender, EventArgs e)
        {

        }

        private void btn_buscar1_Click(object sender, EventArgs e)
        {

            Grid1.Rows.Clear();

            t_cardcode.Clear();
            t_cardname.Clear();

            VariablesGlobales.glb_CardCode = "";
            VariablesGlobales.glb_CardName = "";

            frmSel_SocioNegocio f2 = new frmSel_SocioNegocio();
            DialogResult res = f2.ShowDialog();

            if (VariablesGlobales.glb_CardCode.Trim() != "")
            {
                t_cardcode.Text = VariablesGlobales.glb_CardCode.Trim();
                t_cardname.Text = VariablesGlobales.glb_CardName.Trim();

                t_cardcode.Focus();

            }

        }

        private void btn_consultar4_Click(object sender, EventArgs e)
        {

            string cCardCode;

            cCardCode = "";

            try
            {
                cCardCode = t_cardcode.Text;
            }
            catch
            {
                cCardCode = "";
            }

            carga_grilla(cCardCode);

        }

        private void carga_grilla(string cCardCode)
        {

            try
            {

                string cDocEntry, cNumGuia, cPatente;
                string cCardName, cNumOC, cStatusCalidad;
                string cItemCode, cItemName;

                DateTime dFecha;

                int nIdRomana, nLineId;

                clsCalidad objproducto = new clsCalidad();
                objproducto.cls_Consulta_Analisis_x_Cliente(cCardCode);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid1.Rows.Clear();

                string[] grilla;
                grilla = new string[30];

                //t0.DocEntry , t0.UserSign , t3.U_NAME , 
                //t2.U_NumGuia , t1.U_CardCode , t1.U_CardName , 
                //t2.U_Patente , t2.U_Conductor , 
                //t0.CreateDate , t0.CreateTime , 
                //t1.U_NumOC , 
                //t0. , t0.U_ItemName , 
                //t0. , t0. , t0., 
                //t2.U_PesoGuia



                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        cDocEntry = dTable.Rows[i]["DocEntry"].ToString();
                    }
                    catch
                    {
                        cDocEntry = "";

                    }

                    try
                    {
                        cNumGuia = dTable.Rows[i]["U_NumGuia"].ToString();

                    }
                    catch
                    {
                        cNumGuia = "";
                    }

                    try
                    {
                        cPatente = dTable.Rows[i]["U_Patente"].ToString();
                    }
                    catch
                    {
                        cPatente = "";
                    }

                    try
                    {
                        cCardName = dTable.Rows[i]["U_CardName"].ToString();
                    }
                    catch
                    {
                        cCardName = "";
                    }

                    try
                    {
                        cNumOC = dTable.Rows[i]["U_NumOC"].ToString();
                    }
                    catch
                    {
                        cNumOC = "";
                    }

                    try
                    {
                        cItemName = dTable.Rows[i]["U_ItemName"].ToString();
                    }
                    catch
                    {
                        cItemName = "";
                    }                    

                    try
                    {
                        cItemCode = dTable.Rows[i]["U_ItemCode"].ToString();
                    }
                    catch
                    {
                        cItemCode = "";
                    }

                    try
                    {
                        dFecha = Convert.ToDateTime(dTable.Rows[i]["U_FecIngr"].ToString());
                    }
                    catch
                    {
                        dFecha = DateTime.Parse("01/01/1900");
                    }

                    try
                    {
                        cStatusCalidad = dTable.Rows[i]["U_TipResul"].ToString();
                    }
                    catch
                    {
                        cStatusCalidad = "";
                    }

                    try
                    {
                        nIdRomana = int.Parse(dTable.Rows[i]["U_DocEntry_Ref"].ToString());

                    }
                    catch
                    {
                        nIdRomana = 0;

                    }

                    try
                    {
                        nLineId = int.Parse(dTable.Rows[i]["U_LineId_Ref"].ToString());
                    }
                    catch
                    {
                        nLineId = 0;
                    }

                    grilla[0] = cDocEntry.ToString();
                    grilla[1] = cNumGuia.ToString();
                    grilla[2] = cPatente.ToString();
                    grilla[3] = dFecha.ToString("dd/MM/yyyy");
                    grilla[4] = cCardName.ToString();
                    grilla[5] = cNumOC.ToString();
                    grilla[6] = cItemName.ToString();
                    grilla[7] = cStatusCalidad;
                    grilla[8] = nIdRomana.ToString();
                    grilla[9] = nLineId.ToString();
                    grilla[10] = cItemCode;
                    
                    Grid1.Rows.Add(grilla);

                    if (cStatusCalidad == "")
                    {
                        cStatusCalidad = "En Proceso";
                    }

                    if (cStatusCalidad == "En Proceso")
                    {
                        Grid1[7, i].Style.BackColor = Color.Yellow;
                    }

                    if (cStatusCalidad == "Aprobado")
                    {
                        Grid1[7, i].Style.BackColor = Color.Green;
                    }

                    if (cStatusCalidad == "Rechazad")
                    {
                        Grid1[7, i].Style.BackColor = Color.Red;
                    }

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

        private void button1_Click(object sender, EventArgs e)
        {

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("Debe ingresar un Productor válido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila, nLineId, nIdRomana;
            int nIdCalidad;
            string cItemCode;

            fila = 0;
            nLineId = 0;
            nIdCalidad = 0;
            cItemCode = "";

            try
            {
                fila = Grid1.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            if (fila < 0)
            {
                MessageBox.Show("Debe ingresar un Productor válido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            
            try
            {
                nIdRomana = Convert.ToInt32(Grid1[8, fila].Value.ToString());

            }
            catch
            {
                nIdRomana = -1;

            }

            try
            {
                nLineId = Convert.ToInt32(Grid1[9, fila].Value.ToString());

            }
            catch
            {
                nLineId = -1;

            }

            try
            {
                cItemCode = Grid1[10, fila].Value.ToString();

            }
            catch
            {
                cItemCode = "";

            }
            
            try
            {
                nIdCalidad = Convert.ToInt32(Grid1[0, fila].Value.ToString());
            }
            catch
            {
                nIdCalidad = 0;
            }           

            if (nLineId < 0)
            {
                MessageBox.Show("Debe ingresar un Productor válido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            

            VariablesGlobales.glb_id_calidad = nIdCalidad;
            VariablesGlobales.glb_Object = "100100";
            VariablesGlobales.glb_id_romana = nIdRomana;
            VariablesGlobales.glb_LineId = nLineId;
            VariablesGlobales.glb_ItemCode = cItemCode;

            frmCalidadMP f2 = new frmCalidadMP();
            DialogResult res = f2.ShowDialog();

            btn_consultar4_Click(sender, e);

        }
    }
}
