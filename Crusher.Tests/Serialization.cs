using Crusher.UnrealEngine;
using NUnit.Framework;

namespace Crusher.Tests
{
    public class Serialization
    {
        [Test]
        public void SerializedFileIsTheSameAsDeserializedFile()
        {
            using (var fs = new FileStream("SaveSlot_02.sav", FileMode.Open))
            {
                var saveFile = SaveFile.Read(fs);
                using (var ms = new MemoryStream())
                {
                    saveFile.Write(ms);
                    ms.Seek(0, SeekOrigin.Begin);

                    var saveFile2 = SaveFile.Read(ms);
                    
                    Assert.That(saveFile, Is.EqualTo(saveFile2));
                }                
            }
        }
    }
}