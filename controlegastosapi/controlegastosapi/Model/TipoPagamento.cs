using System;
using System.ComponentModel.DataAnnotations;

namespace controlegastosapi.Model
{
    public class TipoPagamento : Comum.Base
    {     
        public string Codigo { get; set; }       
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        //public Guid ItemId { get; set; }
        //public Item Item { get; set; }
    }
}
