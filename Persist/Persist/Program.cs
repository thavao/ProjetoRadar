using Controllers;
using Models;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Repositories;
using System.Globalization;
string caminho = "../" + "../" +"../" +"../" + "../" + "Arquivos";

//string caminho = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..", @"..", @"..", @"..", @".."));
string arquivo = @"\dados_dos_radares.json";


var settings = new JsonSerializerSettings
{
    Culture = new CultureInfo("pt-BR"),
    DateFormatString = "dd/MM/yyyy"
};

StreamReader sr = new StreamReader(caminho + arquivo);
string json = sr.ReadToEnd();

var r = JsonConvert.DeserializeObject<Radares>(json, settings);


List<Radar> radares =  r.RadaresBrasil;

new RadarController().InserirTodos(radares);
