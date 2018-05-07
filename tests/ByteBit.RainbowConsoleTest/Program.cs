using System;
using ByteBit.RainbowConsole;

namespace ByteBit.RainbowConsoleTest {
	class Program {
		static void Main( string[] args ) {
			var usingVariable = "Hello";
			Rainbow.Parse( $"{usingVariable:Cyan} {ConsoleColor.Red:world} using {ConsoleColor.Yellow:Rainbow} {ConsoleColor.Green:console}" ).RainbowWriteParsedText();

			Rainbow.RainbowWriteText( $"Greetings, this is {ConsoleColor.Red:hello world example} to {ConsoleColor.Green:you} using {nameof( ByteBit.RainbowConsole ):yellow}" );

			"Writing with colored line".ColoredLine( foregroundColor: ConsoleColor.Yellow );

			Console.WriteLine( "all done!" );
		}

	}
}
