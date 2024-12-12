using AdventOfCode2024.Day1;
using Grace.DependencyInjection;

namespace AdventOfCode2024;

class Program
{
    static async Task Main(string[] args)
    {
        var container = new DependencyInjectionContainer();
        container.Setup();
        container.LocateAll<IProblem>()
            .OrderBy(x => x.Day)
            .Select(x => x.Solve())
            .ForEach(x => Console.WriteLine(x));
    }
}