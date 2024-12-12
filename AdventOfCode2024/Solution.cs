using System.Diagnostics;

namespace AdventOfCode2024;

// public class Solution<TSolution1, TSolution2, TInput>
// {
//     public BaseProblem<TSolution1, TSolution2, TInput> Problem { get; }
//     public TSolution1 Problem1SampleDataSolution { get; }
//     public TSolution2 Problem2SampleDataSolution { get; }
//
//     public TSolution1 Problem1InputDataSolution { get; }
//     public TSolution2 Problem2InputDataSolution { get; }
//
//     public Solution(BaseProblem<TSolution1, TSolution2, TInput>problem, TSolution1 problem1SampleDataSolution, TSolution2 problem2SampleDataSolution,
//         TSolution1 problem1InputDataSolution, TSolution2 problem2InputDataSolution)
//     {
//         Problem = problem;
//         Problem1SampleDataSolution = problem1SampleDataSolution;
//         Problem2SampleDataSolution = problem2SampleDataSolution;
//         Problem1InputDataSolution = problem1InputDataSolution;
//         Problem2InputDataSolution = problem2InputDataSolution;
//     }
//
//     private IEnumerable<string> GetSolutionStrings() => new[]
//     {
//         $"{nameof(Problem1SampleDataSolution)}: {Problem1SampleDataSolution}",
//         $"{nameof(Problem2SampleDataSolution)}: {Problem2SampleDataSolution}",
//         $"{nameof(Problem1InputDataSolution)}: {Problem1InputDataSolution}",
//         $"{nameof(Problem2InputDataSolution)}: {Problem2InputDataSolution}",
//     };
//
//     public override string ToString() => $"Day {Problem.Day}:\n"
//                                          + string.Join("\n", GetSolutionStrings().Select(x => x.PadLeft(4)));
// }

public class Solution<TSolution1, TSolution2, TInput>
{
    public BaseProblem<TSolution1, TSolution2, TInput> Problem { get; }
    public TSolution1? Problem1SampleDataSolution { get; private set; }
    public TSolution2? Problem2SampleDataSolution { get; private set; }

    public TSolution1? Problem1InputDataSolution { get; private set; }
    public TSolution2? Problem2InputDataSolution { get; private set; }

    public Solution(BaseProblem<TSolution1, TSolution2, TInput>problem, TSolution1? problem1SampleDataSolution, TSolution2? problem2SampleDataSolution,
        TSolution1? problem1InputDataSolution, TSolution2? problem2InputDataSolution)
    {
        Problem = problem;
        Problem1SampleDataSolution = problem1SampleDataSolution;
        Problem2SampleDataSolution = problem2SampleDataSolution;
        Problem1InputDataSolution = problem1InputDataSolution;
        Problem2InputDataSolution = problem2InputDataSolution;
    }

    // public Solution(BaseProblem<TSolution1, TSolution2, TInput> problem)
    // {
    //     Problem = problem;
    // }

    private IEnumerable<string> GetSolutionStrings() => new[]
    {
        $"{nameof(Problem1SampleDataSolution)}: {Problem1SampleDataSolution}",
        $"{nameof(Problem2SampleDataSolution)}: {Problem2SampleDataSolution}",
        $"{nameof(Problem1InputDataSolution)}: {Problem1InputDataSolution}",
        $"{nameof(Problem2InputDataSolution)}: {Problem2InputDataSolution}",
        // $"{nameof(Problem1SampleDataSolution)}: {GetSolutionString(() => Problem.Problem1(Problem.ParseInput(Problem.SampleData)))}",
        // $"{nameof(Problem2SampleDataSolution)}: {GetSolutionString(() => Problem.Problem2(Problem.ParseInput(Problem.SampleData)))}",
        // $"{nameof(Problem1InputDataSolution)}: {GetSolutionString(() => Problem.Problem1())}",
        // $"{nameof(Problem2InputDataSolution)}: {GetSolutionString(() => Problem.Problem2())}",
    };

    private string GetSolutionString<TSolution>(Func<TSolution> problem)
    {
        var sw = Stopwatch.StartNew();
        TSolution solution;
        var result = "";
        try
        {
            solution = problem();
            result += solution.ToString();
        }
        catch (Exception ex)
        {
            result += ex.ToString();
        }
        sw.Stop();
        
        result += $"\nExecution time: ({sw.ElapsedMilliseconds}ms)";
        return result;
    }
    
    public override string ToString() => $"Day {Problem.Day}:\n"
                                         + string.Join("\n", GetSolutionStrings().Select(x => $"{x}"));
}