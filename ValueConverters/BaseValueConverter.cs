using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Markup;

namespace BasicCRUDTool
{
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T: class, new()
    {
        /// <summary>
        /// A single static instance of a value converter
        /// </summary>
        private static T mConverter = null;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return mConverter ?? (mConverter = new T());
        }

        #region Value Converter Methods
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
    }

    #endregion
}