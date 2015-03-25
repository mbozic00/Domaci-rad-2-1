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
using PzwDomaci2_1;

namespace PzwDomaci2_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {

            for (var i = 0; i < this.UsersContainer.Children.Count; i++)
            {
                var element = this.UsersContainer.Children[i];
                if (element is User)
                {
                    var user = (User)element;
                    user.Delete += new RoutedEventHandler(user_Delete);
                    user.Edit += new RoutedEventHandler(user_Edit);
                }
            }

            for (var i = 0; i < this.PostsContainer.Children.Count; i++)
            {
                var element = this.PostsContainer.Children[i];
                if (element is Post)
                {
                    var post = (Post)element;
                    post.Delete += new RoutedEventHandler(post_Delete);
                    post.Edit += new RoutedEventHandler(post_Edit);
                }
            }
        }

        void user_Delete(object sender, RoutedEventArgs e)
        {
            if (!(sender is User))
            {
                return;
            }
            var user = sender as User;

            var indexOfElement = this.UsersContainer.Children.IndexOf(user);

            if (indexOfElement == -1)
            {
                return;
            }

            this.UsersContainer.Children.RemoveAt(indexOfElement);
        }

        void user_Edit(object sender, RoutedEventArgs e)
        {
            if (!(sender is User))
            {
                return;
            }
            var user = sender as User;

            var oldText = user.UserNameTextBlock.Text;

            user.UserNameTextBlock.Text = Microsoft.VisualBasic.Interaction.InputBox("Enter a new name for this user",
                                           "New User Name",
                                           user.UserNameTextBlock.Text,
                                           -1, -1);

            if(user.UserNameTextBlock.Text == "")
                user.UserNameTextBlock.Text = oldText;
        }

        void post_Delete(object sender, RoutedEventArgs e)
        {
            if (!(sender is Post))
            {
                return;
            }
            var post = sender as Post;

            var indexOfElement = this.PostsContainer.Children.IndexOf(post);

            if (indexOfElement == -1)
            {
                return;
            }

            this.PostsContainer.Children.RemoveAt(indexOfElement);
        }

        void post_Edit(object sender, RoutedEventArgs e)
        {
            if (!(sender is Post))
            {
                return;
            }
            var post = sender as Post;

            var oldText = post.PostTextBlock.Text;

            post.PostTextBlock.Text = Microsoft.VisualBasic.Interaction.InputBox("Edit the text of this post",
                                           "Edit Post",
                                           post.PostTextBlock.Text,
                                           -1, -1);

            if (post.PostTextBlock.Text == "")
                post.PostTextBlock.Text = oldText;
        }
    }
}
