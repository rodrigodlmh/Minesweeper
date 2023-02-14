using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradebookScenario
{
    /// <summary>
    /// The class which is used to represent a user interface theme.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class Theme
    {
        /// <summary>
        /// The background color of the theme.
        /// </summary>
        public string BackgroundColor;

        /// <summary>
        /// The font color of the theme.
        /// </summary>
        public string FontColor;

        /// <summary>
        /// An indicator of whether or not the font is bold.
        /// </summary>
        public bool FontIsBold;

        /// <summary>
        /// An indicator of whether or not the font is italic.
        /// </summary>
        public bool FontIsItalic;

        /// <summary>
        /// The name of the font.
        /// </summary>
        public string FontName;

        /// <summary>
        /// The size of the font.
        /// </summary>
        public double FontSize;

        /// <summary>
        /// An indicator of whether or not the theme is high contrast.
        /// </summary>
        public bool IsHighContrast;

        /// <summary>
        /// The name of the theme.
        /// </summary>
        public string Name;
    }
}