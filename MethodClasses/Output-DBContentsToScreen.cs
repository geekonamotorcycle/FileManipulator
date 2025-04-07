/*
 * FILE: Output_DBContentsToScreen.cs
 *
 * DESCRIPTION:
 * This class retrieves information from the SQLite database and displays it
 * on the console in JSON format. It provides a way to visualize the data
 * that has been stored persistently.
 *
 * PLANNED IMPROVEMENTS:
 *
 * 1. QUERY OPTIONS
 *    - Add filtering capabilities for database queries
 *    - Implement sorting and ordering options
 *    - Create complex query support with multiple conditions
 *
 * 2. PAGINATION
 *    - Implement pagination for large result sets
 *    - Add navigation controls for browsing results
 *    - Create customizable page size options
 *
 * 3. DISPLAY FORMATTING
 *    - Enhance JSON formatting with syntax highlighting
 *    - Add alternative display formats (table, list, etc.)
 *    - Implement customizable property selection for display
 *
 * 4. DATA VISUALIZATION
 *    - Add basic charts and graphs for numeric data
 *    - Implement statistical summaries of database contents
 *    - Create visual representation of relationships
 *
 * 5. EXPORT OPTIONS
 *    - Add direct export of query results to files
 *    - Implement clipboard export functionality
 *    - Create integration with reporting tools
 *
 * 6. PERFORMANCE
 *    - Optimize query execution for large databases
 *    - Implement streaming results for better memory usage
 *    - Add query execution statistics and optimization
 *
 * 7. INTERACTIVE FEATURES
 *    - Add interactive query building capabilities
 *    - Implement drill-down functionality for related data
 *    - Create saved query favorites for frequent use
 *
 * 8. SECURITY
 *    - Add sensitive data masking options
 *    - Implement access control for database operations
 *    - Create audit logging for database queries
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FileManipulator.MethodClasses;

namespace FileManipulator
{
    internal class Output_DBContentsToScreen
    {
        public Output_DBContentsToScreen()
        {
            List<PublicFileInformationModel> SQLDump = new List<PublicFileInformationModel>();
            Write_SQLite write_SQLite = new Write_SQLite();
            SQLDump = write_SQLite.GetDBContents();
            foreach (var item in SQLDump)
            {
                try
                {
                    var options = new JsonSerializerOptions { WriteIndented = true };
                    string jsonString = JsonSerializer.Serialize(item, options);
                    Console.WriteLine(jsonString);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.ToString}");
                    throw;
                }
            }
            Console.WriteLine($"Press any Key to continue");
            Console.ReadKey();
        }
    }
}
