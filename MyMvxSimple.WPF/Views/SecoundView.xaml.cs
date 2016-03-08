﻿using System;
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
using MvvmCross.Wpf.Views;
using MyMvxSimple.Core.ViewModels;

namespace MyMvxSimple.WPF.Views
{
    /// <summary>
    /// Interaction logic for FirstView.xaml
    /// </summary>
    public partial class SecoundView : MvxWpfView
    {
        public new SecoundViewModel ViewModel
        {
            get { return (SecoundViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        public SecoundView()
        {
            InitializeComponent();
        }
    }
}
