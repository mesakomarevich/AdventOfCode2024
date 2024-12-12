using System.Reflection;

namespace AdventOfCode2024;

public static class Constants
{
    public static Assembly CurrentAssembly => typeof(Constants).Assembly;
    public const StringSplitOptions SplitOptions = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;
}