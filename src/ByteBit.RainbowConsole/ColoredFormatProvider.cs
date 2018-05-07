using System;
using ByteBit.RainbowConsole;

namespace ByteBit.RainbowConsole {
	public class ColoredFormatProvider : IFormatProvider {
		private readonly ColoredFormatter _formatter = new ColoredFormatter();
		public ColoredFormatProvider( string escapeString ) => this.EscapeString = escapeString;

		/// <summary>
		/// This string is used for internal color escaping.
		/// </summary>
		public string EscapeString {
			get => this._formatter.EscapeString;
			private set {
				this._formatter.EscapeString = value;
			}
		}

		public object GetFormat( Type formatType ) {
			if (formatType == typeof( ICustomFormatter ))
				return _formatter;
			return null;
		}


		public class ColoredFormatter : ICustomFormatter {
			private string escapeString = "::";
			public string EscapeString {
				get => escapeString;
				set {
					if (!string.IsNullOrWhiteSpace( value )) escapeString = value;
				}
			}

			/// <summary>
			/// Default constructor
			/// </summary>
			/// <param name="escapeString"></param>
			public ColoredFormatter( string escapeString = "::" ) {
				this.EscapeString = escapeString;
			}

			public string Format( string format, object arg, IFormatProvider formatProvider ) {
				// if (arg == null)
				// 	return "NULL";
				if (arg is string) {
					var color = format.StartsWith( "ConsoleColor." ) ? format.Replace( "ConsoleColor.", "" ) : format;
					return $"{escapeString}{color}{escapeString}{arg}{escapeString}";
				} else if (arg is ConsoleColor) {
					var color = (ConsoleColor)arg;
					return $"{escapeString}{color.ToString()}{escapeString}{format}{escapeString}";
				}
				// if (arg is DateTime)
				// 	return "'" + ((DateTime)arg).ToString( "MM/dd/yyyy" ) + "'";
				else if (arg is IFormattable)
					return ((IFormattable)arg).ToString( format, System.Globalization.CultureInfo.InvariantCulture );
				return arg.ToString();
			}
		}
	}
}
