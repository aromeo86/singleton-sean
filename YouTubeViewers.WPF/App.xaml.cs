﻿using System.Windows;
using YouTubeViewers.WPF.ViewModels;

namespace YouTubeViewers.WPF
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new YouTubeViewersViewModel()
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }

}
