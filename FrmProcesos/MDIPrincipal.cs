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
using CapaEntidades;
using System.IO;
using System.Configuration;

namespace FrmProcesos
{
    public partial class MDIPrincipal : Form
    {
        //private int childFormNumber = 0;

        public MDIPrincipal()
        {
            InitializeComponent();
        }

        private void MenuProcesos_Load(object sender, EventArgs e)
        {

            // Formularios - Object 
            // 100000 - HDV_OACC - Acceso Porteria
            // 100100 - HDV_OROM - Romana 
            // 100200 - HDV_ORCAL- Calidad 
            // 100300 - HDV-OPRO - Procesos / Mailer - Programa IA - HP
            // 100400 - HDV_OCOL - COla de envio de Correos - Programa IA - HP
            // 100500 - HDV_OPDX - Recepcion MP v2 

            this.Visible = true;

            // VVVV  VVVVV  
            //  VVVV  VVV
            //   VVVVVVV
            //    VVVVV

            VariablesGlobales.glb_version = "32.3";
            tssl_version.Text = "VERSIÓN: " + VariablesGlobales.glb_version;

            // ***********
            // ***********

            VariablesGlobales.accesoMenuPrincipal = 0;
            VariablesGlobales.glb_User_Code = "";
            VariablesGlobales.glb_User_Name = "";

            frmLogin login = new frmLogin();
            DialogResult res = login.ShowDialog();

            if (VariablesGlobales.accesoMenuPrincipal == 0)
            {
                this.Close();
            }

            statusBar.Text = "Conectado";
            StatusImagenRoja.Visible = false;
            StatusImagenVerde.Visible = true;

            string user_name;
            string produccion, porteria, romana;
            string calidad, recepcion_mp, ventas;
            string produccion_com, declaracion_mermas, autorizacion_mermas;

            int usr_id;

            VariablesGlobales.glb_User_Name = "";

            user_name = "";
            produccion = "";
            porteria = "";
            romana = "";
            calidad = "";
            recepcion_mp = "";
            produccion_com = "";
            ventas = "";
            declaracion_mermas = "";
            autorizacion_mermas = "";

            usr_id = 0;

            clsMaestros objproducto = new clsMaestros();
            objproducto.cls_lee_usuario(VariablesGlobales.glb_User_Code);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                user_name = dTable.Rows[0]["nombre"].ToString();

            }
            catch
            {
                user_name = "";

            }

            try
            {
                produccion = dTable.Rows[0]["Produccion"].ToString();

            }
            catch
            {
                produccion = "";

            }

            try
            {
                porteria = dTable.Rows[0]["Porteria"].ToString();
            }
            catch
            {
                porteria = "";
            }

            try
            {
                romana = dTable.Rows[0]["Romana"].ToString();
            }
            catch
            {
                romana = "";
            }

            try
            {
                calidad = dTable.Rows[0]["Calidad"].ToString();
            }
            catch
            {
                calidad = ""; 
            }

            try
            {
                ventas = dTable.Rows[0]["Ventas"].ToString();
            }
            catch
            {
                ventas = "";

            }

            try
            {
                recepcion_mp = dTable.Rows[0]["Recepcion_MP"].ToString();
            }
            catch
            {
                recepcion_mp = "";
            }

            try
            {
                produccion_com = dTable.Rows[0]["Produccion_COM"].ToString();
            }
            catch
            {
                produccion_com = "";
            }

            try
            {
                declaracion_mermas = dTable.Rows[0]["Declarar_Mermas"].ToString();
            }
            catch
            {
                declaracion_mermas = "";
            }

            try
            {
                autorizacion_mermas = dTable.Rows[0]["Autorizar_Mermas"].ToString();
            }
            catch
            {
                autorizacion_mermas = "";
            }

            try
            {
                usr_id = Convert.ToInt32(dTable.Rows[0]["USERID"].ToString());
            }
            catch
            {
                usr_id = 0;
            }

            try
            {
                VariablesGlobales.glb_User_Sucursal = dTable.Rows[0]["Nom_Sucursal"].ToString(); 
            }
            catch
            {
                VariablesGlobales.glb_User_Sucursal = "";
            }

            VariablesGlobales.glb_User_Name = user_name;
            VariablesGlobales.glb_User_id = usr_id;

            tss_nom_usuario.Text = user_name;
            tss_nom_base_datos.Text = ConfigurationManager.AppSettings.Get("Base_SAP");

            producciónToolStripMenuItem1.Visible = false;
            despelonadoSecadoToolStripMenuItem.Visible = false;

            tsp_gestion_lotes.Enabled = false;

            porteriaToolStripMenuItem.Visible = false;
            romanaToolStripMenuItem.Visible = false;
            calidadToolStripMenuItem.Visible = false;
            recepciónDeMateriasPrimasToolStripMenuItem.Visible = false;

            if (VariablesGlobales.glb_User_Code != "MANAGER")
            {
                ventasToolStripMenuItem.Visible = false;

            }

            if (produccion == "SI")
            {
                producciónToolStripMenuItem1.Visible = true;
                despelonadoSecadoToolStripMenuItem.Visible = true;

                tsp_gestion_lotes.Enabled = true;

                terminationReportToolStripMenuItem.Visible = false;
                terminationReportCOMXToolStripMenuItem.Visible = false;

                if (produccion_com=="NO")
                {
                    terminationReportToolStripMenuItem.Visible = true;
                }
                else
                {
                    terminationReportCOMXToolStripMenuItem.Visible = true;
                }

            }

            if (porteria == "SI")
            {
                porteriaToolStripMenuItem.Visible = true;

            }

            if (romana == "SI")
            {
                romanaToolStripMenuItem.Visible = true;

            }

            if (calidad== "SI")
            {
                calidadToolStripMenuItem.Visible = true;

            }

            if (recepcion_mp == "SI")
            {
                recepciónDeMateriasPrimasToolStripMenuItem.Visible = true;

            }

            if (ventas == "SI")
            {
                ventasToolStripMenuItem.Visible = true;

            }

            //ventasToolStripMenuItem.Visible = true;

            /////////////////////////////////////////////////////
            /////////////////////////////////////////////////////

            //VariablesGlobales.glb_User_Code = "MANAGER";
            //VariablesGlobales.glb_User_id = 1;

            Boolean exists;

            exists = System.IO.Directory.Exists(@"c:\temp");

            if (exists == false)
            {
                MessageBox.Show("Debe crear la Carpeta >Temp< en el Disco C, de lo contrario la aplicación NO funcionara correctamente", "Control de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {

                string sourceDir = @"c:\temp";

                string[] picList = Directory.GetFiles(sourceDir, "i*.png");

                // Copy picture files.
                foreach (string f in picList)
                {
                    // Remove path from the file name.
                    string fName = f.Substring(sourceDir.Length + 1);

                }

                foreach (string f in picList)
                {
                    try
                    {
                        File.Delete(f);

                    }
                    catch
                    {

                    }
                }

                string path = Directory.GetCurrentDirectory();
                path = path + @"\Resources\sheet_white.png";

                try
                {
                    System.IO.File.Copy(path, @"c:\temp\sheet_white.png", true);

                }
                catch
                {

                }

            }

            if (ConfigurationManager.AppSettings.Get("Base_SAP") != "HDV_P03")
            {
                MessageBox.Show("Esta ingresando a una base de PRUEBAS, Tengalo presente", "Control de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            double nValor;
            string cValor, cDecimal, cSeparadorMiles;

            nValor = 1804;

            cValor = nValor.ToString("N2");

            cSeparadorMiles = cValor.Substring(1, 1);
            cDecimal = cValor.Substring(5, 1);

            VariablesGlobales.glb_SimboloDecimal = cDecimal;
            VariablesGlobales.glb_SeparadorMiles = cSeparadorMiles;

    }

        private void accesoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VariablesGlobales.glb_id_acceso = 0;

            frmPorteria frm = new frmPorteria();
            frm.MdiParent = this;
            frm.Show();

        }

        private void listaDeAccesosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VariablesGlobales.glb_id_acceso = 0;
            VariablesGlobales.glb_Referencia1 = "Menu";

            frmPorteria1 frm = new frmPorteria1();
            frm.MdiParent = this;
            frm.Show();

        }

        private void pesajeDeCamionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VariablesGlobales.glb_id_acceso = 0;

            frmRomana frm = new frmRomana();
            frm.MdiParent = this;
            frm.Show();

        }

        private void listaDePesajesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VariablesGlobales.glb_id_acceso = 0;
            VariablesGlobales.glb_Referencia1 = "Menu";

            frmRomana2 frm = new frmRomana2();
            frm.MdiParent = this;
            frm.Show();

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void tsp_gestion_lotes_Click(object sender, EventArgs e)
        {
            frmConsultaLote frm = new frmConsultaLote();            
            frm.MdiParent = this;
            frm.Show();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            status_mensaje.Text = "";
            status_mensaje.BackColor = Color.Empty;

        }

        private void tsb_salir_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void transportistasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTransportistas frm = new frmTransportistas();
            frm.MdiParent = this;
            frm.Show();

        }

    
        private void recepciónDeMPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (VariablesGlobales.glb_User_Sucursal != "Principal")
            {
                MessageBox.Show("Opción No valida para su perfil de usuario, contacte al administrador del sistema", "Menu Principal ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            VariablesGlobales.glb_Formulario_Origen = "";

            frmRecepcionMP1 frm = new frmRecepcionMP1();
            frm.MdiParent = this;
            frm.Show();

        }

        private void listaDePesajesDeRomanaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCalidadMP1 frm = new frmCalidadMP1();
            frm.MdiParent = this;
            frm.Show();

        }

        private void listaDeRecepcionesDeMateriaPrimaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCalidadMP8 frm = new frmCalidadMP8();
            frm.MdiParent = this;
            frm.Show();

        }


        private void terminationReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmOrdenFabricacionTR frm = new frmOrdenFabricacionTR();
            frm.MdiParent = this;
            frm.Show();
        }

      
        private void listaDeProductosEnProcesoRegistroDeInspecciónToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            frmCalidadPP1 frm = new frmCalidadPP1();
            frm.MdiParent = this;
            frm.Show();

        }

        private void parametrosDeCalidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void registrosDeInspacciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCalidadMP4 frm = new frmCalidadMP4();
            frm.MdiParent = this;
            frm.Show();

        }

        private void variedadesDeFrutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVariedad frm = new frmVariedad();
            frm.MdiParent = this;
            frm.Show();

        }

        private void gestiónDeLotesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmBLoqLotes frm = new frmBLoqLotes();
            frm.MdiParent = this;
            frm.Show();
        }

        private void listaDeMaterialesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmReceta1 frm = new frmReceta1();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ordenDeFabricaciónToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            VariablesGlobales.glb_DocEntry = 0;
            VariablesGlobales.glb_ItemCode = "";

            frmOrdenFabricacion frm = new frmOrdenFabricacion();
            frm.MdiParent = this;
            frm.Show();

        }

        private void tsp_etiqueta_Click(object sender, EventArgs e)
        {
            frmOrdenFabricacionTR2 frm = new frmOrdenFabricacionTR2();
            frm.MdiParent = this;
            frm.Show();
        }


        private void ordenesDeVentaPendientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrdenVentas1 frm = new frmOrdenVentas1();
            frm.MdiParent = this;
            frm.Show();

        }

        private void planificaciónDeProducciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrdenFabricacion2 frm = new frmOrdenFabricacion2();
            frm.MdiParent = this;
            frm.Show();

        }

        private void maestroDePalletToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPallet1 frm = new frmPallet1();
            frm.MdiParent = this;
            frm.Show();
        }

       
        private void configuraciónDeBalanzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfiguracion frm = new frmConfiguracion();
            frm.MdiParent = this;
            frm.Show();

        }

        private void palletizadoLoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPallet2 frm = new frmPallet2();
            frm.MdiParent = this;
            frm.Show();

        }

        private void palletizadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPallet3 frm = new frmPallet3();
            frm.MdiParent = this;
            frm.Show();

        }

       
        private void consumoToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            VariablesGlobales.glb_Referencia1 = "";

            frmOrdenFabricacionCO frm = new frmOrdenFabricacionCO();
            frm.MdiParent = this;
            frm.Show();

        }

        private void solicitudesDeTrasladoPlanificadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrdenFabricacion3 frm = new frmOrdenFabricacion3();
            frm.MdiParent = this;
            frm.Show();

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmOrdenFabricacion2 frm = new frmOrdenFabricacion2();
            frm.MdiParent = this;
            frm.Show();
        }

        private void sAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSalidaProduccion frm = new frmSalidaProduccion();
            frm.MdiParent = this;
            frm.Show();

        }

        private void registrosDeRecepciónDeMateriaPrimaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (VariablesGlobales.glb_User_Sucursal == "Principal")
            {
                MessageBox.Show("Opción No valida para su perfil de usuario, contacte al administrador del sistema", "Menu Principal ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;
            }

            VariablesGlobales.glb_Formulario_Origen = "";

            frmRecepcionMP7 frm = new frmRecepcionMP7();
            frm.MdiParent = this;
            frm.Show();

        }

        private void despachoDeCamionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VariablesGlobales.glb_id_acceso = 0;

            frmRomana4 frm = new frmRomana4();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            frmCalibres frm = new frmCalibres();
            frm.MdiParent = this;
            frm.Show();
        }

        private void terminationReportCOMXToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmOrdenFabricacionTR9 frm = new frmOrdenFabricacionTR9();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            VariablesGlobales.glb_DocEntry = 0;
            VariablesGlobales.glb_ItemCode = "";

            frmOrdenFabricacion frm = new frmOrdenFabricacion();
            frm.MdiParent = this;
            frm.Show();

        }

        private void cargaMasivaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fumigadoPorLotePalletToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFumigado frm = new frmFumigado();
            frm.MdiParent = this;
            frm.Show();

        }

        private void fumigadoDesdeArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFumigado1 frm = new frmFumigado1();
            frm.MdiParent = this;
            frm.Show();

        }

        private void colorDeFrutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmColor frm = new frmColor();
            frm.MdiParent = this;
            frm.Show();

        }

        private void cargaMasivaPorAlmacénToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSolicitudTraslado frm = new frmSolicitudTraslado();
            frm.MdiParent = this;
            frm.Show();

        }

        private void cargaMasivaMultiAlmacénToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSolicitudTraslado1 frm = new frmSolicitudTraslado1();
            frm.MdiParent = this;
            frm.Show();

        }

        private void registrosBatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrdenFabricacionCO2 frm = new frmOrdenFabricacionCO2();
            frm.MdiParent = this;
            frm.Show();

        }

        private void transferirLotesBloqueadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTransferenciaStock frm = new frmTransferenciaStock();
            frm.MdiParent = this;
            frm.Show();

        }

        private void parametrosBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCalidadPP2 frm = new frmCalidadPP2();
            frm.MdiParent = this;
            frm.Show();

        }

        private void parametrosPorVariedadCalibreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCalidadPP5 frm = new frmCalidadPP5();
            frm.MdiParent = this;
            frm.Show();

        }

        private void informeDeStockDiarioToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmInforme1 frm = new frmInforme1();
            frm.MdiParent = this;
            frm.Show();

        }

        private void listaDeOrdenesDeVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmCalidadPP6 frm = new frmCalidadPP6();
            frm.MdiParent = this;
            frm.Show();

        }

        private void pruebaDeCostosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCorrigeCosto frm = new frmCorrigeCosto();
            frm.MdiParent = this;
            frm.Show();

        }

        private void recepciónDeInsumosToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            frmRecepcionMPA1 frm = new frmRecepcionMPA1();
            frm.MdiParent = this;
            frm.Show();

        }

        private void planificaciónDeProducciónToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmOrdenFabricacion8 frm = new frmOrdenFabricacion8();
            frm.MdiParent = this;
            frm.Show();
        }

        private void demoProductoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmProductores frm = new frmProductores();
            frm.MdiParent = this;
            frm.Show();

        }

        private void controlDeLotesPorClienteProductorServiciosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmControlProductor frm = new frmControlProductor();
            frm.MdiParent = this;
            frm.Show();

        }

        private void pesajeCamionesSecadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            //VariablesGlobales.glb_id_acceso = 0;

            //frmRomana7 frm = new frmRomana7();
            //frm.MdiParent = this;
            //frm.Show();

            VariablesGlobales.glb_id_acceso = 0;

            frmRomanaA6 frm = new frmRomanaA6();
            frm.MdiParent = this;
            frm.Show();

        }

        private void listaDePesajesDeCamionesDeSecadoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //VariablesGlobales.glb_id_acceso = 0;
            //VariablesGlobales.glb_Referencia1 = "Menu";

            //frmRomana9 frm = new frmRomana9();
            //frm.MdiParent = this;
            //frm.Show();

            VariablesGlobales.glb_id_acceso = 0;
            VariablesGlobales.glb_Referencia1 = "Menu";

            frmRomanaA7 frm = new frmRomanaA7();
            frm.MdiParent = this;
            frm.Show();

        }

        private void recepciónDeMateriaPrimaDesdeSecadoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            VariablesGlobales.glb_Formulario_Origen = "";

            VariablesGlobales.glb_Referencia3 = "Recibe_MP";

            //frmRecepcionMPA4 frm = new frmRecepcionMPA4();
            frmRecepcionMPB9 frm = new frmRecepcionMPB9();
            frm.MdiParent = this;
            frm.Show();

        }

        private void listaDeRegistroDeMateriaPrimaSecadoInspecciónDeHumedadToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmCalidadPPA4 frm = new frmCalidadPPA4();
            frm.MdiParent = this;
            frm.Show();

        }

        private void listaDeRegistroDeMateriaPrimaSecadoInspecciónDeHumedadToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            frmCalidadMPA7 frm = new frmCalidadMPA7();
            frm.MdiParent = this;
            frm.Show();

        }

        private void cargarUbicacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmUbicacionesMasivas frm = new frmUbicacionesMasivas();
            frm.MdiParent = this;
            frm.Show();

        }

        private void trazabilidadDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmOrdenFabricacionTrz frm = new frmOrdenFabricacionTrz();
            frm.MdiParent = this;
            frm.Show();

        }

        private void asistenciaSemanalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAsistencia1 frm = new frmAsistencia1();
            frm.MdiParent = this;
            frm.Show();

        }

        private void recepciónDeSemielaboradosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmRecepcionMPB1 frm = new frmRecepcionMPB1();
            frm.MdiParent = this;
            frm.Show();

        }

        private void consumoDeInsumosYMermasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            VariablesGlobales.glb_DocEntry = 0;

            frmOrdenFabricacionINS1 frm = new frmOrdenFabricacionINS1();
            frm.MdiParent = this;
            frm.Show();

        }

        private void solicitudDeInsumosABodegaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmOrdenFabricacionINS3 frm = new frmOrdenFabricacionINS3();
            frm.MdiParent = this;
            frm.Show();

        }

        private void recepciónDeInsumosDeBodegaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrdenFabricacionINS7 frm = new frmOrdenFabricacionINS7();
            frm.MdiParent = this;
            frm.Show();

        }

        private void asignarDeUbicacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUbicacionPP frm = new frmUbicacionPP();
            frm.MdiParent = this;
            frm.Show();

        }

        private void inventarioDeUbicacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUbicacionesInv1 frm = new frmUbicacionesInv1();
            frm.MdiParent = this;
            frm.Show();

        }

        private void operadorCrackerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOperadorCracker frm = new frmOperadorCracker();
            frm.MdiParent = this;
            frm.Show();

        }

        private void calendarioDeOperadoresDeCrackerToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmCalendarioOperadores frm = new frmCalendarioOperadores();
            frm.MdiParent = this;
            frm.Show();

        }

        private void definiciónDeOrdenDeFabricaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nuevoPesajeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            VariablesGlobales.glb_DocEntry = 0;

            frmRomanaA2 f2 = new frmRomanaA2();
            DialogResult res = f2.ShowDialog();

            VariablesGlobales.glb_DocEntry = 0;

        }

        private void registroDeInspecciónOrdenDeFabricaciónDeSecadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCalidadMPB3 frm = new frmCalidadMPB3();
            frm.MdiParent = this;
            frm.Show();

        }

        private void informeDeMediciónDeHumedadPorProductorGuíaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCalidadMPA2 frm = new frmCalidadMPA2();
            frm.MdiParent = this;
            frm.Show();

        }

        private void chekListGuíaPelónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCalidadMPB6 frm = new frmCalidadMPB6();
            frm.MdiParent = this;
            frm.Show();

        }

        private void trasladoDeInsumosTipoBToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            frmOrdenFabricacionINS5 frm = new frmOrdenFabricacionINS5();
            frm.MdiParent = this;
            frm.Show();

        }

        private void registroDeInspección2021ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCalidadMPB7 frm = new frmCalidadMPB7();
            frm.MdiParent = this;
            frm.Show();

        }

        private void informeDeTrazabilidadPorProductorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fumigadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            frmFumigado3 frm = new frmFumigado3();
            frm.MdiParent = this;
            frm.Show();

        }

        private void definiciónDeProcesosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FRP02 frm = new FRP02();
            frm.MdiParent = this;
            frm.Show();

        }

        private void trazabilidadV2ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmOrdenFabricacionTrz1 frm = new frmOrdenFabricacionTrz1();
            frm.MdiParent = this;
            frm.Show();

        }

        private void definiciónDeBinsEnTerminationReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmBinsProduccion frm = new frmBinsProduccion();
            frm.MdiParent = this;
            frm.Show();

        }

        private void informeDeBinsEnProductoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FRP04 frm = new FRP04();
            frm.MdiParent = this;
            frm.Show();

        }

        private void autorizaciónPorAlmacenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (VariablesGlobales.glb_User_id == 1)
            {
                FRP06 frm = new FRP06();
                frm.MdiParent = this;
                frm.Show();

            }

        }

        private void producciónToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void recepciónDeMateriaPrimaPelónToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            VariablesGlobales.glb_Formulario_Origen = "D&S";

            frmRecepcionMPA6 frm = new frmRecepcionMPA6();
            frm.MdiParent = this;
            frm.Show();

        }

        private void informeDeLotesEnDespelonadoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmRecepcionMPC4 frm = new frmRecepcionMPC4();
            frm.MdiParent = this;
            frm.Show();

        }

        private void consumoDeDespelonadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            VariablesGlobales.glb_Referencia1 = "Despelonado";

            frmOrdenFabricacionCO frm = new frmOrdenFabricacionCO();
            frm.MdiParent = this;
            frm.Show();

        }

        private void consumoDeSecadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            frmOrdenFabricacionCO3 frm = new frmOrdenFabricacionCO3();
            frm.MdiParent = this;
            frm.Show();

        }

        private void definiciónDeOrdenDeFabricaciónToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmRecepcionMPB3 frm = new frmRecepcionMPB3();
            frm.MdiParent = this;
            frm.Show();

        }

        private void terminationReportDeSecadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            VariablesGlobales.glb_Referencia3 = "Envia_Clte";

            frmRomanaA5 frm = new frmRomanaA5();
            frm.MdiParent = this;
            frm.Show();

            //frmRecepcionMPA4 frm = new frmRecepcionMPA4();
            //frm.MdiParent = this;
            //frm.Show();

        }

        private void emisiónDeGuíaDeTrasladoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRecepcionMPB5 frm = new frmRecepcionMPB5();
            frm.MdiParent = this;
            frm.Show();

        }

        private void listaDeGuíasDeTrasladoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmRecepcionMPB8 frm = new frmRecepcionMPB8();
            frm.MdiParent = this;
            frm.Show();

        }

        private void informeDeTrazabilidadPorProductor2020ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCalidadMPB5 frm = new frmCalidadMPB5();
            frm.MdiParent = this;
            frm.Show();

        }

        private void informeDeTrazabilidadPorProductor2021ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCalidadMPB8 frm = new frmCalidadMPB8();
            frm.MdiParent = this;
            frm.Show();

        }

        private void configuraciónGeneralToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FRP07 frm = new FRP07();
            frm.MdiParent = this;
            frm.Show();

        }

        private void configuraciónDeMatricesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmCalidadPPA7 frm = new frmCalidadPPA7();
            frm.MdiParent = this;
            frm.Show();

        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void recepciónDeMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmRecepcionMPC5 frm = new frmRecepcionMPC5();
            frm.MdiParent = this;
            frm.Show();

        }

        private void rediniciónDeTemporadaNCCToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FRP10 frm = new FRP10();
            frm.MdiParent = this;
            frm.Show();

        }

        private void informeNCCToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FRP12 frm = new FRP12();
            frm.MdiParent = this;
            frm.Show();

        }

        private void parametrosDeAlmacenToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FRP13 frm = new FRP13();
            frm.MdiParent = this;
            frm.Show();

        }

        private void informeNivelesStockToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FRP15 frm = new FRP15();
            frm.MdiParent = this;
            frm.Show();

        }

        private void autorizaciónPorProcesoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (VariablesGlobales.glb_User_id == 1)
            {
                FRP16 frm = new FRP16();
                frm.MdiParent = this;
                frm.Show();

            }

        }

        private void informeNCCMonitorToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FRP17 frm = new FRP17();
            frm.MdiParent = this;
            frm.Show();

        }

        private void informeDeCalibresToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FRP18 frm = new FRP18();
            frm.MdiParent = this;
            frm.Show();

        }

        private void humedadToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FRP19 frm = new FRP19();
            frm.MdiParent = this;
            frm.Show();

        }

    }

}

