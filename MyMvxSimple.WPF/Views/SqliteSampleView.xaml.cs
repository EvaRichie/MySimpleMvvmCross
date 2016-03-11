using MvvmCross.Wpf.Views;
using MyMvxSimple.Core.ViewModels;
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

namespace MyMvxSimple.WPF.Views
{
    /// <summary>
    /// Interaction logic for SqliteSampleView.xaml
    /// </summary>
    public partial class SqliteSampleView : MvxWpfView
    {
        public new SqliteSampleViewModel ViewModel
        {
            get { return (SqliteSampleViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        public SqliteSampleView()
        {
            InitializeComponent();
        }
    }
}
