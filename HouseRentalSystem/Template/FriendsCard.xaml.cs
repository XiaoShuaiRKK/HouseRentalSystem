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
    /// FriendsCard.xaml 的交互逻辑
    /// </summary>
    public partial class FriendsCard : UserControl
    {
        public FriendsCard()
        {
            InitializeComponent();
        }

        public string FriendsListImg
        {
            get { return (string)GetValue(FriendsListImgProperty); }
            set { SetValue(FriendsListImgProperty, value); }
        }

        public static readonly DependencyProperty FriendsListImgProperty = DependencyProperty.Register("FriendsListImg", typeof(string), typeof(FriendsCard));

        public string FriendsListName
        {
            get { return (string)GetValue(FriendsListNameProperty); }
            set { SetValue(FriendsListNameProperty, value); }
        }

        public static readonly DependencyProperty FriendsListNameProperty = DependencyProperty.Register("FriendsListName", typeof(string), typeof(FriendsCard));

        public string FriendsListOnline
        {
            get { return (string)GetValue(FriendsListOnlineProperty); }
            set { SetValue(FriendsListOnlineProperty, value); }
        }

        public static readonly DependencyProperty FriendsListOnlineProperty = DependencyProperty.Register("FriendsListOnline", typeof(string), typeof(FriendsCard));

        public string FriendsListSendLately
        {
            get { return (string)GetValue(FriendsListSendLatelyProperty); }
            set { SetValue(FriendsListSendLatelyProperty, value); }
        }

        public static readonly DependencyProperty FriendsListSendLatelyProperty = DependencyProperty.Register("FriendsListSendLately", typeof(string), typeof(FriendsCard));
    }
}
