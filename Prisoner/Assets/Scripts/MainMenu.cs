using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Transform mainMenu, settingsMenu;
    [SerializeField] AudioSource musicSource;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider fxSlider;
    
    void Start()
    {
        if (musicSlider && fxSlider)
        {
            if (!PlayerPrefs.HasKey("musicVolume"))
            {
            PlayerPrefs.SetFloat("musicVolume",1);
            musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
            }
            else
            {
            musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
            }

            fxSlider.value = 1;
        }
        
    }

    public void BackVolume()
    {
        musicSource.volume = musicSlider.value;
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
    }

    public void FxVolume()
    {
        PlayerPrefs.SetFloat("FxVolume", fxSlider.value);
    }

    public void SettingsMenuOpen()
    {
        mainMenu.GetComponent<RectTransform>().DOLocalMoveY(1200, .5f);
        settingsMenu.GetComponent<RectTransform>().DOLocalMoveY(0, .5f);

    }

    public void SettingsMenuClose()
    {
        mainMenu.GetComponent<RectTransform>().DOLocalMoveY(0, .5f);
        settingsMenu.GetComponent<RectTransform>().DOLocalMoveY(-1200, .5f);
    }


    public void GamePlay()
    {
        SceneManager.LoadScene("Level0.1");
    }

    public void QuitGame()
    {
       Application.Quit();
    }
}
