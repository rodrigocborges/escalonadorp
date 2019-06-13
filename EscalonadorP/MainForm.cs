using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscalonadorP
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        List<Process> listProcess = new List<Process>();
        int clocks = 0;

        void GenerateRandomProcess(int amount)
        {
            Random r = new Random();
            for (int i = 0; i < amount; i++)
                listProcess.Add(new Process(i, r.Next(100), r.Next(30)));
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GenerateRandomProcess(10);
            label1.Text = "Aguardando ação...";
            timer.Interval = 500;
            dataGridView1.DataSource = listProcess;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
            clocks = 0; //reset
        }

        int executions = 0;
        double average = 0;
        private void timer_Tick(object sender, EventArgs e)
        {
            clocks++;
            for (int i = 0; i < listProcess.Count; i++)
            {
                Process actual = listProcess[i];
                if (actual.execution < clocks && actual.status == 0)
                {
                    actual.status = 1;
                    ++executions;
                }
            }
            average = executions / clocks;
            label1.Text = "Executando | Clocks: " + clocks + " | Execuções: " + executions + " | Média: " + average.ToString("F5");

            dataGridView1.DataSource = listProcess;
            dataGridView1.Refresh();
            if (executions >= listProcess.Count - 1)
            {
                label1.Text = "Finalizado | " + average.ToString("F2");
                timer.Enabled = false;
            }
        }
    }
}
