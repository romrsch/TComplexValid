using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TComplexValid.TComplex;

namespace TComplexValid
{
    public partial class Form1 : Form
    {
        TControl ctl = new TControl();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ctl.onlyReal = false;
            ActiveBox();
        }

        private void ActiveBox()
        {
            if (ctl.St == TControl.State.FirstNumEnter)
            {
                FirstNumBox.BackColor = Color.Coral;
                SecondNumBox.BackColor = Color.White;
            }
            if (ctl.St == TControl.State.SecondNumEnter)
            {
                FirstNumBox.BackColor = Color.White;
                SecondNumBox.BackColor = Color.Coral;
            }
            
        }
        private void buttonClick(object sender, EventArgs e)
        {
            Label but = (Label)sender;
            int cmd = Convert.ToInt16(but.Tag.ToString());
            DoCmd(cmd);
        }

        private void ComplexCalcKeyPress(object sender, KeyPressEventArgs e)
        {
            int i = -1;
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
                i = (int)e.KeyChar - '0';
            if ((int)e.KeyChar == 43)
                i = 10;
            if ((int)e.KeyChar == 45)
                i = 11;
            if ((int)e.KeyChar == 42)
                i = 12;
            if ((int)e.KeyChar == 47)
                i = 13;
            DoCmd(i);
        }

        private void DoCmd(int cmd)
        {
            switch (cmd)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 14:
                case 15:
                case 17:
                case 18:
                case 20:
                case 21:
                    if (ctl.St == TControl.State.FirstNumEnter)
                        FirstNumBox.Text = ctl.DoCmd(cmd);
                    if (ctl.St == TControl.State.SecondNumEnter)
                        SecondNumBox.Text = ctl.DoCmd(cmd);
                    break;
                case 10:
                case 11:
                case 12:
                case 13:
                    OperatorBox.Text = ctl.DoCmd(cmd);
                    ctl.DoCmd(16);
                    break;

                case 16:
                    ctl.DoCmd(cmd);
                    break;
                case 19:
                    if (OperatorBox.Text.Length != 0)
                        ResultNumBox.Text = ctl.DoCmd(cmd);
                    break;
                case 22:

                    ctl.St = TControl.State.FirstNumEnter;
                    SecondNumBox.Text = ctl.DoCmd(18);       
                    FirstNumBox.Text = ctl.DoCmd(18);
                    ResultNumBox.Text = ctl.DoCmd(18);
                    OperatorBox.Text = "";

                    break;
                default:
                    break;
            }
            ActiveBox();
        }

        private void комплесксноеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ctl.onlyReal = false;
            change_number.Text = "Режим комплексных чисел";
        }

        private void действительноеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ctl.onlyReal = true;
            change_number.Text = "Режим действительных чисел";
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Выполнил:\n.\n. \n Программа «Калькулятор комплексных чисел» позволяет производить расчет математических операций сложения, вычитания, умножения и деления с комплексными числами." +
                "\nПосле запуска программы можно сразу начинать ввод первого числа Х.Активное поле для ввода операнда подсвечивается светло - голубым цветом." +
                "Смену ввода с операнда Х на Y и наоборот, можно осуществить несколькими способами:Специально предназначенной клавишей «Tab»;" +
                "При нажатии клавиши «x», «/», «-», «+» автоматически будет совершаться переключение на другой операнд;" +
                "Клавиша «=» (вычислить результат) при наличии двух операндов будет возвращать курсор на ввод левого операнда." +
                "Оператор в программе можно установить в любой момент, до ввода операндов или после." +
                "Клавиша вычислить результат «=» будет работать только если введены оба операнда и есть оператор." +
                "Для ввода отрицательных чисел или смены знака числа необходимо использовать клавишу «+/ -»." +
                "Клавиша «CE», позволяет очистить текущее поля ввода." +
                "Клавиша «BS» позволяет удалить последний введенный символ." +
                "Для выхода из программы необходимо нажать клавишу «Выход» или воспользоваться клавишей «Х» в правом верхнем углу.", "Калькулятор комплексных чисел"
, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
