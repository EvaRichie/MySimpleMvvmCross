using MvvmCross.Wpf.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using System.Windows.Threading;
using MvvmCross.Wpf.Views;

namespace MyMvxSimple.WPF
{
    public class Setup : MvxWpfSetup
    {
        public Setup(Dispatcher uiThreadDispatcher, IMvxWpfViewPresenter presenter) : base(uiThreadDispatcher, presenter)
        {

        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }
    }
}
