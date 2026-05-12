using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto_POO.Scripts
{
    public abstract class Game
    {
        public string Name { get; set; } = string.Empty;
        public string CoverPath { get; set;  } = string.Empty;
        public string RunPath { get; set; } = string.Empty;
        public bool Favorite { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Size {  get; set; }
        public bool Installed { get; set; }

        public abstract void Run();
        public abstract void Uninstall();
        public abstract void Install();
    }
}
