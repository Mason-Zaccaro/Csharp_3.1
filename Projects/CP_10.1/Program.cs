using System;
using System.Collections.Generic;

// 1. Ограниченный интерфейс IRepository<T>
public interface IEntity
{
    int Id { get; }
}

public interface IRepository<T> where T : IEntity
{
    void Add(T item);
    void Delete(T item);
    T FindById(int id);
    IEnumerable<T> GetAll();
}

public class Product : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

public class Customer : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
}

public class ProductRepository : IRepository<Product>
{
    private List<Product> products = new List<Product>();

    public void Add(Product item) => products.Add(item);
    public void Delete(Product item) => products.Remove(item);
    public Product FindById(int id) => products.Find(p => p.Id == id);
    public IEnumerable<Product> GetAll() => products;
}

public class CustomerRepository : IRepository<Customer>
{
    private List<Customer> customers = new List<Customer>();

    public void Add(Customer item) => customers.Add(item);
    public void Delete(Customer item) => customers.Remove(item);
    public Customer FindById(int id) => customers.Find(c => c.Id == id);
    public IEnumerable<Customer> GetAll() => customers;
}