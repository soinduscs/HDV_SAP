using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CapaNegocio
{
    public class negSap
    {
        public static Boolean GestionLote(int vAbsentry, int vEstado)
        {
            SAPbobsCOM.BatchNumberDetailsService oLote;
            SAPbobsCOM.BatchNumberDetailParams oLoteParams;
            SAPbobsCOM.BatchNumberDetail oLoteDetail;
            oLote = (SAPbobsCOM.BatchNumberDetailsService)VariablesGlobales.sbo_HDV_P03.GetCompanyService().GetBusinessService(SAPbobsCOM.ServiceTypes.BatchNumberDetailsService);
            oLoteDetail = (SAPbobsCOM.BatchNumberDetail)oLote.GetDataInterface(SAPbobsCOM.BatchNumberDetailsServiceDataInterfaces.bndsBatchNumberDetail);
            oLoteParams = (SAPbobsCOM.BatchNumberDetailParams)oLote.GetDataInterface(SAPbobsCOM.BatchNumberDetailsServiceDataInterfaces.bndsBatchNumberDetailParams);
           
            
                oLoteParams.DocEntry = vAbsentry;
                oLoteDetail = oLote.Get(oLoteParams);
            if (vEstado==0)
            { 
                oLoteDetail.Status = SAPbobsCOM.BoDefaultBatchStatus.dbs_Released;
            }
            else
            {
                oLoteDetail.Status = SAPbobsCOM.BoDefaultBatchStatus.dbs_Locked;
            }
            try
                {
                    oLote.Update(oLoteDetail);
                }
                catch (Exception)
                {
                return false;
                }

            return true;
        }
    

        public static string Conexion_SAP(string txtUsuario, string txtClave)
        {
            int Connect = 0;
            int errCode;
            string errMsg;

            VariablesGlobales.glb_Referencia1 = "";
            VariablesGlobales.glb_Referencia2 = "";

            //Boolean conectar;
            //conectar = false;
       
            VariablesGlobales.sbo_HDV_P03 = new SAPbobsCOM.Company();
            VariablesGlobales.sbo_HDV_P03.Server = ConfigurationManager.AppSettings.Get("Servidor_SAP");  
            VariablesGlobales.sbo_HDV_P03.LicenseServer = ConfigurationManager.AppSettings.Get("Servidor_SAP") + ":30000"; 
            VariablesGlobales.sbo_HDV_P03.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;
            VariablesGlobales.sbo_HDV_P03.CompanyDB = ConfigurationManager.AppSettings.Get("Base_SAP");

            if (ConfigurationManager.AppSettings.Get("VersionSQL_SAP") == "2012")
                VariablesGlobales.sbo_HDV_P03.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2012;
            else
                VariablesGlobales.sbo_HDV_P03.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2014;

            VariablesGlobales.sbo_HDV_P03.DbUserName = "sa";
            VariablesGlobales.sbo_HDV_P03.DbPassword = "SAPB1Admin";
            VariablesGlobales.sbo_HDV_P03.UserName = txtUsuario;
            VariablesGlobales.sbo_HDV_P03.Password = txtClave;

            Connect = VariablesGlobales.sbo_HDV_P03.Connect();

            if (Connect == 0)
            {
                //conectar = true;
                errMsg = "";
            }
            else
            {
                //conectar = false;
                VariablesGlobales.sbo_HDV_P03.GetLastError(out errCode, out errMsg);

                VariablesGlobales.glb_Referencia1 = errCode.ToString();
                VariablesGlobales.glb_Referencia1 = errMsg;

            }

            try
            {
                VariablesGlobales.sbo_HDV_P03.Disconnect();

            }
            catch
            {

            }

            return errMsg;

        }

    }
}
