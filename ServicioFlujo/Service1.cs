using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using CapaNegocio;
using CapaDatos;

namespace ServicioFlujo
{
    public partial class HDVMensajeriaWorkflow : ServiceBase
    {
        public HDVMensajeriaWorkflow()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            oTimer.Interval = 5000;
            oTimer.Start();
        }

        protected override void OnStop()
        {
            oTimer.Stop();
        }

        private void oTimer_Tick(object sender, EventArgs e)
        {
            oTimer.Stop();
            Mensajero();


            oTimer.Start();
        }

        private void Mensajero()
        {
            //cldFlujo objPendientes = new cldFlujo();
            //if (objPendientes.HayDatos)
            //{ }
            //else
            //{ }


        }
    }
}
