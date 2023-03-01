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
    public partial class frmRecepcionMPB7 : Form
    {
        public frmRecepcionMPB7()
        {
            InitializeComponent();
        }

        private void frmRecepcionMPB7_Load(object sender, EventArgs e)
        {
            carga_grilla1();

        }

        private void carga_grilla1()
        {

            try
            {

                int nSaldoBins, nLote_tot, nLote;
                int nLote_db;
                double nSaldoKilos;
                string cMostrar;

                try
                {
                    nLote_tot = VariablesGlobales.glb_Array1_ind;

                }
                catch
                {
                    nLote_tot = 0;
                }

                clsOrdenFabricacion objproducto = new clsOrdenFabricacion();
                objproducto.cls_Consultar_Lista_de_guiasinternas_dys("L","");

                DataTable dTable = new DataTable();
                dTable = objproducto.cResultado;

                Grid1.Rows.Clear();

                string[] grilla;
                grilla = new string[30];

                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {

                    try
                    {
                        grilla[0] = dTable.Rows[i]["NumOC"].ToString();
                    }
                    catch
                    {
                        grilla[0] = "";
                    }

                    try
                    {
                        grilla[1] = dTable.Rows[i]["CardName"].ToString();
                    }
                    catch
                    {
                        grilla[1] = "";
                    }

                    try
                    {
                        grilla[2] = dTable.Rows[i]["Variedad"].ToString();
                    }
                    catch
                    {
                        grilla[2] = "";
                    }

                    try
                    {
                        grilla[3] = dTable.Rows[i]["U_ItemCode_Referencia"].ToString();
                    }
                    catch
                    {
                        grilla[3] = "";
                    }
                    
                    try
                    {
                        grilla[4] = dTable.Rows[i]["TipoEnvase"].ToString();
                    }
                    catch
                    {
                        grilla[4] = "";
                    }

                    try
                    {
                        grilla[5] = dTable.Rows[i]["Lote"].ToString();
                        nLote_db = Convert.ToInt32(dTable.Rows[i]["Lote"].ToString());

                    }
                    catch
                    {
                        grilla[5] = "";
                        nLote_db = 0;

                    }

                    try
                    {
                        grilla[6] = dTable.Rows[i]["U_Codigo_CSG"].ToString();
                        
                    }
                    catch
                    {
                        grilla[6] = "";

                    }

                    try
                    {
                        nSaldoBins = Convert.ToInt32(dTable.Rows[i]["Saldo_Bins"].ToString());
                    }
                    catch
                    {
                        nSaldoBins = 0;
                    }

                    grilla[7] = nSaldoBins.ToString("N");

                    try
                    {
                        nSaldoKilos = Convert.ToDouble(dTable.Rows[i]["Kilos_pendientes"].ToString());
                    }
                    catch
                    {
                        nSaldoKilos = 0;
                    }

                    grilla[8] = nSaldoKilos.ToString("N");

                    cMostrar = "S";

                    for (int x = 0; x <= nLote_tot; x++)
                    {
                        try
                        {
                            nLote = VariablesGlobales.glb_Array1[x];

                        }
                        catch
                        {
                            nLote = 0;
                        }

                        if (nLote_db == nLote)
                        {
                            cMostrar = "N";
                            break;

                        }

                    }

                    if (nSaldoBins <= 0)
                    {
                        cMostrar = "N";

                    }

                    if (cMostrar == "S")
                    {
                        Grid1.Rows.Add(grilla);

                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            carga_grilla1();

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_traslado_Click(object sender, EventArgs e)
        {

            if (Grid1.RowCount == 0)
            {
                MessageBox.Show("No Existen datos a seleccionar, opción Cancelada", "Lista de Materiales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int fila, nLote;
            string cProductor, cTipoEnvase;

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
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Lista de Materiales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            try
            {
                nLote = Convert.ToInt32(Grid1[5, fila].Value.ToString());

            }
            catch
            {
                nLote = 0;

            }

            try
            {
                cProductor = Grid1[1, fila].Value.ToString();
            }
            catch
            {
                cProductor = "";

            }

            try
            {
                cTipoEnvase = Grid1[3, fila].Value.ToString();
            }
            catch
            {
                cTipoEnvase = "";

            }

            if (VariablesGlobales.glb_Productor_Ref != "")
            {
                if (VariablesGlobales.glb_Productor_Ref != cProductor)
                {
                    MessageBox.Show("Debe seleccionar un registro valido, El productor debe ser: " + VariablesGlobales.glb_Productor_Ref + " ,opción Cancelada", "Lista de Materiales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

            }

            if (VariablesGlobales.glb_TipoEnvase_Ref != "")
            {
                if (VariablesGlobales.glb_TipoEnvase_Ref != cTipoEnvase)
                {
                    MessageBox.Show("Debe seleccionar un registro valido, El envase debe ser: " + VariablesGlobales.glb_TipoEnvase_Ref + " ,opción Cancelada", "Lista de Materiales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

            }

            VariablesGlobales.glb_Lote = nLote;

            Close();

        }

        private void Grid1_DoubleClick(object sender, EventArgs e)
        {
            btn_traslado_Click(sender, e);

        }

    }
}
