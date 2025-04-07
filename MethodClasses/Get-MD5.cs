/*
 * FILE: Get_MD5.cs
 *
 * DESCRIPTION:
 * This class calculates MD5 hash values for files to enable identification
 * and duplicate detection. It provides a unique fingerprint for each file.
 *
 * PLANNED IMPROVEMENTS:
 *
 * 1. HASH ALGORITHMS
 *    - Add support for additional hash algorithms (SHA-256, SHA-3, etc.)
 *    - Implement algorithm selection based on security requirements
 *    - Add multiple hash support for more robust identification
 *
 * 2. PERFORMANCE OPTIMIZATION
 *    - Implement chunked hashing for large files
 *    - Add parallel processing for better performance
 *    - Implement memory efficient streaming for very large files
 *
 * 3. CACHING SYSTEM
 *    - Add hash caching to avoid recalculating unchanged files
 *    - Implement cache invalidation based on file modification
 *    - Create a persistent cache for frequently accessed files
 *
 * 4. PARTIAL HASHING
 *    - Add support for partial file hashing (first N bytes)
 *    - Implement progressive hashing for quick identification
 *    - Create multi-stage hashing strategies for large files
 *
 * 5. ASYNC IMPLEMENTATION
 *    - Convert hashing operations to async
 *    - Add progress reporting for long-running hash calculations
 *    - Implement cancellation support for hash operations
 *
 * 6. VERIFICATION FEATURES
 *    - Add methods to verify files against known hashes
 *    - Implement batch verification for multiple files
 *    - Create reporting for verification results
 *
 * 7. SECURITY ENHANCEMENTS
 *    - Add secure hash comparison methods
 *    - Implement timing-attack resistant verification
 *    - Add support for keyed hashing (HMAC) where appropriate
 *
 * 8. INTEGRATION IMPROVEMENTS
 *    - Create a factory pattern for hash algorithm instantiation
 *    - Implement a service-based approach for hash calculations
 *    - Add plugin support for custom hash implementations
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using FileManipulator.Interfaces;

namespace FileManipulator
{
    internal class Get_MD5 : IGet_MD5
    {
        public string FilePath { get; set; } = string.Empty;
        public string MD5Value { get; private set; } = string.Empty;

        public Get_MD5(string FilePath)
        {
            this.FilePath = FilePath;
            ReturnMD5();
        }

        private void ReturnMD5()
        {
            MD5 md5 = MD5.Create();
            var stream = File.OpenRead(FilePath);
            MD5Value = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty);
            stream.Close();
            md5.Clear();
        }
    }
}
