using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace wpfThreadSim3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Variables
        Thread thread1, thread2;

        #endregion
        #region Main Method
        public MainWindow()
        {
            thread1 = new Thread(processThread1);
            thread2 = new Thread(processThread2);

            InitializeComponent();

        }
        #endregion
        #region Callback Methods
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            switch(thread1.ThreadState)
            {
                case ThreadState.Unstarted:
                    thread1.Start();
                    break;
                case ThreadState.Stopped:
                    thread1 = new Thread(processThread1);
                    thread1.Start();
                    break;
                case ThreadState.Aborted:
                    thread1 = new Thread(processThread1);
                    thread1.Start();
                    break;
                case ThreadState.WaitSleepJoin:
                    thread1.Suspend();
                    break;
                case ThreadState.Suspended:
                    thread1.Resume();
                    break;
                default:
                    break;
            }

        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            switch(thread2.ThreadState)
            {
                case ThreadState.Unstarted:
                    thread2.Start();
                    break;
                case ThreadState.Stopped:
                    thread2 = new Thread(processThread2);
                    thread2.Start();
                    break;
                case ThreadState.Aborted:
                    thread2 = new Thread(processThread2);
                    thread2.Start();
                    break;
                case ThreadState.WaitSleepJoin:
                    thread2.Suspend();
                    break;
                case ThreadState.Suspended:
                    thread2.Resume();
                    break;
                default:
                    break;

            }
        }
        #endregion
        #region Methods
        public void processThread1()
        {
            for(int i=0; i<101; i++)
            {
                updateTextBox1(Convert.ToString(i));
                Thread.Sleep(50);    
            }
        }
        public void processThread2()
        {
            for(int i=0; i<101; i++)
            {
                updateTextBox2(Convert.ToString(i));
                Thread.Sleep(75);
            }
        }

        public void updateTextBox1(string str)
        {
            string tempbuff = str + " %";
            Dispatcher.Invoke((Action)(() =>
            {
                textBox1.Text = tempbuff;
            }));
        }
        public void updateTextBox2(string str)
        {
            string tempbuff = str + " %";
            Dispatcher.Invoke((Action)(() =>
            {
                textBox2.Text = tempbuff;
            }));
        }
        #endregion


    }
}
