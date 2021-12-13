using System;
using System.ComponentModel.DataAnnotations;

namespace controlegastosapi.Model
{
    public class Item
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime Data { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Produto { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Loja { get; set; }
        public string Local { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int NumeroParcela { get; set; }
        public int QuantidadeParcelas { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }
        public string Observacao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}
