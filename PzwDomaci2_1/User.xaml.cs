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
    /// Interaction logic for User.xaml
    /// </summary>
    public partial class User : UserControl
    {
        public User()
        {
            InitializeComponent();
        }

        public string UserName
        {
            get { return (string)GetValue(UserNameProperty); }
            set { SetValue(UserNameProperty, value); }
        }

        public static readonly DependencyProperty UserNameProperty = DependencyProperty.Register
        (
          "UserName",
          typeof(string),
          typeof(User),
          new UIPropertyMetadata("UserName")
        );

        public string ImageSource
        {
            get { return (string)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register
        (
          "ImageSource",
          typeof(string),
          typeof(User),
          new UIPropertyMetadata("ImageSource")
        );

        public static readonly RoutedEvent DeleteEvent = EventManager.RegisterRoutedEvent
        (
           "Delete",
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(User)
        );

        public event RoutedEventHandler Delete 
        {
            add { AddHandler(DeleteEvent, value); }
            remove { RemoveHandler(DeleteEvent, value); }
        }

        void RaiseDeleteEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(User.DeleteEvent);
            RaiseEvent(newEventArgs);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.DeleteImage.MouseDown += new MouseButtonEventHandler(DeleteImage_MouseDown);
            this.EditImage.MouseDown += new MouseButtonEventHandler(EditImage_MouseDown);
        }

        void DeleteImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RaiseDeleteEvent();
        }

        public static readonly RoutedEvent EditEvent = EventManager.RegisterRoutedEvent
        (
           "Edit",
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(User)
        );

        public event RoutedEventHandler Edit
        {
            add { AddHandler(EditEvent, value); }
            remove { RemoveHandler(EditEvent, value); }
        }

        void RaiseEditEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(User.EditEvent);
            RaiseEvent(newEventArgs);
        }

        void EditImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RaiseEditEvent();
        }
    }
}
