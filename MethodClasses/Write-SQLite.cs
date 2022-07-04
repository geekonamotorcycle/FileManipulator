using Dapper;
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
                if (File.Exists(get_Settings.ConnectionString) == false)
                {
                    Console.WriteLine("The Database Exists");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The Database Does not Exists");
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
                using IDbConnection DBConn = new SQLiteConnection(DBConnectionString);
                var output = DBConn.Query<PublicFileInformationModel>("select * from FileRecords", new DynamicParameters());
                return output.ToList();
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
        public void TestSQLiteConnection()
        {
            Gather_Files_Create_Models gather_Files_Create_Models = new();
            List<FileInformationModel> models = gather_Files_Create_Models.Files();
            try
            {
                foreach (var item in models)
                {
                    WriteToDB(item);
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
