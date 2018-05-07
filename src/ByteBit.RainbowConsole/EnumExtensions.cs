using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;


namespace ByteBit.RainbowConsole {
	public static class EnumExtensions {
		public static T ToEnum<T>( this int value ) where T : struct {
			return (T)(object)value;
		}

		public static string ToEnumName<T>( this int value ) where T : struct {
			return ((T)(object)value).ToString();
		}

		public static string GetDisplayName( this Enum enumValue ) {
			return enumValue.GetType()
							.GetMember( enumValue.ToString() )
							.First()
							.GetCustomAttribute<DisplayAttribute>()
							.GetName();
		}
	}
}
