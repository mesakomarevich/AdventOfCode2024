namespace AdventOfCode2024;

public abstract class BaseProblem<TSolution1, TSolution2, TInput> : IProblem
{
    public const string InputFileName = "input.txt";

    public string InputFilePath => $"Day{Day}\\{InputFileName}";

    public abstract int Day { get; }

    public abstract string[] Problem1SampleData { get; }

    public virtual string[] Problem2SampleData => Problem1SampleData;

    public TInput ParseInput() => ParseInput(File.ReadAllLines(InputFilePath));
    
    public virtual TInput ParseInput(string path) => ParseInput(File.ReadAllLines(path));
    
    public abstract TInput ParseInput(string[] lines);

    public TSolution1 Problem1() => Problem1(ParseInput());
    public abstract TSolution1 Problem1(TInput input);

    public TSolution2 Problem2() => Problem2(ParseInput());
    public abstract TSolution2 Problem2(TInput input);

    private T? SolveProblem<T>(Func<T> problem)
    {
        T? result = default;
        try
        {
            result = problem();
        }
        catch (Exception e)
        {
            //Console.WriteLine(e);
        }

        return result;
    }

    public string Solve()
    {
        var problem1SampleDataSolution = SolveProblem(() => Problem1(ParseInput(Problem1SampleData)));
        var problem2SampleDataSolution = SolveProblem(() => Problem2(ParseInput(Problem2SampleData)));
        var problem1InputDataSolution = SolveProblem(() => Problem1());
        var problem2InputDataSolution = SolveProblem(() => Problem2());
        return new Solution<TSolution1, TSolution2, TInput>(
                this,
                problem1SampleDataSolution,
                problem2SampleDataSolution,
                problem1InputDataSolution,
                problem2InputDataSolution)
            .ToString();
        // return new Solution<TSolution1, TSolution2, TInput>(this)
        //     .ToString();
    }

    // public string Solve()
    // {
    //     return new Solution<TSolution1, TSolution2, TInput>(
    //             this,
    //             Problem1(ParseInput(Problem1SampleData)),
    //             Problem2(ParseInput(Problem2SampleData)),
    //             Problem1(),
    //             Problem2())
    //         .ToString();
    //     // return new Solution<TSolution1, TSolution2, TInput>(this)
    //     //     .ToString();
    // }
}