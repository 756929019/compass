using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace compass
{
    /// <summary>
    /// uc_3d_compass.xaml 的交互逻辑
    /// </summary>
    public partial class uc_3d_compass : UserControl
    {
        bool isf = true;
        public uc_3d_compass()
        {
            InitializeComponent();

            //DispatcherTimer t = new DispatcherTimer();
            //t.Tick += T_Tick;
            //t.Interval = new TimeSpan(0, 0, 0, 5);
            //t.Start();
        }

        private void T_Tick(object sender, EventArgs e)
        {
            if (isf)
            {
                Storyboard story = (Storyboard)this.FindResource("TDarr_f");
                story.Begin();
                Storyboard story1 = (Storyboard)this.FindResource("TDarr1_f");
                story1.Begin();
                isf = false;
            }
            else {
                Storyboard story = (Storyboard)this.FindResource("TDarr");
                story.Begin();
                Storyboard story1 = (Storyboard)this.FindResource("TDarr1");
                story1.Begin();
                isf = true;
            }
           
        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {
           // uc_compass1.BeginStoryboard();
        }

        private void Storyboard_Completed_1(object sender, EventArgs e)
        {
           // uc_compass2.BeginStoryboard();
        }
    }
}
