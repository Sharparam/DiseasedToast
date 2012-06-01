using System;
using System.IO;

using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

namespace RpgLibrary.Serializing
{
	public static class Serializer
	{
		private static readonly log4net.ILog Log = Logging.LogManager.GetLogger(typeof (Serializer));
		private static readonly Lazy<JsonSerializer> JsonSerializer = new Lazy<JsonSerializer>();

		public static string Serialize<T>(T data)
		{
			Log.Info("Serializing " + data.GetType() + " to string.");
			var writer = new StringWriter();
			JsonSerializer.Value.Serialize(writer, data);
			return writer.ToString();
		}

		public static void Serialize<T>(T data, string file)
		{
			Log.Info("Serializing " + data.GetType() + " to " + file);
			using (var writer = new FileStream(file, FileMode.Create, FileAccess.Write, FileShare.None))
				using (var bsonWriter = new BsonWriter(writer))
					JsonSerializer.Value.Serialize(bsonWriter, data);
		}

		public static T Deserialize<T>(string file)
		{
			Log.Info("Deserializing from " + file);

			T data;

			using (var stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read))
				using (var reader = new BsonReader(stream))
					data = JsonSerializer.Value.Deserialize<T>(reader);

			return data;
		}
	}
}
