using Crusher.Infrastructure;

namespace Crusher.UnrealEngine.Components
{
    public sealed class CustomFormatContainer : ISerializableComponent, IEquatable<CustomFormatContainer>
    {
        private readonly List<CustomFormatContainerEntry> _entries = new();

        public IReadOnlyList<CustomFormatContainerEntry> Entries 
            => new List<CustomFormatContainerEntry>(_entries);

        public int ContainerVersion { get; set; }

        internal CustomFormatContainer()
        {
        }

        public CustomFormatContainerEntry AddNew() 
            => _entries.AddNew();

        public void Remove(CustomFormatContainerEntry entry)
            => _entries.Remove(entry);

        public void Deserialize(BinaryReader reader)
        {
            ContainerVersion = reader.ReadInt32();
            
            var count = reader.ReadInt32();
            for (var i = 0; i < count; i++)
            {
                _entries.AddNew().Deserialize(reader);
            }
        }

        public void Serialize(BinaryWriter writer)
        {
            writer.Write(ContainerVersion);

            writer.Write(_entries.Count);
            foreach (var entry in _entries)
            {
                entry.Serialize(writer);
            }
        }

        public bool Equals(CustomFormatContainer? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            
            return _entries.SequenceEqual(other._entries) 
                && ContainerVersion == other.ContainerVersion;
        }

        public override bool Equals(object? obj)
        {
            return ReferenceEquals(this, obj) 
                || obj is CustomFormatContainer other 
                && Equals(other);
        }

        public override int GetHashCode() 
            => HashCode.Combine(_entries, ContainerVersion);

        public static bool operator ==(CustomFormatContainer? left, CustomFormatContainer? right) 
            => Equals(left, right);

        public static bool operator !=(CustomFormatContainer? left, CustomFormatContainer? right) 
            => !Equals(left, right);
    }
}