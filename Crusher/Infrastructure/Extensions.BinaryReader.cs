using System.Text;

namespace Crusher.Infrastructure
{
    internal static partial class Extensions
    {
        public static string? ReadUnrealEngineString(this BinaryReader reader)
        {
            if (reader.PeekChar() < 0)
            {
                return null;
            }

            var stringLength = reader.ReadInt32();

            if (stringLength == 0)
            {
                return null;
            }

            if (stringLength == 1)
            {
                return string.Empty;
            }

            return Encoding.UTF8.GetString(
                reader.ReadBytes(stringLength)
            );
        }
    }
}