using Crusher.Infrastructure;

namespace Crusher.UnrealEngine.Components
{
    public sealed class Header : ISerializableComponent, IEquatable<Header>
    {
        public Signature Signature { get; } = new();

        public int SaveVersion { get; set; }
        public int PackageVersion { get; set; }

        public EngineVersion EngineVersion { get; } = new();
        public CustomFormatContainer CustomFormats { get; } = new();

        public string? ClassName { get; set; }

        internal Header()
        {
        }

        public void Deserialize(BinaryReader reader)
        {
            Signature.Deserialize(reader);
            Signature.Validate();

            SaveVersion = reader.ReadInt32();
            PackageVersion = reader.ReadInt32();

            EngineVersion.Deserialize(reader);
            CustomFormats.Deserialize(reader);

            ClassName = reader.ReadUnrealEngineString();
        }

        public void Serialize(BinaryWriter writer)
        {
            Signature.Validate();
            Signature.Serialize(writer);

            writer.Write(SaveVersion);
            writer.Write(PackageVersion);

            EngineVersion.Serialize(writer);
            CustomFormats.Serialize(writer);
            
            writer.WriteUnrealEngineString(ClassName);
        }

        public bool Equals(Header? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            
            return Signature.Equals(other.Signature) 
                && SaveVersion == other.SaveVersion 
                && PackageVersion == other.PackageVersion
                && EngineVersion.Equals(other.EngineVersion)
                && CustomFormats.Equals(other.CustomFormats)
                && ClassName == other.ClassName;
        }

        public override bool Equals(object? obj)
        {
            return ReferenceEquals(this, obj) 
                || obj is Header other 
                && Equals(other);
        }

        public override int GetHashCode() 
            => HashCode.Combine(Signature, SaveVersion, PackageVersion, EngineVersion, CustomFormats, ClassName);

        public static bool operator ==(Header? left, Header? right) 
            => Equals(left, right);

        public static bool operator !=(Header? left, Header? right) 
            => !Equals(left, right);
    }
}