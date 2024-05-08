using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    ScenePersist scenePersist;
    public bool isGamePaused;
    public GameObject pausePanel;

    

    void Start()
    {
        scenePersist = FindObjectOfType<ScenePersist>();
        if (pausePanel)
        {
            pausePanel.SetActive(false);
        }
        else
        {
            pausePanel.SetActive(false);
        }
    }

    

    public void PausePanelOnOff()
    {

        isGamePaused = !isGamePaused;
        pausePanel.SetActive(isGamePaused);
        //SoundMnager.instance.FxPlay(0);
        Time.timeScale = (isGamePaused) ? 0 : 1;
        
    }

    public void PlayAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void HomeBtn()
    {
        scenePersist.ResetScenePersist();
        SceneManager.LoadScene("MainMenu");
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)){
            PausePanelOnOff();
        }
        else if(Input.GetKey(KeyCode.Escape))
        {
            PausePanelOnOff();
        }
        
    }

    void OnApplicationFocus(bool pauseStatus) {
    if(!pauseStatus){
        PausePanelOnOff();
    }
}
}
