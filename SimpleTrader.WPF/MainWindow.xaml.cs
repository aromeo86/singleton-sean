using System.Runtime.InteropServices.ObjectiveC;
using System.Windows;

namespace SimpleTrader.WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow(object dataContext)
        {
            InitializeComponent();
            DataContext = dataContext;
        }
    }
}