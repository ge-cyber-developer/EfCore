using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EfCore.Domains
{
    public class Pedido : BaseDomain
    {
        [Key]
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public float Preco { get; set; }

        public List<PedidoItem> PedidoItem { get; set; }

    }
}
