using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace FileMix
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			switch (args.Length)
			{
				case 2:
					Process(args[0], args[1]);
					break;
				default:
					var app = Path.GetFileName(Assembly.GetExecutingAssembly().Location);
					Console.WriteLine("Usage: {0} input1.txt input2.txt", app);
					break;
			}
		}

		private static void Process(string file1, string file2)
		{
			var i = 0;
			foreach (var line in FileReader.ReadLines(file1))
			{
				var name = string.Format("{0:00}-{1}.txt", i, line);
				var lines = FileReader.ReadLines(file2).Select(x => string.Format("\"{0}\" {1}", line, x)).ToArray();
				File.WriteAllLines(name, lines);
				i++;
			}

			Console.WriteLine("Done. {0} files written.", i);
		}
	}
}