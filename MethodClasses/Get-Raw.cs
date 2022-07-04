using FileManipulator.Interfaces;

namespace FileManipulator
{
    internal class Get_Raw : IGet_Raw
    {
        public string SourcePath { get; set; } = String.Empty;
        public bool IsRaw { get; private set; }
        private readonly string[] RawExtensions = { ".png", ".3fr", ".ari", ".arw", ".bay", ".braw", ".crw", 
            ".cr2", ".cr3", ".cap", ".data", ".dcs", ".dcr", ".dng", ".drf", ".eip", ".nef", ".erf", ".fff", 
            ".gpr", ".iiq", ".k25", ".kdc", ".mdc", ".mef", ".mos", ".mrw", ".nef", ".nrw", ".obm", ".orf", 
            ".pef", ".ptx", ".pxn", ".r3d", ".raf", ".raw", ".rwl", ".rw2", ".rwz", ".sr2", ".srf", ".srw", 
            ".tif", ".x3f" };
        
        public Get_Raw(string SourcePath)
        {
            this.SourcePath = SourcePath;
            ReturnRaw();
        }
        private void ReturnRaw()
        {
            string FileExtension = Path
                .GetExtension(SourcePath)
                .ToLower();
            if (RawExtensions.Contains(FileExtension))
            {
                this.IsRaw = true;
            }
            else
            {
                this.IsRaw = false;
            }
        }
    }
}
