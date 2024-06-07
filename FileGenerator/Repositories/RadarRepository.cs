using Microsoft.Data.SqlClient;
using Models;
using Dapper;
using MongoDB;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using System;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Repositories
{
    public class RadarRepository
    {
        public string ConnSql { get; set; }
        public string ConnMongo { get; set; }

        public RadarRepository()
        {
            ConnSql = "Data Source=127.0.0.1; Initial Catalog=RadaresBR; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes";
            ConnMongo = "mongodb://root:Mongo%402024%23@localhost:27017/";
        }

        public List<Radar> GetTodosSql()
        {
            string sql = "SELECT Concessionaria, AnoDoPnvSnv, TipoDeRadar, Rodovia, Uf, KmM, Municipio, TipoPista, Sentido, Situacao, DataDaInativacao, Latitude, Longitude, VelocidadeLeve from Radar";
            using (var db = new SqlConnection(ConnSql))
            {

                db.Open();
                var radares = db.Query<Radar>(sql).ToList();
                db.Close();

                foreach (var radar in radares)
                {
                    if (!string.IsNullOrEmpty(radar.DataDaInativacao))
                    {
                        radar.DataDaInativacaoData = radar.DataDaInativacao.Split(',')
                            .Select(dateStr => DateOnly.Parse(dateStr.Trim()))
                            .ToList();
                    }
                }
                return radares;
            }
        }

        public List<Radar> GetTodosMongo()
        {
            var client = new MongoClient(ConnMongo);
            var db = client.GetDatabase("RadaresBR");
            var colecao = db.GetCollection<BsonDocument>("Radar");


            var projecao = Builders<BsonDocument>.Projection.Exclude("_id");
            var filter = Builders<BsonDocument>.Filter.Empty;

            var documento = colecao.Find(filter).Project(projecao).ToList();

            foreach (var d in documento)
            {
                if (d["DataDaInativacao"] == BsonNull.Value)
                {
                    d["DataDaInativacao"] = "";
                }
                var radar = new Radar
                {
                    Concessionaria = d["Concessionaria"].AsString,
                    AnoDoPnvSnv = d["AnoDoPnvSnv"].AsInt32,
                    TipoDeRadar = d["TipoDeRadar"].AsString,
                    Rodovia = d["Rodovia"].AsString,
                    Uf = d["Uf"].AsString,
                    KmM = d["KmM"].AsDouble,
                    Municipio = d["Municipio"].AsString,
                    TipoPista = d["TipoPista"].AsString,
                    Sentido = d["Sentido"].AsString,
                    Situacao = d["Situacao"].AsString,
                    DataDaInativacao = d["DataDaInativacao"].AsString,
                    Latitude = d["Latitude"].AsDouble,
                    Longitude = d["Longitude"].AsDouble,
                    VelocidadeLeve = d["VelocidadeLeve"].AsInt32
                };
                
                r.Add(radar);
            }

            return r;
        }

        public void InserirTodos(List<Radar> radares)
        {
            var client = new MongoClient(ConnMongo);
            var db = client.GetDatabase("RadaresBR");
            var colecao = db.GetCollection<Radar>("Radar");

            colecao.InsertMany(radares);

        }
    }
}
