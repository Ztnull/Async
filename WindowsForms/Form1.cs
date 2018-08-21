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

/// <summary>
/// 【多线程】
///  1、异步，多线程
///  2、异步和多线程的区别：其实在C#中异步和多线程并没有什么区别。只不过，
///  3、异步：使用的事线程池的线程ThreadProlong
/// 总结：我们可以理解为异步和多线程一样
/// </summary>
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
        /// 异步【来自于委托】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //Thread
            Console.WriteLine($"****************button2_Click Start {Thread.CurrentThread.ManagedThreadId}***************");

            Action<string> act = (t) =>
            {//虽然不能使用多播，但是可以这样用
                this.DoSomethingLong("button2_Click DoSomethingLong1");
                this.DoSomethingLong("button2_Click DoSomethingLong2");
            };


            act.Invoke("");

            act.BeginInvoke("button2_Click", c =>
            {// 回调函数
                Console.WriteLine($"***************************{c.AsyncState} {Thread.CurrentThread.ManagedThreadId}****************************");
            }, "回调");

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
