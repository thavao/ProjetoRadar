using Microsoft.Data.SqlClient;
using Models;
using Dapper;

namespace Repositories
{
    public class RadarRepository
    {
        public string Conn { get; set; }

        public RadarRepository()
        {
            Conn = "Data Source=127.0.0.1; Initial Catalog=RadaresBR; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes";
        }

        public List<Radar> GetTodos()
        {
            string sql = "SELECT Concessionaria, AnoDoPnvSnv, TipoDeRadar, Rodovia, Uf, KmM, Municipio, TipoPista, Sentido, Situacao, DataDaInativacao, Latitude, Longitude, VelocidadeLeve from Radar";
            using (var db = new SqlConnection(Conn))
            {
                
                db.Open();
                var radares = db.Query<Radar, DateOnly, Radar>(sql, (r, data) =>
                {
                    r.DataDaInativacao.Add(data);
                    return r;
                }, splitOn: "DataDaInativacao");
                db.Close();

                return (List<Radar>)radares;
            }
        }
    }
}
