using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip bgm_source;

    [SerializeField]
    private List<AudioClip> source = new List<AudioClip>();

    [SerializeField]
    private GameObject bgmGameObject, attackSoundEffectGameObject;

    private AudioSource soundEffect, bgm, attackSoundEffect;

    private List<AudioSource> placedSoundEffect = new List<AudioSource>();

    private float bgm_volume, soundEffect_volume;

    private static SoundManager soundManager;
    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (soundManager == null)
        {
            soundManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
        this.gameObject.AddComponent<AudioSource>();
        soundEffect = GetComponent<AudioSource>();
        attackSoundEffectGameObject.AddComponent<AudioSource>();
        attackSoundEffect = attackSoundEffectGameObject.GetComponent<AudioSource>();

        bgm_volume = 0.2f;
        soundEffect_volume = 1f;
        PlayBGM();
    }


    private void Update()
    {
        bgm.volume = bgm_volume;
    }
    private void PlayBGM()
    {
        bgmGameObject.AddComponent<AudioSource>();
        bgm = bgmGameObject.GetComponent<AudioSource>();
        bgm.clip = bgm_source;
        bgm.playOnAwake = true;
        bgm.loop = true;
        bgm.Play();
    }

    public void AddLowPassFilter()
    {
        AudioLowPassFilter audioLowPassFilter;
        audioLowPassFilter = bgmGameObject.AddComponent<AudioLowPassFilter>();
        audioLowPassFilter.cutoffFrequency = 500;
    }

    public void RemoveLowPassFilter()
    {
        AudioLowPassFilter audioLowPassFilter;
        audioLowPassFilter = bgmGameObject.GetComponent<AudioLowPassFilter>();
        Destroy(audioLowPassFilter);
    }

    public void PlaySoundEffect(int id)
    {
        soundEffect.volume = soundEffect_volume;
        soundEffect.PlayOneShot(source[id]);
    } 

    public void AdjustSoundEffectVolume(float volume)
    {
        soundEffect_volume = volume;
    }

    public void AdjustBGMVolume(float volume)
    {
        bgm_volume = volume;
    }

    public bool CheckAudioIsPlaying(int id)
    {
        return !soundEffect.isPlaying;
    }

    public void MuteAll()
    {
        soundEffect.mute = true ;
        bgm.mute = true;
    }

    public void UnMuteAll()
    {
        soundEffect.mute = false;
        bgm.mute = false;
    }
}
