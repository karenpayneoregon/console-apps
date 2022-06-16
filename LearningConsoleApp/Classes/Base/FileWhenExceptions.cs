using System;
using System.IO;

namespace LearningConsoleApp.Classes.Base
{
    public class FileWhenExceptions
    {
        /// <summary>
        /// For learning how to work with reading a file that may not exists or locked.
        /// Here we deal with any issues in a general fashion
        /// </summary>
        public static (string[] list, Exception exception) ReadFileConventional(string fileName)
        {
            try
            {
                return (File.ReadAllLines(fileName), null);
            }
            catch (Exception localException)
            {
                return (null, localException);
            }
        }

        /// <summary>
        /// For learning how to work with reading a file that may not exists or locked.
        /// Here we deal with each issue type conditionally using [when] along with
        /// checking error messages case insensitive.
        ///
        /// Meant to be executed with one of the issues.
        ///
        /// When executed with no issues, list has lines in the file
        /// When executed with issues message has the error message.
        ///
        /// For a real application we should write the error message to a log file with exception
        /// type. See the LoggingConsoleApp for one idea how to write to a log file and categorize
        /// the error message.
        /// </summary>
        public static (string[] list, string message) ReadFileWithWhenFilter(string fileName)
        {
            try
            {
                return (File.ReadAllLines(fileName), null);
            }
            catch (Exception localException) when (localException.Message.Contains("Could not find file", StringComparison.OrdinalIgnoreCase))
            {
                return (null, $"'{fileName}' is missing dude");
            }
            catch (Exception localException) when (localException.Message.Contains("denied", StringComparison.OrdinalIgnoreCase))
            {
                return (null, $"insufficient rights to {fileName}");
            }
            catch (Exception localException) when (localException.Message.Contains("The process cannot access", StringComparison.OrdinalIgnoreCase))
            {
                return (null, $"Someone has {fileName} opened exclusively");
            }
            catch (Exception localException)
            {
                return (null, localException.Message);
            }
        }

   
    }
}