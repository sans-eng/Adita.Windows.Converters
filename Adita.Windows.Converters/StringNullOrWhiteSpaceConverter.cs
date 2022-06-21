﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace Adita.Windows.Converters
{
    /// <summary>
    /// Represents a string null or white space converter.
    /// </summary>
    public class StringNullOrWhiteSpaceConverter : IValueConverter
    {
        #region Public methods
        /// <summary>Converts a value. </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns <see langword="null" />, the valid null value is used.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not string)
                throw new ArgumentException(Resources.ExceptionStrings.ArgumentInvalidType);

            var input = (string)value;
            return string.IsNullOrWhiteSpace(input);
        }

        /// <summary>Converts a value. </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns <see langword="null" />, the valid null value is used.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion Public methods
    }
}
