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
    /// AddResources.xaml 的交互逻辑
    /// </summary>
    public partial class AddResources : UserControl
    {
        public AddResources()
        {
            InitializeComponent();
        }

        public string HintAddress
        {
            get { return (string)GetValue(HintAddressProperty); }
            set { SetValue(HintAddressProperty, value); }
        }

        public static readonly DependencyProperty HintAddressProperty = DependencyProperty.Register("HintAddress", typeof(string), typeof(AddResources));

        public string HintType
        {
            get { return (string)GetValue(HintTypeProperty); }
            set { SetValue(HintTypeProperty, value); }
        }

        public static readonly DependencyProperty HintTypeProperty = DependencyProperty.Register("HintType", typeof(string), typeof(AddResources));

        public string HintRent
        {
            get { return (string)GetValue(HintRentProperty); }
            set { SetValue(HintRentProperty, value); }
        }

        public static readonly DependencyProperty HintRentProperty = DependencyProperty.Register("HintRent", typeof(string), typeof(AddResources));


        public string HintAge
        {
            get { return (string)GetValue(HintAgeProperty); }
            set { SetValue(HintAgeProperty, value); }
        }

        public static readonly DependencyProperty HintAgeProperty = DependencyProperty.Register("HintAge", typeof(string), typeof(AddResources));

    }
}
