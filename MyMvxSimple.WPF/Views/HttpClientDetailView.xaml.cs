using MvvmCross.Wpf.Views;
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
using System.Windows.Shapes;

namespace MyMvxSimple.WPF.Views
{
    /// <summary>
    /// Interaction logic for HttpClientDetailView.xaml
    /// </summary>
    public partial class HttpClientDetailView : MvxWpfView
    {
        public HttpClientDetailView()
        {
            InitializeComponent();
            this.Loaded += HttpClientDetailView_Loaded;
        }

        private void HttpClientDetailView_Loaded(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(DataContext.ToString());
        }
    }
}
