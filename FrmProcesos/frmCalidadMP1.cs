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
    public partial class frmCalidadMP1 : Form
    {
        public frmCalidadMP1()
        {
            InitializeComponent();
        }

        private void frmCalidadMP1_Load(object sender, EventArgs e)
        {
            dtp_fecha.Value = DateTime.Today;

            string cFecha = "01/" + DateTime.Today.ToString("MM") + "/" + DateTime.Today.ToString("yyyy");
            DateTime dFecha = Convert.ToDateTime(cFecha);

            dtp_fecha1.Value = dFecha; 
            dtp_fecha2.Value = DateTime.Today;

            btn_registros_pendientes_Click(sender, e);

        }

        private void carga_grilla(string accion, string dato1, string dato2)
        {

            try
            {

                string cDocEntry, cLineID, cNumGuia;
                string cPatente, cCardName, cNumOC;
                string cItemName, cStatusCalidad, cMuestra;

                DateTime dFecha;

                int nCantItems, nCantRegistros, nCantRegistroAprobados;
                int nCantRegistroRechazados, nFila;

                clsCalidad objproducto = new clsCalidad();
                objproducto.cls_Consulta_Guias_Calidad(accion, dato1, dato2);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid1.Rows.Clear();

                nFila = 0;

                string[] grilla;
                grilla = new string[30];

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
                        cLineID = dTable.Rows[i]["LineId"].ToString();
                    }
                    catch
                    {
                        cLineID = "";

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
                        cCardName = dTable.Rows[i]["U_CardName_D"].ToString(); 
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
                        nCantItems = Convert.ToInt32(dTable.Rows[i]["CantItms"].ToString());
                    }
                    catch
                    {
                        nCantItems = 0;
                    }

                    try
                    {
                        nCantRegistros = Convert.ToInt32(dTable.Rows[i]["CantRegistros_Calidad"].ToString());
                    }
                    catch
                    {
                        nCantRegistros = 0;
                    }

                    try
                    {
                        nCantRegistroAprobados = Convert.ToInt32(dTable.Rows[i]["CantRegistros_Aprobados"].ToString());
                    }
                    catch
                    {
                        nCantRegistroAprobados = 0;
                    }

                    try
                    {
                        nCantRegistroRechazados = Convert.ToInt32(dTable.Rows[i]["CantRegistros_Rechazados"].ToString());
                    }
                    catch
                    {
                        nCantRegistroRechazados = 0;
                    }

                    try
                    {
                        dFecha = Convert.ToDateTime(dTable.Rows[i]["U_FechaPeso1"].ToString());
                    }
                    catch
                    {
                        dFecha = DateTime.Parse("01/01/1900");
                    }

                    if (dFecha.Year == 1900)
                    {
                        try
                        {
                            dFecha = Convert.ToDateTime(dTable.Rows[i]["CreateDate"].ToString());
                        }
                        catch
                        {
                            dFecha = DateTime.Parse("01/01/1900");
                        }

                    }

                    cStatusCalidad = "";

                    if (nCantItems > 0)
                    {
                        if ((nCantRegistros + nCantRegistroAprobados) == 0)
                        {
                            cStatusCalidad = "Inspección no Registrada";
                        }
                        else
                        {
                            if (nCantRegistros > 0)
                            {
                                cStatusCalidad = "Inspección en Proceso";

                            }
                            if (nCantRegistroAprobados >= nCantItems)
                            {
                                cStatusCalidad = "Inspección Finalizada - Aprobado";

                            }
                            else
                            {
                                if (nCantRegistroRechazados >= nCantItems)
                                {
                                    cStatusCalidad = "Inspección Finalizada - Rechazado";

                                }

                            }


                        }

                    }

                    grilla[0] = cDocEntry.ToString();
                    grilla[1] = cLineID.ToString();
                    grilla[2] = cNumGuia.ToString();
                    grilla[3] = cPatente.ToString();
                    grilla[4] = dFecha.ToString("dd/MM/yyyy");
                    grilla[5] = cCardName.ToString();
                    grilla[6] = cNumOC.ToString();
                    grilla[7] = cItemName.ToString();
                    grilla[8] = cStatusCalidad;

                    cMuestra = "S";

                    if (accion == "X")
                    {
                        cMuestra = "N";

                        if (cStatusCalidad == "Inspección no Registrada")
                        {
                            cMuestra = "S";
                        }

                        if (cStatusCalidad == "Inspección en Proceso")
                        {
                            cMuestra = "S";
                        }

                    }

                    if (cNumGuia == "0")
                    {
                        cMuestra = "N";

                    }

                    if (cMuestra == "S")
                    {

                        Grid1.Rows.Add(grilla);

                        if (cStatusCalidad == "Inspección no Registrada")
                        {
                            Grid1[8, nFila].Style.BackColor = Color.Empty;
                        }

                        if (cStatusCalidad == "Inspección en Proceso")
                        {
                            Grid1[8, nFila].Style.BackColor = Color.Yellow;
                        }

                        if (cStatusCalidad == "Inspección Finalizada - Aprobado")
                        {
                            Grid1[8, nFila].Style.BackColor = Color.Green;
                        }

                        if (cStatusCalidad == "Inspección Finalizada - Rechazado")
                        {
                            Grid1[8, nFila].Style.BackColor = Color.Red;
                        }

                        nFila += 1;

                    }
                        
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dtp_fecha_ValueChanged(object sender, EventArgs e)
        {
            btn_consultar1_Click(sender, e);

        }

        private void btn_consultar1_Click(object sender, EventArgs e)
        {

            DateTime fecha1;

            fecha1 = dtp_fecha.Value;

            string fecha = fecha1.ToString("yyyyMMdd");

            carga_grilla("F1", fecha, "");

            t_ultimo_boton.Text = "F1";

        }

        private void btn_consultar2_Click(object sender, EventArgs e)
        {

            DateTime fecha1, fecha2;

            fecha1 = dtp_fecha1.Value;
            fecha2 = dtp_fecha2.Value;

            string cfecha1 = fecha1.ToString("yyyyMMdd");
            string cfecha2 = fecha2.ToString("yyyyMMdd");

            carga_grilla("F2", cfecha1, cfecha2);

            t_ultimo_boton.Text = "F2";

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            button1_Click(sender, e);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila, id_romana;

            try
            {
                fila = Grid1.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            if (fila == -1)
            {
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            id_romana = 0;

            if (fila >= 0)
            {
                try
                {
                    id_romana = Convert.ToInt32(Grid1[0, fila].Value.ToString().ToUpper());

                }
                catch
                {
                    id_romana = 0;

                }

            }

            if (id_romana>0)
            {
                VariablesGlobales.glb_id_romana = id_romana;

                frmCalidadMP2 f2 = new frmCalidadMP2();
                DialogResult res = f2.ShowDialog();

                if (t_ultimo_boton.Text == "F1")
                {
                    btn_consultar1_Click(sender, e);

                }

                if (t_ultimo_boton.Text == "F2")
                {
                    btn_consultar2_Click(sender, e);

                }

                if (t_ultimo_boton.Text == "X")
                {
                    btn_registros_pendientes_Click(sender, e);

                }


            }


        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void Grid1_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Index == 2)
            {
                e.SortResult = int.Parse(e.CellValue1.ToString()).CompareTo(int.Parse(e.CellValue2.ToString()));
                e.Handled = true;
            }

            if (e.Column.Index == 6)
            {
                e.SortResult = int.Parse(e.CellValue1.ToString()).CompareTo(int.Parse(e.CellValue2.ToString()));
                e.Handled = true; 
            }


        }

        private void btn_consultar3_Click(object sender, EventArgs e)
        {

            int num_guia;
            string c_num_guia;

            num_guia = 0;
            c_num_guia = "";

            try
            {
                num_guia = Convert.ToInt32(t_num_guia.Text);
            }
            catch
            {
                num_guia = 0;
            }

            c_num_guia = num_guia.ToString();

            carga_grilla("N", c_num_guia, "");

            t_ultimo_boton.Text = "N";

        }

        private void t_num_guia_Leave(object sender, EventArgs e)
        {

            int num_guia;

            num_guia = 0;

            try
            {
                num_guia = Convert.ToInt32(t_num_guia.Text);
            }
            catch
            {
                num_guia = 0;
            }

            t_num_guia.Text = num_guia.ToString();

        }

        private void btn_buscar1_Click(object sender, EventArgs e)
        {
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

                t_num_guia.Focus();

            }

        }

        private void t_cardcode_Leave(object sender, EventArgs e)
        {

            t_cardcode.Text = t_cardcode.Text.Replace(".", "");
            t_cardcode.Text = t_cardcode.Text.Replace("-", "");
            t_cardcode.Text = t_cardcode.Text.Replace("p", "P");

            DataTable dTable = new DataTable();
            string CardCode, CardName;
            string CardCode_cP, CardNamecP;

            CardCode = t_cardcode.Text.ToUpper();
            CardName = "";

            CardCode_cP = "";
            CardNamecP = "";

            if (CardCode.Trim() != "")
            {
                if (CardCode.Substring(1, 1).ToUpper() == "P")
                {
                    CardCode_cP = CardCode.ToUpper();
                }
                else
                {
                    CardCode_cP = "P" + CardCode.ToUpper();
                }

            }


            clsSocioNegocio objproducto = new clsSocioNegocio();
            objproducto.cls_Consultar_OCRDxCardCode(CardCode.ToUpper());

            dTable = objproducto.cResultado;

            try
            {
                CardName = dTable.Rows[0].ItemArray[1].ToString();

            }
            catch
            {
                CardName = "";

            }

            objproducto.cls_Consultar_OCRDxCardCode(CardCode_cP.ToUpper());

            dTable = objproducto.cResultado;

            try
            {
                CardNamecP = dTable.Rows[0].ItemArray[1].ToString();

            }
            catch
            {
                CardNamecP = "";

            }

            t_cardname.Clear();

            if (t_cardcode.Text != "")
            {

                if (CardNamecP != "")
                {
                    t_cardcode.Text = CardCode_cP;
                    t_cardname.Text = CardNamecP;

                }
                else
                {
                    t_cardcode.Text = CardCode;
                    t_cardname.Text = CardName;

                }

                if (t_cardname.Text == "")
                {
                    CardName = "ENTIDAD NO EXISTE !!!!";
                    t_cardname.Text = CardName;
                    //t_cardname.Font. .ForeColor = Color.Red;
                }



            }

        }

        private void btn_consultar4_Click(object sender, EventArgs e)
        {

            string c_ItemCode;

            c_ItemCode = "";

            try
            {
                c_ItemCode = t_cardcode.Text;
            }
            catch
            {
                c_ItemCode = "";
            }
            

            carga_grilla("P", c_ItemCode, "");

            t_ultimo_boton.Text = "P";

        }

        private void btn_registros_pendientes_Click(object sender, EventArgs e)
        {
            DateTime fecha1;

            fecha1 = dtp_fecha.Value;

            string fecha = fecha1.ToString("yyyyMMdd");

            carga_grilla("X", fecha, "");

            t_ultimo_boton.Text = "X";

        }
    }


}
