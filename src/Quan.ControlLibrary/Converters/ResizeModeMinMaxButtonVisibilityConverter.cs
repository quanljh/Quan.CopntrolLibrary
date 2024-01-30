﻿using System.Globalization;
using System.Windows;
using Quan.ControlLibrary.Enums;

namespace Quan.ControlLibrary.Converters;

public class ResizeModeMinMaxButtonVisibilityConverter : BaseMultiValueConverter<Visibility>
{
    public override Visibility Convert(object[] values, object parameter, CultureInfo culture)
    {
        if (values != null && parameter is ResizeModeButtonType whichButton)
        {
            var showButton = (values.ElementAtOrDefault(0) as bool?).GetValueOrDefault(true);

            if (whichButton == ResizeModeButtonType.Close)
            {
                return !showButton ? Visibility.Collapsed : Visibility.Visible;
            }

            var windowResizeMode = (values.ElementAtOrDefault(1) as ResizeMode?).GetValueOrDefault(ResizeMode.CanResize);

            switch (windowResizeMode)
            {
                case ResizeMode.NoResize:
                    return Visibility.Collapsed;
                case ResizeMode.CanMinimize:
                    if (whichButton == ResizeModeButtonType.Min)
                    {
                        return !showButton ? Visibility.Collapsed : Visibility.Visible;
                    }

                    return Visibility.Collapsed;
                case ResizeMode.CanResize:
                case ResizeMode.CanResizeWithGrip:
                default:
                    return !showButton ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        return Visibility.Visible;
    }

    public override object[] ConvertBack(Visibility value, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}