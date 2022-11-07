using System.ComponentModel;
using System.Diagnostics;

namespace Ejercicio3Tema1
{
    public partial class Form1 : Form
    {
        Process[] procesos = Process.GetProcesses();
        public string recortes(string process)
        {
            if (process.Length > 20)
            {
                process = process.Substring(0, 20) + "...";
                return process;
            }
            else { return process; }
        } 
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            Process[] procesos = Process.GetProcesses();
            textBox1.Text += $"{"PID",10}{"ProcessName",40}{"MainWindowTitle",40}\r\n\r\n";
            foreach (Process p in procesos)
            {
                textBox1.Text += $"{p.Id,10}{recortes(p.ProcessName),40}{recortes(p.MainWindowTitle),40}\r\n";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process[] procesos = Process.GetProcesses();
            try
            {
                Process p = Process.GetProcessById(Convert.ToInt32(textBox2.Text));
                try
                {
                    textBox1.Text = $"{"PID",8}{"Tiempo de comienzo",25}{"Nombre del módulo",25}{"Nombre del proceso",25}{"numero de hilos",25}\r\n\r\n";

                    textBox1.Text += $"{p.Id,8}{p.StartTime,25}{p.MachineName,25}{recortes(p.ProcessName),25}{p.Threads.Count,25}\r\n\r\n\r\n";

                    ProcessThreadCollection threads = p.Threads;
                    textBox1.Text += $"{"Hilo ID",8}{"Tiempo de comienzo del hilo",35}{"Nivel de prioridad del hilo",35}{"Estado del hilo",30}\r\n\r\n";
                    foreach (ProcessThread t in threads)
                    {
                        textBox1.Text += $"{t.Id,8}{t.StartTime.ToShortTimeString(),35}{t.PriorityLevel,35}{t.ThreadState,30}\r\n";
                    }

                    ProcessModuleCollection modulos = p.Modules;
                    textBox1.Text += $"\r\n\r\n{"Cantidad de Modulos",35}{"Nombre de los Modulos",55}\r\n {p.Modules.Count,25}\r\n";
                    foreach (ProcessModule m in modulos)
                    {
                        textBox1.Text += $"{p.Modules,100}\r\n";
                    }
                }
                catch (Win32Exception)
                {
                    textBox1.Text = "La informacion de ese proceso se encuentra protegida";
                }
            }
            catch (FormatException)
            {
                textBox1.Text = "No existe un proceso con ese ID";
            }
            catch (System.ArgumentException)
            {
                textBox1.Text = "Ese proceso ha sido cerrado";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process[] procesos = Process.GetProcesses();
            try
            {
                Process p = Process.GetProcessById(Convert.ToInt32(textBox2.Text));
                DialogResult mensaje;
                mensaje = MessageBox.Show("¿Quieres cerrar el proceso " + p.ProcessName + " ?", "Cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (mensaje == DialogResult.Yes)
                {
                    textBox1.Text = "Se ha cerrado el proceso " + p.ProcessName;
                    p.CloseMainWindow();
                }
                else
                {
                    textBox1.Text = "Se ha cancelado el cierre";
                }
            }
            catch (FormatException)
            {
                textBox1.Text = "No existe un proceso con ese ID";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process[] procesos = Process.GetProcesses();
            try
            {
                Process p = Process.GetProcessById(Convert.ToInt32(textBox2.Text));
                try
                {
                    p.Kill();
                    textBox1.Text = "El proceso " + p.ProcessName + " Se ha cerrado de manera forzada";
                }
                catch (Win32Exception)
                {
                    textBox1.Text = "No se puede hacer eso";
                }
            }
            catch (FormatException)
            {
                textBox1.Text = "No ha introducido una id de un proceso correcta";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Process p;
                try
                {
                    p = Process.Start(textBox2.Text);
                    textBox1.Text = "El proceso " + p.ProcessName + " Ha comenzado de manera exitosa";
                }
                catch (Win32Exception)
                {
                    textBox1.Text = "El proceso No puede comenzar";
                }
                catch (InvalidOperationException)
                {
                    textBox1.Text = "El proceso No puede comenzar";
                }
            }
            catch (FormatException)
            {
                textBox1.Text = "No ha introducido un nombre de un proceso correcto";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Process[] procesos = Process.GetProcesses();
            textBox1.Text = "";
            textBox1.Text += $"{"PID",10}{"ProcessName",40}{"MainWindowTitle",40}\r\n\r\n";
            Array.ForEach(procesos, p => {  
                if (p.ProcessName.StartsWith(textBox2.Text))
                {
                    textBox1.Text += $"{p.Id,10}{recortes(p.ProcessName),40}{recortes(p.MainWindowTitle),40}\r\n";
                }
                else
                {
                    textBox1.Text += "";
                }
                });
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Multiline = true;
            textBox1.ScrollBars = ScrollBars.Both;
            textBox1.Font = new Font("Lucida Console", 10, FontStyle.Regular);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}