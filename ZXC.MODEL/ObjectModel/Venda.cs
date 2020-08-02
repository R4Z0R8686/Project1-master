using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZXC.MODEL.ObjectModel
{
    public class Venda
    {
        public int ID { get; set; }

        public string Conta { get; set; }

        public string Produto { get; set; }

        public int Meses { get; set; }

        public decimal Valor { get; set; }

        public DateTime Validade_Anterior { get; set; }

        public DateTime Validade_Atual { get; set; }

        public DateTime Data { get; set; }
    }
}
