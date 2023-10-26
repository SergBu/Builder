//  намеренье Builder  (creational design pattern) - отделить конструктор сложного объекта от его представления Product(a, b, c, d, e, ...)

IBuilder builder = new ConcreteBuilder1();
Director.Construct(builder);
var product = builder.GetProduct();
Console.WriteLine(product);

builder = new ConcreteBuilder2();
Director.Construct(builder);
product = builder.GetProduct();
Console.WriteLine(product);


//  Director не создает и не собирает объекты напрамую Product(a, b, c, d, e, ...)
// он ссылается на IBuilder для построения частей сложного объекта
public static class Director
{
    public static void Construct(IBuilder builder) => builder.BuildParts();
}

public interface IBuilder
{
    void BuildParts();
    Product GetProduct();
}

// каждый ConcreteBuilder создает и собирает вид продукта с его компонентами
public class ConcreteBuilder1 : IBuilder
{
    Product product = new Product();
    public void BuildParts()
    {
        product.AddComponents(new List<IComponent> { new ConcreteComponent1("турбодизель"), new ConcreteComponent2("гусиницы") });
    }

    public Product GetProduct() => product;

}

public class ConcreteBuilder2 : IBuilder
{
    Product product = new Product();
    public void BuildParts()
    {
        product.AddComponents(new List<IComponent> { new ConcreteComponent1("электродвигатель"), new ConcreteComponent1("двс v6"), new ConcreteComponent2("колёса") });
    }

    public Product GetProduct() => product;
}

// Product и ConcreteComponent классы будут использованы в сборочном процессе в ConcreteBuilder
public class Product
{
    IList<IComponent> components;
    public void AddComponents(IList<IComponent> components)
    {
        this.components = components;
    }

    public override string ToString()
    {
        return $"Продукт состоит из компонентов: {string.Join(", ", components)}";
    }
}

public interface IComponent
{
}

public class ConcreteComponent1 : IComponent
{
    string name;
    public ConcreteComponent1(string name)
    {
        this.name = name;
    }

    public override string ToString()
    {
        return $"Компонент: {name}";
    }
}

public class ConcreteComponent2 : IComponent
{
    string name;
    public ConcreteComponent2(string name)
    {
        this.name = name;
    }

    public override string ToString()
    {
        return $"Компонент: {name}";
    }
}


