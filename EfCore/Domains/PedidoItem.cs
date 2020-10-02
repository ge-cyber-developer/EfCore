using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore.Domains
{
    public class PedidoItem : BaseDomain
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("IdPedido")]
        public Guid IdPedido { get; set; }
        public Pedido Pedido { get; set; }
        public Guid IdProduto { get; set; }
        [ForeignKey("IdProduto")]
        public Produto Produto { get; set; }

    }
}
