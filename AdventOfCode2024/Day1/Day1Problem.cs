namespace AdventOfCode2024.Day1;

public class Day1Problem : BaseProblem<int, int, IEnumerable<int>>
{
    public string Part1SampleData =
        @"3   4
4   3
2   5
1   3
3   9
3   3";

    /// <inheritdoc />
    public override int Day => 1;

    /// <inheritdoc />
    public override string[] Problem1SampleData { get; } =
    [
        "3   4",
        "4   3",
        "2   5",
        "1   3",
        "3   9",
        "3   3"
    ];

    /// <inheritdoc />
    public override IEnumerable<int> ParseInput(string[] lines) => lines.Select(x =>
            x.Split(['\r', '\n', '\t', ' '], StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries))
        .SelectMany(x => x)
        .Select(x => int.Parse(x))
        .ToList();

    /// <inheritdoc />
    public override int Problem1(IEnumerable<int> input)
    {
        var left = input.Where((x, i) => i % 2 == 0).Order().ToList();
        var right = input.Where((x, i) => i % 2 == 1).Order().ToList();

        var result = left.Zip(right, (l, r) => Math.Abs(l - r)).Sum();
        return result;
    }

    /// <inheritdoc />
    public override int Problem2(IEnumerable<int> input)
    {
        var left = input.Where((x, i) => i % 2 == 0).Order().ToList();
        var right = input.Where((x, i) => i % 2 == 1).Order().ToList();

        return left.GroupJoin(right, l => l, r => r, (l, r) => l * r.Count()).Sum();
        return 0;
    }
}