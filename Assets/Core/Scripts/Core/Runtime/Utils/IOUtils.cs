using System;
using System.IO;
using System.Text;
using UnityEngine;

// Save&Load Copyright belongs to: https://github.com/shapedbyrainstudios/save-load-system - I upgraded the code
public static class IOUtils
{
	public const string encryptionWord = "XOR";
	public const string backupExtension = ".backup";


	/// <summary> Replaces '/' and '\\' with <see cref="Path.DirectorySeparatorChar"/> </summary>
	public static string FixPathByCorrectDirectorySeperator(string path)
	{
		path = path.Replace('/', Path.DirectorySeparatorChar);
        return path.Replace('\\', Path.DirectorySeparatorChar);
	}

	/// <remarks> Use '/' in <paramref name="fullPathWithExtension"/> for platform relative dir seperator </remarks>
	public static void Load(string fullPathWithExtension, out string loadedData, bool useDecryption = false, bool allowRestoreFromBackup = true)
	{
		fullPathWithExtension = FixPathByCorrectDirectorySeperator(fullPathWithExtension);
		loadedData = default;

		// load the serialized data from the file
		try
		{
			using (var stream = new FileStream(fullPathWithExtension, FileMode.Open))
			{
				using var reader = new StreamReader(stream);
				loadedData = reader.ReadToEnd();
			}

			if (useDecryption)
				loadedData = EncryptDecrypt(loadedData);
		}
		// Try to load backup if any exists
		catch (Exception e)
		{
			if (allowRestoreFromBackup)
			{
				Debug.LogWarning($"Filed to load file. Attempting to Rollback: {e}");

				SaveBackupAsMainFile(fullPathWithExtension);

				// verify the newly saved file can be loaded successfully
				Load(fullPathWithExtension, out loadedData, useDecryption, false);
				return;
			}

			// if we hit here, one possibility is that the backup file is also corrupt
			throw;
		}
	}

	/// <remarks> Use '/' in <paramref name="fullPathWithExtension"/> for platform relative dir seperator </remarks>
	public static void Save(string dataToStore, string fullPathWithExtension, bool useEncryption = false, bool createBackup = true)
	{
		fullPathWithExtension = FixPathByCorrectDirectorySeperator(fullPathWithExtension);
		Directory.CreateDirectory(Path.GetDirectoryName(fullPathWithExtension));

		if (useEncryption)
			dataToStore = EncryptDecrypt(dataToStore);

		// write the serialized data to the file
		using (var stream = new FileStream(fullPathWithExtension, FileMode.Create))
		{
			using var writer = new StreamWriter(stream);
			writer.Write(dataToStore);
		}

		// verify the newly saved file can be loaded successfully
		Load(fullPathWithExtension, out _, useEncryption, false);
			
		if (createBackup)
			File.Copy(fullPathWithExtension, (fullPathWithExtension + backupExtension), true);
	}

	public static void Delete(string fullPathWithExtension, bool deleteBackupIfExists = true)
	{
		File.Delete(fullPathWithExtension);

		if (deleteBackupIfExists)
		{
			try
			{
				File.Delete(fullPathWithExtension + backupExtension);
			}
			catch { }
		}
	}

	/// <summary> Simple implementation of XOR encryption </summary>
	public static string EncryptDecrypt(string data)
	{
		var stringBuilder = new StringBuilder(data.Length);

		for (int i = 0; i < data.Length; i++)
			stringBuilder.Append((char)(data[i] ^ encryptionWord[i % encryptionWord.Length]));

		return stringBuilder.ToString();
	}

	public static void SaveBackupAsMainFile(string fullPathWithExtension)
	{
		string backupFilePath = FixPathByCorrectDirectorySeperator(fullPathWithExtension + backupExtension);

		File.Copy(backupFilePath, fullPathWithExtension, true);
		Debug.LogWarning($"Backup saved as main file to path {fullPathWithExtension}");
	}
}