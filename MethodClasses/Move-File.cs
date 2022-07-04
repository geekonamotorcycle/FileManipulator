namespace FileManipulator
{
    internal class Move_File
    {

        public string SourcePath { get; set; } = string.Empty;
        public string DestinationPath { get; set; } = string.Empty;
        private string PathOnly { get; set; } = string.Empty;
        public bool MoveSuccess { get; private set; }

        public Move_File(List<FileInformationModel> paths)
        {

            foreach (var item in paths)
            {
                this.SourcePath = item.SourcePath;
                this.DestinationPath = item.DestinationBase;
                this.PathOnly = item.DestinationBase;

                if (item.DateSource == "exif")
                {
                    this.DestinationPath = item.EXIFdestpath;
                }
                else if (item.DateSource == "created")
                {
                    this.DestinationPath = item.FSCreatedDestPath;
                }
                else if (item.DateSource == "modified")
                {
                    this.DestinationPath = item.FSCreatedDestPath;
                }
                else
                {
                    this.DestinationPath = item.FSCreatedDestPath;
                }

                try
                {
                    if (Directory.Exists(this.PathOnly) == false)
                    {
                        CreatePath();
                    }
                    else
                    {
                        this.Move_Files();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
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
            Console.WriteLine($"Created {this.PathOnly}");
        }
    }
}
