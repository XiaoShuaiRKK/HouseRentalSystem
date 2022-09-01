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
using System.Windows.Shapes;

namespace HouseRentalSystem
{
    /// <summary>
    /// Tenant.xaml 的交互逻辑
    /// </summary>
    public partial class Tenant : Window
    {
        public Tenant(string UserName)
        {
            InitializeComponent();
            this.Width = SystemParameters.WorkArea.Width * 0.72;
            this.Height = SystemParameters.WorkArea.Height * 0.72;
        }
    }
}
