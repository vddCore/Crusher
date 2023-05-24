using Crusher.Infrastructure;

namespace Crusher.UnrealEngine.Components
{
    public sealed class EngineVersion : ISerializableComponent, IEquatable<EngineVersion>
    {
        public short Major { get; set; }
        public short Minor { get; set; }
        public short Patch { get; set; }
        public int Build { get; set; }
        public string? Branch { get; set; } = string.Empty;

        public void Deserialize(BinaryReader reader)
        {
            Major = reader.ReadInt16();
            Minor = reader.ReadInt16();
            Patch = reader.ReadInt16();
            Build = reader.ReadInt32();
            Branch = reader.ReadUnrealEngineString();
        }

        public void Serialize(BinaryWriter writer)
        {
            writer.Write(Major);
            writer.Write(Minor);
            writer.Write(Patch);
            writer.Write(Build);
            writer.WriteUnrealEngineString(Branch);
        }

        public bool Equals(EngineVersion? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            
            return Major == other.Major 
                && Minor == other.Minor 
                && Patch == other.Patch
                && Build == other.Build
                && Branch == other.Branch;
        }

        public override bool Equals(object? obj)
        {
            return ReferenceEquals(this, obj) 
                || obj is EngineVersion other 
                && Equals(other);
        }

        public override int GetHashCode()
            => HashCode.Combine(Major, Minor, Patch, Build, Branch);

        public static bool operator ==(EngineVersion? left, EngineVersion? right) 
            => Equals(left, right);

        public static bool operator !=(EngineVersion? left, EngineVersion? right) 
            => !Equals(left, right);
    }
}