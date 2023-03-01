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
    public partial class frmOrdenFabricacionTrz1 : Form
    {
        public frmOrdenFabricacionTrz1()
        {
            InitializeComponent();
        }

        private void frmOrdenFabricacionTrz1_Load(object sender, EventArgs e)
        {

            clsProduccion objproducto1 = new clsProduccion();
            objproducto1.Cls_ConsultaLista_TipoFruta1();

            cbb_Proceso_MP.DataSource = objproducto1.cResultado;
            cbb_Proceso_MP.ValueMember = "Code";
            cbb_Proceso_MP.DisplayMember = "Code";
            cbb_Proceso_MP.SelectedIndex = 5;

            clsProduccion objproducto = new clsProduccion();
            objproducto.Cls_ConsultaLista_TipoFruta1();

            cbb_Proceso_PT.DataSource = objproducto.cResultado;
            cbb_Proceso_PT.ValueMember = "Code";
            cbb_Proceso_PT.DisplayMember = "Code";
            cbb_Proceso_PT.SelectedIndex = 5;

        }

        private void btn_consultar6_Click(object sender, EventArgs e)
        {

            Grida1.Rows.Clear();

            carga_grilla9();

            Application.DoEvents();

            Grid2.Rows.Clear();

            carga_grilla1();

            Application.DoEvents();

            Grid3.Rows.Clear();

            carga_grilla2();

            Application.DoEvents();

        }

        private void carga_grilla9()
        {

            Grida1.Rows.Clear();

            string clote, ctipo_fruta, cciclo_estricto;

            try
            {
                clote = t_num_lote.Text;
            }
            catch
            {
                clote = "";
            }

            if (clote == "")
            {
                MessageBox.Show("Debe ingresar un lote válido, opción Cancelada", "Trazabilidad de Lotes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                ctipo_fruta = cbb_Proceso_PT.Text;
            }
            catch
            {
                ctipo_fruta = "";
            }

            if (ctipo_fruta == "")
            {
                MessageBox.Show("Debe ingresar un tipo de fruta válido, opción Cancelada", "Trazabilidad de Lotes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ctipo_fruta == "Todo Proceso")
            {
                ctipo_fruta = "%";
            }

            cciclo_estricto = "S";

            if (chk_proceso_estricto_pt.Checked == false)
            {
                cciclo_estricto = "N";

            }

            string cnuez_mecanica_subproceso;

            cnuez_mecanica_subproceso = "";

            if (ctipo_fruta == "Nuez Mecanica")
            {
                try
                {
                    cnuez_mecanica_subproceso = cbb_proceso_nmec_pt.Text;
                }
                catch
                {
                    cnuez_mecanica_subproceso = "";
                }

                if (cnuez_mecanica_subproceso == "Mitades")
                {
                    ctipo_fruta = "Nuez Mecanica_M";
                }

                if (cnuez_mecanica_subproceso == "Large")
                {
                    ctipo_fruta = "Nuez Mecanica_L";

                }

                if (cnuez_mecanica_subproceso == "Medium")
                {
                    ctipo_fruta = "Nuez Mecanica_E";

                }

                if (cnuez_mecanica_subproceso == "Large/Medium")
                {
                    ctipo_fruta = "Nuez Mecanica_A";

                }

            }

            string cLote, cItemCode, cItemName;
            string cNomProductor, cCodigo_CSG, cWhsCode;
            string cVariedad, cFumigado;

            double nQuantity, nStockActual, nCantidadEntrega;
            double nCantidadOV;

            int nDocEntry_Cal, nDocEntry;

            DateTime dFecha, dFechaFumigacion;

            try
            {

                clsCalidad objproducto = new clsCalidad();

                objproducto.cls_SAPB1_INF_TRAZABILIDAD_PT_CSG(clote, "4", ctipo_fruta, cciclo_estricto);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grida1.Rows.Clear();

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        cLote = dTable.Rows[i]["DistNumber"].ToString();
                    }
                    catch
                    {
                        cLote = "";
                    }

                    try
                    {
                        cCodigo_CSG = dTable.Rows[i]["U_Codigo_CSG"].ToString();
                    }
                    catch
                    {
                        cCodigo_CSG = "";
                    }

                    try
                    {
                        cItemCode = dTable.Rows[i]["ItemCode"].ToString();
                    }
                    catch
                    {
                        cItemCode = "";
                    }

                    try
                    {
                        cItemName = dTable.Rows[i]["ItemName"].ToString();
                    }
                    catch
                    {
                        cItemName = "";
                    }

                    try
                    {
                        cNomProductor = dTable.Rows[i]["U_NOMBPROD"].ToString();
                    }
                    catch
                    {
                        cNomProductor = "";
                    }

                    try
                    {
                        nQuantity = double.Parse(dTable.Rows[i]["Quantity"].ToString());
                    }
                    catch
                    {
                        nQuantity = 0;
                    }

                    try
                    {
                        nStockActual = double.Parse(dTable.Rows[i]["StockActualLote"].ToString());
                    }
                    catch
                    {
                        nStockActual = 0;
                    }

                    try
                    {
                        nDocEntry = int.Parse(dTable.Rows[i]["NumeroDocto"].ToString());
                    }
                    catch
                    {
                        nDocEntry = 0;
                    }

                    try
                    {
                        nDocEntry_Cal = int.Parse(dTable.Rows[i]["DocEntry_Calidad"].ToString());
                    }
                    catch
                    {
                        nDocEntry_Cal = 0;
                    }

                    try
                    {
                        cWhsCode = dTable.Rows[i]["WhsCode"].ToString();
                    }
                    catch
                    {
                        cWhsCode = "";
                    }

                    try
                    {
                        dFecha = Convert.ToDateTime(dTable.Rows[i]["FechaRecepcion"].ToString());
                    }
                    catch
                    {
                        dFecha = DateTime.Parse("01/01/1900");
                    }

                    try
                    {
                        cVariedad = dTable.Rows[i]["U_HDV_VARIEDAD"].ToString();
                    }
                    catch
                    {
                        cVariedad = "";
                    }

                    try
                    {
                        cFumigado = dTable.Rows[i]["U_Fumigado"].ToString();

                    }
                    catch
                    {
                        cFumigado = "No";

                    }

                    try
                    {
                        dFechaFumigacion = Convert.ToDateTime(dTable.Rows[i]["U_FechaFumigacion"].ToString());
                    }
                    catch
                    {
                        dFechaFumigacion = DateTime.Parse("01/01/1900");
                    }

                    try
                    {
                        nCantidadEntrega = double.Parse(dTable.Rows[i]["CantidadEntrega"].ToString());
                    }
                    catch
                    {
                        nCantidadEntrega = 0;
                    }

                    try
                    {
                        nCantidadOV = double.Parse(dTable.Rows[i]["CantidadOV"].ToString());
                    }
                    catch
                    {
                        nCantidadOV = 0;
                    }

                    grilla[0] = cLote;
                    grilla[1] = cCodigo_CSG;
                    grilla[2] = cItemCode;
                    grilla[3] = cItemName;
                    grilla[4] = cNomProductor;
                    grilla[5] = cVariedad;

                    grilla[6] = nQuantity.ToString("N2");
                    grilla[7] = nStockActual.ToString("N2");

                    grilla[8] = nDocEntry_Cal.ToString();
                    grilla[9] = nDocEntry.ToString();

                    grilla[10] = cFumigado;

                    if (dFechaFumigacion.ToString("yyyy") == "1900")
                    {
                        grilla[11] = "";
                    }
                    else
                    {
                        grilla[11] = dFechaFumigacion.ToString("dd/MM/yyyy");
                    }

                    try
                    {
                        grilla[12] = dTable.Rows[i]["NumOV"].ToString();

                    }
                    catch
                    {
                        grilla[12] = "";

                    }

                    grilla[13] = nCantidadOV.ToString("N2");

                    try
                    {
                        grilla[14] = dTable.Rows[i]["NumEntrega"].ToString();

                    }
                    catch
                    {
                        grilla[14] = "";

                    }

                    grilla[15] = nCantidadEntrega.ToString("N2");

                    try
                    {
                        grilla[16] = dTable.Rows[i]["ClienteOV"].ToString();

                    }
                    catch
                    {
                        grilla[16] = "";

                    }

                    if (grilla[16] == "")
                    {
                        try
                        {
                            grilla[16] = dTable.Rows[i]["ClienteEntrega"].ToString();

                        }
                        catch
                        {
                            grilla[16] = "";

                        }

                    }

                    Grida1.Rows.Add(grilla);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void carga_grilla1()
        {
            Grid2.Rows.Clear();

            string clote, ctipo_fruta, cciclo_estricto;

            try
            {
                clote = t_num_lote.Text;
            }
            catch
            {
                clote = "";
            }

            if (clote == "")
            {
                MessageBox.Show("Debe ingresar un lote válido, opción Cancelada", "Trazabilidad de Lotes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            try
            {
                ctipo_fruta = cbb_Proceso_PT.Text;
            }
            catch
            {
                ctipo_fruta = "";
            }

            if (ctipo_fruta == "")
            {
                MessageBox.Show("Debe ingresar un tipo de fruta válido, opción Cancelada", "Trazabilidad de Lotes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ctipo_fruta == "Todo Proceso")
            {
                ctipo_fruta = "%";
            }

            cciclo_estricto = "S";

            if (chk_proceso_estricto_pt.Checked == false)
            {
                cciclo_estricto = "N";

            }

            string cnuez_mecanica_subproceso;

            cnuez_mecanica_subproceso = "";

            if (ctipo_fruta == "Nuez Mecanica")
            {
                try
                {
                    cnuez_mecanica_subproceso = cbb_proceso_nmec_pt.Text;
                }
                catch
                {
                    cnuez_mecanica_subproceso = "";
                }

                if (cnuez_mecanica_subproceso == "Mitades")
                {
                    ctipo_fruta = "Nuez Mecanica_M";
                }

                if (cnuez_mecanica_subproceso == "Large")
                {
                    ctipo_fruta = "Nuez Mecanica_L";

                }

                if (cnuez_mecanica_subproceso == "Medium")
                {
                    ctipo_fruta = "Nuez Mecanica_E";

                }

                if (cnuez_mecanica_subproceso == "Large/Medium")
                {
                    ctipo_fruta = "Nuez Mecanica_A";

                }

            }

            string cLote, cItemCode, cItemName;
            string cNomProductor, cCodigo_CSG, cBins;
            string cWhsCode, cFolioNum, cNumOC;
            string cVariedad, cFumigado;

            double nCantidadRecepcionada;

            int nDocEntry_Cal, nDocEntry;

            DateTime dFecha, dFechaFumigacion;

            try
            {

                clsCalidad objproducto = new clsCalidad();

                objproducto.cls_SAPB1_INF_TRAZABILIDAD_PT_CSG(clote, "2", ctipo_fruta, cciclo_estricto);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid2.Rows.Clear();

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        cLote = dTable.Rows[i]["DistNumber"].ToString();
                    }
                    catch
                    {
                        cLote = "";
                    }

                    try
                    {
                        cCodigo_CSG = dTable.Rows[i]["U_Codigo_CSG"].ToString();
                    }
                    catch
                    {
                        cCodigo_CSG = "";
                    }

                    try
                    {
                        cItemCode = dTable.Rows[i]["ItemCode"].ToString();
                    }
                    catch
                    {
                        cItemCode = "";
                    }

                    try
                    {
                        cItemName = dTable.Rows[i]["ItemName"].ToString();
                    }
                    catch
                    {
                        cItemName = "";
                    }

                    try
                    {
                        cNomProductor = dTable.Rows[i]["U_NOMBPROD"].ToString();
                    }
                    catch
                    {
                        cNomProductor = "";
                    }

                    try
                    {
                        cBins = dTable.Rows[i]["U_BINS"].ToString();
                    }
                    catch
                    {
                        cBins = "";
                    }

                    try
                    {
                        nDocEntry = int.Parse(dTable.Rows[i]["DocEntry"].ToString());
                    }
                    catch
                    {
                        nDocEntry = 0;
                    }

                    try
                    {
                        nDocEntry_Cal = int.Parse(dTable.Rows[i]["DocEntry_Calidad"].ToString());
                    }
                    catch
                    {
                        nDocEntry_Cal = 0;
                    }

                    try
                    {
                        cFolioNum = dTable.Rows[i]["FolioNum"].ToString();
                    }
                    catch
                    {
                        cFolioNum = "";
                    }

                    try
                    {
                        cNumOC = dTable.Rows[i]["BaseRef"].ToString();
                    }
                    catch
                    {
                        cNumOC = "";
                    }

                    try
                    {
                        cWhsCode = dTable.Rows[i]["WhsCode"].ToString();
                    }
                    catch
                    {
                        cWhsCode = "";
                    }

                    try
                    {
                        nCantidadRecepcionada = double.Parse(dTable.Rows[i]["CantidadRecepcionada"].ToString());
                    }
                    catch
                    {
                        nCantidadRecepcionada = 0;
                    }

                    try
                    {
                        dFecha = Convert.ToDateTime(dTable.Rows[i]["FechaRecepcion"].ToString());
                    }
                    catch
                    {
                        dFecha = DateTime.Parse("01/01/1900");
                    }

                    try
                    {
                        cVariedad = dTable.Rows[i]["U_HDV_VARIEDAD"].ToString();
                    }
                    catch
                    {
                        cVariedad = "";
                    }

                    try
                    {
                        cFumigado = dTable.Rows[i]["U_Fumigado"].ToString();
                    }
                    catch
                    {
                        cFumigado = "No";
                    }

                    try
                    {
                        dFechaFumigacion = Convert.ToDateTime(dTable.Rows[i]["U_FechaFumigacion"].ToString());
                    }
                    catch
                    {
                        dFechaFumigacion = DateTime.Parse("01/01/1900");
                    }

                    grilla[0] = cLote;
                    grilla[1] = cCodigo_CSG;
                    grilla[2] = cItemCode;
                    grilla[3] = cItemName;
                    grilla[4] = cNomProductor;
                    grilla[5] = cBins;
                    grilla[6] = cVariedad;
                    grilla[7] = nDocEntry.ToString();
                    grilla[8] = cFolioNum;
                    grilla[9] = cNumOC;
                    grilla[10] = nCantidadRecepcionada.ToString("N2");

                    if (dFecha.ToString("yyyy") == "1900")
                    {
                        grilla[11] = "";
                    }
                    else
                    {
                        grilla[11] = dFecha.ToString("dd/MM/yyyy");
                    }

                    grilla[12] = cWhsCode;
                    grilla[13] = nDocEntry_Cal.ToString();

                    grilla[14] = cFumigado;

                    if (dFechaFumigacion.ToString("yyyy") == "1900")
                    {
                        grilla[15] = "";
                    }
                    else
                    {
                        grilla[15] = dFechaFumigacion.ToString("dd/MM/yyyy");
                    }

                    Grid2.Rows.Add(grilla);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void carga_grilla2()
        {
            Grid3.Rows.Clear();

            string clote, ctipo_fruta, cciclo_estricto;

            try
            {
                clote = t_num_lote.Text;
            }
            catch
            {
                clote = "";
            }

            if (clote == "")
            {
                MessageBox.Show("Debe ingresar un lote válido, opción Cancelada", "Trazabilidad de Lotes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            try
            {
                ctipo_fruta = cbb_Proceso_PT.Text;
            }
            catch
            {
                ctipo_fruta = "";
            }

            if (ctipo_fruta == "")
            {
                MessageBox.Show("Debe ingresar un tipo de fruta válido, opción Cancelada", "Trazabilidad de Lotes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ctipo_fruta == "Todo Proceso")
            {
                ctipo_fruta = "%";
            }

            cciclo_estricto = "S";

            if (chk_proceso_estricto_pt.Checked == false)
            {
                cciclo_estricto = "N";

            }

            string cnuez_mecanica_subproceso;

            cnuez_mecanica_subproceso = "";

            if (ctipo_fruta == "Nuez Mecanica")
            {
                try
                {
                    cnuez_mecanica_subproceso = cbb_proceso_nmec_pt.Text;
                }
                catch
                {
                    cnuez_mecanica_subproceso = "";
                }

                if (cnuez_mecanica_subproceso == "Mitades")
                {
                    ctipo_fruta = "Nuez Mecanica_M";
                }

                if (cnuez_mecanica_subproceso == "Large")
                {
                    ctipo_fruta = "Nuez Mecanica_L";

                }

                if (cnuez_mecanica_subproceso == "Medium")
                {
                    ctipo_fruta = "Nuez Mecanica_E";

                }

                if (cnuez_mecanica_subproceso == "Large/Medium")
                {
                    ctipo_fruta = "Nuez Mecanica_A";

                }

            }

            string cLote, cItemCode, cItemName;
            string cNomProductor, cNomCliente, cBins;
            string cWhsCode, cFolioNum, cNumOC;
            string cVariedad;

            double nCantidadRecepcionada;

            int nDocEntry_Cal, nDocEntry;

            DateTime dFecha;

            try
            {

                clsCalidad objproducto = new clsCalidad();

                objproducto.cls_SAPB1_INF_TRAZABILIDAD_PT(clote, "3", ctipo_fruta, cciclo_estricto);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid3.Rows.Clear();

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        cLote = dTable.Rows[i]["DistNumber"].ToString();
                    }
                    catch
                    {
                        cLote = "";
                    }

                    try
                    {
                        cItemCode = dTable.Rows[i]["ItemCode"].ToString();
                    }
                    catch
                    {
                        cItemCode = "";
                    }

                    try
                    {
                        cItemName = dTable.Rows[i]["ItemName"].ToString();
                    }
                    catch
                    {
                        cItemName = "";
                    }

                    try
                    {
                        cNomProductor = dTable.Rows[i]["U_NOMBPROD"].ToString();
                    }
                    catch
                    {
                        cNomProductor = "";
                    }

                    try
                    {
                        cNomCliente = dTable.Rows[i]["U_NOMBCLI"].ToString();
                    }
                    catch
                    {
                        cNomCliente = "";
                    }

                    try
                    {
                        cBins = dTable.Rows[i]["U_BINS"].ToString();
                    }
                    catch
                    {
                        cBins = "";
                    }

                    try
                    {
                        nDocEntry = int.Parse(dTable.Rows[i]["DocEntry"].ToString());
                    }
                    catch
                    {
                        nDocEntry = 0;
                    }

                    try
                    {
                        nDocEntry_Cal = int.Parse(dTable.Rows[i]["DocEntry_Calidad"].ToString());
                    }
                    catch
                    {
                        nDocEntry_Cal = 0;
                    }

                    try
                    {
                        cFolioNum = dTable.Rows[i]["FolioNum"].ToString();
                    }
                    catch
                    {
                        cFolioNum = "";
                    }

                    try
                    {
                        cNumOC = dTable.Rows[i]["BaseRef"].ToString();
                    }
                    catch
                    {
                        cNumOC = "";
                    }

                    try
                    {
                        cWhsCode = dTable.Rows[i]["WhsCode"].ToString();
                    }
                    catch
                    {
                        cWhsCode = "";
                    }

                    try
                    {
                        nCantidadRecepcionada = double.Parse(dTable.Rows[i]["CantidadRecepcionada"].ToString());
                    }
                    catch
                    {
                        nCantidadRecepcionada = 0;
                    }

                    try
                    {
                        dFecha = Convert.ToDateTime(dTable.Rows[i]["FechaRecepcion"].ToString());
                    }
                    catch
                    {
                        dFecha = DateTime.Parse("01/01/1900");
                    }

                    try
                    {
                        cVariedad = dTable.Rows[i]["U_HDV_VARIEDAD"].ToString();
                    }
                    catch
                    {
                        cVariedad = "";
                    }

                    grilla[0] = cLote;
                    grilla[1] = cItemCode;
                    grilla[2] = cItemName;
                    grilla[3] = cNomProductor;
                    grilla[4] = cNomCliente;
                    grilla[5] = cBins;
                    grilla[6] = cVariedad;
                    grilla[7] = nDocEntry.ToString();
                    grilla[8] = cFolioNum;
                    grilla[9] = cNumOC;
                    grilla[10] = nCantidadRecepcionada.ToString("N2");

                    if (dFecha.ToString("yyyy") == "1900")
                    {
                        grilla[11] = "";
                    }
                    else
                    {
                        grilla[11] = dFecha.ToString("dd/MM/yyyy");
                    }

                    grilla[12] = cWhsCode;
                    grilla[13] = nDocEntry_Cal.ToString();

                    Grid3.Rows.Add(grilla);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_consultar_mp_Click(object sender, EventArgs e)
        {

            Grid4.Rows.Clear();

            carga_grilla3();

            Application.DoEvents();

            Grid5.Rows.Clear();

            carga_grilla4();

            Application.DoEvents();

        }

        private void carga_grilla4()
        {
            Grid5.Rows.Clear();

            string clote, ctipo_fruta, cciclo_estricto;
            string cnuez_mecanica_subproceso;

            try
            {
                clote = t_lote_mp.Text;
            }
            catch
            {
                clote = "";
            }

            if (clote == "")
            {
                MessageBox.Show("Debe ingresar un lote válido, opción Cancelada", "Trazabilidad de Lotes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                ctipo_fruta = cbb_Proceso_MP.Text;
            }
            catch
            {
                ctipo_fruta = "";
            }

            if (ctipo_fruta == "")
            {
                MessageBox.Show("Debe ingresar un tipo de fruta válido, opción Cancelada", "Trazabilidad de Lotes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ctipo_fruta == "Todo Proceso")
            {
                ctipo_fruta = "%";
            }

            cnuez_mecanica_subproceso = "";

            if (ctipo_fruta == "Nuez Mecanica")
            {
                try
                {
                    cnuez_mecanica_subproceso = cbb_proceso_nmec.Text;
                }
                catch
                {
                    cnuez_mecanica_subproceso = "";
                }

                if (cnuez_mecanica_subproceso == "Mitades")
                {
                    ctipo_fruta = "Nuez Mecanica_M";
                }

                if (cnuez_mecanica_subproceso == "Large")
                {
                    ctipo_fruta = "Nuez Mecanica_L";

                }

                if (cnuez_mecanica_subproceso == "Medium")
                {
                    ctipo_fruta = "Nuez Mecanica_E";

                }

                if (cnuez_mecanica_subproceso == "Large/Medium")
                {
                    ctipo_fruta = "Nuez Mecanica_A";

                }

            }


            cciclo_estricto = "S";

            if (chk_proceso_estricto_mp.Checked == false)
            {
                cciclo_estricto = "N";

            }

            string cLote, cItemCode, cItemName;
            string cNomProductor, cCodigo_CSG, cWhsCode;
            string cVariedad, cFumigado;

            double nQuantity, nStockActual, nCantidadEntrega;
            double nCantidadOV;

            int nDocEntry_Cal, nDocEntry;

            DateTime dFecha, dFechaFumigacion;

            try
            {

                clsCalidad objproducto = new clsCalidad();

                objproducto.cls_SAPB1_INF_TRAZABILIDAD_MP(clote, "2", ctipo_fruta, cciclo_estricto);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid5.Rows.Clear();

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        cLote = dTable.Rows[i]["DistNumber"].ToString();
                    }
                    catch
                    {
                        cLote = "";
                    }

                    try
                    {
                        cCodigo_CSG = dTable.Rows[i]["U_Codigo_CSG"].ToString();
                    }
                    catch
                    {
                        cCodigo_CSG = "";
                    }

                    try
                    {
                        cItemCode = dTable.Rows[i]["ItemCode"].ToString();
                    }
                    catch
                    {
                        cItemCode = "";
                    }

                    try
                    {
                        cItemName = dTable.Rows[i]["ItemName"].ToString();
                    }
                    catch
                    {
                        cItemName = "";
                    }

                    try
                    {
                        cNomProductor = dTable.Rows[i]["U_NOMBPROD"].ToString();
                    }
                    catch
                    {
                        cNomProductor = "";
                    }

                    try
                    {
                        nQuantity = double.Parse(dTable.Rows[i]["Quantity"].ToString());
                    }
                    catch
                    {
                        nQuantity = 0;
                    }

                    try
                    {
                        nStockActual = double.Parse(dTable.Rows[i]["StockActualLote"].ToString());
                    }
                    catch
                    {
                        nStockActual = 0;
                    }

                    try
                    {
                        nDocEntry = int.Parse(dTable.Rows[i]["NumeroDocto"].ToString());
                    }
                    catch
                    {
                        nDocEntry = 0;
                    }

                    try
                    {
                        nDocEntry_Cal = int.Parse(dTable.Rows[i]["DocEntry_Calidad"].ToString());
                    }
                    catch
                    {
                        nDocEntry_Cal = 0;
                    }

                    try
                    {
                        cWhsCode = dTable.Rows[i]["WhsCode"].ToString();
                    }
                    catch
                    {
                        cWhsCode = "";
                    }

                    try
                    {
                        dFecha = Convert.ToDateTime(dTable.Rows[i]["FechaRecepcion"].ToString());
                    }
                    catch
                    {
                        dFecha = DateTime.Parse("01/01/1900");
                    }

                    try
                    {
                        cVariedad = dTable.Rows[i]["U_HDV_VARIEDAD"].ToString();
                    }
                    catch
                    {
                        cVariedad = "";
                    }

                    try
                    {
                        cFumigado = dTable.Rows[i]["U_Fumigado"].ToString();

                    }
                    catch
                    {
                        cFumigado = "No";

                    }

                    try
                    {
                        dFechaFumigacion = Convert.ToDateTime(dTable.Rows[i]["U_FechaFumigacion"].ToString());
                    }
                    catch
                    {
                        dFechaFumigacion = DateTime.Parse("01/01/1900");
                    }

                    try
                    {
                        nCantidadEntrega = double.Parse(dTable.Rows[i]["CantidadEntrega"].ToString());
                    }
                    catch
                    {
                        nCantidadEntrega = 0;
                    }

                    try
                    {
                        nCantidadOV = double.Parse(dTable.Rows[i]["CantidadOV"].ToString());
                    }
                    catch
                    {
                        nCantidadOV = 0;
                    }

                    grilla[0] = cLote;
                    grilla[1] = cCodigo_CSG;
                    grilla[2] = cItemCode;
                    grilla[3] = cItemName;
                    grilla[4] = cNomProductor;
                    grilla[5] = cVariedad;

                    grilla[6] = nQuantity.ToString("N2");
                    grilla[7] = nStockActual.ToString("N2");

                    grilla[8] = nDocEntry_Cal.ToString();
                    grilla[9] = nDocEntry.ToString();

                    grilla[10] = cFumigado;

                    if (dFechaFumigacion.ToString("yyyy") == "1900")
                    {
                        grilla[11] = "";
                    }
                    else
                    {
                        grilla[11] = dFechaFumigacion.ToString("dd/MM/yyyy");
                    }

                    try
                    {
                        grilla[12] = dTable.Rows[i]["NumOV"].ToString();

                    }
                    catch
                    {
                        grilla[12] = "";

                    }

                    grilla[13] = nCantidadOV.ToString("N2");

                    try
                    {
                        grilla[14] = dTable.Rows[i]["NumEntrega"].ToString();

                    }
                    catch
                    {
                        grilla[14] = "";

                    }

                    grilla[15] = nCantidadEntrega.ToString("N2");

                    try
                    {
                        grilla[16] = dTable.Rows[i]["ClienteOV"].ToString();

                    }
                    catch
                    {
                        grilla[16] = "";

                    }

                    if (grilla[16] == "")
                    {
                        try
                        {
                            grilla[16] = dTable.Rows[i]["ClienteEntrega"].ToString();

                        }
                        catch
                        {
                            grilla[16] = "";

                        }

                    }

                    Grid5.Rows.Add(grilla);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_consultar_insumo_Click(object sender, EventArgs e)
        {

            Grida2.Rows.Clear();

            carga_grillaA1();

            Grid6.Rows.Clear();

            carga_grilla5();

            Application.DoEvents();

            Grid7.Rows.Clear();

            carga_grilla6();

            Application.DoEvents();

        }

        private void carga_grilla6()
        {
            Grid7.Rows.Clear();

            string clote;

            try
            {
                clote = t_lote_insumo.Text;
            }
            catch
            {
                clote = "";
            }

            if (clote == "")
            {
                MessageBox.Show("Debe ingresar un lote válido, opción Cancelada", "Trazabilidad de Lotes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string cLote, cItemCode, cItemName;
            string cNomProductor, cCodigo_CSG, cWhsCode;
            string cVariedad;

            double nQuantity, nStockActual;

            int nDocEntry_Cal, nDocEntry;

            DateTime dFecha;

            try
            {

                clsCalidad objproducto = new clsCalidad();

                objproducto.cls_SAPB1_INF_TRAZABILIDAD_INS_CSG(clote, "2");

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid7.Rows.Clear();

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        cLote = dTable.Rows[i]["DistNumber"].ToString();
                    }
                    catch
                    {
                        cLote = "";
                    }

                    try
                    {
                        cCodigo_CSG = dTable.Rows[i]["U_Codigo_CSG"].ToString();
                    }
                    catch
                    {
                        cCodigo_CSG = "";
                    }

                    try
                    {
                        cItemCode = dTable.Rows[i]["ItemCode"].ToString();
                    }
                    catch
                    {
                        cItemCode = "";
                    }

                    try
                    {
                        cItemName = dTable.Rows[i]["ItemName"].ToString();
                    }
                    catch
                    {
                        cItemName = "";
                    }

                    try
                    {
                        cNomProductor = dTable.Rows[i]["U_NOMBPROD"].ToString();
                    }
                    catch
                    {
                        cNomProductor = "";
                    }

                    try
                    {
                        nQuantity = double.Parse(dTable.Rows[i]["Quantity"].ToString());
                    }
                    catch
                    {
                        nQuantity = 0;
                    }

                    try
                    {
                        nStockActual = double.Parse(dTable.Rows[i]["StockActualLote"].ToString());
                    }
                    catch
                    {
                        nStockActual = 0;
                    }

                    try
                    {
                        nDocEntry = int.Parse(dTable.Rows[i]["NumeroDocto"].ToString());
                    }
                    catch
                    {
                        nDocEntry = 0;
                    }

                    try
                    {
                        nDocEntry_Cal = int.Parse(dTable.Rows[i]["DocEntry_Calidad"].ToString());
                    }
                    catch
                    {
                        nDocEntry_Cal = 0;
                    }

                    try
                    {
                        cWhsCode = dTable.Rows[i]["WhsCode"].ToString();
                    }
                    catch
                    {
                        cWhsCode = "";
                    }

                    try
                    {
                        dFecha = Convert.ToDateTime(dTable.Rows[i]["FechaRecepcion"].ToString());
                    }
                    catch
                    {
                        dFecha = DateTime.Parse("01/01/1900");
                    }

                    try
                    {
                        cVariedad = dTable.Rows[i]["U_HDV_VARIEDAD"].ToString();
                    }
                    catch
                    {
                        cVariedad = "";
                    }

                    grilla[0] = cLote;
                    grilla[1] = cCodigo_CSG;
                    grilla[2] = cItemCode;
                    grilla[3] = cItemName;
                    grilla[4] = cNomProductor;
                    grilla[5] = cVariedad;

                    grilla[6] = nQuantity.ToString("N2");
                    grilla[7] = nStockActual.ToString("N2");

                    grilla[8] = nDocEntry_Cal.ToString();
                    grilla[9] = nDocEntry.ToString();

                    Grid7.Rows.Add(grilla);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void carga_grilla5()
        {
            Grid6.Rows.Clear();

            string clote;

            try
            {
                clote = t_lote_insumo.Text;
            }
            catch
            {
                clote = "";
            }

            if (clote == "")
            {
                MessageBox.Show("Debe ingresar un lote válido, opción Cancelada", "Trazabilidad de Lotes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {

                string cCiclo, cNumOF, cItemCode;
                string cItemName, cProceso;

                DateTime dFecha;

                clsCalidad objproducto = new clsCalidad();

                objproducto.cls_SAPB1_INF_TRAZABILIDAD_INS(clote, "1");

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid6.Rows.Clear();

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        cCiclo = dTable.Rows[i]["ciclo"].ToString();
                    }
                    catch
                    {
                        cCiclo = "";

                    }

                    try
                    {
                        cNumOF = dTable.Rows[i]["DocNum"].ToString();

                    }
                    catch
                    {
                        cNumOF = "";
                    }

                    try
                    {
                        cItemCode = dTable.Rows[i]["ItemCode"].ToString();
                    }
                    catch
                    {
                        cItemCode = "";

                    }

                    try
                    {
                        dFecha = Convert.ToDateTime(dTable.Rows[i]["DueDate"].ToString());
                    }
                    catch
                    {
                        dFecha = DateTime.Parse("01/01/1900");
                    }

                    try
                    {
                        cItemName = dTable.Rows[i]["ItemName"].ToString();
                    }
                    catch
                    {
                        cItemName = "";
                    }

                    try
                    {
                        cProceso = dTable.Rows[i]["U_Proceso"].ToString();
                    }
                    catch
                    {
                        cProceso = "";
                    }

                    grilla[0] = cCiclo;
                    grilla[1] = cNumOF;
                    grilla[2] = cItemCode;
                    grilla[3] = cItemName;
                    grilla[4] = dFecha.ToString("dd/MM/yyyy");
                    grilla[5] = cProceso;

                    Grid6.Rows.Add(grilla);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void carga_grillaA1()
        {

            Grida2.Rows.Clear();

            string clote;

            try
            {
                clote = t_lote_insumo.Text;
            }
            catch
            {
                clote = "";
            }

            if (clote == "")
            {
                MessageBox.Show("Debe ingresar un lote válido, opción Cancelada", "Trazabilidad de Lotes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string cLote, cItemCode, cItemName;
            string cNomProductor, cNomCliente, cBins;
            string cWhsCode, cFolioNum, cNumOC;
            string cVariedad;

            double nCantidadRecepcionada;

            int nDocEntry_Cal, nDocEntry;

            DateTime dFecha;

            try
            {

                clsCalidad objproducto = new clsCalidad();

                objproducto.cls_SAPB1_INF_TRAZABILIDAD_INS(clote, "3");

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grida2.Rows.Clear();

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        cLote = dTable.Rows[i]["DistNumber"].ToString();
                    }
                    catch
                    {
                        cLote = "";
                    }

                    try
                    {
                        cItemCode = dTable.Rows[i]["ItemCode"].ToString();
                    }
                    catch
                    {
                        cItemCode = "";
                    }

                    try
                    {
                        cItemName = dTable.Rows[i]["ItemName"].ToString();
                    }
                    catch
                    {
                        cItemName = "";
                    }

                    try
                    {
                        cNomProductor = dTable.Rows[i]["U_NOMBPROD"].ToString();
                    }
                    catch
                    {
                        cNomProductor = "";
                    }

                    try
                    {
                        cNomCliente = dTable.Rows[i]["U_NOMBCLI"].ToString();
                    }
                    catch
                    {
                        cNomCliente = "";
                    }

                    try
                    {
                        cBins = dTable.Rows[i]["U_BINS"].ToString();
                    }
                    catch
                    {
                        cBins = "";
                    }

                    try
                    {
                        nDocEntry = int.Parse(dTable.Rows[i]["DocEntry"].ToString());
                    }
                    catch
                    {
                        nDocEntry = 0;
                    }

                    try
                    {
                        nDocEntry_Cal = int.Parse(dTable.Rows[i]["DocEntry_Calidad"].ToString());
                    }
                    catch
                    {
                        nDocEntry_Cal = 0;
                    }

                    try
                    {
                        cFolioNum = dTable.Rows[i]["FolioNum"].ToString();
                    }
                    catch
                    {
                        cFolioNum = "";
                    }

                    try
                    {
                        cNumOC = dTable.Rows[i]["BaseRef"].ToString();
                    }
                    catch
                    {
                        cNumOC = "";
                    }

                    try
                    {
                        cWhsCode = dTable.Rows[i]["WhsCode"].ToString();
                    }
                    catch
                    {
                        cWhsCode = "";
                    }

                    try
                    {
                        nCantidadRecepcionada = double.Parse(dTable.Rows[i]["CantidadRecepcionada"].ToString());
                    }
                    catch
                    {
                        nCantidadRecepcionada = 0;
                    }

                    try
                    {
                        dFecha = Convert.ToDateTime(dTable.Rows[i]["FechaRecepcion"].ToString());
                    }
                    catch
                    {
                        dFecha = DateTime.Parse("01/01/1900");
                    }

                    try
                    {
                        cVariedad = dTable.Rows[i]["U_HDV_VARIEDAD"].ToString();
                    }
                    catch
                    {
                        cVariedad = "";
                    }

                    grilla[0] = cLote;
                    grilla[1] = cItemCode;
                    grilla[2] = cItemName;
                    grilla[3] = cNomProductor;
                    grilla[4] = cNomCliente;
                    grilla[5] = cBins;
                    grilla[6] = cVariedad;
                    grilla[7] = nDocEntry.ToString();
                    grilla[8] = cFolioNum;
                    grilla[9] = cNumOC;
                    grilla[10] = nCantidadRecepcionada.ToString("N2");

                    if (dFecha.ToString("yyyy") == "1900")
                    {
                        grilla[11] = "";
                    }
                    else
                    {
                        grilla[11] = dFecha.ToString("dd/MM/yyyy");
                    }

                    grilla[12] = cWhsCode;
                    grilla[13] = nDocEntry_Cal.ToString();

                    Grida2.Rows.Add(grilla);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void carga_grilla3()
        {
            Grid4.Rows.Clear();

            string clote, ctipo_fruta, cciclo_estricto;
            string cnuez_mecanica_subproceso;

            try
            {
                clote = t_lote_mp.Text;
            }
            catch
            {
                clote = "";
            }

            if (clote == "")
            {
                MessageBox.Show("Debe ingresar un lote válido, opción Cancelada", "Trazabilidad de Lotes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                ctipo_fruta = cbb_Proceso_MP.Text;
            }
            catch
            {
                ctipo_fruta = "";
            }

            if (ctipo_fruta == "")
            {
                MessageBox.Show("Debe ingresar un tipo de fruta válido, opción Cancelada", "Trazabilidad de Lotes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ctipo_fruta == "Todo Proceso")
            {
                ctipo_fruta = "%";
            }

            cnuez_mecanica_subproceso = "";

            if (ctipo_fruta == "Nuez Mecanica")
            {
                try
                {
                    cnuez_mecanica_subproceso = cbb_proceso_nmec.Text;
                }
                catch
                {
                    cnuez_mecanica_subproceso = "";
                }

                if (cnuez_mecanica_subproceso == "Mitades")
                {
                    ctipo_fruta = "Nuez Mecanica_M";
                }

                if (cnuez_mecanica_subproceso == "Large")
                {
                    ctipo_fruta = "Nuez Mecanica_L";

                }

                if (cnuez_mecanica_subproceso == "Medium")
                {
                    ctipo_fruta = "Nuez Mecanica_E";

                }

                if (cnuez_mecanica_subproceso == "Large/Medium")
                {
                    ctipo_fruta = "Nuez Mecanica_A";

                }

            }

            cciclo_estricto = "S";

            if (chk_proceso_estricto_mp.Checked == false)
            {
                cciclo_estricto = "N";

            }

            try
            {

                string cCiclo, cNumOF, cItemCode;
                string cItemName, cProceso;

                DateTime dFecha;

                clsCalidad objproducto = new clsCalidad();

                objproducto.cls_SAPB1_INF_TRAZABILIDAD_MP(clote, "1", ctipo_fruta, cciclo_estricto);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid4.Rows.Clear();

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        cCiclo = dTable.Rows[i]["ciclo"].ToString();
                    }
                    catch
                    {
                        cCiclo = "";

                    }

                    try
                    {
                        cNumOF = dTable.Rows[i]["DocNum"].ToString();

                    }
                    catch
                    {
                        cNumOF = "";
                    }

                    try
                    {
                        cItemCode = dTable.Rows[i]["ItemCode"].ToString();
                    }
                    catch
                    {
                        cItemCode = "";

                    }

                    try
                    {
                        dFecha = Convert.ToDateTime(dTable.Rows[i]["DueDate"].ToString());
                    }
                    catch
                    {
                        dFecha = DateTime.Parse("01/01/1900");
                    }

                    try
                    {
                        cItemName = dTable.Rows[i]["ItemName"].ToString();
                    }
                    catch
                    {
                        cItemName = "";
                    }

                    try
                    {
                        cProceso = dTable.Rows[i]["U_Proceso"].ToString();
                    }
                    catch
                    {
                        cProceso = "";
                    }

                    grilla[0] = cCiclo;
                    grilla[1] = cNumOF;
                    grilla[2] = cItemCode;
                    grilla[3] = cItemName;
                    grilla[4] = dFecha.ToString("dd/MM/yyyy");
                    grilla[5] = cProceso;

                    Grid4.Rows.Add(grilla);

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

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }
    }

}
