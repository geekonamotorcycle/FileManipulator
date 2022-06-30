namespace FileManipulator.Classes
{
    internal class CheckExists
    {

        public bool CheckDirectory(string DirectoryPath, bool verbose = false)
        {
            if (Directory.Exists(DirectoryPath))
            {
                if (verbose)
                {
                    Console.WriteLine($"The directory at {DirectoryPath} does exist");
                    return true;
                }
                else
                {
                    return true;
                }

            }
            else
            {
                if (verbose)
                {
                    Console.WriteLine($"The directory at {DirectoryPath} does NOT exist");
                    return true;
                }
                else
                {
                    return true;
                }
            }
        }
        public bool CheckFile(string filePath, bool verbose = false)
        {
            if (File.Exists(filePath))
            {
                if (verbose)
                {
                    Console.WriteLine($"The file at {filePath} does exist");
                    return true;
                }
                else
                {
                    return true;
                }

            }
            else
            {
                if (verbose)
                {
                    Console.WriteLine($"The file at {filePath} does NOT exist");
                    return false;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
