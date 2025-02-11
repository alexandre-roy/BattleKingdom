using System;
using System.Diagnostics;
using System.Windows.Controls;
namespace BattleKingdom.Classes
{
    public static class Journalisation
    {
        public static void Tracer(string texte, TextBox txtTrace)
        {
            string logMessage = $"{DateTime.Now}: {texte}";
            Tracer(logMessage);
            txtTrace.AppendText(logMessage + Environment.NewLine); 
        }

        internal static void Tracer(string texte)
        {
            Trace.WriteLine(texte);
        }
    }
}
