using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMnager : MonoBehaviour
{
    public static SoundMnager instance;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource[] fxVoice;
    [SerializeField] private AudioClip[] musicClips;
    private AudioClip randomMusicClip;
    public bool isMusicActive = true;
    public bool isFxActive = true;

    public IconManager musicIcon;
    public IconManager fxIcon;




    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        randomMusicClip = RandomChooseMusic(musicClips);
        BackgroundMusic(randomMusicClip);
    }

    AudioClip RandomChooseMusic(AudioClip[] clips)
    {
        AudioClip randomClip = clips[Random.Range(0, clips.Length)];
        return randomClip;
    }

    public void BackgroundMusic(AudioClip clipp)
    {
        if (!clipp || !musicSource || !isMusicActive)
        {
            return;
        }

        musicSource.volume = PlayerPrefs.GetFloat("musicVolume");
        musicSource.clip = clipp;
        musicSource.Play();
    }

    void MusicUpdate()
    {
        if (musicSource.isPlaying != isMusicActive)
        {
            if (isMusicActive)
            {
                randomMusicClip = RandomChooseMusic(musicClips);
                BackgroundMusic(randomMusicClip);
            }
            else
            {
                musicSource.Stop();
            }
        }
    }


    public void BackgroundMusicOnOff()
    {
        isMusicActive = !isMusicActive;
        MusicUpdate();
        musicIcon.IconTurn(isMusicActive);
    }

    public void FxMusicOnOff()
    {
        isFxActive = !isFxActive;
        fxIcon.IconTurn(isFxActive);
    }


    public void FxPlay(int whichfx)
    {
        if (isFxActive)
        {
            fxVoice[whichfx].volume = PlayerPrefs.GetFloat("FxVolume");
            fxVoice[whichfx].Stop();
            fxVoice[whichfx].Play();
        }
    }

}
