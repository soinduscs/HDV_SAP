using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class entEntrada
    {
        public int DocEntry { get; set; }
        public int FolioNum { get; set; }
        public int OrdenCompra { get; set; }
        public String Status { get; set; }
        public DateTime Fecha { get; set; }
        public String TipoFruta { get; set; }
        public int Lote { get; set; }
        public String ItemCode { get; set; }
        public String ItemName { get; set; }
        public float Recepcionado { get; set; }
        public float GuiaProductor { get; set; }
        public float Precio { get; set; }
    }


}
