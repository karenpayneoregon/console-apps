using Newtonsoft.Json;

namespace MenuConsoleApp.Classes
{
    public class JsonHelpers
    {

        /// <summary>
        /// List of T from file
        /// </summary>
        /// <typeparam name="T">Type to deserialize</typeparam>
        /// <param name="fileName">Read from file</param>
        /// <returns><see cref="ValueTuple"/> of <see cref="List{T}"/>  and <see cref="Exception"/></returns>
        public static (List<T>, Exception) JsonToList<T>(string fileName)
        {
            try
            {
                return (JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(fileName)), null)!;
            }
            catch (Exception exception)
            {
                return (null, exception)!;
            }

        }
       
    }
}