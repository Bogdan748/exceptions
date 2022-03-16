using System;

namespace Exceptions
{
    class Program
    {
		public static void Main()
		{
			try
			{
				// TODO: Run in VS because DotNetFiddle doesn't handle console reads
				Console.Write("Enter directory path=");
				var directory = Console.ReadLine();

				Console.Write("Enter file name=");
				var fileName = Console.ReadLine();

				Console.Write("Lookup text=");
				var lookupText = Console.ReadLine();

				Console.Write("Replace with text=");
				var replaceWithText = Console.ReadLine();

				FileProcessor.ReplaceText(directory, fileName, lookupText, replaceWithText);
			}
			catch (ArgumentNullException argEx) when (ExceptionFilters.IsDirectoryOrFileException(argEx))
			{
				Console.WriteLine("Directory or file exception!");
				Console.WriteLine(argEx.Message);
				Console.WriteLine(argEx.StackTrace);
			}
			catch (ArgumentNullException argEx) when (ExceptionFilters.IsFileContentReplaceException(argEx))
			{
				Console.WriteLine("Content replace exception!");
				Console.WriteLine(argEx.Message);
				Console.WriteLine(argEx.StackTrace);
			}
			catch (Exception otherEx)
			{
				Console.WriteLine("Other exception occured!");
				Console.WriteLine(otherEx.Message);
				Console.WriteLine(otherEx.StackTrace);
			}
		}
	}
}
