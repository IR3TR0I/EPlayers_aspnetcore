using System.Collections.Generic;
using System.IO;
using EPlayers_ASPNETCORE.Interfaces;

namespace EPlayers_ASPNETCORE.Models
{
    public class Equipe : EPlayersBase , IEquipe
    {
        // ID - identificador único
        public int IdEquipe { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }
        public object e { get; private set; }

        private const string path = "Database/Equipe.csv";

        public Equipe()
        {
            CreateFolderAndFile(path);
        }
        
        
        public string Prepare(Equipe e)
        {
            return $"{e.IdEquipe};{e.Nome};{e.Imagem}";
        }

        public void Create(Equipe novaEquipe)
        {
            string[] linhas = { Prepare(novaEquipe) };
            File.AppendAllLines(path, linhas); 
        }

        public List<Equipe> ReadAll()
        {
            List<Equipe> equipes = new List<Equipe>();

            string[] linhas = File.ReadAllLines(path);

            foreach(var item in linhas)
            {
                string[] linha = item.Split(";");


                Equipe equipe = new Equipe();

                equipe.IdEquipe = int.Parse( linha[0] );
                equipe.Nome   = linha[1];
                equipe.Imagem = linha[2];

                equipes.Add(equipe);
            }
            return equipes;
        }

        public void Update(Equipe e)
        {
            List<string> linhas = ReadAllLinesCSV(path);

            linhas.RemoveAll(x => x.Split(";")[0] == e.IdEquipe.ToString());

            linhas.Add(Prepare(e) );
            RewriteCSV(path , linhas);
        }

        private string Prepare(object e)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            List<string> linhas = ReadAllLinesCSV(path);

            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());

            RewriteCSV(path , linhas);
        }
    }
}