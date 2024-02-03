using ConsumerProducer;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace ConsumerProducerTests
{
    public class UnitTest1
    {
        private Stopwatch stopWatch = new Stopwatch();
        private List<long> timesInMs = new List<long>();
        private const int LOOP_COUNT = 10; 

        [Fact]
        public void CalculateBaseLineAvgTime()
        {
            long totalTimeMs = 0;
            for(int i = 0; i < LOOP_COUNT; i++)
            {
                var test = new Baseline();
                stopWatch.Start();
                test.LoadFiles();
                test.ResolveNames();
                stopWatch.Stop();
                totalTimeMs += stopWatch.ElapsedMilliseconds;
                timesInMs.Add(stopWatch.ElapsedMilliseconds);
                stopWatch.Reset();
            }
            var averageTime = totalTimeMs / LOOP_COUNT;
        }
    }
}