﻿using Newtonsoft.Json;
using System.Xml.Linq;
namespace Models
{
    public class Radar
    {
        [JsonProperty("concessionaria")]
        public string Concessionaria { get; set; }

        [JsonProperty("ano_do_pnv_snv")]
        public int AnoDoPnvSnv { get; set; }

        [JsonProperty("tipo_de_radar")]
        public string TipoDeRadar { get; set; }

        [JsonProperty("rodovia")]
        public string Rodovia { get; set; }

        [JsonProperty("uf")]
        public string Uf { get; set; }

        [JsonProperty("km_m")]
        public double KmM { get; set; }

        [JsonProperty("municipio")]
        public string Municipio { get; set; }

        [JsonProperty("tipo_pista")]
        public string TipoPista { get; set; }

        [JsonProperty("sentido")]
        public string Sentido { get; set; }

        [JsonProperty("situacao")]
        public string Situacao { get; set; }

        [JsonProperty("data_da_inativacao")]
        public DateTime[]? DataDaInativacao { get; set; } = null;

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("velocidade_leve")]
        public int VelocidadeLeve { get; set; }

        public override string ToString()
        { 
            return
               $"Concessionária....: {Concessionaria}\n" +
               $"Ano do PNV/SNV....: {AnoDoPnvSnv}\n" +
               $"Tipo de radar.....: {TipoDeRadar}\n" +
               $"Rodovia...........: {Rodovia}\n" +
               $"UF................: {Uf}\n" +
               $"Km/m..............: {KmM}\n" +
               $"Município.........: {Municipio}\n" +
               $"Tipo de pista.....: {TipoPista}\n" +
               $"Sentido...........: {Sentido}\n" +
               $"Situação..........: {Situacao}\n" +
               $"Data da inativação: {(DataDaInativacao.Length != 0 ? DataDaInativacao.Last().ToString("yyyy-MM-dd") : "N/A")}\n" +
               //{string.Join(", ", DataDaInativacao)}
               $"Latitude..........: {Latitude}\n" +
               $"Longitude.........: {Longitude}\n" +
               $"Velocidade limite.: {VelocidadeLeve}";

        }

        public string ToCSV()
        {
            return $"{Concessionaria};{AnoDoPnvSnv};{TipoDeRadar};{Rodovia};{Uf};{KmM};{Municipio};{TipoPista};{Sentido};{Situacao};" +
                   $"{(DataDaInativacao != null ? DataDaInativacao.Last().ToString("yyyy-MM-dd") : "N/A")};{Latitude};{Longitude};{VelocidadeLeve}";
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public string ToXML()
        {


            var xml = new XElement("radar",
                        new XElement("concessionaria", Concessionaria),
                        new XElement("ano_do_pnv_snv", AnoDoPnvSnv),
                        new XElement("tipo_de_radar", TipoDeRadar),
                        new XElement("rodovia", Rodovia),
                        new XElement("uf", Uf),
                        new XElement("km_m", KmM),
                        new XElement("municipio", Municipio),
                        new XElement("tipo_pista", TipoPista),
                        new XElement("sentido", Sentido),
                        new XElement("situacao", Situacao),
                        new XElement("data_da_inativacao", (DataDaInativacao != null ? DataDaInativacao.Last().ToString("yyyy-MM-dd") : string.Empty)),
                        new XElement("latitude", Latitude),
                        new XElement("longitude", Longitude),
                        new XElement("velocidade_leve", VelocidadeLeve)
            );

            return xml.ToString();
        }
    }
}

