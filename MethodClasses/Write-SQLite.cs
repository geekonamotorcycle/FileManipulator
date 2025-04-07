/*
 * FILE: Write_SQLite.cs
 *
 * DESCRIPTION:
 * This class handles database operations for the application, including writing
 * file information to a SQLite database and retrieving stored records. It uses
 * Dapper for data access.
 *
 * PLANNED IMPROVEMENTS:
 *
 * 1. REPOSITORY PATTERN
 *    - Implement the repository pattern for data access
 *    - Create an interface for the repository to support different database providers
 *    - Separate query logic from data access code
 *
 * 2. UNIT OF WORK
 *    - Implement Unit of Work pattern for transaction management
 *    - Support for batch operations with proper transaction handling
 *    - Add rollback support for failed operations
 *
 * 3. CONNECTION MANAGEMENT
 *    - Improve database connection management
 *    - Implement connection pooling for better performance
 *    - Add proper connection disposal and cleanup
 *
 * 4. MIGRATION SUPPORT
 *    - Add database schema migration capabilities
 *    - Implement version tracking for database schema
 *    - Support for upgrading database schema between versions
 *
 * 5. QUERY OPTIMIZATION
 *    - Add indexes for commonly queried fields
 *    - Implement paging for large result sets
 *    - Add support for complex queries with joins
 *
 * 6. ERROR HANDLING
 *    - Implement database-specific error handling
 *    - Add retry logic for transient errors
 *    - Improve error messages and logging
 *
 * 7. ASYNCHRONOUS OPERATIONS
 *    - Convert database operations to async
 *    - Implement cancellation token support
 *    - Use async streams for large result sets
 *
 * 8. SECURITY IMPROVEMENTS
 *    - Implement parameterized queries for all operations
 *    - Add support for database encryption
 *    - Implement proper access control for sensitive operations
 */



using System.Data;
using System.Data.SQLite;
using Dapper;

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
                Console.WriteLine(
                    $"Something went wrong when contructing the Write_SQLite class \n{e.ToString}"
                );
                Console.ResetColor();
                throw;
            }
        }

        public List<PublicFileInformationModel> GetDBContents()
        {
            try
            {
                using IDbConnection DBConn = new SQLiteConnection(DBConnectionString);
                var output = DBConn.Query<PublicFileInformationModel>(
                    "select * from FileRecords",
                    new DynamicParameters()
                );
                return output.ToList();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(
                    $"There was an error while connecting or reading the DB\n{e.ToString}"
                );
                Console.ResetColor();
                throw;
            }
        }

        public void WriteToDB(FileInformationModel DataToWrite)
        {
            try
            {
                using (IDbConnection DBConn = new SQLiteConnection(DBConnectionString))
                    DBConn.Execute(
                        "insert into FileRecords (SourcePath,FileName,FilExtension,IsRAW,MD5FileHash,DateSource,FSCreatedDate,FSModifiedDate,"
                            + "ExifOrigDate,DestinationBase,EXIFdestpath,FSCreatedDestPath,FSModifiedDestPath,FileMoved) values (@SourcePath,@FileName,@FilExtension,@IsRAW,"
                            + "@MD5FileHash,@DateSource,@FSCreatedDate,@FSModifiedDate,@ExifOrigDate,@DestinationBase,@EXIFdestpath,@FSCreatedDestPath,@FSModifiedDestPath,@FileMoved)",
                        DataToWrite
                    );
                ;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(
                    $"There was an error while connecting or writing to the DB\n{e.ToString}"
                );
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
                Console.WriteLine(
                    $"There was an error while connecting or writing to the DB\n{e.ToString}"
                );
                Console.ResetColor();
                throw;
            }
        }
    }
}
