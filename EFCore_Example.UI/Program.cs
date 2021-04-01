#region Using namespaces

using System;
using System.Linq;
using System.Threading.Tasks;
using EFCore_Example.Infrastructure;
using EFCore_Example.Infrastructure.Entities;

#endregion

namespace EFCore_Example.UI
{
    internal class Program
    {
        private static readonly Random Random = new();

        private static async Task Main(string[] args)
        {
            var clowns = Enumerable.Range(0, 100).Select(x => CreateClown()).ToArray();
            var circuses = Enumerable.Range(0, 10).Select(x => CreateCircus()).ToArray();
            var events = Enumerable.Range(0, 30).Select(x => CreateCircusEvent(circuses));
            var performances = Enumerable.Range(0, 200).Select(x => CreateClownPerformance(clowns, circuses));

            await using var context = new ClownsContext();
            await context.Clowns.AddRangeAsync(clowns);
            await context.Circuses.AddRangeAsync(circuses);
            await context.Events.AddRangeAsync(events);
            await context.ClownPerformances.AddRangeAsync(performances);
            await context.SaveChangesAsync();
        }

        private static ClownEntity CreateClown() =>
            new()
            {
                Age = Random.Next(7, 90),
                Name = Guid.NewGuid().ToString().Substring(0, 10)
            };

        private static ClownPerformanceEntity CreateClownPerformance(ClownEntity[] clowns, CircusEntity[] circuses) =>
            new()
            {
                Circus = circuses[Random.Next(0, circuses.Length)],
                Clown = clowns[Random.Next(0, clowns.Length)],
                Title = Guid.NewGuid().ToString().Substring(0, 11)
            };

        private static CircusEntity CreateCircus() =>
            new()
            {
                Address = Guid.NewGuid().ToString().Substring(0, 7)
            };

        private static CircusEventEntity CreateCircusEvent(CircusEntity[] circuses) =>
            new()
            {
                Circus = circuses[Random.Next(0, circuses.Length)],
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(Random.Next(1, 100)),
                Title = Guid.NewGuid().ToString().Substring(0, 6)
            };
    }
}