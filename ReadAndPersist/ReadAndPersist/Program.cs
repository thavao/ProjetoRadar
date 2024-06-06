using Repositories;
using Models;

List<Radar> r = new RadarRepository().GetTodos();

foreach (var item in r)
{
    Console.WriteLine(item);
    Console.WriteLine();
}