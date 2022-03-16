using System;
using System.IO;

namespace Exceptions
{
    public static class ExceptionFilters
	{
		public static bool IsDirectoryOrFileException(Exception ex)
		{
			var isDirOrFileException =
				(
				  (ex is ArgumentNullException argNullEx)
				  && (
						string.Equals(argNullEx.ParamName, "directory", StringComparison.OrdinalIgnoreCase)
						|| string.Equals(argNullEx.ParamName, "fileName", StringComparison.OrdinalIgnoreCase)
					 )
				)
				|| (ex is DirectoryNotFoundException)
				|| (ex is FileNotFoundException);

			return isDirOrFileException;
		}

		public static bool IsFileContentReplaceException(Exception ex)
		{
			var isFilContentReplaceException =
				(
				  (ex is ArgumentNullException argNullEx)
				  && (
						string.Equals(argNullEx.ParamName, "searchText", StringComparison.OrdinalIgnoreCase)
						|| string.Equals(argNullEx.ParamName, "replaceWithText", StringComparison.OrdinalIgnoreCase)
					 )
				);

			return isFilContentReplaceException;
		}
	}
}
