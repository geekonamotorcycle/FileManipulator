namespace FileManipulator.Interfaces
{
    internal interface IGet_Raw
    {
        string SourcePath { get; set; }
        bool IsRaw{ get; }

        
    }
}