using Controllers;
using FileGenerator;
using Models;
using Repositories;

string s = "";

ManipuladorArquivo manipulador = new();

void CriarArquivosVindosDoMongo()
{
    List<Radar> r = new RadarController().GetTodosMongo();

    s = "";
    foreach (var item in r)
    {
        s += item.ToCSV() + "\n";
    }
    manipulador.CriarArquivo("radaresMongo.csv", s);
    s = "";

    foreach (var item in r)
    {
        s += item.ToXML() + "\n";
    }

    manipulador.CriarArquivo("radaresMongo.xml", s);
    s = "";

    foreach (var item in r)
    {
        s += item.ToJson() + "\n";
    }
    manipulador.CriarArquivo("radaresMongo.json", s);
    s = "";
}
void CriarArquivosVindosDoSql()
{
    List<Radar> r = new RadarController().GetTodosSql();

    s = "";
    foreach (var item in r)
    {
        s += item.ToCSV() + "\n";
    }
    manipulador.CriarArquivo("radaresSql.csv", s);
    s = "";

    foreach (var item in r)
    {
        s += item.ToXML() + "\n";
    }

    manipulador.CriarArquivo("radaresSql.xml", s);
    s = "";

    foreach (var item in r)
    {
        s += item.ToJson() + "\n";
    }
    manipulador.CriarArquivo("radaresSql.json", s);
    s = "";

}

CriarArquivosVindosDoMongo();
CriarArquivosVindosDoSql();

Console.WriteLine("FIM");