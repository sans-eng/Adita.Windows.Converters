using System;
using System.Globalization;
using System.Windows.Data;

namespace Adita.Windows.Converters
{
    /// <summary>
    /// Represents a less than converter for a primitive numeric value.
    /// </summary>
    public class LessThanConverter : IValueConverter
    {
        #region Public methods

        /// <summary>Converts a value. </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns <see langword="null" />, the valid null value is used.</returns>
        /// <exception cref="FormatException">value is not in an appropriate format for a primitive numeric  type.</exception>
        /// <exception cref="InvalidCastException">value does not implement the <see cref="IConvertible"/> interface. -or- The conversion is not supported.</exception>
        /// <exception cref="OverflowException">value represents a number that is less than <see cref="double.MinValue"/> or greater than <see cref="double.MaxValue"/>.</exception>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (double.TryParse(value.ToString(), out double inputValue) && double.TryParse(parameter.ToString(), out double comparerValue))
            {
                return inputValue < comparerValue;
            }
            else
            {
                throw new ArgumentException(Resources.ExceptionStrings.ArgumentInvalidType);
            }
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
