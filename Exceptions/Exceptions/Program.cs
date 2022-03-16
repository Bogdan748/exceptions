using System;
using System.Diagnostics;

namespace Exceptions
{
    class Program
    {
		public static void Main()
		{

			string[] list = StringArrayGenerator.RepeatString(10_000, "abc");

			Stopwatch watch1 = Stopwatch.StartNew();
			int[] integerArray1 = ConvertToIntArray_Normal(list);
			watch1.Stop();
			Console.WriteLine($"(1) List converted in {watch1.ElapsedMilliseconds} ms");
			Console.WriteLine(integerArray1.Length);
			Console.WriteLine(integerArray1[344]);
		}

		private static int[] ConvertToIntArray_Normal(string[] stringArray)
		{
			int[] result = new int[stringArray.Length];
			for (int i = 0; i < stringArray.Length; i++)
			{
				result[i] = ConversionHelper.ToInt(stringArray[i], 0);
			}

			return result;

		}
		private static void ExampleWithExceptionFilters()
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
