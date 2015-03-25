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

namespace PzwDomaci2_1
{
    /// <summary>
    /// Interaction logic for User_NoEditDelete.xaml
    /// </summary>
    public partial class User_NoEditDelete : UserControl
    {
        public User_NoEditDelete()
        {
            InitializeComponent();
        }

        public string UserName_No
        {
            get { return (string)GetValue(UserNameProperty); }
            set { SetValue(UserNameProperty, value); }
        }

        public static readonly DependencyProperty UserNameProperty = DependencyProperty.Register
        (
          "UserName_No",
          typeof(string),
          typeof(User_NoEditDelete),
          new UIPropertyMetadata("UserName_No")
        );

        public string ImageSource_No
        {
            get { return (string)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register
        (
          "ImageSource_No",
          typeof(string),
          typeof(User_NoEditDelete),
          new UIPropertyMetadata("ImageSource_No")
        );
    }
}
