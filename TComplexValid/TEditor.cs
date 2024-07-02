using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;

namespace TComplexValid
{
    internal class TEditor
    {
        const char point = ',';

        public string Number { get; set; } = "";

        const char ZERO = '0';

        const char I = 'i';

        public string AddDigit(char Num)
        {
            if (Number.Length > 0)
            {
                if (Number[0] == '0' && Number.Length == 1)
                    return Number;
                if (Number.Length >= 4)
                    if (Number[Number.Length - 1] == '0' && Number[Number.Length - 2] == 'i')
                        return Number;
            }
            Number += Num;
            return Number.Replace(" ", "");
        }

        public string ChangeSign()
        {
            if (Number.Length == 0)
                return Number;
            else
            {
                if (Number[0] == '0')
                    return Number;
                if (Number[0] == '-')
                    Number = Number.Substring(1, Number.Length - 1);
                else
                    Number = Number.Insert(0, "-");
            }
            return Number;
        }

        public string AddPoint()
        {
            if (cheackPoint())
                Number += point;
            return Number.Replace(" ", "");
        }
        public string AddIm(int Sign)
        {
            if (Number.Length > 0)
            {
                for (int i = 0; i < Number.Length; i++)
                    if (Number[i] == I)
                        return Number;
                if (Sign == 1)
                    Number += "+i";
                else
                    Number += "-i";
                return Number.Replace(" ", "");
            }
            return Number;
        }

        public string AddZero()
        {
            if (Number.Length > 0)
            {
                if (Number[0] == '0' && Number.Length == 1)
                    return Number;
                if (Number.Length >= 4)
                    if (Number[Number.Length - 1] == '0' && Number[Number.Length - 2] == 'i')
                        return Number;
                Number += ZERO;
                return Number;
            }
            Number += ZERO;
            return Number.Replace(" ", "");
        }

        public string BS()
        {
            if (Number.Length > 0)
            {
                if (Number[Number.Length - 1] == I)
                {
                    Number = Number.Substring(0, Number.Length - 2);
                    return Number.Replace(" ", "");
                }
                Number = Number.Substring(0, Number.Length - 1);
                return Number.Replace(" ", "");
            }
            return Number.Replace(" ", "");
        }

        public string Clear()
        {
            Number = "";
            return Number;
        }

        public string AppRestart()
        {
            Process.Start(Assembly.GetExecutingAssembly().Location);
            Environment.Exit(0);
            string ext = "";
            return ext;
        }

        public string DoEdit(int command)
        {
            switch (command)
            {
                case 0:
                    return AddZero();
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    return AddDigit(command.ToString()[0]);
                case 14:
                    return AddIm(1);
                case 20:
                    return AddIm(0);
                case 15:
                    return AddPoint();
                case 17:
                    return BS();
                case 18:
                    return Clear();
                case 21:
                    return ChangeSign();
                case 22:
                    return AppRestart();
                default:
                    return Number;
            }
        }

        private bool cheackPoint()
        {
            bool isValid = true;
            if (Number.Length == 0)
                isValid = false;
            else
            {
                bool pointUse = false;
                for (int i = 0; i < Number.Length; i++)
                {
                    if ((Number[i] == '-' || Number[i] == '+') && i != 0)
                        pointUse = false;
                    if (Number[i] == point)
                        pointUse = true;
                }
                if ((Number[Number.Length - 1] >= '0' && Number[Number.Length - 1] <= '9') && pointUse == false)
                    isValid = true;
                else
                    isValid = false;
            }
            return isValid;
        }

    }
}
