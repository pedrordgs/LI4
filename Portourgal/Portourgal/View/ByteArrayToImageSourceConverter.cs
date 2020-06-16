using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace Portourgal.View
{
    public class ByteArrayToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ImageSource retSource = null;
            if (value != null)
            {
                if ((string)value == "") retSource = ImageSource.FromFile("district.png");
                else
                {
                    byte[] imageAsBytes = System.Convert.FromBase64String((string)value);
                    var stream = new MemoryStream(imageAsBytes);
                    retSource = ImageSource.FromStream(() => stream);
                }
            }
            return retSource;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
