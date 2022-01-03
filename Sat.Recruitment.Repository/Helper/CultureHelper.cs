using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Sat.Recruitment.Repository.Helper
{
    public static class CultureHelper
    {
        public static NumberFormatInfo GetNumberFormat()
        {
            var currentCulture = CultureInfo.InstalledUICulture;
            var numberFormat = (NumberFormatInfo)currentCulture.NumberFormat.Clone();
            numberFormat.NumberDecimalSeparator = ".";

            return numberFormat;
        }
    }
}
