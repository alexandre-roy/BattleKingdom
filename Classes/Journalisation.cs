using System;
using System.Diagnostics;
namespace BattleKingdom.Classes
{
    public static class Journalisation
    { 
        public static void Tracer(string texte, System.Windows.Controls.TextBox txtTrace)
        {

        }

        internal static void Tracer(string texte)
        {
            Trace.WriteLine(texte);
        }
    }
}
