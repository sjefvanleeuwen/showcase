using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProductionSimulation;
using System.IO;
using System.Text.Json;

namespace HerdSimulation
{
    public class Program
    {
     
        public static void Main(string[] args)
        {
            // Create production data to test our application.
            Sim sim = new Sim();
            sim.Start();
            // Serialize to disk, for later analysis.
            File.WriteAllText(@"production-data.json" , JsonSerializer.Serialize(ProductionSimulation.ActiveObjects.Cow.ProductionData));
        }
    }
}
