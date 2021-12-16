using System;
using System.ComponentModel.DataAnnotations;

namespace controlegastosapi.Model
{
    public class Fatura : Comum.Base
    {

        public string mes { get; set; }
        public string ano { get; set; }
        public DateTime DataInicio { get; set; }       
        public DateTime DataFinal { get; set; }
        public string Observacao { get; set; }
        //public Guid ItemId { get; set; }
        //public Item Item { get; set; }
    }
}
