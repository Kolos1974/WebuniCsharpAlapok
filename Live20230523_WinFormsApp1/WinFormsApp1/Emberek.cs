using System;
using System.Collections.Generic;

namespace WinFormsApp1
{
    public partial class Emberek
    {
        public int Id { get; set; }
        public int Szev { get; set; }
        public string Nev { get; set; } = null!;
        public string? Tel { get; set; }



        public override string ToString()
        {
            return $"{Nev} - {Szev} --- {Tel} ";
        }
    }
}
