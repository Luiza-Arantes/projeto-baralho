using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

[CreateAssetMenu(fileName = "AudioLibrary", menuName = "ScriptableObjects/AudioLibrary", order = 6)]
public class AudioLibrary : ScriptableObject
{
    public SerializableDictionary<string, EventReference> sounds = new SerializableDictionary<string, EventReference>();
    public SerializableDictionary<string, EventReference> eventIntances = new SerializableDictionary<string, EventReference>();
    public SerializableDictionary<string, EventReference> bgm = new SerializableDictionary<string, EventReference>();
}
