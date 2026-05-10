using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Policy;
using System.Text;

namespace Projeto_POO.Scripts.Plataform
{
    public class SuperNintendo : Game
    {
        public override void Install()
        {
            this.Installed = true;
        }

        public override void Run()
        {
            if (string.IsNullOrEmpty(this.RunPath))
                return;

            Process.Start(new ProcessStartInfo
            {
                FileName = RunPath,
                UseShellExecute = true
            });
        }

        public override void Uninstall()
        {
            this.Installed = false;
        }
    }
}
