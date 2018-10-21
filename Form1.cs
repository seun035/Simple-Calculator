using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mysimplecalculator
{
    public partial class Form1 : Form
    {
        public Form1(MySimpleCalculator myObject)
        {
            InitializeComponent();
            this.myObject = myObject;
        }

        public MySimpleCalculator myObject;
        enum State { OFF, ON }

        State flag = State.OFF;
        void AddValues(object input)
        {
            if(input is Button)
            {
                Button button = input as Button;
                if (((int)flag == 1 && Screen.Text == "0" ) || (myObject.Answer.ToString() == Screen.Text))
                {
                    Screen.Text = button.Text;
                }

                else if ((int)flag == 1 && Screen.Text != "")
                {
                    Screen.Text += button.Text;
                }
            }

            if (input is KeyPressEventArgs)
            {
                KeyPressEventArgs key = input as KeyPressEventArgs;
                if (((int)flag == 1 && Screen.Text == "0") || (myObject.Answer.ToString() == Screen.Text))
                {
                    Screen.Text = Convert.ToString(key.KeyChar);
                }

                else if ((int)flag == 1 && Screen.Text != "")
                {
                    Screen.Text += Convert.ToString(key.KeyChar);
                }
            }
        }

        private void AddOperator(object sender)
        {
            try
            {
                if (Screen.Text != "0")
                {
                    Button[] mybutton = { buttonDiv, buttonMul, buttonAdd, buttonSub };
                    for (int i = 0; i < mybutton.Length; ++i)
                    {
                        if (sender.Equals(mybutton[i]))
                        {
                            myObject.Number1 = Convert.ToDouble(Screen.Text);
                            Screen.Text += mybutton[i].Text;
                            myObject.Index = Screen.Text.IndexOf(mybutton[i].Text);
                        }
                    }
                }
            }
            catch (FormatException ex) {
                Console.WriteLine(ex.Message);
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)(e.KeyChar) >= 48 && (int)(e.KeyChar) <= 57){
                AddValues(e);
            }
            else if ((int)(e.KeyChar) == 42 || (int)(e.KeyChar) == 43 || (int)(e.KeyChar) == 45 || (int)(e.KeyChar) == 47)
            {
                switch ((int)e.KeyChar)
                {
                    case 42:
                        AddOperator(buttonMul);
                        break;
                    case 43:
                        AddOperator(buttonAdd);
                        break;
                    case 45:
                        AddOperator(buttonSub);
                        break;
                    case 47:
                        AddOperator(buttonDiv);
                        break;
                }
            }
            else if((int)(e.KeyChar) == 46)
            {
                buttonDec_Click(sender,e);
            }
            else if ((int)(e.KeyChar) == 61)
            {
                buttonEqu_Click(sender,e);
            }
        }

        private void buttonON_Click(object sender, EventArgs e)
        {
            flag = State.ON;
            Screen.Text = "0";
        }

        private void buttonOOF_Click(object sender, EventArgs e)
        {
            Screen.Text = "";
            flag = State.OFF;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddValues(sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddValues(sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddValues(sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddValues(sender);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddValues(sender);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddValues(sender);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AddValues(sender);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AddValues(sender);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AddValues(sender);
        }

        private void button0_Click(object sender, EventArgs e)
        {
            AddValues(sender);
        }

        private void button00_Click(object sender, EventArgs e)
        {
            if ((int)flag == 1 && Screen.Text != "0")
            {
                Screen.Text += "00";
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddOperator(sender);  
        }

        private void buttonSub_Click(object sender, EventArgs e)
        {
            AddOperator(sender);
        }

        private void buttonMul_Click(object sender, EventArgs e)
        {
            AddOperator(sender);
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            AddOperator(sender);
        }

        private void buttonDec_Click(object sender, EventArgs e)
        {
            char[] searchOperator = { '+', '*', '-', '/' }; //an array of basic operators

             if (Screen.Text != "" && Screen.Text.IndexOf('.') == -1)  //excutes if calc is ON and no decimal point in a label text
            {
                Screen.Text += ".";  //Concatenates decimal point to label text
            }
            else if (Screen.Text.IndexOfAny(searchOperator) != -1)  //excutes if any element of array searchOperator exit
            {
                int sign = Screen.Text.IndexOfAny(searchOperator);
                if (Screen.Text.IndexOf('.', sign) == -1)           //
                    Screen.Text += ".";
            }
        }

        private void buttonEqu_Click(object sender, EventArgs e)
        {
            try
            {
                if (Screen.Text != "" && Screen.Text != "0" && (Screen.Text[myObject.Index] == '+' || Screen.Text[myObject.Index] == '-'
                       || Screen.Text[myObject.Index] == '/' || Screen.Text[myObject.Index] == '*')) //Execute if Calc is ON and label text has an Operator
                {
                    myObject.Number2 = Convert.ToDouble(Screen.Text.Substring(myObject.Index + 1)); //Assign number after Operator to field Number2
                    if (Screen.Text[myObject.Index] == '+') //Execute if Operator in text is '+'
                    {
                        Screen.Text = Convert.ToString(myObject.Addition());
                        myObject.Answer = Convert.ToDouble(Screen.Text);
                    }

                    else if (Screen.Text[myObject.Index] == '-')
                    {
                        Screen.Text = Convert.ToString(myObject.Subtraction());
                        myObject.Answer = Convert.ToDouble(Screen.Text);
                    }

                    else if (Screen.Text[myObject.Index] == '*')
                    {
                        Screen.Text = Convert.ToString(myObject.Multiplication());
                        myObject.Answer = Convert.ToDouble(Screen.Text);
                    }

                    else if (Screen.Text[myObject.Index] == '/')
                    {
                        Screen.Text = Convert.ToString(myObject.Division());
                        myObject.Answer = Convert.ToDouble(Screen.Text);
                    }
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            if (Screen.Text.Length == 1)
            {
                Screen.Text = "0";
            }
            else
            {
                StringBuilder temp = new StringBuilder();
                for (int i = 0; i < (Screen.Text.Length - 1) ; i++)
                {
                    temp.Append(Screen.Text[i]);
                }
                Screen.Text = temp.ToString();
            }
        }

        private void buttonAns_Click(object sender, EventArgs e)
        {
            char[] searchOperator = { '+', '*', '-', '/' };
            if ((int)flag == 1 && Screen.Text != "" && Screen.Text.IndexOfAny(searchOperator) == -1)
            {
                Screen.Text = Convert.ToString(myObject.Answer);
            }
            else if (Screen.Text.IndexOfAny(searchOperator) != -1)  //excutes if any element of array searchOperator exit
            {
                int sign = Screen.Text.IndexOfAny(searchOperator);
                if (sign == (Screen.Text.Length - 1))
                {
                    Screen.Text += Convert.ToString(myObject.Answer);
                }
            }
        }

    }
}
