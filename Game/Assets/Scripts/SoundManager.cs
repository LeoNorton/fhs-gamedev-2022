using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SoundManager : MonoBehaviour
{
    [SerializeField] [Range(0, 1)] private float _volumeMultiplier = 1;

    private static SoundManager _instance;
    public static SoundManager Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(gameObject);
        else
            _instance = this;
    }

    [SerializeField] private List<SoundEffect> _soundEffects;
    public void OnValidate()
    {
        for (int i = 0; i < _soundEffects.Count; i++)
        {
            _soundEffects[i].OnValidate();
        }
    }

    public void PlayClickSoundEffect() => PlaySoundEffect(SoundType.Click);
    /// <summary>
    /// Plays a certain sound from an instance of the SoundManager. Volume is constant
    /// </summary>
    /// <param name="soundType">The type of sound that will play</param>
    public void PlaySoundEffect(SoundType soundType) => PlaySoundEffect(soundType, 0);
    /// <summary>
    /// Plays a certain sound from an instance of the SoundManager. Volume is constant
    /// </summary>
    /// <param name="soundType">The type of sound that will play</param>
    /// <param name="modifier">Modifier on the pitch of the sound</param>
    public void PlaySoundEffect(SoundType soundType, int modifier)
    {
        var matchingEffects = _soundEffects.Where(s => s.Type.Equals(soundType)).ToList();
        var soundEffect = matchingEffects[Random.Range(0, matchingEffects.Count)];
        var newSoundEffect = new GameObject($"Sound: {soundType}, {soundEffect.Clip.length}s");
        newSoundEffect.transform.parent = transform;
        Destroy(newSoundEffect, soundEffect.Clip.length * 1.5f);
        var source = newSoundEffect.AddComponent<AudioSource>();
        source.clip = soundEffect.Clip;
        source.volume = soundEffect.Volume * _volumeMultiplier;
        if (soundEffect.Vary) source.pitch += Random.Range(-0.1f, 0.1f);
        source.pitch += 0.05f * modifier; //used exclusively for the eating sound effect
        source.Play();
    }
}

[System.Serializable]
public enum SoundType
{
    Bleh,
    Eat,
    Icky,
    Condiment,
    Vegetable,
    Meat,
    Woosh,
    Toaster,
    Click,
    Bell,
    Thud,
}

[System.Serializable]
public struct SoundEffect
{
    [SerializeField] [HideInInspector] private string name;
    public SoundType Type;
    public AudioClip Clip;
    [Range(0, 1)] public float Volume;
    public bool Vary;
    public void OnValidate() => name = Type.ToString();
}