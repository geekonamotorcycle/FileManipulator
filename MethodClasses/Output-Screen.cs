/*
 * FILE: Output_Screen.cs
 *
 * DESCRIPTION:
 * This class handles the display of file information to the console screen
 * in JSON format. It provides a way to visualize the data model for inspection
 * and debugging.
 *
 * PLANNED IMPROVEMENTS:
 *
 * 1. DISPLAY FORMATTING
 *    - Implement syntax highlighting for JSON output
 *    - Add collapsible sections for complex objects
 *    - Create tabular view option for easier reading
 *
 * 2. PAGINATION
 *    - Add pagination support for large datasets
 *    - Implement scrolling and navigation controls
 *    - Create search functionality within displayed data
 *
 * 3. FILTERING OPTIONS
 *    - Add filtering capabilities by property values
 *    - Implement property selection for focused display
 *    - Create sorting options for different criteria
 *
 * 4. CUSTOM VIEWS
 *    - Add predefined view templates (summary, detailed, etc.)
 *    - Create user-definable view profiles
 *    - Implement context-sensitive views based on content
 *
 * 5. INTERACTIVE FEATURES
 *    - Add ability to drill down into complex objects
 *    - Implement interactive editing of displayed properties
 *    - Create comparison view for multiple files
 *
 * 6. EXPORT OPTIONS
 *    - Add export to clipboard functionality
 *    - Implement direct file export from the view
 *    - Create integration with other reporting tools
 *
 * 7. VISUALIZATION
 *    - Add graphical elements for data visualization
 *    - Implement basic charts for numerical properties
 *    - Create relationship diagrams for linked objects
 *
 * 8. PERFORMANCE
 *    - Optimize rendering for large datasets
 *    - Implement virtual scrolling for better memory usage
 *    - Add background loading for complex objects
 */


using System.Text.Json;
using FileManipulator.Classes;
using FileManipulator.MethodClasses;

namespace FileManipulator
{
    public class Output_Screen
    {
        public Output_Screen()
        {
            Gather_Files_Create_Models gather_Files_Create_Model = new();
            List<FileInformationModel> models = gather_Files_Create_Model.Files();

            foreach (var item in models)
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(item, options);
                Console.WriteLine(jsonString);
            }
            Console.ResetColor();
            Console.WriteLine("Press Any Key to return to the main menu");
            Console.ReadKey();
        }
    }
}
