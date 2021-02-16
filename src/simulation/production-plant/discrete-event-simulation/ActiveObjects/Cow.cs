using ProductionModels;
using SimSharp;
using System;
using System.Collections.Generic;

namespace ProductionSimulation.ActiveObjects
{
    /// <summary>
    /// This active object represents one Cow for Milk Yield
    /// </summary>
    public class Cow : ActiveObject<Simulation>
    {
        static int precision = 3;
        static double hourlySalary = 85;
        /// <summary>
        /// Total Number of animals milked
        /// </summary>
        public static long Milked { get; private set; }
        public static IList<ProductionModels.Milk> ProductionData { get; private set; } = new List<ProductionModels.Milk>();
        /// <summary>
        /// Total Milking time
        /// </summary>
        public static TimeSpan TotalMilkingTime { get; private set;  } = TimeSpan.Zero;
        /// <summary>
        /// Avg. processing time to milk a yak in minutes
        /// </summary>
        private static readonly TimeSpan PtMeanMilking = TimeSpan.FromMinutes(5.0);
        /// <summary>
        /// Sigma of the milking processing time in minutes
        /// </summary>
        private static readonly TimeSpan PtSigmaMilking = TimeSpan.FromMinutes(1.0);
        /// <summary>
        /// Avg. processing time to shave a yak in minutes
        /// </summary>
        private static readonly TimeSpan PtMeanShaving = TimeSpan.FromMinutes(30.0);
        /// <summary>
        /// Sigma of shaving processing time in minutes
        /// </summary>
        private static readonly TimeSpan PtSigmaShaving = TimeSpan.FromMinutes(4.0);

        public Process Process { get; private set; }
        public string Name { get; }

        /// <summary>
        /// Initializes a yak in its simulation environment.
        /// </summary>
        /// <param name="environment"></param>
        /// <param name="milker"></param>
        public Cow(Simulation environment, string name, PreemptiveResource milker, PreemptiveResource shaver) : base(environment)
        {
            Process = environment.Process(LifeCycle(milker));
            Name = name;
        }

        /// <summary>
        /// A daily event that indicates the yak can be milked.
        /// </summary>
        /// <returns>Scheduled Event</returns>
        private IEnumerable<Event> LifeCycle(PreemptiveResource milker)
        {
            while (true)
            {
                yield return Environment.Timeout(TimeSpan.FromDays(1));
                // Ready to milk the Cow
                // Request a milker. The Cow will be milked as soon as the milker is available.
                var timeToMilk = Environment.RandNormal(PtMeanMilking, PtSigmaMilking);
                using (var req = milker.Request(priority: 1, preempt: false))
                {
                    yield return req;
                    // Milker available, start milking the yak.
                    var time = Environment.RandNormal(PtMeanMilking, PtSigmaMilking);
                    TotalMilkingTime += time;
                    yield return Environment.Timeout(time);
                    // The yak is milked.
                    ProductionData.Add(new Milk()
                    {
                        Animal = new Animal() { Code = "", Name = Name },
                        Composition = new MilkComposition() { 
                            Fats        = Math.Round(Environment.RandUniform(0.055, 0.072), precision), 
                            Lactose     = Math.Round(Environment.RandUniform(0.045, 0.05),  precision), 
                            Minerals    = Math.Round(Environment.RandUniform(0.08, 0.09),   precision), 
                            Protein     = Math.Round(Environment.RandUniform(0.049, 0.053), precision), 
                            Solids      = Math.Round(Environment.RandUniform(0.169, 0.177), precision),
                        },
                        Kg = Math.Round(Environment.RandUniform(0.3, 2.9), 2),
                        ProductionInfo = new ProductionInfo() { DateOfProduction = Environment.Now, ProductionTime = time, Costs = hourlySalary/60*time.Minutes }
                    }); ;
                    Milked++;
                }
            }
        }

        private IEnumerable<Event> ShavingJob(Simulation env, PreemptiveResource shaver)
        {
            while (true)
            {
                // Start a new job
                var doneIn = Environment.RandNormal(PtMeanShaving, PtSigmaShaving);
                while (doneIn > TimeSpan.Zero)
                {
                    // Retry the job until it is done.
                    // It's priority is lower than that of milking
                    using (var req = shaver.Request(priority: 2))
                    {
                        yield return req;
                        var start = env.Now;
                        yield return env.Timeout(doneIn);
                        if (env.ActiveProcess.HandleFault())
                            doneIn -= env.Now - start;
                        else doneIn = TimeSpan.Zero;
                    }
                }
            }
        }
    }
}
