using System;
using System.IO;

public static class FileProcessor
{
	public static void ReplaceText(
		string directory, 
		string fileName, 
		string searchText, 
		string replaceWithText)
	{
		if (string.IsNullOrWhiteSpace(directory))
		{
			throw new ArgumentNullException(nameof(directory));
		}

		if (!Directory.Exists(directory))
		{
			throw new DirectoryNotFoundException($"Directory '{directory}' was not found");
		}

		if (string.IsNullOrWhiteSpace(fileName))
		{
			throw new ArgumentNullException(nameof(fileName));
		}

		var fullPath = Path.Combine(directory, fileName);
		if (!File.Exists(fullPath))
		{
			throw new FileNotFoundException($"File '{fullPath}' was not found");
		}

		if (string.IsNullOrEmpty(searchText))
		{
			throw new ArgumentNullException(nameof(searchText));
		}

		if (replaceWithText is null)
		{
			throw new ArgumentNullException(nameof(replaceWithText));
		}

		var fileContent = File.ReadAllText(fullPath);
		var newContent = fileContent.Replace(searchText, replaceWithText);
		File.WriteAllText(fullPath, newContent);
	}
}

