using ProductionSimulation.Extensions;
using SimSharp;
using System;
using System.Linq;

namespace ProductionSimulation
{
    public class Sim
    {
        private static string[] YakNames = { "Abby", "Amazone", "Amber", "Annabelle", "Apple", "April", "Arizone", "Autumn", "Babette", "Babs", "Baby", "Barbara", "Bella", "Belle", "Bernice", "Bertha", "Bess", "Bessy", "Beth", "Betsy", "Booboo", "Brooke", "Brownie", "Bubble", "Bubbles", "Bumble", "Bumbles", "Butter", "Buttercup", "Button", "Buttons", "Caramel", "Caramelle", "Chancey", "Charme", "Chloe", "Cinnamon", "Clarabell", "Clover", "Coco", "Cookie", "Corona", "Creame", "Creme", "Cutie", "Daffodil", "Daisy", "Dala", "Darcy", "Darla", "Dear", "Dew", "Dolly", "Dora", "Doris", "Dot", "Dottie", "Dream", "Dutchess", "Eleanor", "Fancy", "Flower", "Fortuna", "Fortune", "Freckles", "Gambles", "Ginger", "Grace", "Gracie", "Gwen", "Hazel", "Honey", "Isabella", "Jade", "Jane", "Jess", "July", "June", "Lavender", "Lilly", "Lily", "Lilypad", "Lola", "Lulu", "Magnolia", "Maple", "Marge", "Marigold", "Martha", "Maude", "May", "Midnight", "Moode", "Mooffin", "Moogy", "Moolissa", "Moolly", "Mooly", "Moomee", "Moomoo", "Moomy", "Moona", "Moonbeam", "Moonica", "Muffin", "Nemoo", "Nighte", "Nora", "Olive", "Oreo", "Patches", "Patience", "Pearl", "Penny", "Pepper", "Petunia", "Pickle", "Pickles", "Precious", "Princess", "Prudence", "Pumpkin", "Queen", "Queenie", "Queste", "Rose", "Rosie", "Ruby", "Satin", "Savanah", "Shade", "Shadow", "Snow", "Snowdrop", "Snowflake", "Sparkle", "Spot", "Spring", "Sprinkles", "Sugar", "Summer", "Sunbeam", "Sweetie", "Valentine", "Viola", "Violet", "Wendy", "Willow", "Winter" };
        public void Start(int rseed = 42)
        {
            YakNames = YakNames.ToList().Shuffle().ToArray();
            // Setup and start the simulation
            // Create an environment and start the setup process
            var start = DateTime.Now;
            var env = new Simulation(start, rseed);
            env.Log("== Dairy Production Plant ==");
            var milker = new PreemptiveResource(env, 1);
            var shaver = new PreemptiveResource(env, 1);
            var yaks = Enumerable.Range(0, 20).Select(x => new ActiveObjects.Cow(env, YakNames[x], milker, shaver)).ToArray();
            //env.Process(ShavingJobs(env, shaver));
            var startPerf = DateTime.UtcNow;
            // Execute!
            env.Run(TimeSpan.FromDays(365));
            var perf = DateTime.UtcNow - startPerf;
            // Analyis/results
            env.Log("Dairy Production Plant results after {0} days.", (env.Now - start).TotalDays);
            env.Log(string.Empty);
            env.Log("Processed {0} events in {1} seconds ({2} events/s).", env.ProcessedEvents, perf.TotalSeconds, (env.ProcessedEvents / perf.TotalSeconds));
            env.Log($"Milked: { ActiveObjects.Cow.Milked} animals.");
            env.Log($"Total Milking Timed: { ActiveObjects.Cow.TotalMilkingTime}.");
        }
    }
}
