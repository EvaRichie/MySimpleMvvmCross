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
            if(parameter == null || parameter.ToString() != "reverse")
            {
                var visibility = value == true ? MvxVisibility.Visible : MvxVisibility.Collapsed;
                var canResolve = Mvx.CanResolve<IMvxNativeVisibility>();
                if (canResolve)
                    return Mvx.Resolve<IMvxNativeVisibility>().ToNative(visibility);
                else
                    return null;
            }
            else
            {
                var visibility = value == false ? MvxVisibility.Collapsed : MvxVisibility.Visible;
                var canResolve = Mvx.CanResolve<IMvxNativeVisibility>();
                if (canResolve)
                    return Mvx.Resolve<IMvxNativeVisibility>().ToNative(visibility);
                else
                    return null;
            }
        }
    }
}
