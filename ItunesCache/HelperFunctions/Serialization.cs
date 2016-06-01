using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ItunesCache.HelperFunctions
{
    public static class Serialization
    {
        public static T DeserializeFromFile<T>(string filename)
        {
            T deserialized;
            using (Stream stream = File.Open(filename, FileMode.Open))
            {
                deserialized = (T)new BinaryFormatter().Deserialize(stream);
                stream.Close();
            }
            return deserialized;
        }

        public static void SerializeToFile(object objectToSerialize, string filename)
        {
            using (Stream stream = File.Open(filename, FileMode.Create, FileAccess.ReadWrite))
            {
                new BinaryFormatter().Serialize(stream, objectToSerialize);
                stream.Close();
            }
        }
    }
}
