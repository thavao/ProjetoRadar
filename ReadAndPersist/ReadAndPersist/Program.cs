using Repositories;
using Models;
using Controllers;

List<Radar> r = new RadarRepository().GetTodos();

new RadarController().InserirTodos(r);
Console.WriteLine("FIM");