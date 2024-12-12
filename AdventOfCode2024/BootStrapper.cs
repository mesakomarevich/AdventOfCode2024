using Grace.DependencyInjection;

namespace AdventOfCode2024;

public static class BootStrapper
{
    public static DependencyInjectionContainer Setup(this DependencyInjectionContainer container)
    {
        container.Configure(x => x.ExportAssembly(Constants.CurrentAssembly)
            .BasedOn(typeof(IProblem))
            .ByInterface<IProblem>());

        return container;
    }
}