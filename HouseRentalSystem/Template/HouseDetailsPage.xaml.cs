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
    /// HouseDetailsPage.xaml 的交互逻辑
    /// </summary>
    public partial class HouseDetailsPage : Grid
    {
        public HouseDetailsPage()
        {
            InitializeComponent();
        }

        public string DetailsHouseAddress
        {
            get { return (string)GetValue(DetailsHouseAddressProperty); }
            set { SetValue(DetailsHouseAddressProperty, value); }
        }

        public static readonly DependencyProperty DetailsHouseAddressProperty = DependencyProperty.Register("DetailsHouseAddress", typeof(string), typeof(HouseDetailsPage));

        public string DetailsHouseType
        {
            get { return (string)GetValue(DetailsHouseTypeProperty); }
            set { SetValue(DetailsHouseTypeProperty, value); }
        }

        public static readonly DependencyProperty DetailsHouseTypeProperty = DependencyProperty.Register("DetailsHouseType", typeof(string), typeof(HouseDetailsPage));

        public string DetailsHouseRent
        {
            get { return (string)GetValue(DetailsHouseRentProperty); }
            set { SetValue(DetailsHouseRentProperty, value); }
        }

        public static readonly DependencyProperty DetailsHouseRentProperty = DependencyProperty.Register("DetailsHouseRent", typeof(string), typeof(HouseDetailsPage));


        public string DetailsHouseMaster
        {
            get { return (string)GetValue(DetailsHouseMasterProperty); }
            set { SetValue(DetailsHouseMasterProperty, value); }
        }

        public static readonly DependencyProperty DetailsHouseMasterProperty = DependencyProperty.Register("DetailsHouseMaster", typeof(string), typeof(HouseDetailsPage));

        public string DetailsHouseState
        {
            get { return (string)GetValue(DetailsHouseStateProperty); }
            set { SetValue(DetailsHouseStateProperty, value); }
        }

        public static readonly DependencyProperty DetailsHouseStateProperty = DependencyProperty.Register("DetailsHouseState", typeof(string), typeof(HouseDetailsPage));

        public string DetailsHouseTenant
        {
            get { return (string)GetValue(DetailsHouseTenantProperty); }
            set { SetValue(DetailsHouseTenantProperty, value); }
        }

        public static readonly DependencyProperty DetailsHouseTenantProperty = DependencyProperty.Register("DetailsHouseTenant", typeof(string), typeof(HouseDetailsPage));

        public string DetailsHouseAge
        {
            get { return (string)GetValue(DetailsHouseAgeProperty); }
            set { SetValue(DetailsHouseAgeProperty, value); }
        }

        public static readonly DependencyProperty DetailsHouseAgeProperty = DependencyProperty.Register("DetailsHouseAge", typeof(string), typeof(HouseDetailsPage));

        public string ButtonText
        {
            get { return (string)GetValue(ButtonTextProperty); }
            set { SetValue(ButtonTextProperty, value); }
        }

        public static readonly DependencyProperty ButtonTextProperty = DependencyProperty.Register("ButtonText", typeof(string), typeof(HouseDetailsPage));
    }
}
