using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileMix
{
	internal class FileReader
	{
		public static IEnumerable<string> ReadLines(string path)
		{
			return File.ReadLines(path).Select(x => x.Trim()).Where(x => !string.IsNullOrEmpty(x));
		}
	}
}