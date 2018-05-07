using System;

namespace ByteBit.RainbowConsole {
	public static class StringEx {
		public static void Write( this string text ) => System.Console.Write( text );
		public static void WriteLine( this string text ) => System.Console.WriteLine( text );

		/// <summary>
		/// Write text in console using specific colors
		/// </summary>
		/// <param name="text"></param>
		/// <param name="foregroundColor"></param>
		/// <param name="backgroundColor"></param>
		public static void Colored( this string text, ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black ) {
			var oldBacground = System.Console.BackgroundColor;
			var oldForeground = System.Console.ForegroundColor;

			System.Console.ForegroundColor = foregroundColor;
			System.Console.BackgroundColor = backgroundColor;
			System.Console.Write( text, foregroundColor );

			System.Console.BackgroundColor = oldBacground;
			System.Console.ForegroundColor = oldForeground;
		}

		/// <summary>
		/// Write text line in console using specific colors
		/// </summary>
		/// <param name="text"></param>
		/// <param name="foregroundColor"></param>
		/// <param name="backgroundColor"></param>
		public static void ColoredLine( this string text, ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black ) {
			var oldBacground = System.Console.BackgroundColor;
			var oldForeground = System.Console.ForegroundColor;

			System.Console.ForegroundColor = foregroundColor;
			System.Console.BackgroundColor = backgroundColor;
			System.Console.WriteLine( text, foregroundColor );

			System.Console.BackgroundColor = oldBacground;
			System.Console.ForegroundColor = oldForeground;
		}

		/// <summary>
		/// Get english alphabet
		/// </summary>
		/// <returns></returns>
		public static System.Collections.Generic.IEnumerable<char> EnglishAlphabet() {
			for (char c = 'A' ; c <= 'Z' ; c++) yield return c;
		}

		public static void UpdateLine( this string text ) {
			Console.CursorLeft = 0;
			Console.Write( text );
		}

		public static ConsoleColor ToConsoleColor( this string colorString ) {
			var outEnum = ConsoleColor.White;
			Enum.TryParse( colorString, ignoreCase: true, result: out outEnum );
			return outEnum;
		}
	}
}
