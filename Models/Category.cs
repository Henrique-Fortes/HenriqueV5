
using System;
using System.Collections.Generic;

namespace HenriqueV5.Models
{
    public class Category
    {
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        internal object Select(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
    }
}