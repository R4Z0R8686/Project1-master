using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZXC.MODEL.ObjectModel;

namespace ZXC.UI.Models
{
    public class ViewModelContaCliente
    {
        public Cliente cliente { get; set; }
        public Conta conta { get; set; }
        public Venda venda { get; set; }
    }
}