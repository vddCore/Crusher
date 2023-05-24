using System.Text;
using Crusher.UnrealEngine.Components;

namespace Crusher.UnrealEngine
{
    public class SaveFile : IEquatable<SaveFile>
    {
        public Header Header { get; } = new();
        
        private SaveFile()
        {
        }

        public static SaveFile Read(Stream inStream)
        {
            var ret = new SaveFile();
            {
                using (var reader = new BinaryReader(inStream, Encoding.UTF8, true))
                {
                    ret.Header.Deserialize(reader);
                }
            }
            
            return ret;
        }

        public SaveFile Write(Stream outStream)
        {
            using (var writer = new BinaryWriter(outStream, Encoding.UTF8, true))
            {
                Header.Serialize(writer);
            }

            return this;
        }

        public bool Equals(SaveFile? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            
            return Header.Equals(other.Header);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            
            return Equals((SaveFile)obj);
        }

        public override int GetHashCode() 
            => Header.GetHashCode();

        public static bool operator ==(SaveFile? left, SaveFile? right) 
            => Equals(left, right);

        public static bool operator !=(SaveFile? left, SaveFile? right) 
            => !Equals(left, right);
    }
}