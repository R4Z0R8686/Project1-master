using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZXC.MODEL.ObjectModel
{
   
    public class Cliente
    {

        public int ID { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }

        public string Mail { get; set; }

        public DateTime Data { get; set; }
    }
    
}
