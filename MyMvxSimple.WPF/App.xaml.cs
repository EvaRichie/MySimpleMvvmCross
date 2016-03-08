using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Wpf.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MyMvxSimple.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private bool isInitial = false;

        protected override void OnActivated(EventArgs e)
        {
            if (!isInitial)
                InitialMvx();
            base.OnActivated(e);
        }

        private void InitialMvx()
        {
            var presenter = new MvxSimpleWpfViewPresenter(MainWindow);
            var setup = new Setup(Dispatcher, presenter);
            setup.Initialize();
            var startup = Mvx.Resolve<IMvxAppStart>();
            startup.Start();
            isInitial = !isInitial;
        }
    }
}
