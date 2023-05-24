using System.Text;

namespace Crusher.Infrastructure
{
    internal static partial class Extensions
    {
        public static void WriteUnrealEngineString(this BinaryWriter writer, string? value)
        {
            if (value == null)
            {
                writer.Write(0);
            }
            else
            {
                var bytes = Encoding.UTF8.GetBytes(value);
                
                writer.Write(bytes.Length);

                if (bytes.Any())
                {
                    writer.Write(bytes);
                }
            }
        }
    }
}