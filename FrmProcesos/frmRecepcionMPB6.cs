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
    public partial class frmRecepcionMPB6 : Form
    {
        public frmRecepcionMPB6()
        {
            InitializeComponent();
        }

        private void frmRecepcionMPB6_Load(object sender, EventArgs e)
        {
            btn_ok.Enabled = true;
            btn_imprimir.Enabled = false;
            btn_eliminar.Enabled = false;
            
            t_Ref_BaseObject2.Clear();

            if (VariablesGlobales.glb_id_romana != 0)
            {
                t_id_romana.Text = VariablesGlobales.glb_id_romana.ToString();
                t_Line_Id.Text = VariablesGlobales.glb_LineId.ToString();

                carga_datos_x_id();

                t_num_guia.Text = VariablesGlobales.glb_id_romana.ToString();

                tsb_agrega_oc.Enabled = false;
                tsb_eliminar.Enabled = false;

                btn_ok.Enabled = false;
                btn_imprimir.Enabled = true;

                if (t_Ref_BaseObject2.Text == "")
                {
                    btn_eliminar.Enabled = true;

                }

                Grid1.Columns[7].ReadOnly = true;

                if (textBox1.Visible == true)
                {
                    btn_eliminar.Enabled = false;
                    btn_ok.Enabled = false;

                }

            }

        }

        private void tsb_agrega_oc_Click(object sender, EventArgs e)
        {

            int nLote, nLote_old;
            string cValido, cProductor, cTipoEnvase;

            nLote = 0;
            nLote_old = 0;

            VariablesGlobales.glb_Array1_ind = 0;
            Array.Resize(ref VariablesGlobales.glb_Array1, 1000);

            //int[] VariablesGlobales.glb_Array1 = new int[1000];

            try
            {
                cProductor = Grid1[3, 0].Value.ToString();
            }
            catch
            {
                cProductor = "";
            }

            try
            {
                cTipoEnvase = Grid1[6, 0].Value.ToString();
            }
            catch
            {
                cTipoEnvase = "";
            }

            VariablesGlobales.glb_Productor_Ref = cProductor;
            VariablesGlobales.glb_TipoEnvase_Ref = cTipoEnvase;

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {

                try
                {
                    nLote_old = Convert.ToInt32(Grid1[0, i].Value.ToString());

                }
                catch
                {
                    nLote_old = 0;

                }

                try
                {
                    VariablesGlobales.glb_Array1[i] = nLote_old;
                    VariablesGlobales.glb_Array1_ind = i;

                }
                catch
                {

                }

            }

            VariablesGlobales.glb_Lote = 0;

            frmRecepcionMPB7 f2 = new frmRecepcionMPB7();
            DialogResult res = f2.ShowDialog();

            try
            {
                nLote = VariablesGlobales.glb_Lote;

            }
            catch
            {
                nLote = 0;

            }

            if (nLote > 0)
            {

                cValido = "S";

                for (int i = 0; i <= Grid1.RowCount - 1; i++)
                {

                    try
                    {
                        nLote_old = Convert.ToInt32(Grid1[0, i].Value.ToString());

                    }
                    catch
                    {
                        nLote_old = 0;

                    }

                    if (nLote_old == nLote)
                    {
                        cValido = "N";
                        break;

                    }

                }

                if (cValido == "N")
                {
                    Close();

                }

                try
                {

                    clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
                    objproducto.cls_Consultar_Lista_de_guiasinternas_dys("D", Convert.ToString(nLote));

                    DataTable dTable = new DataTable();
                    dTable = objproducto.cResultado;

                    string[] grilla;
                    grilla = new string[30];

                    try
                    {
                        grilla[0] = dTable.Rows[0]["Lote"].ToString();
                    }
                    catch
                    {
                        grilla[0] = "";
                    }

                    try
                    {
                        grilla[1] = dTable.Rows[0]["NumOC"].ToString();
                    }
                    catch
                    {
                        grilla[1] = "";
                    }

                    try
                    {
                        grilla[2] = dTable.Rows[0]["CardCode"].ToString();
                    }
                    catch
                    {
                        grilla[2] = "";
                    }

                    try
                    {
                        grilla[3] = dTable.Rows[0]["CardName"].ToString();
                    }
                    catch
                    {
                        grilla[3] = "";
                    }

                    try
                    {
                        grilla[4] = dTable.Rows[0]["ItemCode"].ToString();
                    }
                    catch
                    {
                        grilla[4] = "";
                    }

                    try
                    {
                        grilla[5] = dTable.Rows[0]["Variedad"].ToString(); 
                    }
                    catch
                    {
                        grilla[5] = "";
                    }

                    try
                    {
                        grilla[6] = dTable.Rows[0]["U_ItemCode_Referencia"].ToString(); 
                    }
                    catch
                    {
                        grilla[6] = "";
                    }

                    try
                    {
                        grilla[7] = dTable.Rows[0]["Saldo_Bins"].ToString(); //cant envases
                    }
                    catch
                    {
                        grilla[7] = "0";
                    }

                    try
                    {
                        grilla[8] = dTable.Rows[0]["Saldo_Bins"].ToString(); //cant envases original
                    }
                    catch
                    {
                        grilla[8] = "0";
                    }

                    grilla[9] = "0";

                    try
                    {
                        grilla[10] = dTable.Rows[0]["PesoInt"].ToString(); //peso unit bins
                    }
                    catch
                    {
                        grilla[10] = "0";
                    }

                    grilla[11] = "0"; //Peso bruto total

                    try
                    {
                        grilla[12] = dTable.Rows[0]["Kilos_x_bins"].ToString(); //peso neto unit
                    }
                    catch
                    {
                        grilla[12] = "0";
                    }

                    try
                    {
                        grilla[14] = dTable.Rows[0]["U_Codigo_CSG"].ToString(); 
                    }
                    catch
                    {
                        grilla[14] = "";
                    }

                    Grid1.Rows.Add(grilla);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

            }

            calcula_bins();

        }

        private void tsb_eliminar_Click(object sender, EventArgs e)
        {
            if (t_cardcode.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar previamente una guía válida, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("Debe ingresar un Productor válido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila;

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

            DialogResult result = MessageBox.Show("Esta seguro de eliminar este registro", "Recepción de Carga", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Grid1.Rows.RemoveAt(fila);

            }

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_ok_Click(object sender, EventArgs e)
        {

            if (t_cardname.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una Proveedor válido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int num_guia;

            try
            {
                num_guia = Convert.ToInt32(t_num_guia.Text);
            }
            catch
            {
                num_guia = 0;
            }

            if (num_guia == 0)
            {
                //MessageBox.Show("Debe ingresar una Guía de Despacho válida, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;
            }

            if (t_patente.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una Patente válida, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (t_conductor.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un Conducto válido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (t_cantidad_envases.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un cantidad de envases válidos, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int cantidad_envase;

            cantidad_envase = 0;

            try
            {
                cantidad_envase = Convert.ToInt32(t_cantidad_envases.Text);
            }
            catch
            {
                cantidad_envase = 0;
            }

            if (cantidad_envase == 0)
            {
                MessageBox.Show("Debe ingresar un cantidad de envases válidos, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ///////////////////////////////////////////////////////////7
            // 
            // Valido los datos de la Romana **********
            // 
            // 

            string cCardCode_D, cItemCode_D, cItemCodeBis_D;
            string cLote, cCodigo_CSG_D;

            int nCantBins_D, nCant_ItemsValidos_D, nSumaBins_D;
            int nNumOC_D;

            cCardCode_D = "";
            cItemCode_D = "";
            cItemCodeBis_D = "";
            nCantBins_D = 0;
            nCant_ItemsValidos_D = 0;
            nSumaBins_D = 0;

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {

                try
                {
                    nNumOC_D = Convert.ToInt32(Grid1[1, i].Value.ToString());

                }
                catch
                {
                    nNumOC_D = 0;

                }

                cCardCode_D = Grid1[2, i].Value.ToString().ToUpper();
                cItemCode_D = Grid1[4, i].Value.ToString().ToUpper();
                cItemCodeBis_D = Grid1[6, i].Value.ToString().ToUpper();

                try
                {
                    nCantBins_D = Convert.ToInt32(Grid1[7, i].Value);

                }
                catch
                {
                    nCantBins_D = 0;

                }

                if (cCardCode_D.Trim() == "")
                {
                    MessageBox.Show("Debe ingresar un Productor válido en el detalle de Productores, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                if (cItemCode_D.Trim() == "")
                {
                    MessageBox.Show("Debe ingresar un Producto válido en el detalle de Productores, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                if (cItemCodeBis_D.Trim() == "")
                {
                    MessageBox.Show("Debe seleccionar un tipo de envase válido en el detalle de Productores, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                if (nCantBins_D == 0)
                {
                    MessageBox.Show("Debe ingresar una Cantidad de Bins válidos en el detalle de Productores, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                nSumaBins_D = nSumaBins_D + nCantBins_D;
                nCant_ItemsValidos_D = +1;

            }

            if (nCant_ItemsValidos_D == 0)
            {
                MessageBox.Show("Debe ingresar datos válidos en el detalle de Productores, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (cantidad_envase != nSumaBins_D)
            {
                MessageBox.Show("La Cantidad total de Bins NO corresponde con lo definido en el detalle de Productores, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            string CardCode, CardName; //, ItemName;
            string CardCode_trans, CardName_trans;
            string patente, conductor, cod_envase;
            int id_romana, id_acceso;
            int UserId;
            float peso_bruto, peso_tara, peso_neto;
            float peso_guia;
            string fecha_ini, fecha_fin;

            CardCode = t_cardcode.Text.Trim();
            CardName = t_cardname.Text.Trim();
            //num_pedido_compra 
            //itemcode
            //ItemName = cbb_Producto.Text.Trim();
            //num_guia;
            patente = t_patente.Text.Trim();
            conductor = t_conductor.Text.Trim();

            cod_envase = "";

            //cantidad_envase
            CardCode_trans = "";
            CardName_trans = "";

            UserId = VariablesGlobales.glb_User_id;

            id_romana = 0;
            peso_bruto = 0;

            try
            {
                peso_bruto = float.Parse(t_peso_bruto.Text);
            }
            catch
            {
                peso_bruto = 0;
            }

            peso_neto = 0;

            try
            {
                peso_neto = float.Parse(t_peso_neto.Text);
            }
            catch
            {
                peso_neto = 0;
            }

            peso_tara = 0;

            try
            {
                peso_tara = (float)Math.Round(float.Parse(t_peso_tara.Text));
            }
            catch
            {
                peso_tara = 0;
            }

            peso_guia = 0;

            try
            {
                peso_guia = float.Parse(t_peso_guia.Text);
            }
            catch
            {
                peso_guia = 0;
            }

            if (peso_guia == 0)
            {
                MessageBox.Show("Debe ingresar un peso de guía válido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (peso_bruto == 0)
            {
                MessageBox.Show("Debe ingresar un peso total válido para la guía, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                id_acceso = Convert.ToInt32(t_peso_neto.Text);
            }
            catch
            {
                id_acceso = 0;
            }

            // 1. Preguntar quien grabo este registro
            // siempre y cuando no sea el primer registros y que no venga de la romana (x_x)

            if ((id_romana > 0) && (t_peso_tara.Text == ""))
            {

                string cUsuarioAutorizado;
                double nPesoNetoBD, nPesoNetoFormulario;

                cUsuarioAutorizado = "N";
                nPesoNetoBD = 0;
                nPesoNetoFormulario = 0;

                clsRomana objproducto = new clsRomana();
                objproducto.cls_Consulta_Partidas_abiertas_x_id(id_romana, -1);

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                int nUserId, nUsuarioDocumento;

                try
                {
                    nUsuarioDocumento = Convert.ToInt32(dTable.Rows[0]["UserSign"].ToString());

                }
                catch
                {
                    nUsuarioDocumento = 0;

                }

                try
                {
                    nPesoNetoBD = Convert.ToDouble(dTable.Rows[0]["U_PesoNeto"].ToString());

                }
                catch
                {
                    nPesoNetoBD = 0;

                }

                try
                {
                    nPesoNetoFormulario = Convert.ToDouble(t_peso_neto.Text);

                }
                catch
                {
                    nPesoNetoFormulario = 0;

                }

                if (nPesoNetoBD == nPesoNetoFormulario)
                {

                    int nIdUsuarioPrograma;
                    string cNomUsuariosHabilitados;
                    string cNomUsuario, cNombreEmpleado, cApellidoEmpleado;

                    nIdUsuarioPrograma = 0;

                    try
                    {
                        nIdUsuarioPrograma = VariablesGlobales.glb_User_id;

                    }
                    catch
                    {
                        nIdUsuarioPrograma = 0;

                    }

                    cNomUsuario = "";
                    cNomUsuariosHabilitados = "";

                    // 2. Preguntar los jefes del que grabo

                    clsPorteria objproducto1 = new clsPorteria();
                    objproducto1.cls_Consultar_Dependencias_x_UserId(nUsuarioDocumento);

                    DataTable dTable1 = new DataTable();
                    dTable = objproducto1.cResultado;

                    for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                    {

                        try
                        {
                            nUserId = Convert.ToInt32(dTable.Rows[i]["UserId"].ToString());

                        }
                        catch
                        {
                            nUserId = 0;

                        }

                        if (nUsuarioDocumento != nUserId)
                        {
                            try
                            {
                                cNombreEmpleado = dTable.Rows[i]["Nombre"].ToString();

                            }
                            catch
                            {
                                cNombreEmpleado = "";

                            }

                            try
                            {
                                cApellidoEmpleado = dTable.Rows[i]["Apellido"].ToString();

                            }
                            catch
                            {
                                cApellidoEmpleado = "";

                            }

                            cNomUsuario = cNombreEmpleado.Trim() + " " + cApellidoEmpleado.Trim();

                            cNomUsuariosHabilitados = cNomUsuariosHabilitados + cNomUsuario + ", ";

                            if (nUserId == nIdUsuarioPrograma)
                            {
                                cUsuarioAutorizado = "S";

                            }

                        }


                    }

                    if (cNomUsuariosHabilitados.Trim() != "")
                    {
                        cNomUsuariosHabilitados = cNomUsuariosHabilitados.Substring(0, cNomUsuariosHabilitados.Length - 2);

                    }

                    // 3. Si el usuario de sistema es jefe

                    if (cUsuarioAutorizado == "N")
                    {
                        MessageBox.Show("Estimado " + VariablesGlobales.glb_User_Name + " este registro solo puede ser modificado por " + cNomUsuariosHabilitados + ", Opción cancelada", "Control de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }

                }

            }

            //t_fecha_1er_peso
            //t_fecha_2do_peso

            fecha_ini = "19000101";
            fecha_fin = "19000101";

            string UserCode;
            int nLineId;

            nLineId = 0;

            try
            {
                nLineId = int.Parse(t_Line_Id.Text);

            }
            catch
            {
                nLineId = 0;

            }

            UserCode = VariablesGlobales.glb_User_Code;
            id_acceso = 0;

            String mensaje = clsRomana.SAPB1_ROMANA(id_romana, CardCode, CardName, num_guia, patente, conductor, cod_envase, cantidad_envase, peso_bruto, fecha_ini, peso_tara, fecha_fin, peso_neto, t_observacion.Text.Trim(), id_acceso, CardCode_trans, CardName_trans, UserId, peso_guia, nLineId, "I");

            if (id_romana == 0)
            {
                id_romana = 0;

                clsRomana objproducto = new clsRomana();
                objproducto.cls_Consulta_Nuevo_DocEntry();

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                try
                {
                    id_romana = Convert.ToInt32(dTable.Rows[0].ItemArray[0].ToString());

                }
                catch
                {
                    id_romana = 0;

                }

                t_num_guia.Text = id_romana.ToString();
                t_id_romana.Text = id_romana.ToString();

            }

            String mensaje1 = clsRomana.SAPB1_ROMANA2(id_romana, -1, "", "", "", "", "", 0, 0, 0,"","",0,"");

            string cCardName_D, cItemName_D, cItemCode_OC_D;
            string cItemName_OC_D;
            int nPesoBis_D;

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {

                try
                {
                    nNumOC_D = Convert.ToInt32(Grid1[1, i].Value.ToString().ToUpper());

                }
                catch
                {
                    nNumOC_D = 0;

                }

                try
                {
                    cLote = Grid1[0, i].Value.ToString().ToUpper(); 

                }
                catch
                {
                    cLote = "0";

                }

                cItemCode_OC_D = "";
                cItemName_OC_D = "";

                clsRomana objproducto_oc = new clsRomana();
                objproducto_oc.cls_Consulta_ItemCode_OC(nNumOC_D.ToString());

                DataTable dTable = new DataTable();
                dTable = objproducto_oc.cResultado;

                try
                {
                    cItemCode_OC_D = dTable.Rows[0].ItemArray[0].ToString();

                }
                catch
                {
                    cItemCode_OC_D = "";

                }

                try
                {
                    cItemName_OC_D = dTable.Rows[0].ItemArray[1].ToString();

                }
                catch
                {
                    cItemName_OC_D = "";

                }

                cCardCode_D = Grid1[2, i].Value.ToString().ToUpper();
                cCardName_D = Grid1[3, i].Value.ToString().ToUpper();
                cItemCode_D = cItemCode_OC_D; // "FP.NUE.MP.XXXX.XXX.X.XXX-XXX.XXX.G.0001K.01"; // Grid1[4, i].Value.ToString().ToUpper();
                cItemName_D = cItemName_OC_D; //"NUEZ PROPIA MP GRANEL - " + Grid1[5, i].Value.ToString().ToUpper(); // Grid1[4, i].Value.ToString().ToUpper();
                cItemCodeBis_D = Grid1[6, i].Value.ToString().ToUpper();
                cCodigo_CSG_D = Grid1[14, i].Value.ToString().ToUpper();

                try
                {
                    nCantBins_D = Convert.ToInt32(Grid1[7, i].Value);

                }
                catch
                {
                    nCantBins_D = 0;

                }

                try
                {
                    nPesoBis_D = Convert.ToInt32(Grid1[9, i].Value);

                }
                catch
                {
                    nPesoBis_D = 0;

                }

                if (cCardCode_D.Trim() != "")
                {

                    if (cItemCode_D.Trim() != "")
                    {

                        if (cItemCodeBis_D.Trim() != "")
                        {
                            mensaje1 = clsRomana.SAPB1_ROMANA2(id_romana, i, cCardCode_D, cCardName_D, cItemCode_D, cItemName_D, cItemCodeBis_D, nCantBins_D, nNumOC_D, 0, cLote, cCodigo_CSG_D,0,"");

                        }

                    }

                }

            }

            if (mensaje == "Y")
            {
                MessageBox.Show("Registro Grabado", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(mensaje, "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btn_ok.Enabled = false;
            btn_imprimir.Enabled = true;

            //carga_datos_x_id();

            try
            {
                id_romana = Convert.ToInt32(t_id_romana.Text);
            }
            catch
            {
                id_romana = 0;
            }

        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {

            int id_romana;

            id_romana = 0;

            try
            {
                id_romana = Convert.ToInt32(t_id_romana.Text);
            }
            catch
            {
                id_romana = 0;
            }

            if (id_romana > 0)
            {
                VariablesGlobales.glb_id_romana = id_romana;

                frmRomanaA9 f2 = new frmRomanaA9();
                DialogResult res = f2.ShowDialog();

            }

        }

        private void Grid1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            int fil, cant_bins, maximo_bins;
            //int peso_unit_bins, pesto_tot_bins;

            fil = 0;

            try
            {
                fil = Grid1.CurrentCell.RowIndex;
            }
            catch
            {
                fil = -1;
            }

            if (fil < 0)
            {
                return;
            }

            try
            {
                cant_bins = Convert.ToInt32(Grid1[7, fil].Value);

            }
            catch
            {
                cant_bins = 0;

            }

            Grid1[7, fil].Value = cant_bins.ToString();

            try
            {
                maximo_bins = Convert.ToInt32(Grid1[8, fil].Value);

            }
            catch
            {
                maximo_bins = 0;

            }

            if (cant_bins > maximo_bins)
            {
                MessageBox.Show("No puede ingresar mas bins disponibles que los pendientes, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Grid1[7, fil].Value = maximo_bins.ToString();

                return;

            }

            calcula_bins();

        }

        private void calcula_bins()
        {

            int cant_bins, peso_unit_bins, pesto_tot_bins;
            int nTot_bins;

            double nPesoNeto_unit, nPesoBruto_tot, nTot_bruto;
            double nTot_tara, nTot_neto;

            nTot_bins = 0;
            nTot_tara = 0;
            nTot_bruto = 0;

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {
                try
                {
                    cant_bins = Convert.ToInt32(Grid1[7, i].Value);

                }
                catch
                {
                    cant_bins = 0;
                }

                try
                {
                    peso_unit_bins = Convert.ToInt32(Grid1[10, i].Value);

                }
                catch
                {
                    peso_unit_bins = 0;
                }

                try
                {
                    nPesoNeto_unit = Convert.ToDouble(Grid1[12, i].Value);

                }
                catch
                {
                    nPesoNeto_unit = 0;
                }
                
                nTot_bins += cant_bins;
                pesto_tot_bins = peso_unit_bins + cant_bins;
                nTot_tara += pesto_tot_bins;
                nPesoBruto_tot = (nPesoNeto_unit + peso_unit_bins) * cant_bins;
                //nPesoBruto_tot = (nPesoNeto_unit) * cant_bins;
                nTot_bruto += nPesoBruto_tot;

                Grid1[9, i].Value = pesto_tot_bins.ToString();
                Grid1[11, i].Value = nPesoBruto_tot.ToString();

            }

            nTot_neto = nTot_bruto - nTot_tara;

            if (nTot_neto<0)
            {
                nTot_neto = 0;
            }

            t_cantidad_envases.Text = nTot_bins.ToString();
            t_peso_tara.Text = nTot_tara.ToString();
            t_peso_bruto.Text = nTot_bruto.ToString();
            t_peso_neto.Text = nTot_neto.ToString();

            t_peso_guia.Text = nTot_bruto.ToString("N");

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

        private void carga_datos_x_id()
        {

            int id_romana, nLineId;

            try
            {
                id_romana = Convert.ToInt32(t_id_romana.Text);
            }
            catch
            {
                id_romana = 0;

            }

            if (id_romana == 0)
            {
                return;
            }

            try
            {
                nLineId = int.Parse(t_Line_Id.Text);

            }
            catch
            {
                nLineId = 0;

            }

            string CardCode, CardName;
            string ItemCode, ItemName;
            int numguia, cant_envases;
            string patente, conductor, ItemCodeBins;
            float peso_bruto, peso_tara, peso_neto;
            float peso_guia, peso_bins;
            string obs;
            DateTime fecha_hora1, fecha_hora2;
            int id_acceso;
            string CardCode_trans, CardName_trans, c_eliminado;

            CardCode = "";
            CardName = "";
            ItemCode = "";
            ItemName = "";
            CardCode_trans = "";
            CardName_trans = "";
            ItemCodeBins = "_";
            numguia = 0;
            patente = "";
            conductor = "";
            peso_bruto = 0;
            peso_tara = 0;
            peso_neto = 0;
            peso_guia = 0;
            cant_envases = 0;
            obs = "";
            fecha_hora1 = DateTime.Parse("01/01/1900");
            fecha_hora2 = DateTime.Parse("01/01/1900");
            id_acceso = 0;
            peso_bins = 0;
            c_eliminado = "";

            t_cardcode.Clear();
            t_cardname.Clear();
            t_num_guia.Clear();
            t_patente.Clear();
            t_patentecarro.Clear();
            t_conductor.Clear();
            t_peso_bruto.Clear();
            t_peso_neto.Clear();
            t_cantidad_envases.Clear();
            t_observacion.Clear();
            t_fecha_1er_peso.Clear();
            t_peso_neto.Clear();
            t_peso_guia.Clear();
            t_fecha_2do_peso.Clear();
            t_CardoName_Trans.Clear();
            t_CardoCode_Trans.Clear();
            t_Ref_BaseObject2.Clear();

            clsRomana objproducto = new clsRomana();
            objproducto.cls_Consulta_Partidas_abiertas_x_id(id_romana, nLineId);

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            try
            {
                CardCode = dTable.Rows[0].ItemArray[1].ToString();

            }
            catch
            {
                CardCode = "";

            }

            try
            {
                CardName = dTable.Rows[0].ItemArray[2].ToString();

            }
            catch
            {
                CardName = "";

            }

            try
            {
                ItemCode = dTable.Rows[0].ItemArray[3].ToString();

            }
            catch
            {
                ItemCode = "";

            }

            try
            {
                ItemName = dTable.Rows[0].ItemArray[4].ToString();

            }
            catch
            {
                ItemName = "";

            }

            try
            {
                patente = dTable.Rows[0].ItemArray[6].ToString();

            }
            catch
            {
                patente = "";

            }

            try
            {
                conductor = dTable.Rows[0].ItemArray[20].ToString();

            }
            catch
            {
                conductor = "";

            }

            try
            {
                obs = dTable.Rows[0].ItemArray[16].ToString();

            }
            catch
            {
                obs = "";

            }

            try
            {
                numguia = Convert.ToInt32(dTable.Rows[0].ItemArray[5].ToString());

            }
            catch
            {
                numguia = 0;

            }

            try
            {
                peso_bruto = float.Parse(dTable.Rows[0]["U_PesoBruto_Full"].ToString());

            }
            catch
            {
                peso_bruto = 0;

            }

            try
            {
                peso_tara = float.Parse(dTable.Rows[0].ItemArray[14].ToString());

            }
            catch
            {
                peso_tara = 0;

            }

            try
            {
                peso_neto = float.Parse(dTable.Rows[0].ItemArray[15].ToString());

            }
            catch
            {
                peso_neto = 0;

            }

            try
            {
                cant_envases = int.Parse(dTable.Rows[0].ItemArray[7].ToString());

            }
            catch
            {
                cant_envases = 0;

            }

            try
            {
                fecha_hora1 = DateTime.Parse(dTable.Rows[0].ItemArray[17].ToString());
            }
            catch
            {
                fecha_hora1 = DateTime.Parse("01/01/1900");
            }

            try
            {
                fecha_hora2 = DateTime.Parse(dTable.Rows[0]["U_FechaPeso2"].ToString());
            }
            catch
            {
                fecha_hora2 = DateTime.Parse("01/01/1900");
            }

            try
            {
                c_eliminado = dTable.Rows[0]["U_Det_Vigente"].ToString();

            }
            catch
            {
                c_eliminado = "";

            }

            try
            {
                t_Ref_BaseObject2.Text = dTable.Rows[0]["Ref_BaseObject2"].ToString();
            }
            catch
            {
                t_Ref_BaseObject2.Clear();
            }

            try
            {
                id_acceso = Convert.ToInt32(dTable.Rows[0].ItemArray[19].ToString());
            }
            catch
            {
                id_acceso = 0;
            }

            try
            {
                CardCode_trans = dTable.Rows[0].ItemArray[21].ToString();
            }
            catch
            {
                CardCode_trans = "";
            }

            try
            {
                CardName_trans = dTable.Rows[0].ItemArray[22].ToString();
            }
            catch
            {
                CardName_trans = "";
            }

            try
            {
                peso_guia = float.Parse(dTable.Rows[0].ItemArray[27].ToString());
            }
            catch
            {
                peso_guia = 0;
            }

            try
            {
                peso_bins = float.Parse(dTable.Rows[0].ItemArray[31].ToString());
            }
            catch
            {
                peso_bins = 0;
            }

            try
            {
                t_patentecarro.Text = dTable.Rows[0]["U_PatenteCarro"].ToString();
            }
            catch
            {
                t_patentecarro.Clear();
            }

            ////////////////////////////////////////////////////7
            //// Cargo el detalle de productores
            ////

            string cCardCode_D, cCardName_D, cItemCode_D;
            string cItemName_D;
            int nCantBins_D, n_PesoUnitBins_D, nNumOC_D;
            int nCantAnalisisCalidad_D, nCantAnalisisCalidad_Total;

            Grid1.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            nCantAnalisisCalidad_Total = 0;

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {
                nNumOC_D = 0;
                cCardCode_D = "";
                cCardName_D = "";
                cItemCode_D = "";
                cItemName_D = "";
                nCantBins_D = 0;
                n_PesoUnitBins_D = 0;
                nCantAnalisisCalidad_D = 0;

                try
                {
                    nNumOC_D = Convert.ToInt32(dTable.Rows[i]["U_NumOC"].ToString());

                }
                catch
                {
                    nNumOC_D = 0;

                }

                try
                {
                    cCardCode_D = dTable.Rows[i].ItemArray[28].ToString().ToUpper();

                }
                catch
                {

                }

                try
                {
                    cCardName_D = dTable.Rows[i].ItemArray[29].ToString().ToUpper();

                }
                catch
                {

                }

                try
                {
                    cItemCode_D = dTable.Rows[i].ItemArray[3].ToString().ToUpper();

                }
                catch
                {

                }

                try
                {
                    cItemName_D = dTable.Rows[i]["U_ItemName_D2"].ToString().ToUpper();

                }
                catch
                {

                }

                try
                {
                    ItemCodeBins = dTable.Rows[i].ItemArray[12].ToString();

                }
                catch
                {
                    ItemCodeBins = "_";

                }

                try
                {
                    nCantBins_D = Convert.ToInt32(dTable.Rows[i].ItemArray[30].ToString().ToUpper());

                }
                catch
                {
                    nCantBins_D = 0;

                }

                try
                {
                    n_PesoUnitBins_D = Convert.ToInt32(dTable.Rows[i].ItemArray[32].ToString().ToUpper());
                }
                catch
                {
                    n_PesoUnitBins_D = 0;
                }

                try
                {
                    nCantAnalisisCalidad_D = Convert.ToInt32(dTable.Rows[i]["Cant_Analisis_Calidad"].ToString().ToUpper());

                }
                catch
                {
                    nCantAnalisisCalidad_D = 0;

                }

                nCantAnalisisCalidad_Total = nCantAnalisisCalidad_Total + nCantAnalisisCalidad_D;

                grilla[0] = "";

                try
                {
                    grilla[0] = dTable.Rows[i]["Lote_guia_interna"].ToString();

                }
                catch
                {

                }

                grilla[1] = nNumOC_D.ToString();
                grilla[2] = cCardCode_D.ToUpper();
                grilla[3] = cCardName_D.ToUpper();
                grilla[4] = cItemCode_D.ToUpper();
                grilla[5] = "";

                try
                {
                    grilla[5] = dTable.Rows[i]["Variedad_guia_interna"].ToString();

                }
                catch
                {

                }

                grilla[6] = ItemCodeBins;
                grilla[7] = Convert.ToString(nCantBins_D);
                grilla[8] = Convert.ToString(nCantBins_D);
                grilla[9] = Convert.ToString(n_PesoUnitBins_D);
                //grilla[8] = Convert.ToString(nCantAnalisisCalidad_D);

                try
                {
                    grilla[14] = dTable.Rows[i]["U_Codigo_CSG"].ToString();

                }
                catch
                {
                    grilla[14] = "";

                }

                Grid1.Rows.Add(grilla);

            }

            //sql += "Patente 6, Envases 7, FechaPeso1 8, PesoBruto 9 ";
            //sql += "from db_ROMANA ";
            //sql += "where id_romana = " + id_romana + " ";

            t_cardcode.Text = CardCode;
            t_cardname.Text = CardName;
            t_CardoName_Trans.Text = CardName_trans;
            t_CardoCode_Trans.Text = CardCode_trans;

            t_patente.Text = patente;
            t_conductor.Text = conductor;

            t_peso_bruto.Text = peso_bruto.ToString("N2");
            t_peso_neto.Clear();

            if (peso_neto != 0)
            {
                t_peso_neto.Text = peso_neto.ToString("N2");

            }

            if (peso_guia != 0)
            {
                t_peso_guia.Text = peso_guia.ToString("N2");

            }

            if (fecha_hora1.Year != 1900)
            {
                t_fecha_1er_peso.Text = fecha_hora1.ToString("dd/MM/yyyy mm:hh"); //DateTime.Now.ToString(fecha_hora1. , "dd/MM/yyyy mm:hh");

            }

            if (fecha_hora2.Year != 1900)
            {
                t_fecha_2do_peso.Text = fecha_hora2.ToString("dd/MM/yyyy mm:hh"); //DateTime.Now.ToString(fecha_hora1. , "dd/MM/yyyy mm:hh");

            }

            t_ref.Text = "S";

            //cbb_envase.SelectedIndex = id_envase;
            t_cantidad_envases.Text = cant_envases.ToString();
            t_observacion.Text = obs;

            btn_buscar1.Visible = false;
            btn_buscar2.Visible = false;

            if (peso_tara != 0)
            {
                btn_imprimir.Enabled = true;

            }

            /////////////////////////////////////////////////////////////////
            //// Si el total de analisis es mayor que 0 no se puede modificar

            if (nCantAnalisisCalidad_Total > 0)
            {
                if (peso_neto > 0)
                {
                    btn_ok.Enabled = false;

                    tsb_agrega_oc.Enabled = false;
                    tsb_eliminar.Enabled = false;

                    Grid1.Columns[5].ReadOnly = true;
                    Grid1.Columns[6].ReadOnly = true;

                }

            }
            
            if (c_eliminado == "N")
            {
                label1.Visible = true;
                textBox1.Visible = true;
                btn_eliminar.Enabled = false;
                btn_ok.Enabled = false;

            }
            else
            {
                label1.Visible = false;
                textBox1.Visible = false;
                btn_eliminar.Enabled = true;
                btn_ok.Enabled = true;

            }

        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {

            if (t_cardcode.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar previamente una guía válida, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("Debe ingresar un Productor válido, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila;

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

            int id_porteria, id_entrada_mercancia, n_anho_1er_pesaje;

            try
            {
                id_porteria = Convert.ToInt32(t_num_guia.Text);
            }
            catch
            {
                id_porteria = 0;

            }

            clsPorteria objproducto = new clsPorteria();
            objproducto.cls_Consultar_EntradaMercancia_x_Folio(id_porteria);

            DataTable dTable = new DataTable();

            dTable = objproducto.cResultado;

            id_entrada_mercancia = 0;

            try
            {
                id_entrada_mercancia = Convert.ToInt32(dTable.Rows[0]["DocEntry"].ToString());

            }
            catch
            {
                id_entrada_mercancia = 0;
            }

            if (id_entrada_mercancia > 0)
            {
                MessageBox.Show("La Guía YA fue recepcionada, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            n_anho_1er_pesaje = 0;

            clsPorteria objproducto3 = new clsPorteria();
            objproducto3.cls_Consultar_1er_pesaje_x_Folio(id_porteria);

            DataTable dTable3 = new DataTable();

            dTable3 = objproducto3.cResultado;

            id_entrada_mercancia = 0;

            try
            {
                n_anho_1er_pesaje = Convert.ToInt32(dTable3.Rows[0]["year_pesaje"].ToString());

            }
            catch
            {
                n_anho_1er_pesaje = 0;
            }

            if (n_anho_1er_pesaje > 1900)
            {
                MessageBox.Show("La Guía YA tiene un pesaje en romana, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }


            string cSupervisor = "NO";

            VariablesGlobales.glb_User_Code_Autorizacion = "";

            frmLoginSupervisor f5 = new frmLoginSupervisor();
            DialogResult res5 = f5.ShowDialog();

            if (VariablesGlobales.glb_User_Code_Autorizacion == "")
            {
                MessageBox.Show("Clave de Supervisor No valida, opción Cancelada", "Recepción de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (VariablesGlobales.glb_User_Code_Autorizacion != "")
            {

                clsMaestros objproducto1 = new clsMaestros();
                objproducto1.cls_lee_usuario(VariablesGlobales.glb_User_Code_Autorizacion);

                DataTable dTable1 = new DataTable();
                dTable1 = objproducto1.cResultado;

                try
                {
                    cSupervisor = dTable1.Rows[0]["Supervisor"].ToString();

                }
                catch
                {
                    cSupervisor = "NO";

                }

            }

            if (cSupervisor == "NO")
            {
                return;
            }

            int nDocEntry;

            try
            {
                nDocEntry = Convert.ToInt32(t_num_guia.Text);
            }
            catch
            {
                nDocEntry = 0;
            }

            if (nDocEntry == 0)
            {
                MessageBox.Show("La guía de traslado NO ha sido grabado", "Traslado de productos ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result;

            result = MessageBox.Show("Esta Seguro de Eliminar el Traslado interno", "Traslado de productos ", buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {

                string mensaje;

                mensaje = clsCalidad.SAPB1_ROMANAv1("B", nDocEntry);

                if (mensaje == "Y")
                {
                    MessageBox.Show("Registro Eliminado", "Traslado de productos ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(mensaje, "Traslado de productos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Close();

            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

}
