using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace STRCK_Flasher
{
    internal static class Program
    {
        /// <summary>
        /// Hlavní vstupní bod aplikace.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (File.Exists("avrdude.exe") && File.Exists("avrdude.conf"))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            else
            {
                MessageBox.Show("Chybí důležité soubory programu. Program bude ukončen", "Kritická chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);   
            }
            
        }
    }
}
