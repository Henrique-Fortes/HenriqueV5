using System.Collections.Generic;

namespace HenriqueV5.Models
{
    public class Supplier
    {
        public long SupplierId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}