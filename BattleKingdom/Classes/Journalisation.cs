using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Controls;
namespace BattleKingdom.Classes
{
    public static class Journalisation
    {      
        static Journalisation()
        {
            Stream leFichier = File.Create("FichierTrace.txt");
            TextWriterTraceListener leListener = new TextWriterTraceListener(leFichier);
            Trace.AutoFlush = true;
            Trace.Listeners.Add(leListener);
        }

        internal static void Tracer(string texte)
        {
            Trace.WriteLine($"{DateTime.Now} : {texte}");
        }

        public static void Tracer(string texte, TextBox txtTrace)
        {
            Tracer(texte);
            txtTrace.Text += texte + "\n\r";
            txtTrace.ScrollToEnd();
        }   
    }
}
