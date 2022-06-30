namespace FileManipulator
{
    internal class Move_File
    {

        public string SourcePath { get; set; } = string.Empty;
        public string DestinationPath { get; set; } = string.Empty;
        public bool MoveSuccess { get; private set; }

        private string PathOnly { get; set; } = string.Empty;

        public Move_File(string SourcePath, string DestinationPath)
        {
            this.MoveSuccess = false;
            this.DestinationPath = DestinationPath;
            this.SourcePath = SourcePath;
            this.PathOnly = Path.GetDirectoryName(DestinationPath);

            if (Directory.Exists(this.PathOnly) == false)
            {
                CreatePath();
            }
            else
            {
                this.Move_Files();
            }
        }
        private void Move_Files()
        {
            if (Directory.Exists(this.PathOnly))
            {
                try
                {
                    File.Move(SourcePath, DestinationPath);
                    if (File.Exists(DestinationPath))
                    {
                        this.MoveSuccess = true;
                    }
                    else
                    {
                        this.MoveSuccess = false;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The process failed: {0}", e.ToString());
                    this.MoveSuccess = false;
                    throw;
                }
            }
            else
            {
                try
                {
                    this.CreatePath();
                    File.Move(SourcePath, DestinationPath);
                    if (File.Exists(DestinationPath))
                    {
                        this.MoveSuccess = true;
                    }
                    else
                    {
                        this.MoveSuccess = false;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The process failed: {0}", e.ToString());
                    this.MoveSuccess = false;
                    throw;
                }
            }

        }
        private void CreatePath()
        {
            Directory.CreateDirectory(this.PathOnly);
        }
    }
}
