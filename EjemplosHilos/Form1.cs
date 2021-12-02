using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjemplosHilos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        int x = 10;
        private void button1_Click(object sender, EventArgs e)
        {
            ProgressBar pb = new ProgressBar();
            pb.Value = 0;
            pb.Size = new Size(80, 20);
            pb.Location = new Point(x,20);
            x += 90;
            pb.Click += Pb_Click;
            panel1.Controls.Add(pb);
        }

        private void Pb_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(incrementar);
            t.Start(sender);
        }
        public void incrementar(Object pb)
        {
            ProgressBar progressBar = pb as ProgressBar;
            for (int i = 0; i <=100; i++)
            {
                progressBar.Value = i;
                Thread.Sleep(100);
            }
        }

    }
}
