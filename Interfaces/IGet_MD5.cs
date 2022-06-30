namespace FileManipulator.Interfaces
{
    internal interface IGet_MD5
    {
        string FilePath { get; set; }
        string MD5Value { get; }
    }
}