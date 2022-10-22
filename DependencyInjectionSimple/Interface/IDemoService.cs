using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

