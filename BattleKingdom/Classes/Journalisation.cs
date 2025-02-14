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

        /// <summary>
        /// Trace dans le fichier
        /// </summary>
        /// <param name="texte">Le texte à tracer</param>
        internal static void Tracer(string texte)
        {
            Trace.WriteLine($"{DateTime.Now} : {texte}");
        }

        /// <summary>
        /// Trace dans un textbox
        /// </summary>
        /// <param name="texte">Texte à tracer</param>
        /// <param name="txtTrace">Textbox à tracer dedans</param>
        public static void Tracer(string texte, TextBox txtTrace)
        {
            Tracer(texte);
            txtTrace.Text += texte + "\n\r";
            txtTrace.ScrollToEnd();
        }   
    }
}
