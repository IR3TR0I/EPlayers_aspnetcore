using System.Collections.Generic;
using EPlayers_ASPNETCORE.Models;

namespace EPlayers_ASPNETCORE.Interfaces
{
    public interface IEquipe
    {
         //CRUD
         void Create(Equipe novaEquipe);
         List<Equipe> ReadAll();
         void Update(Equipe equipeAlterada);
         void Delete(int idEquipe);
    }
}