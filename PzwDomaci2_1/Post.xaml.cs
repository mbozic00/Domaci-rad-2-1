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
    /// Interaction logic for Post.xaml
    /// </summary>
    public partial class Post : UserControl
    {
        public Post()
        {
            InitializeComponent();
        }

        public string PostUserName
        {
            get { return (string)GetValue(PostUserNameProperty); }
            set { SetValue(PostUserNameProperty, value); }
        }

        public static readonly DependencyProperty PostUserNameProperty = DependencyProperty.Register
        (
          "PostUserName",
          typeof(string),
          typeof(Post),
          new UIPropertyMetadata("PostUserName")
        );

        public string PostImageSource
        {
            get { return (string)GetValue(PostImageSourceProperty); }
            set { SetValue(PostImageSourceProperty, value); }
        }

        public static readonly DependencyProperty PostImageSourceProperty = DependencyProperty.Register
        (
          "PostImageSource",
          typeof(string),
          typeof(Post),
          new UIPropertyMetadata("PostImageSource")
        );

        public string BackgroundColor
        {
            get { return (string)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static readonly DependencyProperty BackgroundColorProperty = DependencyProperty.Register
        (
          "BackgroundColor",
          typeof(string),
          typeof(Post),
          new UIPropertyMetadata("BackgroundColor")
        );

        public string PostText
        {
            get { return (string)GetValue(PostTextProperty); }
            set { SetValue(PostTextProperty, value); }
        }

        public static readonly DependencyProperty PostTextProperty = DependencyProperty.Register
        (
          "PostText",
          typeof(string),
          typeof(Post),
          new UIPropertyMetadata("PostText")
        );

        public static readonly RoutedEvent DeleteEvent = EventManager.RegisterRoutedEvent
        (
           "Delete",
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(Post)
        );

        public event RoutedEventHandler Delete
        {
            add { AddHandler(DeleteEvent, value); }
            remove { RemoveHandler(DeleteEvent, value); }
        }

        void RaiseDeleteEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(Post.DeleteEvent);
            RaiseEvent(newEventArgs);
        }

        private void PostControl_Loaded(object sender, RoutedEventArgs e)
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
            typeof(Post)
        );

        public event RoutedEventHandler Edit
        {
            add { AddHandler(EditEvent, value); }
            remove { RemoveHandler(EditEvent, value); }
        }

        void RaiseEditEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(Post.EditEvent);
            RaiseEvent(newEventArgs);
        }

        void EditImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RaiseEditEvent();
        }
    }
}
