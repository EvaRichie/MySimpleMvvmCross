using MvvmCross.Platform.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using MvvmCross.Platform.UI;
using MvvmCross.Platform;

namespace MyMvxSimple.Core.Converters
{
    public class BoolVisibilityConverter : MvxValueConverter<bool>
    {
        protected override object Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            var visibility = value == true ? MvxVisibility.Visible : MvxVisibility.Collapsed;
            var canResolve = Mvx.CanResolve<IMvxNativeVisibility>();
            if (canResolve)
            {
                var nativeVisbility = Mvx.Resolve<IMvxNativeVisibility>();
                return nativeVisbility.ToNative(visibility);
            }
            else
                return null;
        }
    }
}
