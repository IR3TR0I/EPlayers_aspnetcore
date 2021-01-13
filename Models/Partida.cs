using System;

namespace EPlayers_ASPNETCORE.Models
{
    public class Partida
    {
        public int Idpartida { get; set; }
        
        public int IdJogador1 { get; set; }
        public int Idjogador2 { get; set; }
        public DateTime  HorarioInicio { get; set; }
        public DateTime HorarioTermino { get; set; }
    }
}