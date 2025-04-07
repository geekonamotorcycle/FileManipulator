/*
 * FILE: CheckExists.cs
 *
 * DESCRIPTION:
 * This utility class provides methods to verify the existence of files and directories.
 * It serves as a validation layer before performing operations on paths.
 *
 * PLANNED IMPROVEMENTS:
 *
 * 1. ENHANCED VALIDATION
 *    - Add permission checking for files and directories
 *    - Implement size and free space validation
 *    - Add validation for path length and character restrictions
 *
 * 2. ACCESS TESTING
 *    - Add methods to verify read/write access to paths
 *    - Implement lock detection for files
 *    - Add timeout options for network resources
 *
 * 3. ERROR DETAILS
 *    - Return detailed error information rather than boolean results
 *    - Implement a Result pattern with error codes and messages
 *    - Add suggestions for resolving common access issues
 *
 * 4. ASYNC SUPPORT
 *    - Add async versions of validation methods
 *    - Implement cancellation token support
 *    - Create non-blocking validation for UI responsiveness
 *
 * 5. EXTENDED VALIDATION
 *    - Add validation for file types and signatures
 *    - Implement path sanitization for security
 *    - Add support for validating URL-based resources
 *
 * 6. CACHING
 *    - Implement caching for repeated validation requests
 *    - Add cache invalidation strategies
 *    - Create a timeout mechanism for cached results
 *
 * 7. NETWORK AWARENESS
 *    - Add special handling for network paths
 *    - Implement retry logic for intermittent connections
 *    - Add timeout configuration for network operations
 *
 * 8. LOGGING AND TELEMETRY
 *    - Add detailed logging of validation operations
 *    - Implement performance tracking for validation calls
 *    - Create statistics for validation success/failure rates
 */


namespace FileManipulator.Classes
{
    internal class CheckExists
    {
        public bool CheckDirectory(string DirectoryPath)
        {
            if (Directory.Exists(DirectoryPath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
