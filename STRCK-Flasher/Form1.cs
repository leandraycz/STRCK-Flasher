using System;
using System.IO.Ports;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace STRCK_Flasher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            portsComboBox.Items.AddRange(ports);

            if (File.Exists("program.hex"))
            {
                fileNameTextBox.Text = "program.hex";
            }

            statusLabel.Text = "Připraveno";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fileNameTextBox.Text = ofd.FileName;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (portsComboBox.Text == "")
            {
                MessageBox.Show("Prosím vyberte port!", "STRCK Flasher", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (fileNameTextBox.Text == "")
            {
                MessageBox.Show("Prosím vyberte název souboru!", "STRCK Flasher", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            statusLabel.Text = "Flashování";

            string arguments = "-c arduino -p m328p -P " + portsComboBox.Text + " -U flash:w:" + fileNameTextBox.Text + ":a";

            Process avrdude_process = new Process();

            avrdude_process.StartInfo.FileName = "avrdude.exe";
            avrdude_process.StartInfo.Arguments = arguments;
            avrdude_process.Start();
            avrdude_process.WaitForExit();

            statusLabel.Text = "Připraveno";

            MessageBox.Show("Flashování proběhlo úspěšně", "STRCK Flasher", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
