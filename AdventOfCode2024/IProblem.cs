namespace AdventOfCode2024;

public interface IProblem
{
    public string InputFilePath { get; }
    public int Day { get; }
    public string[] Problem1SampleData { get; }
    public string[] Problem2SampleData { get; }
    public string Solve();
}