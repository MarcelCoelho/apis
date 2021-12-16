using System;
using System.ComponentModel.DataAnnotations;

namespace controlegastosapi.Model
{
    public class Item : Comum.Base
    {      
        public DateTime Data { get; set; }
        public Fatura Fatura { get; set; }
        
        public TipoPagamento TipoPagamento { get; set; }
        public string Produto { get; set; }       
        public string Loja { get; set; }
        public string Local { get; set; }
        public int NumeroParcela { get; set; }
        public int QuantidadeParcelas { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
        public string Observacao { get; set; }
    }
}
