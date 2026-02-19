using System.ComponentModel;

public class invalidProductException : Exception
{
    public invalidProductException(string message) : base(message)
    {
        
    }
}
public enum Categroy
{
    Electronics ,
    Clothing , 
    Books , 
    Groceries 
}
public interface IProduct
{
    public int Id {get; set;}
    public string Name {get; set;}
    public int Price {get; set;}
    
    public Category Categroy {get; set;}
}

public class ProductRepo <T> where T : class , IProduct // contraint are that t should be a reference type and should implement the IProduct 
{
    private List<T> _products = new List<T>();

    public void AddProduct(T product)
    {
        foreach(var item in _products)
        {
            if (product.Id == item.id)
            {
                throw new invalidProductException("this id product exist already");
            }
        }
        if (product.Price < 0)
        {
            throw new invalidProductException("price cant be negative");
        }
        if (string.IsNullOrEmpty(product.Name))
        {
            throw new invalidProductException("name can be null");
        }
        _products.Add(product);

    }
}