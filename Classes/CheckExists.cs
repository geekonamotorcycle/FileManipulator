namespace FileManipulator.Classes
{
    internal class CheckExists
    {
        public bool CheckDirectory(string DirectoryPath)
        {
            if (Directory.Exists(DirectoryPath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool CheckFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}

