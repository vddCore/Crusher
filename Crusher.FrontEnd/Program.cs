using Crusher.UnrealEngine;

var fs = File.Open(
    "SaveSlot_02.sav",
    FileMode.Open
);

var sf = SaveFile.Read(fs);