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
    public partial class frmBLoqLotes : Form
    {
        public frmBLoqLotes()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            SAPbobsCOM.Recordset oRecordset;
            oRecordset = (SAPbobsCOM.Recordset)VariablesGlobales.sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            oRecordset.DoQuery("select DistNumber,statusLote,WhsCode,Quantity,* from vista_inventario_lotes_completa where distnumber='"+txtLotePallet.Text+ "' or Pallet='" + txtLotePallet.Text + "'");
          
            if (oRecordset.RecordCount > 0)
            {
                while (oRecordset.EoF == false)
                {
                    string lote = oRecordset.Fields.Item(0).Value.ToString();


                    dataGridView1.Rows.Add(oRecordset.Fields.Item(0).Value.ToString(), oRecordset.Fields.Item(1).Value.ToString(), oRecordset.Fields.Item(2).Value.ToString(), oRecordset.Fields.Item(3).Value.ToString());
                    oRecordset.MoveNext();
                }
            }
            oRecordset = null;


        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void btnBloquear_Click(object sender, EventArgs e)
        {


            SAPbobsCOM.Recordset oRecordset;

            oRecordset = (SAPbobsCOM.Recordset)VariablesGlobales.sbo_HDV_P03.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            string Lote, Lote1;
            int absEntry;
            for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
            {
                Lote = dataGridView1[0, i].Value.ToString();
                oRecordset.DoQuery("select absentry from obtn where distnumber='" + Lote + "'");
                Lote1 = oRecordset.Fields.Item(0).Value.ToString();
                absEntry = Convert.ToInt32(Lote1);
                Boolean UpdateLote;
                UpdateLote = negSap.GestionLote(absEntry, 1);

                // mejorar mensajeria cuando no pueda actualizar.


            }
            MessageBox.Show("Selección de Lotes Bloqueada");
            dataGridView1.Rows.Clear();


        }

        private void btnDesbloquear_Click(object sender, EventArgs e)
        {
            ///////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////

            string UsuarioSap, ClaveSap;

            try
            {
                UsuarioSap = VariablesGlobales.glb_User_Code;
            }
            catch
            {
                UsuarioSap = "";
            }

            try
            {
                ClaveSap = VariablesGlobales.glb_User_Psw;
            }
            catch
            {
                ClaveSap = "";
            }

            string Lote, mensaje;

            for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
            {
                Lote = dataGridView1[0, i].Value.ToString();

                try
                {
                    mensaje = clsOrdenFabricacion.Production_CambiaStatus_Lote(Convert.ToInt32(Lote), "N", UsuarioSap, ClaveSap);

                }
                catch
                {

                } 


            }
            MessageBox.Show("Selección de Lotes Desbloqueada");
            dataGridView1.Rows.Clear();

        }

        private void btn_bloquea_lotes_calidad_Click(object sender, EventArgs e)
        {

            try
            {
                string cDistNumber, cStatusLotes, cWhsCode;
                double nQuantity;

                clsCalidad objproducto = new clsCalidad();
                objproducto.cls_Consulta_Lotes_Rechazados();

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                dataGridView1.Rows.Clear();

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        cDistNumber = dTable.Rows[i]["DistNumber"].ToString();
                    }
                    catch
                    {
                        cDistNumber = "";
                    }

                    try
                    {
                        cStatusLotes = dTable.Rows[i]["StatusLote"].ToString();
                    }
                    catch
                    {
                        cStatusLotes = "";
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
                        nQuantity = double.Parse(dTable.Rows[i]["Quantity"].ToString());
                    }
                    catch
                    {
                        nQuantity = 0;
                    } 

                    grilla[0] = cDistNumber;
                    grilla[1] = cStatusLotes;
                    grilla[2] = cWhsCode;
                    grilla[3] = nQuantity.ToString("N2");

                    dataGridView1.Rows.Add(grilla);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btn_libera_lotes_calidad_Click(object sender, EventArgs e)
        {
            try
            {
                string cDistNumber, cStatusLotes, cWhsCode;
                double nQuantity;

                clsCalidad objproducto = new clsCalidad();
                objproducto.cls_Consulta_Lotes_Rechazados1();

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                dataGridView1.Rows.Clear();

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        cDistNumber = dTable.Rows[i]["DistNumber"].ToString();
                    }
                    catch
                    {
                        cDistNumber = "";
                    }

                    try
                    {
                        cStatusLotes = dTable.Rows[i]["StatusLote"].ToString();
                    }
                    catch
                    {
                        cStatusLotes = "";
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
                        nQuantity = double.Parse(dTable.Rows[i]["Quantity"].ToString());
                    }
                    catch
                    {
                        nQuantity = 0;
                    }

                    grilla[0] = cDistNumber;
                    grilla[1] = cStatusLotes;
                    grilla[2] = cWhsCode;
                    grilla[3] = nQuantity.ToString("N2");

                    dataGridView1.Rows.Add(grilla);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string cDistNumber, cStatusLotes, cWhsCode;
                double nQuantity;

                clsCalidad objproducto = new clsCalidad();
                objproducto.cls_Consulta_Lotes_Proceso();

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                dataGridView1.Rows.Clear();

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        cDistNumber = dTable.Rows[i]["DistNumber"].ToString();
                    }
                    catch
                    {
                        cDistNumber = "";
                    }

                    try
                    {
                        cStatusLotes = dTable.Rows[i]["StatusLote"].ToString();
                    }
                    catch
                    {
                        cStatusLotes = "";
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
                        nQuantity = double.Parse(dTable.Rows[i]["Quantity"].ToString());
                    }
                    catch
                    {
                        nQuantity = 0;
                    }

                    grilla[0] = cDistNumber;
                    grilla[1] = cStatusLotes;
                    grilla[2] = cWhsCode;
                    grilla[3] = nQuantity.ToString("N2");

                    dataGridView1.Rows.Add(grilla);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            ///////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////

            string UsuarioSap, ClaveSap;

            try
            {
                UsuarioSap = VariablesGlobales.glb_User_Code;
            }
            catch
            {
                UsuarioSap = "";
            }

            try
            {
                ClaveSap = VariablesGlobales.glb_User_Psw;
            }
            catch
            {
                ClaveSap = "";
            }

            string Lote, mensaje;

            for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
            {
                Lote = dataGridView1[0, i].Value.ToString();

                try
                {
                    mensaje = clsOrdenFabricacion.Production_CambiaStatus_Lote(Convert.ToInt32(Lote), "Y", UsuarioSap, ClaveSap);

                }
                catch
                {

                }


            }
            MessageBox.Show("Selección de Lotes Desbloqueada");
            dataGridView1.Rows.Clear();

        }
    }

}

