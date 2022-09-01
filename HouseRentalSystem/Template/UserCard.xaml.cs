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
    /// UserCard.xaml 的交互逻辑
    /// </summary>
    public partial class UserCard : UserControl
    {
        public UserCard()
        {
            InitializeComponent();
        }

        public string SalesListUserImg
        {
            get { return (string)GetValue(SalesListUserImgProperty); }
            set { SetValue(SalesListUserImgProperty, value); }
        }

        public static readonly DependencyProperty SalesListUserImgProperty = DependencyProperty.Register("SalesListUserImg", typeof(string), typeof(UserCard));

        public string Sales
        {
            get { return (string)GetValue(SalesProperty); }
            set { SetValue(SalesProperty, value); }
        }

        public static readonly DependencyProperty SalesProperty = DependencyProperty.Register("Sales", typeof(string), typeof(UserCard));

        public string Period
        {
            get { return (string)GetValue(PeriodProperty); }
            set { SetValue(PeriodProperty, value); }
        }

        public static readonly DependencyProperty PeriodProperty = DependencyProperty.Register("Period", typeof(string), typeof(UserCard));

        public string UserName
        {
            get { return (string)GetValue(UserNameProperty); }
            set { SetValue(UserNameProperty, value); }
        }

        public static readonly DependencyProperty UserNameProperty = DependencyProperty.Register("UserName", typeof(string), typeof(UserCard));
    }

}
