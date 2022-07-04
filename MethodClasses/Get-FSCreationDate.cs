using FileManipulator.Interfaces;

namespace FileManipulator
{
    internal class Get_FSCreationDate : IGet_Dates
    {
        private readonly string _sourcePath;
        public DateTime ReturnedDateTime { get; private set; }
        public string sourcepath { get; set; } = string.Empty;

        public Get_FSCreationDate(string sourcepath)
        {
            _sourcePath = sourcepath;
            GetFSCreationDateTime();
        }
        private void GetFSCreationDateTime()
        {
            DateTime date = File.GetCreationTime(_sourcePath);
            ReturnedDateTime = date;
        }

    }
}
