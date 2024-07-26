using System.Text.RegularExpressions;

namespace Finance.Expensia.Shared.Helpers
{
	public static partial class StringHelper
	{
		[GeneratedRegex("(\\B[A-Z])")]
		private static partial Regex CamelCaseRegex();

		// Fungsi untuk menambahkan spasi pada camel case
		public static string AddSpaceToCamelCase(this string value) 
			=> CamelCaseRegex().Replace(value, " $1");
	}
}
