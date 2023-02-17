using System;
namespace oop.products;
class Product
{
    private string codeProduct;
    private string nameProduct;
    private double priceProduct;
    private int quantityStock;
    public Product(string codeProduct, string nameProduct, double priceProduct, int quantityStock)
    {
        this.codeProduct = codeProduct;
        this.nameProduct = nameProduct;
        this.priceProduct = priceProduct;
        this.quantityStock = quantityStock;
    }
    public string CodeProduct { get { return codeProduct; } set { codeProduct = value; } }
    public string NameProduct { get { return nameProduct; } set { nameProduct = value; } }
    public double PriceProduct { get { return priceProduct; } set { priceProduct = value; } }
    public int QuantityStock { get { return quantityStock; } set { quantityStock = value; } }
    static public void Title()
    {
        Console.Write("\nID\tName\tPrice\tQuantity\n");
    }
    public override string ToString()
    {
        return codeProduct + "\t" + nameProduct + "\t" + priceProduct + "\t" + quantityStock;
    }
    public bool searchProduct(string seek)
    {
        if (seek == codeProduct)
        {
            return true;
        }
        else return false;
    }
    public bool checkProduct(string check)
    {
        if (check == codeProduct)
        {
            return false;
        }
        else return true;
    }
    public bool deleteProduct(string delete)
    {
        if (delete == codeProduct)
        {
            return true;
        }
        else return false;
    }
    public void editProduct()
    {
        nameProduct = "SachGK";
        priceProduct = 79000;
        quantityStock = 1000;
    }
}
class Program
{
    static void Main()
    {
        List<Product> products = new List<Product>();
        Product[] list = new Product[]
        {
            new Product("M01", "Sach", 55000, 500),
            new Product("M02", "But", 10000, 1000),
            new Product("M03", "Do choi", 36000, 64)
        };
        products.AddRange(list);

        // Redefine the ToString() method
        Product.Title();
        foreach (dynamic venus in products)
        {
            Console.WriteLine(venus);
        }

        // Search product
        Console.Write("\nSearch product: ");
        var seek = Console.ReadLine();
        Product.Title();
        foreach (dynamic venus in products)
        {
            if (venus.searchProduct(seek) == true)
            {
                Console.WriteLine(venus);
            }
            else Console.WriteLine("Not found ", seek);
        }

        // Add product && uniqueness check
        Product objects = new Product("M04", "Pepsi", 10000, 1000);
        products.Add(objects);
        Console.Write("\n\nCheck the product is unique:");
        for (int i = 0; i < list.Length; i++)
        {
            if (objects.checkProduct(list[i].CodeProduct) == false)
            {
                Console.Write("\nFound a product with the same code as", objects.CodeProduct);
                products.Remove(objects);
            }
            else Console.Write("\n{0} doesn't coincide with {1}", list[i].CodeProduct, objects.CodeProduct);
        }

        // Delete product
        Console.WriteLine("\n\nDelete product: ");
        var delete = Console.ReadLine();
        Console.Write("\nList of products after deleting products with codes {0}:", delete);
        Product.Title();
        for (int i = 0; i < list.Length; i++)
        {
            if (list[i].deleteProduct(delete) == true)
            {
                products.Remove(list[i]);
                foreach (dynamic venus in products)
                {
                    Console.WriteLine(venus);
                }
            }
        }

        // Edit product
        Console.WriteLine("\n\nEdit product: ");
        var edit = Console.ReadLine();
        Console.Write("\nList of products after fixing products with codes {0}:", edit);
        Product.Title();
        for (int i = 0; i < list.Length; i++)
        {
            if (edit != null)
            {
                if (list[i].CodeProduct == edit)
                {
                    list[i].editProduct();
                    foreach (dynamic venus in products)
                    {
                        Console.WriteLine(venus);
                    }
                }
            }
            else Console.Write("\nNot found ", edit);
        }
    }
}
