using System.Text;

namespace Crusher.Infrastructure
{
    internal static partial class Extensions
    {
        public static string AsAsciiString(this byte[] bytes) 
            => Encoding.ASCII.GetString(bytes);
    }
}