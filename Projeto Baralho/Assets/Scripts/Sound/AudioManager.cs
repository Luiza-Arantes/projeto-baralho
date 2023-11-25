using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using System.Text.RegularExpressions;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioLibrary library;

    [Header("Volume")]
    public float defaultVolume = 0.7f;
    [Range(0, 1)] public float masterVolume;
    [Range(0, 1)] public float musicVolume;
    [Range(0, 1)] public float sfxVolume;

    private Dictionary<string, EventInstance> eventInstances;
    private Dictionary<string, EventInstance> bgm;

    private EventInstance currentRegion;
    private string currentRegionKey;

    Bus musicBus;
    Bus sfxBus;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }

        eventInstances = new Dictionary<string, EventInstance>();
        bgm = new Dictionary<string, EventInstance>();

        foreach (var reference in library.eventIntances)
        {
            EventInstance instance = RuntimeManager.CreateInstance(reference.Value);
            eventInstances.Add(reference.Key, instance);
        }

        foreach (var reference in library.bgm)
        {
            EventInstance instance = RuntimeManager.CreateInstance(reference.Value);
            bgm.Add(reference.Key, instance);
        }

        musicBus = RuntimeManager.GetBus("bus:/Music");
        sfxBus = RuntimeManager.GetBus("bus:/SFX");

        musicVolume = defaultVolume * masterVolume;
        musicBus.setVolume(musicVolume);

        sfxVolume = defaultVolume * masterVolume;
        sfxBus.setVolume(sfxVolume);

        PlayBGM("MenuMusic");
    }

    public void PlaySound(string sound, Vector3 worldPos)
    {
        EventReference reference = library.sounds[sound];
        RuntimeManager.PlayOneShot(reference, worldPos);
    }

    public void PlayEventInstance(string sound)
    {
        EventInstance instance = eventInstances[sound];
        instance.start();
    }

    public void StopEventInstanceFade(string sound)
    {
        EventInstance instance = eventInstances[sound];
        instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    public void StopEventInstanceImmediate(string sound)
    {
        EventInstance instance = eventInstances[sound];
        instance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }

    public void PlayBGM(string bgmKey)
    {
        if (!bgm.ContainsKey(bgmKey))
            return;

        if (bgmKey!=currentRegionKey)
        {
            currentRegion.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            currentRegion=bgm[bgmKey];
            currentRegionKey=bgmKey;
            currentRegion.start();
        }

    }

    public void SetMasterVolume(float volume)
    {
        masterVolume = volume;
        SetMusicVolume(musicVolume);
        SetSFXVolume(sfxVolume);
    }

    public void SetMusicVolume(float volume)
    {
        musicVolume = volume * masterVolume;
        musicBus.setVolume(musicVolume);
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume * masterVolume;
        sfxBus.setVolume(sfxVolume);
    }
}
