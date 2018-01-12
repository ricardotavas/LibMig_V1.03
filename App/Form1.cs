using System;
using System.Windows.Forms;
using LibMig;

namespace App
{
    public partial class Form1 : Form
    {
        private IServerMig mig = new ServerMig();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Carrega informações básicas na dll
            mig._serverIp = "192.168.0.114";
            mig._userNum = 1;

            // Carrega informações básicas nos controles do programa
            textBox_ipserver.Text = "192.168.0.114";
            numericUpDown_user.Value = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Busca próximo ticket na fila do servidor e chama no painel cadastrado no servidor
            mig.GetNextTicket();
            PrintResultServer();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Busca ticket especifico no servidor e chama no painel cadastrado no servidor
            mig.SetCallTicket(1, Convert.ToUInt16(numericUpDown_ticketesp.Value));
            PrintResultServer();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Repete última chamada no painel cadastrado no servidor
            mig.GetLastTicket();
            PrintResultServer();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Encerra o último atendimento
            mig.CloseCall();
            PrintResultServer();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Cancela a última chamada
            mig.CancelCall();
            PrintResultServer();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Encerra e encaminha o ticket para a fila do departamento escolhido (Ex: 5)
            mig.RouteTicket(Convert.ToByte(numericUpDown_depesp.Value));
            PrintResultServer();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Habilita uma pesquisa no teclado de opinião.
            mig.StartResearch(1);
            PrintResultServer();
        }

        private void PrintResultServer()
        {
            textBox1.Text += mig._status + Convert.ToChar(13) + Convert.ToChar(10);
        }

        private void button_get_Click(object sender, EventArgs e)
        {
            // Lê os atributos do atendimento ativo
            comboBox_row.SelectedIndex = mig._activeRowDisp - 1;
            if (mig._activeAlphaTicket == 32)
                comboBox_alpha.SelectedIndex = 0;
            else if (mig._activeAlphaTicket >= 65)
                comboBox_alpha.SelectedIndex = mig._activeAlphaTicket - 64;
            numericUpDown_box.Value = mig._activeRowDisp;
            numericUpDown_ticket.Value = mig._activeTicket;
            comboBox_type.SelectedIndex = mig._activeTypeTicket;
            numericUpDown_dep.Value = mig._activeDepNum;
            textBox_dep.Text = mig._activeDepName;
            textBox_ipdisp.Text = mig._activeDisplayIp;
            if (mig._activeDispInterf == 2)
                comboBox_interfDisp.SelectedIndex = 0;
            else if (mig._activeDispInterf == 64)
                comboBox_interfDisp.SelectedIndex = 1;
            textBox_iptop.Text = mig._activeTopIp;
            if (mig._activeTopInterf == 2)
                comboBox_interfTop.SelectedIndex = 0;
            else if (mig._activeTopInterf == 64)
                comboBox_interfTop.SelectedIndex = 1;
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            // Carrega informações básicas na dll
            mig._serverIp = textBox_ipserver.Text;
            mig._userNum = Convert.ToByte(numericUpDown_user.Value);
        }
    }
}
