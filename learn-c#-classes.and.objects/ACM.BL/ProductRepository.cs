using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class ProductRepository
    {
        public Product Retrieve(int productId)
        {
            //crearea unei instante din clasa Product
            Product product = new Product(productId);

            if (productId==2)
            {
                product.ProductName = "Sunflowers";
                product.ProductDescription = "Assorted Size Set of 4 Bright Yellow Mini Sunflowers";
                product.CurrentPrice = 15.96M;
            }
            Object myObject = new Object();
            Console.WriteLine($"Object:{myObject.ToString()}");
            Console.WriteLine($"Product:{product.ToString()}");
            return product;
        }
        public bool Save(Product product)
        {
            var success = true;
            if (product.HasChanges)
            {
                if(product.IsValid)
                    {


                    if (product.IsNew)
                    {
                        //apelam o procedura inserata 
                    }
                    else
                    {
                        //apelam o procedura actualizata
                    }
                }
                else
                {
                    success = false;
                }
            }
            return success;
        }
        
    }
}
