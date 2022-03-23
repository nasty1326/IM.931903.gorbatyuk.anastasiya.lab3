using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _931903.gorbatyuk.anastasiya.lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        int rule;
        Random random = new Random();

        private void btRule_Click(object sender, EventArgs e)
        {

            
            //считываем значение правила
            rule = (int)edRule.Value;
            //добавляем массив панелей 0 строки
            List<List<Panel>> myList = new List<List<Panel>>();
           
            myList.Add(new List<Panel> { panel0_1, panel0_2, panel0_3, panel0_4, panel0_5, panel0_6, panel0_7, panel0_8, panel0_9, panel0_10, panel0_11, panel0_12, panel0_13, panel0_14 });
            myList.Add(new List<Panel> { panel1_1, panel1_2, panel1_3, panel1_4, panel1_5, panel1_6, panel1_7, panel1_8, panel1_9, panel1_10, panel1_11, panel1_12, panel1_13, panel1_14 });
            myList.Add(new List<Panel> { panel2_1, panel2_2, panel2_3, panel2_4, panel2_5, panel2_6, panel2_7, panel2_8, panel2_9, panel2_10, panel2_11, panel2_12, panel2_13, panel2_14 });
            myList.Add(new List<Panel> { panel3_1, panel3_2, panel3_3, panel3_4, panel3_5, panel3_6, panel3_7, panel3_8, panel3_9, panel3_10, panel3_11, panel3_12, panel3_13, panel3_14 });
            myList.Add(new List<Panel> { panel4_1, panel4_2, panel4_3, panel4_4, panel4_5, panel4_6, panel4_7, panel4_8, panel4_9, panel4_10, panel4_11, panel4_12, panel4_13, panel4_14 });
            myList.Add(new List<Panel> { panel5_1, panel5_2, panel5_3, panel5_4, panel5_5, panel5_6, panel5_7, panel5_8, panel5_9, panel5_10, panel5_11, panel5_12, panel5_13, panel5_14 });
            myList.Add(new List<Panel> { panel6_1, panel6_2, panel6_3, panel6_4, panel6_5, panel6_6, panel6_7, panel6_8, panel6_9, panel6_10, panel6_11, panel6_12, panel6_13, panel6_14 });
            
           for (int i=0; i <= 6; i++)
            {
                for(int j=0; j <= 13; j++)
                {
                    myList[i][j].BackColor = Color.White;
                }
            }
            //создаем и заполняем массив рандомными значениями
            int[] a0 = new int[14];
            for (int a=0; a<14;a++)
            {
                if (random.Next(100) < 50)
                {
                    a0[a] = 1;
                    //Окрашиваем в красный панель, если ставим 1 в значении
                    myList[0][a].BackColor = Color.Red;
                }
                else { a0[a] = 0; }

            }


            // переводим правило в двоичную систему
            string BinaryCode = Convert.ToString(rule, 2);
            //добавляю недостающие 0 до 8 знаков в строке
            BinaryCode = BinaryCode.PadLeft(8, '0');
            // переводим в целочисленный массив
            int[] RulesNumber = BinaryCode.Select(x => x - '0').ToArray();

            label1.Text = BinaryCode[0].ToString();
            label2.Text = BinaryCode[1].ToString();
            label3.Text = BinaryCode[2].ToString();
            label4.Text = BinaryCode[3].ToString();
            label5.Text = BinaryCode[4].ToString();
            label6.Text = BinaryCode[5].ToString();
            label7.Text = BinaryCode[6].ToString();
            label8.Text = BinaryCode[7].ToString();

            int[] mass = new int[14];
            int value=0;
            int[] a1 = new int[14];

           

            for (int i=1;i<7;i++)
            { 
                    //для первого элемента
                        value = (a0[13] )* 4 + (a0[0]) * 2 + (a0[1]) * 1;
                        if (RulesNumber[7 - value] == 1)
                        {
                            myList[i][0].BackColor = Color.Red;
                            a1[0] = 1;
                        }
                    //для элементов по середине 
                for (int j=1; j<13; j++)
                {  
                        value = (a0[j-1]) * 4 + (a0[j] )* 2 + (a0[j+1]) * 1;
                        if (RulesNumber[7 - value] == 1)
                        {
                            myList[i][j].BackColor = Color.Red;
                            a1[j] = 1;
                        }
                }
                    //для последнего элемента
                    
                        value = (a0[12]) * 4 + (a0[13]) * 2 + (a0[0]) * 1;
                        if (RulesNumber[7 - value] == 1)
                        {
                           myList[i][13].BackColor = Color.Red;
                            a1[13] = 1;
                        }
                  
                for (int a=0; a<=13; a++)
                {
                    a0[a] = a1[a];
                    a1[a] = 0;
                }
            }
           
        }

    }
}
