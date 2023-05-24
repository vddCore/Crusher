namespace Crusher.Infrastructure
{
    public interface ISerializableComponent
    {
        void Deserialize(BinaryReader reader);
        void Serialize(BinaryWriter writer);
    }
}