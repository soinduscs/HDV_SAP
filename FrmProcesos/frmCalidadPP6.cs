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
using Excel = Microsoft.Office.Interop.Excel;

namespace FrmProcesos
{
    public partial class frmCalidadPP6 : Form
    {
        public frmCalidadPP6()
        {
            InitializeComponent();
        }

        private void frmCalidadPP6_Load(object sender, EventArgs e)
        {
           

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

            Grid1.Rows.Clear();
            Grid2.Rows.Clear();
            Grid3.Rows.Clear();
            Grid4.Rows.Clear();

            carga_grilla("D", c_num_guia, "");

            carga_grilla1("L", c_num_guia, "");

            t_ultimo_boton.Text = "N";

        }

        private void carga_grilla(string accion, string dato1, string dato2)
        {
            
            try
            {

                string cDocEntry, cLineID, cAlmacen;
                string cItemName, cItemCode, cDocNum;
                string cCardName, cTipoFruta, cTipoProceso;
                string cAutorizador, cNom_Autorizador;

                DateTime dFecha;

                int nFila, nCantItems;

                double nQuantity;

                clsCalidad objproducto = new clsCalidad();

                objproducto.cls_Consulta_Recepcion_PP_Calidad_V(accion, dato1);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid2.Rows.Clear();

                nFila = 0;

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        cDocEntry = dTable.Rows[i]["DocEntryOV"].ToString();
                    }
                    catch
                    {
                        cDocEntry = "";
                    }

                    try
                    {
                        cDocNum = dTable.Rows[i]["DocNumOV"].ToString();
                    }
                    catch
                    {
                        cDocNum = "";
                    }
                    
                    try
                    {
                        cLineID = dTable.Rows[i]["LineNumOV"].ToString();
                    }
                    catch
                    {
                        cLineID = "";
                    }

                    try
                    {
                        cCardName = dTable.Rows[i]["CardName"].ToString();
                    }
                    catch
                    {
                        cCardName = "";
                    }
                   
                    try
                    {
                        dFecha = Convert.ToDateTime(dTable.Rows[i]["DocDateOV"].ToString());
                    }
                    catch
                    {
                        dFecha = DateTime.Parse("01/01/1900");
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
                        nCantItems = Convert.ToInt32(dTable.Rows[i]["QuantityOV"].ToString());
                    }
                    catch
                    {
                        nCantItems = 0;
                    }

                    try
                    {
                        cAlmacen = dTable.Rows[i]["WhsCodeE"].ToString();
                    }
                    catch
                    {
                        cAlmacen = "";
                    }

                    try
                    {
                        cTipoFruta = dTable.Rows[i]["U_TipoProducto"].ToString();
                    }
                    catch
                    {
                        cTipoFruta = "";
                    }

                    try
                    {
                        cTipoProceso = dTable.Rows[i]["U_TipoProceso"].ToString();
                    }
                    catch
                    {
                        cTipoProceso = "";
                    }

                    try
                    {
                        nQuantity = double.Parse(dTable.Rows[i]["QuantityOV"].ToString());
                    }
                    catch
                    {
                        nQuantity = 0;
                    }

                    try
                    {
                        cAutorizador = dTable.Rows[i]["Autorizador"].ToString();
                    }
                    catch
                    {
                        cAutorizador = "";
                    }

                    try
                    {
                        cNom_Autorizador = dTable.Rows[i]["Nom_Autorizador"].ToString();
                    }
                    catch
                    {
                        cNom_Autorizador = "";
                    }

                    ////////////////////////////////////////////
                    ////////////////////////////////////////////

                    grilla[0] = cDocEntry;
                    grilla[1] = cDocNum;
                    grilla[2] = dFecha.ToString("dd/MM/yyyy");
                    grilla[3] = cCardName;
                    grilla[4] = cItemCode;
                    grilla[5] = cItemName;
                    grilla[6] = cLineID;
                    grilla[7] = nQuantity.ToString("N2");
                    grilla[8] = cAlmacen;
                    grilla[9] = cTipoFruta;
                    grilla[10] = cTipoProceso;

                    grilla[11] = cAutorizador;
                    grilla[12] = cNom_Autorizador;

                    Grid2.Rows.Add(grilla);

                    nFila += 1;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void carga_grilla1(string accion, string dato1, string dato2)
        {

            string cLote, cItemCode, cItemName;
            string cProductor, cCliente;
            string cFumigado, cVariedad, cColor;
            string cCalibre, cUnidad, cTipoFruta;
            string cTipoProceso, cNumOF;

            double nPeso, nExtraLigth, nLigth;
            double nLigthAmbar, nAmbar, nHalves;
            double nQuartes, nPieces, nDefectos;

            //double nAlm_PepaSana, nAlm_PelonSuelto, nAlm_Canuto;
            double nAlm_PepaSana, nAlm_PelonSuelto;
            double nAlm_Impurezas, nAlm_Piedras, nAlm_Gemelas;
            double nAlm_PartidasRotas, nAlm_MVariedad, nAlm_AstilladasLeve;
            double nAlm_AstilladasGraves, nAlm_DeshidratadaGrave, nAlm_DeshidratadaLeve;
            double nAlm_Goma, nAlm_PuntoGoma, nAlm_FueraColor;
            double nAlm_Mancha, nAlm_DanhoInsectoSLarva, nAlm_DanhoInsectoCLarva;
            double nAlm_HongoInactivo, nAlm_HongoActivo, nAlm_Rancidez;
            double nAlm_Cascara, nAlm_VariedadDisimil, nAlm_Reseca;
            double nAlm_TotalDanhosSerios, nAlm_OtrosDefectos, nAlm_Ratio;
            double nAlm_Humedad;

            double nOnzas;

            int nFila, nDocEntry;

            DateTime dFechaElaboración;

            try
            {

                clsCalidad objproducto = new clsCalidad();

                objproducto.cls_Consulta_Recepcion_PP_Calidad_V(accion, dato1);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid1.Rows.Clear();

                nFila = 0;

                string[] grilla;
                grilla = new string[60];

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
                        cProductor = dTable.Rows[i]["U_NOMBPROD"].ToString();
                    }
                    catch
                    {
                        cProductor = "";
                    }

                    try
                    {
                        cCliente = dTable.Rows[i]["U_NOMBCLI"].ToString();
                    }
                    catch
                    {
                        cCliente = "";
                    }

                    try
                    {
                        cFumigado = dTable.Rows[i]["U_Fumigado"].ToString();
                    }
                    catch
                    {
                        cFumigado = "";
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
                        cColor = dTable.Rows[i]["U_HDV_COLOR"].ToString();
                    }
                    catch
                    {
                        cColor = "";
                    }

                    try
                    {
                        cCalibre = dTable.Rows[i]["U_Calibre"].ToString();
                    }
                    catch
                    {
                        cCalibre = "";
                    }

                    try
                    {
                        cUnidad = dTable.Rows[i]["SalUnitMsr"].ToString();
                    }
                    catch
                    {
                        cUnidad = "";
                    }

                    try
                    {
                        nPeso = Convert.ToDouble(dTable.Rows[i]["SWeight1"].ToString());
                    }
                    catch
                    {
                        nPeso = 0;
                    }

                    try
                    {
                        cTipoFruta = dTable.Rows[i]["U_TipoProducto"].ToString();
                    }
                    catch
                    {
                        cTipoFruta = "";
                    }

                    try
                    {
                        cTipoProceso = dTable.Rows[i]["U_TipoProceso"].ToString();
                    }
                    catch
                    {
                        cTipoProceso = "";
                    }
                   
                    try
                    {
                        nDocEntry = Convert.ToInt32(dTable.Rows[i]["DocEntry"].ToString());
                    }
                    catch
                    {
                        nDocEntry = 0;
                    }

                    /////////////////////////////////
                    // Nueces

                    try
                    {
                        nExtraLigth = Convert.ToDouble(dTable.Rows[i]["Nuez_ExtraLigth"].ToString());
                    }
                    catch
                    {
                        nExtraLigth = 0;
                    }

                    try
                    {
                        nLigth = Convert.ToDouble(dTable.Rows[i]["Nuez_Ligth"].ToString());
                    }
                    catch
                    {
                        nLigth = 0;
                    }

                    try
                    {
                        nLigthAmbar = Convert.ToDouble(dTable.Rows[i]["Nuez_LigthAmbar"].ToString());
                    }
                    catch
                    {
                        nLigthAmbar = 0;
                    }

                    try
                    {
                        nAmbar = Convert.ToDouble(dTable.Rows[i]["Nuez_Ambar"].ToString());
                    }
                    catch
                    {
                        nAmbar = 0;
                    }

                    try
                    {
                        nHalves = Convert.ToDouble(dTable.Rows[i]["Nuez_Halves"].ToString());
                    }
                    catch
                    {
                        nHalves = 0;
                    }

                    try
                    {
                        nQuartes = Convert.ToDouble(dTable.Rows[i]["Nuez_Quartes"].ToString());
                    }
                    catch
                    {
                        nQuartes = 0;
                    }

                    try
                    {
                        nPieces = Convert.ToDouble(dTable.Rows[i]["Nuez_Pieces"].ToString());
                    }
                    catch
                    {
                        nPieces = 0;
                    }

                    try
                    {
                        nDefectos = Convert.ToDouble(dTable.Rows[i]["Nuez_Defectos"].ToString());
                    }
                    catch
                    {
                        nDefectos = 0;
                    }

                    ////////////////////////
                    // Almendras
                    // . as  , ta1., ta1.Cascara,  ta1.impurezas, ta1.Gemela , ta1.VariedadDisimil ,

                    try
                    {
                      nAlm_PepaSana   = Convert.ToDouble(dTable.Rows[i]["PepaSana"].ToString());
                    }
                    catch
                    {
                        nAlm_PepaSana = 0;
                    }

                    try
                    {
                        nAlm_PelonSuelto = Convert.ToDouble(dTable.Rows[i]["PelonSuelto"].ToString());
                    }
                    catch
                    {
                        nAlm_PelonSuelto = 0;
                    }

                    try
                    {
                        nAlm_Cascara = Convert.ToDouble(dTable.Rows[i]["Cascara"].ToString());
                    }
                    catch
                    {
                        nAlm_Cascara = 0;
                    }

                    try
                    {
                        nAlm_Impurezas = Convert.ToDouble(dTable.Rows[i]["impurezas"].ToString());
                    }
                    catch
                    {
                        nAlm_Impurezas = 0;
                    }

                    try
                    {
                        nAlm_Gemelas = Convert.ToDouble(dTable.Rows[i]["Gemela"].ToString());
                    }
                    catch
                    {
                        nAlm_Gemelas = 0;
                    }

                    try
                    {
                        nAlm_VariedadDisimil = Convert.ToDouble(dTable.Rows[i]["VariedadDisimil"].ToString());
                    }
                    catch
                    {
                        nAlm_VariedadDisimil = 0;
                    }

                    try
                    {
                        nAlm_AstilladasLeve = Convert.ToDouble(dTable.Rows[i]["AstilladasyRayadasLeve"].ToString()); 
                    }
                    catch
                    {
                        nAlm_AstilladasLeve = 0;
                    }

                    try
                    {
                        nAlm_AstilladasGraves = Convert.ToDouble(dTable.Rows[i]["AstilladasyRayadasGrave"].ToString());
                    }
                    catch
                    {
                        nAlm_AstilladasGraves = 0;
                    }

                    try
                    {
                        nAlm_PartidasRotas = Convert.ToDouble(dTable.Rows[i]["PartidayRotas"].ToString());
                    }
                    catch
                    {
                        nAlm_PartidasRotas = 0;
                    }
                    
                    try
                    {
                        nAlm_Reseca = Convert.ToDouble(dTable.Rows[i]["Reseca"].ToString());
                    }
                    catch
                    {
                        nAlm_Reseca = 0;
                    }

                    try
                    {
                        nAlm_Goma = Convert.ToDouble(dTable.Rows[i]["Goma"].ToString());
                    }
                    catch
                    {
                        nAlm_Goma = 0;
                    }

                    try
                    {
                        nAlm_PuntoGoma = Convert.ToDouble(dTable.Rows[i]["PuntoGoma"].ToString());
                    }
                    catch
                    {
                        nAlm_PuntoGoma = 0;
                    }

                    try
                    {
                        nAlm_FueraColor = Convert.ToDouble(dTable.Rows[i]["FueradeColor"].ToString());
                    }
                    catch
                    {
                        nAlm_FueraColor = 0;
                    }

                    try
                    {
                        nAlm_HongoInactivo = Convert.ToDouble(dTable.Rows[i]["HongoInactivo"].ToString());
                    }
                    catch
                    {
                        nAlm_HongoInactivo = 0;
                    }

                    try
                    {
                        nAlm_DanhoInsectoSLarva = Convert.ToDouble(dTable.Rows[i]["Danhoinsecto"].ToString());
                    }
                    catch
                    {
                        nAlm_DanhoInsectoSLarva = 0;
                    }

                    try
                    {
                        nAlm_HongoActivo = Convert.ToDouble(dTable.Rows[i]["HongoActivo"].ToString());
                    }
                    catch
                    {
                        nAlm_HongoActivo = 0;
                    }

                    try
                    {
                        nAlm_Rancidez = Convert.ToDouble(dTable.Rows[i]["Rancidez"].ToString());
                    }
                    catch
                    {
                        nAlm_Rancidez = 0;
                    }

                    //, ,  , 

                    try
                    {
                        nAlm_TotalDanhosSerios = Convert.ToDouble(dTable.Rows[i]["Total_DanhosSerios"].ToString());
                    }
                    catch
                    {
                        nAlm_TotalDanhosSerios = 0;
                    }

                    try
                    {
                        nAlm_OtrosDefectos = Convert.ToDouble(dTable.Rows[i]["Otros_Defectos"].ToString());
                    }
                    catch
                    {
                        nAlm_OtrosDefectos = 0;
                    }

                    try
                    {
                        nAlm_Ratio = Convert.ToDouble(dTable.Rows[i]["Ratio"].ToString());
                    }
                    catch
                    {
                        nAlm_Ratio = 0;
                    }

                    try
                    {
                        nAlm_MVariedad = Convert.ToDouble(dTable.Rows[i]["MezclaVariedad"].ToString());
                    }
                    catch
                    {
                        nAlm_MVariedad = 0;
                    }

                    try
                    {
                        nAlm_Humedad = Convert.ToDouble(dTable.Rows[i]["Humedad"].ToString());
                    }
                    catch
                    {
                        nAlm_Humedad = 0;
                    }

                    try
                    {
                        nAlm_Piedras = Convert.ToDouble(dTable.Rows[i]["Piedras"].ToString());
                    }
                    catch
                    {
                        nAlm_Piedras = 0;
                    }

                    try
                    {
                        cNumOF =dTable.Rows[i]["OrdenFabricacion"].ToString();
                    }
                    catch
                    {
                        cNumOF = "";
                    }

                    try
                    {
                       dFechaElaboración = Convert.ToDateTime(dTable.Rows[i]["FechaElaboracion"].ToString());
                    }
                    catch
                    {
                        dFechaElaboración = Convert.ToDateTime("01/01/1900");
                    }

                    ///////////////////////////////////////////////////////////////////////////

                    try
                    {
                        nAlm_DeshidratadaGrave = Convert.ToDouble(dTable.Rows[i]["Alm_DeshidratadaGrave"].ToString());
                    }
                    catch
                    {
                        nAlm_DeshidratadaGrave = 0;
                    }

                    try
                    {
                        nAlm_DeshidratadaLeve = Convert.ToDouble(dTable.Rows[i]["Alm_DeshidratadaLeve"].ToString());
                    }
                    catch
                    {
                        nAlm_DeshidratadaLeve = 0;
                    }

                    try
                    {
                        nAlm_Mancha = Convert.ToDouble(dTable.Rows[i]["Alm_Mancha"].ToString());
                    }
                    catch
                    {
                        nAlm_Mancha = 0;
                    }

                    try
                    {
                        nAlm_DanhoInsectoCLarva = Convert.ToDouble(dTable.Rows[i]["Alm_DanhoInsectoCLarva"].ToString());
                    }
                    catch
                    {
                        nAlm_DanhoInsectoCLarva = 0;
                    }

                    try
                    {
                        nOnzas = Convert.ToDouble(dTable.Rows[i]["Onzas"].ToString());
                    }
                    catch
                    {
                        nOnzas = 0;
                    }

                    ////////////////////////////////////////////
                    ////////////////////////////////////////////

                    if (cTipoFruta == "Nuez")
                    {

                        if (cTipoProceso != "Con Cáscara")
                        {

                            grilla[0] = cLote;
                            grilla[1] = cItemCode;
                            grilla[2] = cItemName;
                            grilla[3] = cProductor;
                            grilla[4] = cCliente;
                            grilla[5] = cFumigado;
                            grilla[6] = cCalibre;
                            grilla[7] = cVariedad;
                            grilla[8] = cColor;
                            grilla[9] = cUnidad;
                            grilla[10] = nPeso.ToString("N2");

                            grilla[11] = nDocEntry.ToString();

                            grilla[12] = nExtraLigth.ToString("N2");
                            grilla[13] = nLigth.ToString("N2");
                            grilla[14] = nLigthAmbar.ToString("N2");
                            grilla[15] = nAmbar.ToString("N2");
                            grilla[16] = nHalves.ToString("N2");
                            grilla[17] = nQuartes.ToString("N2");
                            grilla[18] = nPieces.ToString("N2");
                            grilla[19] = nDefectos.ToString("N2");

                            Grid1.Rows.Add(grilla);

                        }

                        if (cTipoProceso == "Con Cáscara")
                        {

                            grilla[0] = cLote;
                            grilla[1] = cItemCode;
                            grilla[2] = cItemName;
                            grilla[3] = cProductor;
                            grilla[4] = cCliente;
                            grilla[5] = cFumigado;
                            grilla[6] = cCalibre;
                            grilla[7] = cVariedad;
                            grilla[8] = cColor;
                            grilla[9] = cUnidad;
                            grilla[10] = nPeso.ToString("N2");

                            grilla[11] = nDocEntry.ToString();

                            grilla[12] = nExtraLigth.ToString("N2");
                            grilla[13] = nLigth.ToString("N2");
                            grilla[14] = nLigthAmbar.ToString("N2");
                            grilla[15] = nAmbar.ToString("N2");
                            grilla[16] = nHalves.ToString("N2");
                            grilla[17] = nQuartes.ToString("N2");
                            grilla[18] = nPieces.ToString("N2");
                            grilla[19] = nDefectos.ToString("N2");

                            Grid4.Rows.Add(grilla);

                        }

                    }

                    if (cTipoFruta == "Almendra")
                    {
                        grilla[0] = cLote;
                        grilla[1] = cItemCode;
                        grilla[2] = cItemName;
                        grilla[3] = cProductor;
                        grilla[4] = cCliente;
                        grilla[5] = cFumigado;
                        grilla[6] = cCalibre;
                        grilla[7] = cVariedad;
                        grilla[8] = cColor;
                        grilla[9] = cUnidad;
                        grilla[10] = nPeso.ToString("N2");

                        grilla[11] = nDocEntry.ToString();

                        grilla[12] = nOnzas.ToString("N2");                       
                        grilla[13] = nAlm_PepaSana.ToString("N2");
                        grilla[14] = nAlm_PelonSuelto.ToString("N2");
                        grilla[15] = nAlm_Cascara.ToString("N2");
                        grilla[16] = nAlm_Impurezas.ToString("N2");
                        grilla[17] = nAlm_Gemelas.ToString("N2");
                        grilla[18] = nAlm_VariedadDisimil.ToString("N2");
                        grilla[19] = nAlm_AstilladasLeve.ToString("N2");
                        grilla[20] = nAlm_AstilladasGraves.ToString("N2");
                        grilla[21] = nAlm_PartidasRotas.ToString("N2");
                        grilla[22] = nAlm_Reseca.ToString("N2");
                        grilla[23] = nAlm_Goma.ToString("N2");
                        grilla[24] = nAlm_PuntoGoma.ToString("N2");
                        grilla[25] = nAlm_FueraColor.ToString("N2");
                        grilla[26] = nAlm_HongoInactivo.ToString("N2");
                        grilla[27] = nAlm_DanhoInsectoSLarva.ToString("N2");
                        grilla[28] = nAlm_HongoActivo.ToString("N2");
                        grilla[29] = nAlm_Rancidez.ToString("N2");
                        grilla[30] = nAlm_TotalDanhosSerios.ToString("N2");
                        grilla[31] = nAlm_OtrosDefectos.ToString("N2");
                        grilla[32] = nAlm_Ratio.ToString("N2");
                        grilla[33] = nAlm_MVariedad.ToString("N2");
                        grilla[34] = nAlm_Humedad.ToString("N2");
                        grilla[35] = nAlm_Piedras.ToString("N2");
                        grilla[36] = cNumOF;
                        grilla[37] = dFechaElaboración.ToString("dd/MM/yyyy");

                        Grid3.Rows.Add(grilla);

                    }


                    nFila += 1;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                clsCalidad objproducto1 = new clsCalidad();

                objproducto1.cls_Sapb1_query_vistacalidad_ncc(Convert.ToInt32(dato1));

                DataTable dTable1 = new DataTable();
                dTable1 = objproducto1.cResultado;

                Grid4.Rows.Clear();

                string[] grilla;
                grilla = new string[60];

                for (int i = 0; i <= dTable1.Rows.Count - 1; i++)
                {

                    try
                    {
                        cLote = dTable1.Rows[i]["NoLote"].ToString();
                    }
                    catch
                    {
                        cLote = "";
                    }

                    try
                    {
                        cItemCode = ""; // dTable.Rows[i]["ItemCode"].ToString();
                    }
                    catch
                    {
                        cItemCode = "";
                    }

                    try
                    {
                        cItemName = dTable1.Rows[i]["ItemName"].ToString();
                    }
                    catch
                    {
                        cItemName = "";
                    }

                    try
                    {
                        cProductor = dTable1.Rows[i]["U_NOMBPROD"].ToString();
                    }
                    catch
                    {
                        cProductor = "";
                    }

                    try
                    {
                        cCliente = dTable1.Rows[i]["U_NOMBCLI"].ToString();
                    }
                    catch
                    {
                        cCliente = "";
                    }

                    try
                    {
                        cFumigado = dTable1.Rows[i]["U_Fumigado"].ToString();
                    }
                    catch
                    {
                        cFumigado = "";
                    }

                    try
                    {
                        cVariedad = dTable1.Rows[i]["Variedad"].ToString();
                    }
                    catch
                    {
                        cVariedad = "";
                    }

                    try
                    {
                        cColor = ""; // dTable.Rows[i]["U_HDV_COLOR"].ToString();
                    }
                    catch
                    {
                        cColor = "";
                    }

                    try
                    {
                        cCalibre = dTable1.Rows[i]["CalibreLote"].ToString();
                    }
                    catch
                    {
                        cCalibre = "";
                    }

                    try
                    {
                        cUnidad = ""; // dTable.Rows[i]["SalUnitMsr"].ToString();
                    }
                    catch
                    {
                        cUnidad = "";
                    }

                    try
                    {
                        nPeso = Convert.ToDouble(dTable1.Rows[i]["Kilos"].ToString());
                    }
                    catch
                    {
                        nPeso = 0;
                    }

                    try
                    {
                        cTipoFruta = dTable1.Rows[i]["U_TipoProducto"].ToString();
                    }
                    catch
                    {
                        cTipoFruta = "";
                    }

                    try
                    {
                        cTipoProceso = dTable1.Rows[i]["Especie"].ToString();
                    }
                    catch
                    {
                        cTipoProceso = "";
                    }

                    try
                    {
                        nDocEntry = Convert.ToInt32(dTable1.Rows[i]["DocEntry"].ToString());
                    }
                    catch
                    {
                        nDocEntry = 0;
                    }

                    /////////////////////////////////
                    // Nueces

                    try
                    {
                        nExtraLigth = Convert.ToDouble(dTable1.Rows[i]["P5_ExtraLight"].ToString());
                    }
                    catch
                    {
                        nExtraLigth = 0;
                    }

                    try
                    {
                        nLigth = Convert.ToDouble(dTable1.Rows[i]["P5_Light"].ToString());
                    }
                    catch
                    {
                        nLigth = 0;
                    }

                    try
                    {
                        nLigthAmbar = Convert.ToDouble(dTable1.Rows[i]["P5_LightAmbar"].ToString());
                    }
                    catch
                    {
                        nLigthAmbar = 0;
                    }

                    try
                    {
                        nAmbar = Convert.ToDouble(dTable1.Rows[i]["P5_Ambar"].ToString());
                    }
                    catch
                    {
                        nAmbar = 0;
                    }

                    try
                    {
                        nHalves = Convert.ToDouble(dTable1.Rows[i]["P5_Amarillo"].ToString());
                    }
                    catch
                    {
                        nHalves = 0;
                    }

                    try
                    {
                        nQuartes = Convert.ToDouble(dTable1.Rows[i]["P6_Peso100U"].ToString());
                    }
                    catch
                    {
                        nQuartes = 0;
                    }

                    try
                    {
                        nPieces = 0; // Convert.ToDouble(dTable.Rows[i]["Nuez_Pieces"].ToString());
                    }
                    catch
                    {
                        nPieces = 0;
                    }

                    try
                    {
                        nDefectos = 0; // Convert.ToDouble(dTable.Rows[i]["Nuez_Defectos"].ToString());
                    }
                    catch
                    {
                        nDefectos = 0;
                    }

                    ////////////////////////
                    // Almendras
                    // . as  , ta1., ta1.Cascara,  ta1.impurezas, ta1.Gemela , ta1.VariedadDisimil ,


                    try
                    {
                        cNumOF = dTable1.Rows[i]["OrdenFabricacion"].ToString();
                    }
                    catch
                    {
                        cNumOF = "";
                    }

                    try
                    {
                        dFechaElaboración = Convert.ToDateTime(dTable1.Rows[i]["CreateDate"].ToString());
                    }
                    catch
                    {
                        dFechaElaboración = Convert.ToDateTime("01/01/1900");
                    }

                    ///////////////////////////////////////////////////////////////////////////

                    grilla[0] = cLote;
                    grilla[1] = cItemCode;
                    grilla[2] = cItemName;
                    grilla[3] = cProductor;
                    grilla[4] = cCliente;
                    grilla[5] = cFumigado;
                    grilla[6] = cCalibre;
                    grilla[7] = cVariedad;
                    grilla[8] = cColor;
                    grilla[9] = cUnidad;
                    grilla[10] = nPeso.ToString("N2");

                    grilla[11] = nDocEntry.ToString();

                    grilla[12] = nExtraLigth.ToString("N2");
                    grilla[13] = nLigth.ToString("N2");
                    grilla[14] = nLigthAmbar.ToString("N2");
                    grilla[15] = nAmbar.ToString("N2");
                    grilla[16] = nHalves.ToString("N2");
                    grilla[17] = nQuartes.ToString("N2");

                    grilla[18] = cNumOF;

                    Grid4.Rows.Add(grilla);

                }


            }
            catch
            {

            }

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_exp_excel_Click(object sender, EventArgs e)
        {

            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            Excel.Range oRng;

            try
            {
                //Start Excel and get Application object.
                oXL = new Excel.Application();

                //Get a new workbook.
                oWB = (Excel._Workbook)(oXL.Workbooks.Add());
                oSheet = (Excel._Worksheet)oWB.ActiveSheet;

                //Add table headers going cell by cell.
                oSheet.Cells[1, 1] = "Orden Venta";
                oSheet.Cells[1, 2] = t_num_guia.Text;

                //Format A1:D1 as bold, vertical alignment = center.
                oSheet.get_Range("a1", "b2").Font.Bold = true;
                //oSheet.get_Range("A1", "D1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                //Add table headers going cell by cell.
                oSheet.Cells[3, 1] = "Lote";
                oSheet.Cells[3, 2] = "Código";
                oSheet.Cells[3, 3] = "Especie";
                oSheet.Cells[3, 4] = "Productor";
                oSheet.Cells[3, 5] = "Cliente";
                oSheet.Cells[3, 6] = "Fumigado";
                oSheet.Cells[3, 7] = "Calibre";
                oSheet.Cells[3, 8] = "Variedad";
                oSheet.Cells[3, 9] = "Color";
                oSheet.Cells[3, 10] = "Unidad";
                oSheet.Cells[3, 11] = "Peso Unit.";

                oSheet.Cells[3, 12] = "Extra Ligth";
                oSheet.Cells[3, 13] = "Ligth";
                oSheet.Cells[3, 14] = "Ligth Ambar";
                oSheet.Cells[3, 15] = "Ambar";
                oSheet.Cells[3, 16] = "Halves";
                oSheet.Cells[3, 17] = "Quartes";
                oSheet.Cells[3, 18] = "Pieces";
                oSheet.Cells[3, 19] = "Defectos";

                //Format A1:D1 as bold, vertical alignment = center.
                oSheet.get_Range("a3", "k3").Font.Bold = true;
                oSheet.get_Range("a3", "k3").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                for (int i = 0; i <= Grid1.RowCount - 1; i++)
                {

                    oSheet.Cells[4 + i, 1] = Grid1[0, i].Value.ToString();
                    oSheet.Cells[4 + i, 2] = Grid1[1, i].Value.ToString();
                    oSheet.Cells[4 + i, 3] = Grid1[2, i].Value.ToString();
                    oSheet.Cells[4 + i, 4] = Grid1[3, i].Value.ToString();
                    oSheet.Cells[4 + i, 5] = Grid1[4, i].Value.ToString();
                    oSheet.Cells[4 + i, 6] = Grid1[5, i].Value.ToString();
                    oSheet.Cells[4 + i, 7] = Grid1[6, i].Value.ToString();
                    oSheet.Cells[4 + i, 8] = Grid1[7, i].Value.ToString();
                    oSheet.Cells[4 + i, 9] = Grid1[8, i].Value.ToString();
                    oSheet.Cells[4 + i, 10] = Grid1[9, i].Value.ToString();
                    oSheet.Cells[4 + i, 11] = Grid1[10, i].Value.ToString();

                    oSheet.Cells[4 + i, 12] = Grid1[12, i].Value.ToString();
                    oSheet.Cells[4 + i, 13] = Grid1[13, i].Value.ToString();
                    oSheet.Cells[4 + i, 14] = Grid1[14, i].Value.ToString();
                    oSheet.Cells[4 + i, 15] = Grid1[15, i].Value.ToString();
                    oSheet.Cells[4 + i, 16] = Grid1[16, i].Value.ToString();
                    oSheet.Cells[4 + i, 17] = Grid1[17, i].Value.ToString();
                    oSheet.Cells[4 + i, 18] = Grid1[18, i].Value.ToString();
                    oSheet.Cells[4 + i, 19] = Grid1[19, i].Value.ToString();

                }

                //AutoFit columns A:D.
                oRng = oSheet.get_Range("A1", "k1");
                oRng.EntireColumn.AutoFit();

                //Manipulate a variable number of columns for Quarterly Sales Data.
                //DisplayQuarterlySales(oSheet);

                //Make sure Excel is visible and give the user control
                //of Microsoft Excel's lifetime.
                oXL.Visible = true;
                oXL.UserControl = true;
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                MessageBox.Show(errorMessage, "Error");
            }

        }

        private void btn_registro_insp_Click(object sender, EventArgs e)
        {

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila, id_Recepcion, id_LineNum;
            int id_NumOF, nLineOF, nLote;
            int nIdCalidad;

            string cItemCode;

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

            id_Recepcion = 0;
            id_LineNum = 0;
            id_NumOF = 0;
            nLineOF = 0;
            nLote = 0;
            nIdCalidad = 0;
            cItemCode = "";

            id_Recepcion = 0;
            id_LineNum = 0;
            id_NumOF = 0;
            nLineOF = 0;

            try
            {
                nLote = int.Parse(Grid1[0, fila].Value.ToString());
            }
            catch
            {
                nLote = 0;
            }

            try
            {
                nIdCalidad = int.Parse(Grid1[11, fila].Value.ToString());
            }
            catch
            {
                nIdCalidad = 0;
            }

            try
            {
                cItemCode = Grid1[1, fila].Value.ToString().ToUpper();
            }
            catch
            {
                cItemCode = "";
            }

            if (nLote > 0)
            {

                VariablesGlobales.glb_id_calidad = nIdCalidad;
                VariablesGlobales.glb_Object = "59";
                VariablesGlobales.glb_id_romana = 0;

                VariablesGlobales.glb_DocEntry = id_Recepcion;
                VariablesGlobales.glb_LineId = id_LineNum;

                VariablesGlobales.glb_NumOF = id_NumOF;
                VariablesGlobales.glb_LineNumOF = nLineOF;

                VariablesGlobales.glb_ItemCode = cItemCode;
                VariablesGlobales.glb_Lote = nLote;

                frmCalidadPP4 f2 = new frmCalidadPP4();
                DialogResult res = f2.ShowDialog();
              
            }

        }

        private void btn_exp_excel2_Click(object sender, EventArgs e)
        {


            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            Excel.Range oRng;

            try
            {
                //Start Excel and get Application object.
                oXL = new Excel.Application();

                //Get a new workbook.
                oWB = (Excel._Workbook)(oXL.Workbooks.Add());
                oSheet = (Excel._Worksheet)oWB.ActiveSheet;

                //Add table headers going cell by cell.
                oSheet.Cells[1, 1] = "Orden Venta";
                oSheet.Cells[1, 2] = t_num_guia.Text;

                //Format A1:D1 as bold, vertical alignment = center.
                oSheet.get_Range("a1", "b2").Font.Bold = true;
                //oSheet.get_Range("A1", "D1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                //Add table headers going cell by cell.
                oSheet.Cells[3, 1] = "Lote";
                oSheet.Cells[3, 2] = "Código";
                oSheet.Cells[3, 3] = "Especie";
                oSheet.Cells[3, 4] = "Productor";
                oSheet.Cells[3, 5] = "Cliente";
                oSheet.Cells[3, 6] = "Fumigado";
                oSheet.Cells[3, 7] = "Calibre";
                oSheet.Cells[3, 8] = "Variedad";
                oSheet.Cells[3, 9] = "Color";
                oSheet.Cells[3, 10] = "Unidad";
                oSheet.Cells[3, 11] = "Peso Unit.";

                oSheet.Cells[3, 12] = "onza";

                oSheet.Cells[3, 13] = "Pepa Sana";
                oSheet.Cells[3, 14] = "Pelon Suelto";
                oSheet.Cells[3, 15] = "Cascara";
                oSheet.Cells[3, 16] = "Impurezas";
                oSheet.Cells[3, 17] = "Gemelas";
                oSheet.Cells[3, 18] = "Variedad Disimil";
                oSheet.Cells[3, 19] = "Astilladas Leve";
                oSheet.Cells[3, 20] = "Astilladas Graves";
                oSheet.Cells[3, 21] = "Partidas Rotas";
                oSheet.Cells[3, 22] = "Reseca";
                oSheet.Cells[3, 23] = "Goma";
                oSheet.Cells[3, 24] = "Punto Goma";
                oSheet.Cells[3, 25] = "Fuera Color";
                oSheet.Cells[3, 26] = "Hongo Inactivo";
                oSheet.Cells[3, 27] = "Daño Insecto Sin Larva";
                oSheet.Cells[3, 28] = "Hongo Activo";
                oSheet.Cells[3, 29] = "Rancidez";
                oSheet.Cells[3, 30] = "Total Daño Serios";
                oSheet.Cells[3, 31] = "Otros Defectos";
                oSheet.Cells[3, 32] = "Ratio";
                oSheet.Cells[3, 33] = "M.Variedad";
                oSheet.Cells[3, 34] = "Humedad";
                oSheet.Cells[3, 35] = "Piedras";

                //oSheet.Cells[3, 12] = "Extra Ligth";
                //oSheet.Cells[3, 13] = "Ligth";
                //oSheet.Cells[3, 14] = "Ligth Ambar";
                //oSheet.Cells[3, 15] = "Ambar";
                //oSheet.Cells[3, 16] = "Halves";
                //oSheet.Cells[3, 17] = "Quartes";
                //oSheet.Cells[3, 18] = "Pieces";
                //oSheet.Cells[3, 19] = "Defectos";

                //Format A1:D1 as bold, vertical alignment = center.
                oSheet.get_Range("a3", "af3").Font.Bold = true;
                oSheet.get_Range("a3", "af3").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                for (int i = 0; i <= Grid3.RowCount - 1; i++)
                {

                    oSheet.Cells[4 + i, 1] = Grid3[0, i].Value.ToString();
                    oSheet.Cells[4 + i, 2] = Grid3[1, i].Value.ToString();
                    oSheet.Cells[4 + i, 3] = Grid3[2, i].Value.ToString();
                    oSheet.Cells[4 + i, 4] = Grid3[3, i].Value.ToString();
                    oSheet.Cells[4 + i, 5] = Grid3[4, i].Value.ToString();
                    oSheet.Cells[4 + i, 6] = Grid3[5, i].Value.ToString();
                    oSheet.Cells[4 + i, 7] = Grid3[6, i].Value.ToString();
                    oSheet.Cells[4 + i, 8] = Grid3[7, i].Value.ToString();
                    oSheet.Cells[4 + i, 9] = Grid3[8, i].Value.ToString();
                    oSheet.Cells[4 + i, 10] = Grid3[9, i].Value.ToString();
                    oSheet.Cells[4 + i, 11] = Grid3[10, i].Value.ToString();

                    oSheet.Cells[4 + i, 12] = Grid3[12, i].Value.ToString();
                    oSheet.Cells[4 + i, 13] = Grid3[13, i].Value.ToString();
                    oSheet.Cells[4 + i, 14] = Grid3[14, i].Value.ToString();
                    oSheet.Cells[4 + i, 15] = Grid3[15, i].Value.ToString();
                    oSheet.Cells[4 + i, 16] = Grid3[16, i].Value.ToString();
                    oSheet.Cells[4 + i, 17] = Grid3[17, i].Value.ToString();
                    oSheet.Cells[4 + i, 18] = Grid3[18, i].Value.ToString();
                    oSheet.Cells[4 + i, 19] = Grid3[19, i].Value.ToString();
                    oSheet.Cells[4 + i, 20] = Grid3[20, i].Value.ToString();
                    oSheet.Cells[4 + i, 21] = Grid3[21, i].Value.ToString();
                    oSheet.Cells[4 + i, 22] = Grid3[22, i].Value.ToString();
                    oSheet.Cells[4 + i, 23] = Grid3[23, i].Value.ToString();
                    oSheet.Cells[4 + i, 24] = Grid3[24, i].Value.ToString();
                    oSheet.Cells[4 + i, 25] = Grid3[25, i].Value.ToString();
                    oSheet.Cells[4 + i, 26] = Grid3[26, i].Value.ToString();
                    oSheet.Cells[4 + i, 27] = Grid3[27, i].Value.ToString();
                    oSheet.Cells[4 + i, 28] = Grid3[28, i].Value.ToString();
                    oSheet.Cells[4 + i, 29] = Grid3[29, i].Value.ToString();
                    oSheet.Cells[4 + i, 30] = Grid3[30, i].Value.ToString();
                    oSheet.Cells[4 + i, 31] = Grid3[31, i].Value.ToString();
                    oSheet.Cells[4 + i, 32] = Grid3[32, i].Value.ToString();
                    oSheet.Cells[4 + i, 33] = Grid3[33, i].Value.ToString();
                    oSheet.Cells[4 + i, 34] = Grid3[34, i].Value.ToString();
                    oSheet.Cells[4 + i, 35] = Grid3[35, i].Value.ToString();

                    //oSheet.Cells[4 + i, 12] = Grid3[12, i].Value.ToString();
                    //oSheet.Cells[4 + i, 13] = Grid3[13, i].Value.ToString();
                    //oSheet.Cells[4 + i, 14] = Grid3[14, i].Value.ToString();
                    //oSheet.Cells[4 + i, 15] = Grid3[15, i].Value.ToString();
                    //oSheet.Cells[4 + i, 16] = Grid3[16, i].Value.ToString();
                    //oSheet.Cells[4 + i, 17] = Grid3[17, i].Value.ToString();
                    //oSheet.Cells[4 + i, 18] = Grid3[18, i].Value.ToString();
                    //oSheet.Cells[4 + i, 19] = Grid3[19, i].Value.ToString();

                }

                //AutoFit columns A:D.
                oRng = oSheet.get_Range("A1", "af1");
                oRng.EntireColumn.AutoFit();

                //Manipulate a variable number of columns for Quarterly Sales Data.
                //DisplayQuarterlySales(oSheet);

                //Make sure Excel is visible and give the user control
                //of Microsoft Excel's lifetime.
                oXL.Visible = true;
                oXL.UserControl = true;
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                MessageBox.Show(errorMessage, "Error");
            }

        }

        private void btn_registro_insp1_Click(object sender, EventArgs e)
        {


            if (Grid3.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila, id_Recepcion, id_LineNum;
            int id_NumOF, nLineOF, nLote;
            int nIdCalidad;

            string cItemCode;

            try
            {
                fila = Grid3.CurrentCell.RowIndex;

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

            id_Recepcion = 0;
            id_LineNum = 0;
            id_NumOF = 0;
            nLineOF = 0;
            nLote = 0;
            nIdCalidad = 0;
            cItemCode = "";

            id_Recepcion = 0;
            id_LineNum = 0;
            id_NumOF = 0;
            nLineOF = 0;

            try
            {
                nLote = int.Parse(Grid3[0, fila].Value.ToString());
            }
            catch
            {
                nLote = 0;
            }

            try
            {
                nIdCalidad = int.Parse(Grid3[11, fila].Value.ToString());
            }
            catch
            {
                nIdCalidad = 0;
            }

            try
            {
                cItemCode = Grid3[1, fila].Value.ToString().ToUpper();
            }
            catch
            {
                cItemCode = "";
            }

            if (nLote > 0)
            {

                VariablesGlobales.glb_id_calidad = nIdCalidad;
                VariablesGlobales.glb_Object = "59";
                VariablesGlobales.glb_id_romana = 0;

                VariablesGlobales.glb_DocEntry = id_Recepcion;
                VariablesGlobales.glb_LineId = id_LineNum;

                VariablesGlobales.glb_NumOF = id_NumOF;
                VariablesGlobales.glb_LineNumOF = nLineOF;

                VariablesGlobales.glb_ItemCode = cItemCode;
                VariablesGlobales.glb_Lote = nLote;

                string cModeloFrm;

                cModeloFrm = "";

                clsCalidad objproducto = new clsCalidad();
                objproducto.cls_Consulta_Registro_Inspeccion(nIdCalidad);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                try
                {
                    cModeloFrm = dTable.Rows[0]["ModeloFrm"].ToString();
                }
                catch
                {
                    cModeloFrm = "";
                }

                if (cModeloFrm == "OLD")
                {
                    frmCalidadPP4 fv1 = new frmCalidadPP4();
                    DialogResult res1 = fv1.ShowDialog();

                }
                else
                {
                    frmCalidadPPA6 fv2 = new frmCalidadPPA6();
                    DialogResult res2 = fv2.ShowDialog();

                }

            }

        }

        private void btn_exp_excel3_Click(object sender, EventArgs e)
        {

            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            Excel.Range oRng;

            try
            {
                //Start Excel and get Application object.
                oXL = new Excel.Application();

                //Get a new workbook.
                oWB = (Excel._Workbook)(oXL.Workbooks.Add());
                oSheet = (Excel._Worksheet)oWB.ActiveSheet;

                //Add table headers going cell by cell.
                oSheet.Cells[1, 1] = "Orden Venta";
                oSheet.Cells[1, 2] = t_num_guia.Text;

                //Format A1:D1 as bold, vertical alignment = center.
                oSheet.get_Range("a1", "b2").Font.Bold = true;
                //oSheet.get_Range("A1", "D1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                //Add table headers going cell by cell.
                oSheet.Cells[3, 1] = "Lote";
                oSheet.Cells[3, 2] = "Código";
                oSheet.Cells[3, 3] = "Especie";
                oSheet.Cells[3, 4] = "Productor";
                oSheet.Cells[3, 5] = "Cliente";
                oSheet.Cells[3, 6] = "Fumigado";
                oSheet.Cells[3, 7] = "Calibre";
                oSheet.Cells[3, 8] = "Variedad";
                oSheet.Cells[3, 9] = "Color";
                oSheet.Cells[3, 10] = "Unidad";
                oSheet.Cells[3, 11] = "Peso Unit.";

                oSheet.Cells[3, 12] = "Extra Ligth";
                oSheet.Cells[3, 13] = "Ligth";
                oSheet.Cells[3, 14] = "Ligth Ambar";
                oSheet.Cells[3, 15] = "Ambar";
                oSheet.Cells[3, 16] = "Amarillas";
                oSheet.Cells[3, 17] = "Peso 100U";
                //oSheet.Cells[3, 18] = "Pieces";
                //oSheet.Cells[3, 19] = "Defectos";

                //Format A1:D1 as bold, vertical alignment = center.
                oSheet.get_Range("a3", "k3").Font.Bold = true;
                oSheet.get_Range("a3", "k3").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                for (int i = 0; i <= Grid4.RowCount - 1; i++)
                {

                    oSheet.Cells[4 + i, 1] = Grid4[0, i].Value.ToString();
                    oSheet.Cells[4 + i, 2] = Grid4[1, i].Value.ToString();
                    oSheet.Cells[4 + i, 3] = Grid4[2, i].Value.ToString();
                    oSheet.Cells[4 + i, 4] = Grid4[3, i].Value.ToString();
                    oSheet.Cells[4 + i, 5] = Grid4[4, i].Value.ToString();
                    oSheet.Cells[4 + i, 6] = Grid4[5, i].Value.ToString();
                    oSheet.Cells[4 + i, 7] = Grid4[6, i].Value.ToString();
                    oSheet.Cells[4 + i, 8] = Grid4[7, i].Value.ToString();
                    oSheet.Cells[4 + i, 9] = Grid4[8, i].Value.ToString();
                    oSheet.Cells[4 + i, 10] = Grid4[9, i].Value.ToString();
                    oSheet.Cells[4 + i, 11] = Grid4[10, i].Value.ToString();

                    oSheet.Cells[4 + i, 12] = Grid4[12, i].Value.ToString();
                    oSheet.Cells[4 + i, 13] = Grid4[13, i].Value.ToString();
                    oSheet.Cells[4 + i, 14] = Grid4[14, i].Value.ToString();
                    oSheet.Cells[4 + i, 15] = Grid4[15, i].Value.ToString();
                    oSheet.Cells[4 + i, 16] = Grid4[16, i].Value.ToString();
                    oSheet.Cells[4 + i, 17] = Grid4[17, i].Value.ToString();
                    //oSheet.Cells[4 + i, 18] = Grid4[18, i].Value.ToString();
                    //oSheet.Cells[4 + i, 19] = Grid4[19, i].Value.ToString();

                }

                //AutoFit columns A:D.
                oRng = oSheet.get_Range("A1", "k1");
                oRng.EntireColumn.AutoFit();

                //Manipulate a variable number of columns for Quarterly Sales Data.
                //DisplayQuarterlySales(oSheet);

                //Make sure Excel is visible and give the user control
                //of Microsoft Excel's lifetime.
                oXL.Visible = true;
                oXL.UserControl = true;
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                MessageBox.Show(errorMessage, "Error");
            }

        }

        private void btn_registro_insp3_Click(object sender, EventArgs e)
        {


            if (Grid4.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila, id_Recepcion, id_LineNum;
            int id_NumOF, nLineOF, nLote;
            int nIdCalidad;

            string cItemCode;

            try
            {
                fila = Grid4.CurrentCell.RowIndex;

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

            id_Recepcion = 0;
            id_LineNum = 0;
            id_NumOF = 0;
            nLineOF = 0;
            nLote = 0;
            nIdCalidad = 0;
            cItemCode = "";

            id_Recepcion = 0;
            id_LineNum = 0;
            id_NumOF = 0;
            nLineOF = 0;

            try
            {
                nLote = int.Parse(Grid4[0, fila].Value.ToString());
            }
            catch
            {
                nLote = 0;
            }

            try
            {
                nIdCalidad = int.Parse(Grid4[11, fila].Value.ToString());
            }
            catch
            {
                nIdCalidad = 0;
            }

            try
            {
                id_NumOF = int.Parse(Grid4[18, fila].Value.ToString());
            }
            catch
            {
                id_NumOF = 0;
            }

            try
            {
                cItemCode = Grid4[1, fila].Value.ToString().ToUpper();
            }
            catch
            {
                cItemCode = "";
            }

            if (nLote > 0)
            {

                VariablesGlobales.glb_id_calidad = nIdCalidad;
                VariablesGlobales.glb_Object = "59";
                VariablesGlobales.glb_id_romana = 0;

                VariablesGlobales.glb_DocEntry = id_Recepcion;
                VariablesGlobales.glb_LineId = id_LineNum;

                VariablesGlobales.glb_NumOF = id_NumOF;
                VariablesGlobales.glb_LineNumOF = nLineOF;

                VariablesGlobales.glb_ItemCode = cItemCode;
                VariablesGlobales.glb_Lote = nLote;

                string cDestino;

                cDestino = "";

                clsCalidad objproducto22 = new clsCalidad();
                objproducto22.cls_Consulta_Registro_Inspeccion_x_orden(id_NumOF);

                DataTable dTable22 = new DataTable();
                dTable22 = objproducto22.cResultado;

                try
                {
                    cDestino = dTable22.Rows[0]["Destino"].ToString();
                }
                catch
                {
                    cDestino = "Proceso Anterior";
                }

                if (cDestino == "Proceso Anterior")
                {
                    frmCalidadPP4 fv4 = new frmCalidadPP4();
                    DialogResult res4 = fv4.ShowDialog();

                }
                else
                {
                    frmCalidadPPA6 fv0 = new frmCalidadPPA6();
                    DialogResult res0 = fv0.ShowDialog();

                }


            }

        }

        private void btn_registro_insp4_Click(object sender, EventArgs e)
        {



        }

        private void btn_exp_excel4_Click(object sender, EventArgs e)
        {

        }

        private void imprimirCertificadoDeCalidadToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int fila;
            string cDocNum, cItemCode, cTipoFruta;
            string cTipoProceso, cAutorizador;

            try
            {
                fila = Grid2.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            if (fila == -1)
            {
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Orden de Venta ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                cDocNum = Grid2[1, fila].Value.ToString();
            }
            catch
            {
                cDocNum = "";
            }

            try
            {
                cItemCode = Grid2[4, fila].Value.ToString();
            }
            catch
            {
                cItemCode = "";
            }

            try
            {
                cTipoFruta = Grid2[9, fila].Value.ToString();
            }
            catch
            {
                cTipoFruta = "";
            }

            try
            {
                cTipoProceso = Grid2[10, fila].Value.ToString();
            }
            catch
            {
                cTipoProceso = "";
            }

            try
            {
                cAutorizador = Grid2[11, fila].Value.ToString();
            }
            catch
            {
                cAutorizador = "";
            }

            if (cDocNum == "")
            {
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Orden de Venta ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                VariablesGlobales.glb_DocEntry = int.Parse(cDocNum);
            }
            catch
            {
                VariablesGlobales.glb_DocEntry = 0;
            }

            try
            {
                VariablesGlobales.glb_ItemCode = cItemCode;
            }
            catch
            {
                VariablesGlobales.glb_ItemCode = "";
            }

            VariablesGlobales.glb_Referencia1 = "9";

            if (cAutorizador.ToUpper() =="PCARCAMO")
            {
                VariablesGlobales.glb_Referencia1 = "0";

            }

            if (cAutorizador.ToUpper() == "CSOTO")
            {
                VariablesGlobales.glb_Referencia1 = "1";

            }

            if (cAutorizador.ToUpper() == "CCLAVIJO")
            {
                VariablesGlobales.glb_Referencia1 = "2";

            }

            if (VariablesGlobales.glb_DocEntry > 0)
            {

                if (cTipoFruta == "Almendra")
                {

                    frmCalidadPP8 f2 = new frmCalidadPP8();
                    DialogResult res = f2.ShowDialog();

                }

                if (cTipoFruta == "Nuez")
                {

                    if (cTipoProceso != "Con Cáscara")
                    {

                        frmCalidadPP7 f2 = new frmCalidadPP7();
                        DialogResult res = f2.ShowDialog();

                    }
                    else
                    {

                        frmCalidadPPA2 f2 = new frmCalidadPPA2();
                        DialogResult res = f2.ShowDialog();

                    }

                }

            }

        }

        private void imprimirCertificadoSimplificadoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int fila;
            string cDocNum, cItemCode, cTipoFruta;
            string cTipoProceso, cAutorizador;

            try
            {
                fila = Grid2.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            if (fila == -1)
            {
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Orden de Venta ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                cAutorizador = Grid2[11, fila].Value.ToString();
            }
            catch
            {
                cAutorizador = "";
            }

            try
            {
                cDocNum = Grid2[1, fila].Value.ToString();
            }
            catch
            {
                cDocNum = "";
            }

            try
            {
                cItemCode = Grid2[4, fila].Value.ToString();
            }
            catch
            {
                cItemCode = "";
            }

            try
            {
                cTipoFruta = Grid2[9, fila].Value.ToString();
            }
            catch
            {
                cTipoFruta = "";
            }

            try
            {
                cTipoProceso = Grid2[10, fila].Value.ToString();
            }
            catch
            {
                cTipoProceso = "";
            }

            if (cDocNum == "")
            {
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Orden de Venta ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                VariablesGlobales.glb_DocEntry = int.Parse(cDocNum);
            }
            catch
            {
                VariablesGlobales.glb_DocEntry = 0;
            }

            try
            {
                VariablesGlobales.glb_ItemCode = cItemCode;
            }
            catch
            {
                VariablesGlobales.glb_ItemCode = "";
            }

            VariablesGlobales.glb_Referencia1 = "9";

            if (cAutorizador.ToUpper() == "PCARCAMO")
            {
                VariablesGlobales.glb_Referencia1 = "0";

            }

            if (cAutorizador.ToUpper() == "CSOTO")
            {
                VariablesGlobales.glb_Referencia1 = "1";

            }

            if (VariablesGlobales.glb_DocEntry > 0)
            {

                if (cTipoFruta == "Almendra")
                {

                    frmCalidadPP9 f2 = new frmCalidadPP9();
                    DialogResult res = f2.ShowDialog();

                }

                if (cTipoFruta == "Nuez")
                {

                    if (cTipoProceso != "Con Cáscara")
                    {

                        frmCalidadPPA1 f2 = new frmCalidadPPA1();
                        DialogResult res = f2.ShowDialog();

                    }
                    else
                    {
                        frmCalidadPPA2 f2 = new frmCalidadPPA2();
                        DialogResult res = f2.ShowDialog();

                    }
                }

            }

        }

        private void firmarLineaDeOrdenDeVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cCalidad_Firma_PT;

            cCalidad_Firma_PT = "NO";

            clsMaestros objproducto = new clsMaestros();
            objproducto.cls_lee_usuario(VariablesGlobales.glb_User_Code);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                cCalidad_Firma_PT = dTable.Rows[0]["Calidad_Firma_PT"].ToString();

            }
            catch
            {
                cCalidad_Firma_PT = "NO";

            }

            if (cCalidad_Firma_PT == "NO")
            {
                MessageBox.Show("Usuario NO Autorizado para realizar esta actividad, opción Cancelada", "Orden de Venta ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila, nNumLinea, nDocEntry;
            string cItemCode, cAutorizador;

            try
            {
                fila = Grid2.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            if (fila == -1)
            {
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Orden de Venta ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                nDocEntry = Convert.ToInt32(Grid2[0, fila].Value);
            }
            catch
            {
                nDocEntry = 0;
            }

            try
            {
                cItemCode = Grid2[4, fila].Value.ToString();
            }
            catch
            {
                cItemCode = "";
            }

            if (nDocEntry == 0)
            {
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Orden de Venta ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                nNumLinea = Convert.ToInt32(Grid2[6, fila].Value.ToString());
            }
            catch
            {
                nNumLinea = 0;
            }

            try
            {
                cAutorizador = Grid2[12, fila].Value.ToString();
            }
            catch
            {
                cAutorizador = "";
            }

            if (cAutorizador != "")
            {
                MessageBox.Show("La línea seleccionada ya fue autorizada, opción Cancelada", "Orden de Venta ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            DialogResult result = MessageBox.Show("Desea firmar la línea seleccionada?", "Orden de Venta ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;

            }

            cAutorizador = VariablesGlobales.glb_User_Code.ToUpper();

            clsCalidad objproducto1 = new clsCalidad();

            objproducto1.U_Actualiza_Linea_OrdenVenta_Calidad(nDocEntry, nNumLinea, cAutorizador);

            MessageBox.Show("Registro Grabado", "Orden de Venta ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Grid2[11, fila].Value = cAutorizador;
            Grid2[12, fila].Value = VariablesGlobales.glb_User_Name;

        }

        private void cancelarFirmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cCalidad_Firma_PT;

            cCalidad_Firma_PT = "NO";

            clsMaestros objproducto = new clsMaestros();
            objproducto.cls_lee_usuario(VariablesGlobales.glb_User_Code);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                cCalidad_Firma_PT = dTable.Rows[0]["Calidad_Firma_PT"].ToString();

            }
            catch
            {
                cCalidad_Firma_PT = "NO";

            }

            if (cCalidad_Firma_PT == "NO")
            {
                MessageBox.Show("Usuario NO Autorizado para realizar esta actividad, opción Cancelada", "Orden de Venta ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila, nNumLinea, nDocEntry;
            string cItemCode, cAutorizador;

            try
            {
                fila = Grid2.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            if (fila == -1)
            {
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Orden de Venta ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                nDocEntry = Convert.ToInt32(Grid2[0, fila].Value);
            }
            catch
            {
                nDocEntry = 0;
            }

            try
            {
                cItemCode = Grid2[4, fila].Value.ToString();
            }
            catch
            {
                cItemCode = "";
            }

            if (nDocEntry == 0)
            {
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Orden de Venta ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                nNumLinea = Convert.ToInt32(Grid2[6, fila].Value.ToString());
            }
            catch
            {
                nNumLinea = 0;
            }

            try
            {
                cAutorizador = Grid2[11, fila].Value.ToString();
            }
            catch
            {
                cAutorizador = "";
            }

            if (cAutorizador == "")
            {
                MessageBox.Show("La línea seleccionada NO ha sido autorizada, opción Cancelada", "Orden de Venta ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            DialogResult result = MessageBox.Show("Desea borrar la firmar de la línea seleccionada?", "Orden de Venta ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;

            }

            clsCalidad objproducto1 = new clsCalidad();

            objproducto1.U_Actualiza_Linea_OrdenVenta_Calidad(nDocEntry, nNumLinea, "");

            MessageBox.Show("Registro Grabado", "Orden de Venta ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Grid2[11, fila].Value = "";
            Grid2[12, fila].Value = "";

        }

        private void btn_certificado_Click(object sender, EventArgs e)
        {

            int fila;
            string cDocNum, cItemCode, cTipoFruta;
            string cTipoProceso, cAutorizador;

            try
            {
                fila = Grid2.CurrentCell.RowIndex;

            }
            catch
            {
                fila = -1;
            }

            if (fila == -1)
            {
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Orden de Venta ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                cDocNum = Grid2[1, fila].Value.ToString();
            }
            catch
            {
                cDocNum = "";
            }

            try
            {
                cItemCode = Grid2[4, fila].Value.ToString();
            }
            catch
            {
                cItemCode = "";
            }

            try
            {
                cTipoFruta = Grid2[9, fila].Value.ToString();
            }
            catch
            {
                cTipoFruta = "";
            }

            try
            {
                cTipoProceso = Grid2[10, fila].Value.ToString();
            }
            catch
            {
                cTipoProceso = "";
            }

            try
            {
                cAutorizador = Grid2[11, fila].Value.ToString();
            }
            catch
            {
                cAutorizador = "";
            }

            if (cDocNum == "")
            {
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Orden de Venta ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                VariablesGlobales.glb_DocEntry = int.Parse(cDocNum);
            }
            catch
            {
                VariablesGlobales.glb_DocEntry = 0;
            }

            try
            {
                VariablesGlobales.glb_ItemCode = cItemCode;
            }
            catch
            {
                VariablesGlobales.glb_ItemCode = "";
            }

            VariablesGlobales.glb_Referencia1 = "9";
            VariablesGlobales.glb_tipo_fruta = cTipoFruta;
            VariablesGlobales.glb_tipo_proceso = cTipoProceso;

            if (cAutorizador.ToUpper() == "PCARCAMO")
            {
                VariablesGlobales.glb_Referencia1 = "0";

            }

            if (cAutorizador.ToUpper() == "CSOTO")
            {
                VariablesGlobales.glb_Referencia1 = "1";

            }

            if (cAutorizador.ToUpper() == "CCLAVIJO")
            {
                VariablesGlobales.glb_Referencia1 = "2";

            }

            if (VariablesGlobales.glb_DocEntry > 0)
            {

                if (cTipoFruta == "Almendra")
                {

                    frmCalidadPPB7 f2 = new frmCalidadPPB7();
                    DialogResult res = f2.ShowDialog();

                }

                if (cTipoFruta == "Nuez")
                {

                    if (cTipoProceso != "Con Cáscara")
                    {

                        frmCalidadPPB7 f2 = new frmCalidadPPB7();
                        DialogResult res = f2.ShowDialog();

                    }
                    else
                    {

                        frmCalidadPPB7 f2 = new frmCalidadPPB7();
                        DialogResult res = f2.ShowDialog();

                        //frmCalidadPPA2 f2 = new frmCalidadPPA2();
                        //DialogResult res = f2.ShowDialog();

                    }

                }

            }

        }

    }

}
