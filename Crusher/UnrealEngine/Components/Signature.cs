using System.Text;
using Crusher.Infrastructure;

namespace Crusher.UnrealEngine.Components
{
    public sealed class Signature : ISerializableComponent, IEquatable<Signature>
    {
        private static byte[] HeaderValue { get; } = Encoding.ASCII.GetBytes("GVAS");

        public byte[] Value { get; private set; } = new byte[4];

        internal Signature()
        {
        }

        public void Validate()
        {
            if (!HeaderValue.SequenceEqual(Value))
            {
                throw new UnrealFormatException("Signature did not match the expected 'GVAS' byte string.");
            }
        }

        public void Deserialize(BinaryReader reader) 
            => Value = reader.ReadBytes(4);

        public void Serialize(BinaryWriter writer) 
            => writer.Write(HeaderValue);

        public bool Equals(Signature? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            
            return Value.SequenceEqual(other.Value);
        }

        public override bool Equals(object? obj)
        {
            return ReferenceEquals(this, obj) 
                   || obj is Signature other && Equals(other);
        }

        public override int GetHashCode() 
            => Value.GetHashCode();

        public static bool operator ==(Signature? left, Signature? right) 
            => Equals(left, right);

        public static bool operator !=(Signature? left, Signature? right) 
            => !Equals(left, right);
    }
}