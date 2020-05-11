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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace compass
{
    /// <summary>
    /// uc_compass.xaml 的交互逻辑
    /// </summary>
    public partial class uc_compass1 : UserControl
    {
        public uc_compass1()
        {
            InitializeComponent();
        }

        public void BeginStoryboard() {
            Storyboard story = (Storyboard)this.FindResource("Run");
            story.Begin();
        }
    }
}
