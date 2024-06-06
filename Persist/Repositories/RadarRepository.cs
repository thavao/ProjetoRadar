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

        public void InserirTodos(List<Radar> radares)
        {
            string sql = "INSERT INTO Radar (Concessionaria, AnoDoPnvSnv, TipoDeRadar, Rodovia, Uf, KmM, Municipio, TipoPista, Sentido, Situacao, DataDaInativacao, Latitude, Longitude, VelocidadeLeve)" +
                "VALUES (@Concessionaria, @AnoDoPnvSnv, @TipoDeRadar, @Rodovia, @Uf, @KmM, @Municipio, @TipoPista, @Sentido, @Situacao, @DataDaInativacao, @Latitude, @Longitude, @VelocidadeLeve)";
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                db.Execute(sql, radares);
                db.Close();
            }
        }
        /*public void Inserir(Radar radar)
        {
            string sql = "INSERT INTO Radar (Concessionaria, AnoDoPnvSnv, TipoDeRadar, Rodovia, Uf, KmM, Municipio, TipoPista, Sentido, Situacao, DataDaInativacao, Latitude, Longitude, VelocidadeLeve)" +
                "VALUES (@Concessionaria, @AnoDoPnvSnv, @TipoDeRadar, @Rodovia, @Uf, @KmM, @Municipio, @TipoPista, @Sentido, @Situacao, @DataDaInativacao, @Latitude, @Longitude, @VelocidadeLeve)";
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                db.Execute(sql, radar);
                db.Close();
            }
        }*/
    }
}
