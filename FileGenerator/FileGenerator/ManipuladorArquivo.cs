using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileGenerator
{
    public class ManipuladorArquivo
    {
        private string caminho = "../" + "../" + "../" + "../" + "../" + "Arquivos/";

        public void CriarArquivo(string nome, string conteudo)
        {
            if (!File.Exists(caminho + nome))
            {
                var f = File.Create(caminho + nome);
                f.Close();
            }

            StreamWriter sr = new StreamWriter(caminho + nome);
            sr.Write(conteudo);
            sr.Close();

        }
    }
}
