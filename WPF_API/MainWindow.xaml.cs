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

namespace WPF_API
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public API api = new API();
        public List<Post> Posts = new List<Post>();
        public MainWindow()
        {
            InitializeComponent();
            loadPosts();
        }
        public async void loadPosts()
        {
            Posts = await api.LoadPosts();
            CreatePosts();
        }
        public void CreatePosts()
        {
            foreach (Post post in Posts)
            {
                StackPanel panelPost = new StackPanel();
                //panelPost.Orientation = Orientation.Horizontal;
                MainPanel.Children.Add(panelPost);
                Label PostTitle = new Label();
                PostTitle.Content = post.title;
                panelPost.Children.Add(PostTitle);
                Label PostText = new Label();
                PostText.Content = post.body;
                panelPost.Children.Add(PostText);
                Label PostUserID = new Label();
                PostUserID.Content = post.id;
                PostUserID.HorizontalAlignment = HorizontalAlignment.Right;
                panelPost.Children.Add(PostUserID);
                panelPost.Children.Add(new Separator());
            }
           
        }
    }
    
}
