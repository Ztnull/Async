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

namespace WindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 同步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button1_Click(object sender, EventArgs e)
        {
            //Thread
            Console.WriteLine($"****************button1_Click Start {Thread.CurrentThread.ManagedThreadId}***************");

            for (int i = 0; i < 5; i++)
            {
                string name = string.Format($"button1_Click{i}");
                this.DoSomethingLong(name);
            }

            Console.WriteLine($"****************button1_Click   End {Thread.CurrentThread.ManagedThreadId}***************");
        }
        /// <summary>
        /// 异步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //Thread
            Console.WriteLine($"****************button2_Click Start {Thread.CurrentThread.ManagedThreadId}***************");

      

            Console.WriteLine($"****************button2_Click   End {Thread.CurrentThread.ManagedThreadId}***************");
        }


        #region Private Method
        /// <summary>
        /// 一个比较耗时耗资源的私有方法
        /// </summary>
        /// <param name="name"></param>
        private void DoSomethingLong(string name)
        {
            Console.WriteLine($"****************DoSomethingLong Start {Thread.CurrentThread.ManagedThreadId}***************");
            long lResult = 0;
            for (int i = 0; i < 10000000; i++)
            {
                lResult += i;
            }
            Thread.Sleep(2000);

            Console.WriteLine($"****************DoSomethingLong   End {Thread.CurrentThread.ManagedThreadId}***************");
        }
        #endregion
    }



}
