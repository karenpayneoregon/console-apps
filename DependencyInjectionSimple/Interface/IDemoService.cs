namespace DependencyInjectionSimple.Interface;

public interface IDemoService
{
    public void Hello();
}

public class DemoService : IDemoService
{
    public void Hello()
    {
        Console.WriteLine($"Hello from {nameof(DemoService)}");
    }
}

