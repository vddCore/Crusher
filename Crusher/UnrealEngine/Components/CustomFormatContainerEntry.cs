using Crusher.Infrastructure;

namespace Crusher.UnrealEngine.Components
{
    public sealed class CustomFormatContainerEntry : ISerializableComponent, IEquatable<CustomFormatContainerEntry>
    {
        public Guid GUID { get; set; }
        public int Value { get; set; }

        internal CustomFormatContainerEntry()
        {
        }
        
        public void Deserialize(BinaryReader reader)
        {
            GUID = new Guid(reader.ReadBytes(16));
            Value = reader.ReadInt32();
        }

        public void Serialize(BinaryWriter writer)
        {
            writer.Write(GUID.ToByteArray());
            writer.Write(Value);
        }

        public bool Equals(CustomFormatContainerEntry? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            
            return GUID.Equals(other.GUID)
                && Value == other.Value;
        }

        public override bool Equals(object? obj)
        {
            return ReferenceEquals(this, obj) 
                || obj is CustomFormatContainerEntry other 
                && Equals(other);
        }

        public override int GetHashCode() 
            => HashCode.Combine(GUID, Value);

        public static bool operator ==(CustomFormatContainerEntry? left, CustomFormatContainerEntry? right) 
            => Equals(left, right);

        public static bool operator !=(CustomFormatContainerEntry? left, CustomFormatContainerEntry? right) 
            => !Equals(left, right);
    }
}