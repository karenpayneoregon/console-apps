using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CustomerDatabaseLibraryEntityFramework.LanguageExtensions
{
    public static class Extensions
    {
        /// <summary>
        /// Test connection with exception handling
        /// </summary>
        /// <param name="context"><see cref="DbContext"/></param>
        /// <returns></returns>
        public static async Task<(bool success, Exception exception)> CanConnectAsync(this DbContext context)
        {
            try
            {
                return (await Task.Run(async () => await context.Database.CanConnectAsync()), null);
            }
            catch (Exception localException)
            {
                return (false, localException);
            }
        }
    }
}
