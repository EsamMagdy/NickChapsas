using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace BenchmarkingExample
{
    // A diagnoser can attach to your benchmark and get some useful info.
    [MemoryDiagnoser]

    // Orderers allows customizing the order of benchmark results in the summary table.
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]

    /* used to display the rank of benchmarked methods 
     * or jobs in the summary table generated after running benchmarks. 
     * It helps you quickly identify which method 
     * or job performed the best in terms of a specific metric (e.g., execution time or memory allocation).
    */
    [RankColumn]
    public class DateParserBenchMarkers
    {
        private const string DateTime = "2023-09-13T11:51:06Z";
        private readonly DateParser Parser = new DateParser();

        [Benchmark]
        public void GetYearFromDateTime()
        {
            Parser.GetYearFromDateTime(DateTime);
        }

        [Benchmark]
        public void GetYearFromSplit()
        {
            Parser.GetYearFromSplit(DateTime);
        }

        [Benchmark]
        public void GetYearFromSubstring()
        {
            Parser.GetYearFromSubstring(DateTime);
        }

        [Benchmark]
        public void GetYearFromSpan()
        {
            Parser.GetYearFromSpan(DateTime);
        }
    }
}
