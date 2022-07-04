using Dapper;
using FileManipulator.Classes;
using System.Data;
using System.Data.SQLite;

namespace FileManipulator.MethodClasses
{
    internal class Write_SQLite
    {
        private string DBConnectionString { get; set; }
        private string DBProviderString { get; set; }

        public Write_SQLite()
        {

            try
            {
                Get_Settings get_Settings = new();
                DBConnectionString = get_Settings.ConnectionString;
                DBProviderString = get_Settings.ProviderName;
                if (!File.Exists(get_Settings.ConnectionString))
                {
                    Console.WriteLine("The Database Exists");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The Database Exists");
                    Console.ResetColor();
                }

            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Something went wrong when contructing the Write_SQLite class \n{e.ToString}");
                Console.ResetColor();
                throw;
            }
        }

        public List<PublicFileInformationModel> GetDBContents()
        {
            try
            {
                using (IDbConnection DBConn = new SQLiteConnection(DBConnectionString))
                {
                    var output = DBConn.Query<PublicFileInformationModel>("select * from FileRecords", new DynamicParameters());
                    return output.ToList();
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"There was an error while connecting or reading the DB\n{e.ToString}");
                Console.ResetColor();
                throw;
            }
        }

        public void WriteToDB(FileInformationModel DataToWrite)
        {
            try
            {
                using (IDbConnection DBConn = new SQLiteConnection(DBConnectionString))
                    DBConn.Execute("insert into FileRecords (SourcePath,FileName,FilExtension,IsRAW,MD5FileHash,DateSource,FSCreatedDate,FSModifiedDate," +
                        "ExifOrigDate,DestinationBase,EXIFdestpath,FSCreatedDestPath,FSModifiedDestPath,FileMoved) values (@SourcePath,@FileName,@FilExtension,@IsRAW," +
                        "@MD5FileHash,@DateSource,@FSCreatedDate,@FSModifiedDate,@ExifOrigDate,@DestinationBase,@EXIFdestpath,@FSCreatedDestPath,@FSModifiedDestPath,@FileMoved)", DataToWrite); ;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"There was an error while connecting or writing to the DB\n{e.ToString}");
                Console.ResetColor();
                throw;
            }
        }

        public void CheckSQLiteConnection()
        {
            try
            {
                Get_Settings fileinfosettings = new();
                string destpath = fileinfosettings.DestinationBase;
                Get_SourcePaths filegatherer = new(fileinfosettings.SourcePath);
                CheckExists checker = new();
                bool BaseDestExists = checker.CheckDirectory(destpath);
                List<FileInformationModel> files = new();

                foreach (var path in filegatherer.Geteresults())
                {
                    bool SourceFileExists = CheckExists.CheckFile(path);
                    if (SourceFileExists && BaseDestExists)
                    {
                        FileInformationModel FileInfoObject = new(path, destpath);
                        files.Add(FileInfoObject);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("One of the paths failed to check");
                        Console.ResetColor();
                    }

                }
                foreach (var item in files)
                {
                    using (IDbConnection DBConn = new SQLiteConnection(DBConnectionString))
                        DBConn.Execute("insert into FileRecords (SourcePath,FileName,FilExtension,IsRAW,MD5FileHash,DateSource,FSCreatedDate,FSModifiedDate," +
                            "ExifOrigDate,DestinationBase,EXIFdestpath,FSCreatedDestPath,FSModifiedDestPath,FileMoved) values (@SourcePath,@FileName,@FilExtension,@IsRAW," +
                            "@MD5FileHash,@DateSource,@FSCreatedDate,@FSModifiedDate,@ExifOrigDate,@DestinationBase,@EXIFdestpath,@FSCreatedDestPath,@FSModifiedDestPath,@FileMoved)", item);
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"There was an error while connecting or writing to the DB\n{e.ToString}");
                Console.ResetColor();
                throw;
            }

        }
    }
}
