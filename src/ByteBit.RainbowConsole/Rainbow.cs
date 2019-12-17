using System;
using ByteBit.RainbowConsole;

namespace ByteBit.RainbowConsole {

	public static class Rainbow {
		/// <summary>
		/// Print line using colors
		/// </summary>
		/// <param name="text"></param>
		/// <param name="separator">Color separator</param>
		/// <param name="newLine">Move to new line at end of text</param>
		public static void RainbowWriteParsedText( this string text, string separator = "::", bool newLine = true ) {
			var start = 0;
			// do we have separators in text ?
			var separatorIndex = text.IndexOf( separator, startIndex: start );
			if (separatorIndex == -1) {
				Console.Write( text );
				if (newLine) Console.WriteLine();
				return;
			}

			var length = separatorIndex;

			// separator index is absolute position
			while (separatorIndex >= 0) {
				// write text till separator
				text.Substring( start, length ).Write();
				// move over separator
				start = separatorIndex + separator.Length;
				// get end of color string
				separatorIndex = text.IndexOf( separator, startIndex: start );
				// length of color string
				length = separatorIndex - start;
				var colorString = text.Substring( start, length );
				ConsoleColor color = StringEx.ToConsoleColor( colorString );
				// move over separator
				start = separatorIndex + separator.Length;
				// find size of text to display (location of end separator)
				separatorIndex = text.IndexOf( separator, startIndex: start );
				// get string length
				length = separatorIndex - start;
				// print text
				text.Substring( start, length ).Colored( color );
				// move pointer after last color escape separator
				start = separatorIndex + separator.Length;
				// do we have more color escape codes ?
				separatorIndex = text.IndexOf( separator, startIndex: start );
				length = separatorIndex - start;
			}
			// dump rest of string
			text.Substring( start, text.Length - start ).Write();
			if (newLine) System.Console.WriteLine();
		}

		public static string Parse( FormattableString formattable, string separator = "::" ) {
			return formattable.ToString( new ColoredFormatProvider( separator ) );
		}

		public static void RainbowWriteText( this FormattableString formattable, string separator = "::", bool newLine = true ) {
			var text = Rainbow.Parse( formattable, separator );
			text.RainbowWriteParsedText( separator: separator, newLine: newLine );
		}
	}
}
