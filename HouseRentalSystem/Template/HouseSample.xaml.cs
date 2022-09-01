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

namespace HouseRentalSystem.Template
{
    /// <summary>
    /// HouseSample.xaml 的交互逻辑
    /// </summary>
    public partial class HouseSample : UserControl
    {
        public HouseSample()
        {
            InitializeComponent();
        }

        public string HouseAddress
        {
            get { return (string)GetValue(HouseAddressProperty); }
            set { SetValue(HouseAddressProperty, value); }
        }

        public static readonly DependencyProperty HouseAddressProperty = DependencyProperty.Register("HouseAddress", typeof(string), typeof(HouseSample));

        public string HouseStyle
        {
            get { return (string)GetValue(HouseStyleProperty); }
            set { SetValue(HouseStyleProperty, value); }
        }

        public static readonly DependencyProperty HouseStyleProperty = DependencyProperty.Register("HouseStyle", typeof(string), typeof(HouseSample));

        public string HouseRent
        {
            get { return (string)GetValue(HouseRentProperty); }
            set { SetValue(HouseRentProperty, value); }
        }

        public static readonly DependencyProperty HouseRentProperty = DependencyProperty.Register("HouseRent", typeof(string), typeof(HouseSample));

        public string HouseState
        {
            get { return (string)GetValue(HouseStateProperty); }
            set { SetValue(HouseStateProperty, value); }
        }

        public static readonly DependencyProperty HouseStateProperty = DependencyProperty.Register("HouseState", typeof(string), typeof(HouseSample));

    }
}
