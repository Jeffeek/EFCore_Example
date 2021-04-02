#region Using namespaces

using System;
using System.Linq;
using System.Threading.Tasks;
using EFCore_Example.Infrastructure;
using EFCore_Example.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

#endregion

namespace EFCore_Example.UI
{
    internal class Program
    {
        private static readonly Random Random = new();

        private static async Task Main(string[] args)
        {
            await using var db = new ClownsContext();

            // пройтись по всем сущностям и поменять значения
            await db.Clowns.ForEachAsync(x => x.Name = "баран");

            // сохранение текущего состояния контекста
            await db.SaveChangesAsync();

            // фильтрация данных
            var clowns2 = await db.Clowns
                                  .Where(x => x.Name == "баран")
                                  .ToListAsync();

            // вывод всех клоунов с именем "баран"
            foreach (var item in clowns2)
                Console.WriteLine(item.Name);

            // получение самого первого клоуна
            var firstClown = await db.Clowns.FirstOrDefaultAsync();

            // устанавливаем новое значение свойства
            firstClown.Age = 10;

            await db.SaveChangesAsync();

            var clownToRemove = db.Clowns.ElementAtOrDefault(10);

            // удаление
            if (clownToRemove is not null)
            {
                db.Clowns.Remove(clownToRemove);
                await db.SaveChangesAsync();
            }

            #region Generate and fill

            //var clowns = Enumerable.Range(0, 100)
            //                       .Select(x => CreateClown())
            //                       .ToArray();

            //var circuses = Enumerable.Range(0, 10)
            //                         .Select(x => CreateCircus())
            //                         .ToArray();

            //var events = Enumerable.Range(0, 30)
            //                       .Select(x => CreateCircusEvent(circuses));

            //var performances = Enumerable.Range(0, 200)
            //                             .Select(x => CreateClownPerformance(clowns, circuses));

            //await using var context = new ClownsContext();
            //await context.Clowns.AddRangeAsync(clowns);
            //await context.Circuses.AddRangeAsync(circuses);
            //await context.Events.AddRangeAsync(events);
            //await context.ClownPerformances.AddRangeAsync(performances);
            //await context.SaveChangesAsync();

            #endregion
        }

        #region Generate section

        private static ClownEntity CreateClown() =>
            new()
            {
                Age = Random.Next(7, 90),
                Name = Guid.NewGuid().ToString().Substring(0, 10)
            };

        private static ClownPerformanceEntity CreateClownPerformance(ClownEntity[] clowns, CircusEntity[] circuses) =>
            new()
            {
                Circus =
                    circuses[Random.Next(0,
                                         circuses
                                             .Length)],
                Clown =
                    clowns[Random.Next(0,
                                       clowns
                                           .Length)],
                Title = Guid.NewGuid()
                            .ToString()
                            .Substring(0, 11)
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

        #endregion
    }
}