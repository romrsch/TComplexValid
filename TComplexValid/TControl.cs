using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;

namespace TComplexValid
{
    internal class TControl
    {
        TEditor FirstNum = new TEditor();

        TEditor SecondNum = new TEditor();

        public bool onlyReal;

        public enum State { FirstNumEnter, SecondNumEnter, Execute };

        public State St { get; set; }

        public enum Operation { Add, Substract, Multiply, Devide, Undefined };

        public Operation Op { get; set; }

        public TControl()
        {
            St = State.FirstNumEnter;
            Op = Operation.Undefined;
        }

        public string DoCmd(int cmd)
        {
            Console.WriteLine(cmd);
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
                    if (St == State.FirstNumEnter)
                        return FirstNum.DoEdit(cmd);
                    if (St == State.SecondNumEnter)
                        return SecondNum.DoEdit(cmd);
                    break;
                case 10:
                    Op = Operation.Add;
                    return "+";
                case 11:
                    Op = Operation.Substract;
                    return "-";
                case 12:
                    Op = Operation.Multiply;
                    return "*";
                case 13:
                    Op = Operation.Devide;
                    return "/";
                case 16:
                    if (St == State.FirstNumEnter)
                        St = State.SecondNumEnter;
                    else
                        St = State.FirstNumEnter;
                    break;
                case 19:
                    if (FirstNum.Number.Length == 0 || SecondNum.Number.Length == 0)
                    {
                       
                        break;
                    }
                    if (!onlyReal)
                    {
                        if (FirstNum.Number[FirstNum.Number.Length - 1] == 'i' || SecondNum.Number[SecondNum.Number.Length - 1] == 'i')
                            break;

                        bool isComplexFirst = false;
                        bool isComplexSecond = false;
                        for (int i = 0; i < FirstNum.Number.Length; i++)
                            if (FirstNum.Number[i] == 'i')
                            {
                                isComplexFirst = true;
                                break;
                            }
                        for (int i = 0; i < SecondNum.Number.Length; i++)
                            if (SecondNum.Number[i] == 'i')
                            {
                                isComplexSecond = true;
                                break;
                            }

                        if (!isComplexFirst || !isComplexSecond)
                            break;
                    }
                    St = State.Execute;
                    TComplex a = new TComplex(FirstNum.Number, onlyReal);
                    TComplex b = new TComplex(SecondNum.Number, onlyReal);

                    string result = "";
                    switch (Op)
                    {
                        case Operation.Add:
                            result = (a + b).ToString();
                            break;
                        case Operation.Substract:
                            result = (a - b).ToString();
                            break;
                        case Operation.Multiply:
                            result = (a * b).ToString();
                            break;
                        case Operation.Devide:
                            result = (a / b).ToString();
                            break;
                        default:
                            break;
                    }
                    St = State.FirstNumEnter;
                    return result;
                case 22:

                    Process.Start(Assembly.GetExecutingAssembly().Location);
                    Environment.Exit(0);

                    break;
                default:
                    break;
            }
            return "";
        }

        internal TEditor TEditor
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

    }
}
