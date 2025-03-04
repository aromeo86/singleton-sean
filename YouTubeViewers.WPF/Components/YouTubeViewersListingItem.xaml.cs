using System.Windows;
using System.Windows.Controls;

namespace YouTubeViewers.WPF.Components
{
    public partial class YouTubeViewersListingItem : UserControl
    {
        public YouTubeViewersListingItem()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dropdown.IsOpen = false;
        }
    }
}
