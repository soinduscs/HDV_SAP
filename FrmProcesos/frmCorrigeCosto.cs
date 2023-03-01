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
    public partial class frmCorrigeCosto : Form
    {
        public frmCorrigeCosto()
        {
            InitializeComponent();
        }

        private void frmCorrigeCosto_Load(object sender, EventArgs e)
        {
            carga_productos();
        }

        private void carga_productos()
        {

            string cItemCode, cDistNumber, cWhsCode;
            string cItemCode_Old, cWhsCode_Old;

            double nQuantity, nQuantity_full, nIsCommited;
            double nAvgPrice;

            int nDocEntry;

            cItemCode_Old = "_";
            cWhsCode_Old = "_";

            clsProductos objproducto = new clsProductos();
            objproducto.cls_consultar_Productos_x_Corregir();

            DataTable dTable = new DataTable();
            dTable = objproducto.cResultado;

            Grid1.Rows.Clear();

            string[] grilla;
            grilla = new string[30];

            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {

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
                    cDistNumber = dTable.Rows[i]["DistNumber"].ToString();
                }
                catch
                {
                    cDistNumber = "";

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
                    nQuantity = Convert.ToDouble(dTable.Rows[i]["Quantity"].ToString());
                }
                catch
                {
                    nQuantity = 0;
                }

                try
                {
                    nIsCommited = Convert.ToDouble(dTable.Rows[i]["IsCommited"].ToString());
                }
                catch
                {
                    nIsCommited = 0;
                }

                try
                {
                    nDocEntry = Convert.ToInt32(dTable.Rows[i]["DocEntry"].ToString());
                }
                catch
                {
                    nDocEntry = 0;
                }

                try
                {
                    nAvgPrice = Convert.ToDouble(dTable.Rows[i]["AvgPrice"].ToString()); 
                }
                catch
                {
                    nAvgPrice = 0;
                }

                grilla[0] = cItemCode;
                grilla[1] = cDistNumber;
                grilla[2] = cWhsCode;
                grilla[3] = nQuantity.ToString("N2");
                grilla[4] = nIsCommited.ToString("N2");
                grilla[5] = nDocEntry.ToString();

                Grid1.Rows.Add(grilla);

                if ((cItemCode_Old != cItemCode) || (cWhsCode_Old != cWhsCode))
                {
                    grilla[0] = cItemCode;
                    grilla[1] = cWhsCode;
                    grilla[2] = "0";
                    grilla[3] = nAvgPrice.ToString("N2");

                    Grid2.Rows.Add(grilla);

                    cItemCode_Old = cItemCode;
                    cWhsCode_Old = cWhsCode;

                }


            }

            for (int i = 0; i <= Grid2.RowCount - 1; i++)
            {
                nQuantity_full = 0;

                try
                {
                    cItemCode_Old = Grid2[0, i].Value.ToString();
                }
                catch
                {
                    cItemCode_Old = "";
                }

                try
                {
                    cWhsCode_Old = Grid2[1, i].Value.ToString();
                }
                catch
                {
                    cWhsCode_Old = "";
                }

                for (int z = 0; z <= Grid1.RowCount - 1; z++)
                {

                    try
                    {
                        cItemCode = Grid1[0, z].Value.ToString();
                    }
                    catch
                    {
                        cItemCode = "";
                    }

                    try
                    {
                        cWhsCode = Grid1[2, z].Value.ToString();
                    }
                    catch
                    {
                        cWhsCode = "";
                    }

                    try
                    {
                        nQuantity = Convert.ToDouble(Grid1[3, z].Value.ToString());
                    }
                    catch
                    {
                        nQuantity = 0;
                    }

                    if (cItemCode_Old == cItemCode)
                    {
                        if (cWhsCode_Old == cWhsCode)
                        {
                            nQuantity_full += nQuantity;

                        }

                    }

                }

                Grid2[2, i].Value = nQuantity_full.ToString("N2");

            }




        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {

            int fila;
            string cItemCode, cLote, cWhsCode;
            double nQuantity, nQuantity_D;

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
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Orden de Fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                cItemCode = Grid2[0, fila].Value.ToString();
            }
            catch
            {
                cItemCode = "";
            }

            try
            {
                cWhsCode = Grid2[1, fila].Value.ToString();
            }
            catch
            {
                cWhsCode = "";
            }

            try
            {
                nQuantity = Convert.ToDouble(Grid2[2, fila].Value.ToString());
            }
            catch
            {
                nQuantity = 0;
            }

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

            string cItemCode_D, cWhsCode_D, cRef;
            int nDocEntrySolicitud, nDocEntrySolicitud_R;

            string[] grilla;
            grilla = new string[30];

            for (int z = 0; z <= Grid1.RowCount - 1; z++)
            {

                try
                {
                    cItemCode_D = Grid1[0, z].Value.ToString();
                }
                catch
                {
                    cItemCode_D = "";
                }

                try
                {
                    cWhsCode_D = Grid1[2, z].Value.ToString();
                }
                catch
                {
                    cWhsCode_D = "";
                }

                try
                {
                    nDocEntrySolicitud = Convert.ToInt32(Grid1[5, z].Value.ToString());
                }
                catch
                {
                    nDocEntrySolicitud = 0;
                }

                if (cItemCode_D == cItemCode)
                {
                    if (cWhsCode_D == cWhsCode)
                    {
                        if (nDocEntrySolicitud > 0)
                        {

                            cRef = "";

                            for (int i = 0; i <= Grid3.RowCount - 1; i++)
                            {

                                try
                                {
                                    nDocEntrySolicitud_R = Convert.ToInt32(Grid3[0, i].Value.ToString());
                                }
                                catch
                                {
                                    nDocEntrySolicitud_R = 0;
                                }

                                if (nDocEntrySolicitud_R == nDocEntrySolicitud)
                                {
                                    cRef = "x";
                                    break;
                                }

                            }

                            if (cRef == "")
                            {
                                grilla[0] = nDocEntrySolicitud.ToString();

                                Grid3.Rows.Add(grilla);

                            }

                        }

                    }

                }

            }

            String mensaje;

            for (int z = 0; z <= Grid3.RowCount - 1; z++)
            {

                try
                {
                    nDocEntrySolicitud = Convert.ToInt32(Grid3[0, z].Value.ToString());
                }
                catch
                {
                    nDocEntrySolicitud = 0;
                }

                if (nDocEntrySolicitud > 0)
                {
                    mensaje = clsProductos.CierraSolicitud_Productos_x_Corregir(nDocEntrySolicitud, UsuarioSap, ClaveSap);

                }

            }

            string[,] d_arrDetalle = new string[10, 1000];

            for (int i = 0; i <= 999; i++)
            {
                d_arrDetalle[1, i] = "";

            }

            int j = 0;

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {
                try
                {
                    cItemCode_D = Grid1[0, i].Value.ToString();
                }
                catch
                {
                    cItemCode_D = "";
                }

                try
                {
                    cWhsCode_D = Grid1[2, i].Value.ToString();
                }
                catch
                {
                    cWhsCode_D = "";
                }

                try
                {
                    cLote = Grid1[1, i].Value.ToString();
                }
                catch
                {
                    cLote = "";
                }

                try
                {
                    nQuantity_D = Convert.ToDouble(Grid1[3, i].Value.ToString());
                }
                catch
                {
                    nQuantity_D = 0;
                }

                if (cItemCode_D == cItemCode)
                {
                    if (cWhsCode_D == cWhsCode)
                    {
                        d_arrDetalle[1, j] = cItemCode_D;
                        d_arrDetalle[2, j] = cLote;
                        d_arrDetalle[3, j] = nQuantity_D.ToString();
                        d_arrDetalle[4, j] = cWhsCode_D;

                        j += 1;

                    }

                }

            }

            mensaje = clsProductos.Salida_Productos_x_Corregir("20180914" , cItemCode , d_arrDetalle, cWhsCode , nQuantity, UsuarioSap, ClaveSap);

            mensaje = clsProductos.Entrada_Productos_x_Corregir("20180914", cItemCode, d_arrDetalle, cWhsCode, nQuantity, UsuarioSap, ClaveSap);

            //mensaje = clsProductos.Entrada_Productos_x_Corregir("20180914", cItemCode, cLote, cWhsCode, nQuantity, UsuarioSap, ClaveSap);


        }

        private void button1_Click(object sender, EventArgs e)
        {

            int fila;
            string cItemCode, cLote, cWhsCode;
            double nQuantity;

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
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Orden de Fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                cItemCode = Grid1[0, fila].Value.ToString();
            }
            catch
            {
                cItemCode = "";
            }

            try
            {
                cLote = Grid1[1, fila].Value.ToString();
            }
            catch
            {
                cLote = "";
            }

            try
            {
                cWhsCode = Grid1[2, fila].Value.ToString();
            }
            catch
            {
                cWhsCode = "";
            }

            try
            {
                nQuantity = Convert.ToDouble(Grid1[3, fila].Value.ToString());
            }
            catch
            {
                nQuantity = 0;
            }

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

            //String mensaje = clsProductos.Entrada_Productos_x_Corregir("20180914", cItemCode, cLote, cWhsCode, nQuantity, UsuarioSap, ClaveSap);



        }

        private void button2_Click(object sender, EventArgs e)
        {

            int fila;
            string cItemCode, cLote, cWhsCode;
            double nQuantity, nQuantity_D;

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
                MessageBox.Show("Debe seleccionar un registro valido, opción Cancelada", "Orden de Fabricacion ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                cItemCode = Grid2[0, fila].Value.ToString();
            }
            catch
            {
                cItemCode = "";
            }

            try
            {
                cWhsCode = Grid2[1, fila].Value.ToString();
            }
            catch
            {
                cWhsCode = "";
            }

            try
            {
                nQuantity = Convert.ToDouble(Grid2[2, fila].Value.ToString());
            }
            catch
            {
                nQuantity = 0;
            }

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

            string cItemCode_D, cWhsCode_D, cRef;
            int nDocEntrySolicitud, nDocEntrySolicitud_R;

            string[] grilla;
            grilla = new string[30];

            for (int z = 0; z <= Grid1.RowCount - 1; z++)
            {

                try
                {
                    cItemCode_D = Grid1[0, z].Value.ToString();
                }
                catch
                {
                    cItemCode_D = "";
                }

                try
                {
                    cWhsCode_D = Grid1[2, z].Value.ToString();
                }
                catch
                {
                    cWhsCode_D = "";
                }

                try
                {
                    nDocEntrySolicitud = Convert.ToInt32(Grid1[5, z].Value.ToString());
                }
                catch
                {
                    nDocEntrySolicitud = 0;
                }

                if (cItemCode_D == cItemCode)
                {
                    if (cWhsCode_D == cWhsCode)
                    {
                        if (nDocEntrySolicitud > 0)
                        {

                            cRef = "";

                            for (int i = 0; i <= Grid3.RowCount - 1; i++)
                            {

                                try
                                {
                                    nDocEntrySolicitud_R = Convert.ToInt32(Grid3[0, i].Value.ToString());
                                }
                                catch
                                {
                                    nDocEntrySolicitud_R = 0;
                                }

                                if (nDocEntrySolicitud_R == nDocEntrySolicitud)
                                {
                                    cRef = "x";
                                    break;
                                }

                            }

                            if (cRef == "")
                            {
                                grilla[0] = nDocEntrySolicitud.ToString();

                                Grid3.Rows.Add(grilla);

                            }

                        }

                    }

                }

            }

            String mensaje;

            for (int z = 0; z <= Grid3.RowCount - 1; z++)
            {

                try
                {
                    nDocEntrySolicitud = Convert.ToInt32(Grid3[0, z].Value.ToString());
                }
                catch
                {
                    nDocEntrySolicitud = 0;
                }

                if (nDocEntrySolicitud > 0)
                {
                    mensaje = clsProductos.CierraSolicitud_Productos_x_Corregir(nDocEntrySolicitud, UsuarioSap, ClaveSap);

                }

            }

            string[,] d_arrDetalle = new string[10, 1000];

            for (int i = 0; i <= 999; i++)
            {
                d_arrDetalle[1, i] = "";

            }

            int j = 0;

            for (int i = 0; i <= Grid1.RowCount - 1; i++)
            {
                try
                {
                    cItemCode_D = Grid1[0, i].Value.ToString();
                }
                catch
                {
                    cItemCode_D = "";
                }

                try
                {
                    cWhsCode_D = Grid1[2, i].Value.ToString();
                }
                catch
                {
                    cWhsCode_D = "";
                }

                try
                {
                    cLote = Grid1[1, i].Value.ToString();
                }
                catch
                {
                    cLote = "";
                }

                try
                {
                    nQuantity_D = Convert.ToDouble(Grid1[3, i].Value.ToString());
                }
                catch
                {
                    nQuantity_D = 0;
                }

                if (cItemCode_D == cItemCode)
                {
                    if (cWhsCode_D == cWhsCode)
                    {
                        d_arrDetalle[1, j] = cItemCode_D;
                        d_arrDetalle[2, j] = cLote;
                        d_arrDetalle[3, j] = nQuantity_D.ToString();
                        d_arrDetalle[4, j] = cWhsCode_D;

                        j += 1;

                    }

                }

            }

            mensaje = clsProductos.Revalorizacion_Inventario("20181228", cItemCode, UsuarioSap, ClaveSap,"");



        }
    }
}
