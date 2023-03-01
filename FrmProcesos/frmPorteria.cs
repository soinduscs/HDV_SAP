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
using WIA;
using System.Configuration;

namespace FrmProcesos
{
    public partial class frmPorteria : Form
    {
        public frmPorteria()
        {
            InitializeComponent();
        }

        private void frmPorteria_Load(object sender, EventArgs e)
        {
            t_fecha_registro.Visible = false;
            lbl_fecha_ingreso.Visible = false;
            t_cargo.Clear();
            
            this.Size = new Size(520, 400);

            Boolean exists;

            //exists = System.IO.Directory.Exists("c:\ExistingFolderName")

            exists = System.IO.Directory.Exists(@"c:\temp");

            if (exists==false)
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

                string archivoDestino_Path;

                archivoDestino_Path = @"c:\temp\sheet_white.png";

                if (!File.Exists(archivoDestino_Path))
                {
                    System.IO.File.Copy(Application.StartupPath + "\\Resources\\sheet_white.png", @"c:\\Temp\\sheet_white.png", true);

                }

            }

            clsSocioNegocio objproducto = new clsSocioNegocio();
            objproducto.cls_Consultar_Transportistas();

            this.cbb_Transportista.DataSource = objproducto.cResultado;
            this.cbb_Transportista.ValueMember = "CardCode";
            this.cbb_Transportista.DisplayMember = "CardName";

            clsPorteria objproducto1 = new clsPorteria();
            objproducto1.cls_Consultar_Razon_de_Ingreso();

            this.cbb_razoningreso.DataSource = objproducto1.cResultado;
            this.cbb_razoningreso.ValueMember = "FldValue";
            this.cbb_razoningreso.DisplayMember = "Descr";

            if (VariablesGlobales.glb_id_acceso != 0)
            {
                t_id_acceso.Text = VariablesGlobales.glb_id_acceso.ToString();
                t_1er_grabado.Text = VariablesGlobales.glb_id_acceso.ToString();

                carga_datos_x_id();
            }
            else
            {
                cbb_Transportista.SelectedValue = ".z.";
                cbb_razoningreso.Text = "(Seleccione Razón de Ingreso)";
            }

            t_cargo.Text = "////";

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

        private void btn_escanear_Click(object sender, EventArgs e)
        {

            if (btn_escanear.Text == "Escanear Documento")
            {

                Boolean grabado;

                grabado = graba_acceso();

                if (grabado == false)
                {
                    return;
                }

                Random rnd = new Random();

                int var_archivo;
                string nom_archivo;

                var_archivo = rnd.Next(10000, 99999);

                nom_archivo = "Img" + Convert.ToString(var_archivo) + ".png";

                try
                {

                    WIA.CommonDialog dialog = new WIA.CommonDialog();

                    //var dialog = new WIA.CommonDialogClass(); 
                    var scannedImage = dialog.ShowAcquireImage(WIA.WiaDeviceType.ScannerDeviceType) as WIA.ImageFile;
                    if (scannedImage != null)
                    {
                        if (System.IO.File.Exists("C:/Temp/" + nom_archivo))
                            System.IO.File.Delete("C:/Temp/" + nom_archivo);
                        scannedImage.SaveFile("C:/Temp/" + nom_archivo);

                    }

                    t_imagen.Text = "C:/Temp/" + nom_archivo;

                }
                catch
                {
                    MessageBox.Show("Error en la digitalización del documento", "Control de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    t_imagen.Text = "C:/Temp/sheet_white.png";

                }

            }
            else
            {

                int id_acceso;

                try
                {
                    id_acceso = Convert.ToInt32(t_id_acceso.Text);

                }
                catch
                {
                    id_acceso = 0;

                }

                if (id_acceso > 0)
                {

                    VariablesGlobales.glb_id_acceso = id_acceso;

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

                    VariablesGlobales.glb_Referencia2 = "S";

                    if (id_romana > 0)
                    {
                        VariablesGlobales.glb_Referencia2 = "N";

                    }

                    frmPorteria2 f2 = new frmPorteria2();
                    DialogResult res = f2.ShowDialog();

                }

            }

            btn_escanear.Text = "Ver Documento";

        }


        private void btn_ok_Click(object sender, EventArgs e)
        {

            // 1. Preguntar quien grabo este registro

            int nDocEntry;

            try
            {
                nDocEntry = Convert.ToInt32(t_id_acceso.Text);
            }
            catch 
            {
                nDocEntry = 0;
            }

            if (nDocEntry>0 && t_1er_grabado.Text.Trim() != "")
            {

                string cUsuarioAutorizado;

                cUsuarioAutorizado = "N";

                clsPorteria objproducto = new clsPorteria();
                objproducto.cls_Consultar_Accesos_x_Id(nDocEntry);

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

                    if (nUsuarioDocumento!= nUserId)
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

                if (cNomUsuariosHabilitados.Trim() != "" )
                {
                    cNomUsuariosHabilitados = cNomUsuariosHabilitados.Substring(0, cNomUsuariosHabilitados.Length - 2);

                }

                // 3. Si el usuario de sistema es jefe

                if (cUsuarioAutorizado == "N")
                {
                    MessageBox.Show("Estimado " + VariablesGlobales.glb_User_Name + " este registro solo puede ser modificado por "  + cNomUsuariosHabilitados + ", Opción cancelada", "Control de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

            }

            /////////////////////////////
            /////// prueba

            Boolean grabado;

            grabado = graba_acceso();
            //grabado = true;

            if (grabado == true)
            {
                MessageBox.Show("Registro Grabado", "Control de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btn_nuevo_Click(sender, e);

            }
            else
            {
                MessageBox.Show("Error en el registro de grabación", "Control de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private Boolean graba_acceso()  
        {
            if (t_cardname.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una Productor válido, opción Cancelada", "Control de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }

            if (t_patente.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una Patente válida, opción Cancelada", "Control de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }

            if (t_conductor.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un Conductor válido, opción Cancelada", "Control de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }

            if (cbb_razoningreso.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar una razón para el ingreso del camion, opción Cancelada", "Control de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

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

            string CardCode, CardName, UserCode;
            string CardCode_Transportista, CardName_Transportista;
            string patente, conductor, id_razoningreso;
            int id_acceso, UserId;

            CardCode = t_cardcode.Text.Trim();
            CardName = t_cardname.Text.Trim();
            UserCode = VariablesGlobales.glb_User_Code;
            UserId = VariablesGlobales.glb_User_id;

            id_razoningreso = "";

            try
            {
                id_razoningreso = cbb_razoningreso.SelectedValue.ToString();
            }
            catch
            {
                id_razoningreso = "";
            }

            CardCode_Transportista = "";
            CardName_Transportista = "";

            if (id_razoningreso != "5")
            {
                if (t_num_guia.Text.Trim() == "")
                {
                    MessageBox.Show("Debe ingresar una Guía de Despacho válida, opción Cancelada", "Control de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (id_razoningreso == "1")
                {
                    if (num_guia == 0)
                    {
                        MessageBox.Show("Debe ingresar una Guía de Despacho válida, opción Cancelada", "Control de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;

                    }

                }

                if (cbb_Transportista.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar un transportita válido, opción Cancelada", "Control de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;

                }

                if (cbb_Transportista.Text.Trim() == "(Seleccione un Transportista)")
                {
                    MessageBox.Show("Debe seleccionar un transportita válido, opción Cancelada", "Control de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;

                }

                if (cbb_Transportista.Text.Trim() == "EXTERNO  ***  NUEVO TRANSPORTISTA")
                {
                    MessageBox.Show("Debe seleccionar un transportita válido, opción Cancelada", "Control de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;

                }

                try
                {
                    CardCode_Transportista = cbb_Transportista.SelectedValue.ToString();
                    CardName_Transportista = cbb_Transportista.Text;

                }
                catch
                {
                    CardCode_Transportista = "";
                    CardName_Transportista = "";

                }

            }
            else
            {
                CardCode_Transportista = "";
                CardName_Transportista = "";
            }

            patente = t_patente.Text.Trim();
            conductor = t_conductor.Text.Trim();

            try
            {
                id_acceso = Convert.ToInt32(t_id_acceso.Text);
            }
            catch
            {
                id_acceso = 0;
            }

            string ruta_imagen = t_imagen.Text;

            if (ruta_imagen == "")
            {
                ruta_imagen = "C:/Temp/sheet_white.png";

            }           

            String mensaje = clsPorteria.SAPB1_ACCESO(id_acceso, CardCode, CardName, num_guia, patente, UserId, conductor, CardCode_Transportista, CardName_Transportista, ruta_imagen, id_razoningreso, t_patente_carro.Text , t_sellos.Text);

            //MessageBox.Show("Registro Grabado", "Control de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (mensaje == "N")
            {
                return false;
                //MessageBox.Show("Registro Grabado", "Control de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (mensaje == "Y")
            {
                if (id_acceso == 0)
                {

                    int new_id_acceso;

                    new_id_acceso = 0;

                    clsPorteria objproducto2 = new clsPorteria();
                    objproducto2.cls_Consultar_Accesos_max_Id();

                    DataTable dTable2 = new DataTable();
                    dTable2 = objproducto2.cResultado;

                    try
                    {
                        new_id_acceso = Convert.ToInt32(dTable2.Rows[0].ItemArray[0].ToString());

                    }
                    catch
                    {
                        new_id_acceso = 0;
                    }

                    t_id_acceso.Text = new_id_acceso.ToString();
                    id_acceso = new_id_acceso;

                }

            }

            if (ruta_imagen != "")
            {

                if (id_acceso != 0)
                {
                    if (ruta_imagen != "")
                    {
                        CardCode = "con_imagen";

                        String mensaje1 = clsPorteria.SAPB1_ACCESO(id_acceso, CardCode, CardName, num_guia, patente, UserId, conductor, CardCode_Transportista, CardName_Transportista, ruta_imagen, id_razoningreso, t_patente_carro.Text , t_sellos.Text);

                        if (mensaje1 == "Y")
                        {
                            //MessageBox.Show("Registro Grabado", "Control de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            //MessageBox.Show(mensaje1, "Control de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }

                }

            }

            return true;

        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            btn_buscar1.Visible = true;
            t_fecha_registro.Visible = false;
            lbl_fecha_ingreso.Visible = false;
            cbb_Transportista.Enabled = true;
            t_num_guia.Enabled = true;
            cbb_razoningreso.Enabled = true;

            t_1er_grabado.Clear();
            t_cardcode.Clear();
            t_cardname.Clear();
            t_patente.Clear();
            t_conductor.Clear();
            t_num_guia.Clear();
            t_id_romana.Clear();
            t_id_acceso.Clear();
            t_imagen.Clear();
            t_patente_carro.Clear();
            t_sellos.Clear();

            cbb_Transportista.Text = "(Seleccione un Transportista)";
            cbb_razoningreso.Text = "(Seleccione Razón de Ingreso)";
            btn_escanear.Text = "Escanear Documento";

            t_cardcode.ReadOnly = false;
            btn_ok.Enabled = true;

            cbb_razoningreso.Focus();

        }

        private void btn_finalizar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void carga_datos_x_id()
        {

            btn_buscar1.Visible = true;
            t_fecha_registro.Visible = false;

            int id_acceso;

            try
            {
                id_acceso = Convert.ToInt32(t_id_acceso.Text);
            }
            catch
            {
                id_acceso = 0;

            }

            if (id_acceso == 0)
            {
                return;
            }

            btn_buscar1.Visible = false;
            t_fecha_registro.Visible = true;
            lbl_fecha_ingreso.Visible = true;

            string CardCode, CardName;
            string CardCode_trans;
            int numguia, con_imagen, id_romana;
            string patente, conductor, razoningreso;
            DateTime fecha_hora;

            CardCode = "";
            CardName = "";
            CardCode_trans = "";
            numguia = 0;
            patente = "";
            conductor = "";
            id_romana = 0;
            fecha_hora = DateTime.Parse("01/01/1900");
            razoningreso = "";

            t_cardcode.Clear();
            t_cardname.Clear();
            t_num_guia.Clear();
            t_patente.Clear();
            t_conductor.Clear();
            t_fecha_registro.Clear();
            t_id_romana.Clear();
            t_patente_carro.Clear();
            t_sellos.Clear();

            clsPorteria objproducto = new clsPorteria();
            objproducto.cls_Consultar_Accesos_x_Id(id_acceso);

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
                CardCode_trans = dTable.Rows[0].ItemArray[8].ToString();

            }
            catch
            {
                CardCode_trans = "";

            }

            try
            {
                patente = dTable.Rows[0].ItemArray[3].ToString();

            }
            catch
            {
                patente = "";

            }

            try
            {
                conductor = dTable.Rows[0].ItemArray[7].ToString();

            }
            catch
            {
                conductor = "";

            }

            try
            {
                numguia = Convert.ToInt32(dTable.Rows[0].ItemArray[4].ToString());

            }
            catch
            {
                numguia = 0;

            }

            try
            {
                con_imagen = Convert.ToInt32(dTable.Rows[0].ItemArray[11].ToString());

            }
            catch
            {
                con_imagen = 0;

            }

            try
            {
                fecha_hora = DateTime.Parse(dTable.Rows[0].ItemArray[5].ToString());

            }
            catch
            {
                fecha_hora = DateTime.Parse("01/01/1900");

            }

            try
            {
                id_romana = Convert.ToInt32(dTable.Rows[0].ItemArray[12].ToString());
            }
            catch
            {
                id_romana = 0;
            }

            try
            {
                razoningreso = dTable.Rows[0]["U_RazonAcceso"].ToString();
            }
            catch
            {
                razoningreso = "";
            }

            try
            {
                t_patente_carro.Text = dTable.Rows[0]["U_PatenteCarro"].ToString();
            }
            catch
            {
                t_patente_carro.Text = "";
            }

            try
            {
                t_sellos.Text = dTable.Rows[0]["U_Sellos"].ToString();
            }
            catch
            {
                t_sellos.Text = "";
            }

            t_cardcode.Text = CardCode;
            t_cardname.Text = CardName;
            t_cardcode.ReadOnly = true;
            cbb_razoningreso.Enabled = false;

            t_num_guia.Text = Convert.ToString(numguia);
            t_patente.Text = patente;
            t_conductor.Text = conductor;
            t_id_romana.Text = Convert.ToString(id_romana);

            if (id_romana > 0)
            {
                btn_ok.Enabled = false;
            }
            else
            {
                btn_ok.Enabled = true;
            }

            if (fecha_hora.Year != 1900)
            {
                t_fecha_registro.Text = fecha_hora.ToString("dd/MM/yyyy HH:mm"); //DateTime.Now.ToString(fecha_hora1. , "dd/MM/yyyy mm:hh");

            }

            try
            {
                cbb_Transportista.SelectedValue = CardCode_trans;

            }
            catch
            {

            }

            try
            {
                cbb_razoningreso.SelectedValue = razoningreso;
            }
            catch
            {

            }

            this.Size = new Size(510, 360);

            clsPorteria objproducto1 = new clsPorteria();
            objproducto1.cls_Consultar_Accesos_x_Imagen(id_acceso);

            this.dataGridView1.DataSource = objproducto1.cResultado;

            //this.Size = new Size(510, 360);

            //Bitmap marking;
            //marking = (Bitmap) dataGridView1.Rows[0].Cells[0].Value;
            //pictureBox1.Image = marking;

            if (con_imagen == 0)
            {
                btn_escanear.Text = "Escanear Documento";

            }
            else
            {
                btn_escanear.Text = "Ver Documento";

            }

            t_num_guia.Focus();

            this.Size = new Size(520, 400);


        }

        private void t_patente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (t_id_acceso.Text == "")
            {

                if (e.KeyChar == (char)Keys.Return)
                {

                    // Esta en modo consulta
                    t_patente.Text = t_patente.Text.ToUpper();

                    int id_acceso;
                    string valor;

                    valor = "";

                    try
                    {
                        valor = t_patente.Text.ToString();

                    }
                    catch
                    {
                        valor = "";

                    }

                    if (valor == "")
                    {
                        return;
                    }

                    id_acceso = 0;

                    DataTable dTable = new DataTable();

                    clsPorteria objproducto = new clsPorteria();
                    objproducto.cls_Consultar_Accesos_x_Caracter("Patente", valor);

                    dTable = objproducto.cResultado;

                    if (dTable.Rows.Count > 1)
                    {
                        VariablesGlobales.glb_Busqueda_Variable = "Patente";
                        VariablesGlobales.glb_Busqueda_Valor = valor;

                        frmPorteria4 f2 = new frmPorteria4();
                        DialogResult res = f2.ShowDialog();

                        try
                        {
                            id_acceso = Convert.ToInt32(VariablesGlobales.glb_id_acceso.ToString());
                        }
                        catch
                        {
                            id_acceso = 0;
                        }

                        if (id_acceso > 0)
                        {
                            t_id_acceso.Text = VariablesGlobales.glb_id_acceso.ToString();
                            carga_datos_x_id();

                        }

                    }
                    else
                    {
                        try
                        {
                            id_acceso = Convert.ToInt32(dTable.Rows[0].ItemArray[0].ToString());

                        }
                        catch
                        {
                            id_acceso = 0;

                        }

                        if (id_acceso > 0)
                        {
                            VariablesGlobales.glb_id_acceso = id_acceso;
                            t_id_acceso.Text = VariablesGlobales.glb_id_acceso.ToString();
                            carga_datos_x_id();

                        }
                    }
                }

            }


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            t_imagen.Text = "C:/Temp/guia_despacho.png";
            btn_escanear.Text = "Ver Documento";

        }

        private void t_cardcode_Leave(object sender, EventArgs e)
        {

            t_cardcode.Text = t_cardcode.Text.Replace(".", "");
            t_cardcode.Text = t_cardcode.Text.Replace("-", "");
            t_cardcode.Text = t_cardcode.Text.Replace("p", "P");

            string CardCode, CardName, CardCode_x;
            string CardCode_cP;

            CardCode = t_cardcode.Text.ToUpper();
            CardCode_x = "";
            CardName = "";

            CardCode_cP = "";
           
            try
            {
                if (CardCode.Trim() != "")
                {
                    if (CardCode.Substring(0, 1).ToUpper() == "P")
                    {
                        CardCode_cP = CardCode.ToUpper();
                    }
                    else
                    {
                        CardCode_cP = "P" + CardCode.ToUpper();
                    }

                }
            }
            catch
            {
                CardCode_cP = CardCode.ToUpper();

            }

            CardCode = CardCode_cP;

            t_cardcode.Text = CardCode.ToUpper();
            t_cardname.Clear();

            consulta_productor(CardCode.ToUpper());

            if (t_cardcode.Text != "")
            {                
                if (t_cardname.Text == "")
                {
                    CardCode_x = CardCode.Substring(0, CardCode.Length - 1).ToUpper();

                    consulta_productor(CardCode_x.ToUpper());

                    if (t_cardname.Text != "")
                    {
                        t_cardcode.Text = CardCode_x.ToUpper();

                    }
                    else
                    {
                        CardName = "ENTIDAD NO EXISTE !!!!";
                        t_cardname.Text = CardName;

                    }

                }

            }

            
        }

        private void consulta_productor(string CardCode)
        {
            DataTable dTable = new DataTable();
            string CardName;

            CardName = "";

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

            t_cardname.Text = CardName;

        }

        private void t_patente_Leave(object sender, EventArgs e)
        {

            t_patente.Text = t_patente.Text.Replace("-", "");
            t_patente.Text = t_patente.Text.Replace("_", "");
            t_patente.Text = t_patente.Text.Replace(".", "");

            t_patente.Text = t_patente.Text.ToUpper();

            string Patente;

            Patente = "";

            try
            {
                Patente = t_patente.Text.Trim();

            }
            catch
            {
                Patente = "";

            }

            if (Patente =="" )
            {
                return;
            }

            string CardCodeTrans, Conductor, CardCodeTrans1;

            CardCodeTrans = "";
            Conductor = "";
            CardCodeTrans1 = "";

            if (cbb_Transportista.Text.Trim() == "(Seleccione un Transportista)")
            {
                CardCodeTrans1 = "";

            }
            else
            {
                try
                {
                    CardCodeTrans1 = cbb_Transportista.SelectedValue.ToString();

                }
                catch
                {
                    CardCodeTrans1 = "";

                }

            }

            DataTable dTable = new DataTable();

            clsPorteria objproducto = new clsPorteria();
            objproducto.cls_Consultar_Transporstica_Patente(Patente);

            dTable = objproducto.cResultado;

            //U_PatenteCarro 
            try
            {
                t_patente_carro.Text = dTable.Rows[0]["U_PatenteCarro"].ToString().ToUpper();
            }
            catch
            {
                t_patente_carro.Clear();
            }

            try
            {
                CardCodeTrans = dTable.Rows[0].ItemArray[0].ToString().ToUpper();

            }
            catch
            {
                CardCodeTrans = "";

            }

            try
            {
                Conductor = dTable.Rows[0].ItemArray[2].ToString().ToUpper();

            }
            catch
            {
                Conductor = "";

            }

            if (CardCodeTrans !="")
            {
                if (CardCodeTrans1 == "")
                {
                    try
                    {
                        cbb_Transportista.SelectedValue = CardCodeTrans;

                    }
                    catch
                    {

                    }

                }

            }

            if (Conductor != "")
            {
                if (t_conductor.Text == "")
                {
                    try
                    {
                        t_conductor.Text = Conductor;

                    }
                    catch
                    {

                    }

                }

            }



        }

        private void cbb_Transportista_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (t_cargo.Text == "")
            {
                return;

            }

            string CardCode_Transportista;

            try
            {
                CardCode_Transportista = cbb_Transportista.SelectedValue.ToString();

            }
            catch
            {
                CardCode_Transportista = "";

            }

            if (CardCode_Transportista == "._.")
            {
                VariablesGlobales.glb_CardCode = "";

                frmTransportistas1 f2 = new frmTransportistas1();
                DialogResult res = f2.ShowDialog();

                if (VariablesGlobales.glb_CardCode != "")
                {

                    clsSocioNegocio objproducto = new clsSocioNegocio();
                    objproducto.cls_Consultar_Transportistas();

                    this.cbb_Transportista.DataSource = objproducto.cResultado;
                    this.cbb_Transportista.ValueMember = "CardCode";
                    this.cbb_Transportista.DisplayMember = "CardName";

                    cbb_Transportista.SelectedValue = VariablesGlobales.glb_CardCode;

                }

                VariablesGlobales.glb_CardCode = "";

            }


        }

        private void t_num_guia_Leave(object sender, EventArgs e)
        {

            int nDocNum; //, nDocEntry;

            try
            {
                nDocNum = Convert.ToInt32(t_num_guia.Text);

            }
            catch
            {
                nDocNum = 0;
            }

            t_num_guia.Text = nDocNum.ToString();

            DataTable dTable = new DataTable();
            string CardCode;

            CardCode = "";
            nDocNum = 0;
            //nDocEntry = 0;

            try
            {
                CardCode = t_cardcode.Text;
            }
            catch
            {
                CardCode = "";
            }

            try
            {
                nDocNum = Convert.ToInt32(t_num_guia.Text);

            }
            catch
            {
                nDocNum = 0;

            }


            // Esta en modo consulta

            int docnum, id_acceso;

            docnum = 0;

            try
            {
                docnum = Convert.ToInt32(t_num_guia.Text.ToString());

            }
            catch
            {
                docnum = 0;

            }

            if (docnum == 0)
            {
                return;
            }

            id_acceso = 0;

            //DataTable dTable = new DataTable();

            clsPorteria objproducto = new clsPorteria();
            objproducto.cls_Consultar_Accesos_x_Numero("DocNum", docnum, t_cardcode.Text);

            dTable = objproducto.cResultado;

            if (dTable.Rows.Count > 1)
            {
                VariablesGlobales.glb_Busqueda_Variable = "DocNum";
                VariablesGlobales.glb_Busqueda_Valor = Convert.ToString(docnum);
                VariablesGlobales.glb_CardCode = CardCode;

                frmPorteria4 f2 = new frmPorteria4();
                DialogResult res = f2.ShowDialog();

                try
                {
                    id_acceso = Convert.ToInt32(VariablesGlobales.glb_id_acceso.ToString());
                }
                catch
                {
                    id_acceso = 0;
                }

                if (id_acceso > 0)
                {
                    t_id_acceso.Text = VariablesGlobales.glb_id_acceso.ToString();
                    carga_datos_x_id();

                }

            }
            else
            {
                try
                {
                    id_acceso = Convert.ToInt32(dTable.Rows[0].ItemArray[0].ToString());

                }
                catch
                {
                    id_acceso = 0;

                }

                if (id_acceso > 0)
                {
                    VariablesGlobales.glb_id_acceso = id_acceso;
                    t_id_acceso.Text = VariablesGlobales.glb_id_acceso.ToString();
                    carga_datos_x_id();

                }
            }

            //clsPorteria objproducto = new clsPorteria();
            //objproducto.cls_Consultar_Accesos_x_Documento(CardCode, nDocNum);

            //dTable = objproducto.cResultado;

            //try
            //{
            //    nDocEntry = Convert.ToInt32(dTable.Rows[0].ItemArray[0].ToString());

            //}
            //catch
            //{
            //    nDocEntry = 0;

            //}

            //if (nDocEntry>0)
            //{

            //    VariablesGlobales.glb_id_acceso = nDocEntry;
            //    t_id_acceso.Text = nDocEntry.ToString();

            //    carga_datos_x_id();

            //}

        }

        private void t_conductor_Leave(object sender, EventArgs e)
        {
            t_conductor.Text = t_conductor.Text.ToUpper();

        }

        private void cbb_razoningreso_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nRazonIngreso;

            try
            {
                nRazonIngreso = Convert.ToInt32(cbb_razoningreso.SelectedValue);

            }
            catch
            {
                nRazonIngreso = -1;

            }

            if (nRazonIngreso>0)
            {
                if (nRazonIngreso == 5)
                {
                    cbb_Transportista.Enabled = false;
                    t_num_guia.Enabled = false;

                }
                else
                {
                    cbb_Transportista.Enabled = true;
                    t_num_guia.Enabled = true;

                }

            }

        }

        private void t_patente_carro_Leave(object sender, EventArgs e)
        {

            t_patente_carro.Text = t_patente_carro.Text.Replace("-", "");
            t_patente_carro.Text = t_patente_carro.Text.Replace("_", "");
            t_patente_carro.Text = t_patente_carro.Text.Replace(".", "");

            t_patente_carro.Text = t_patente_carro.Text.ToUpper();
            
        }

    }

}
