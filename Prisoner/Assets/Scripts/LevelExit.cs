using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] ParticleSystem exitEffect;
    public bool ended = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayExitEffect();
            SoundMnager.instance.FxPlay(2);
            StartCoroutine(LoadNextLevel());
            ended = true;
        }

    }

    IEnumerator LoadNextLevel()
    {

        yield return new WaitForSecondsRealtime(.6f);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        ended = false;
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    void PlayExitEffect()
    {
        ParticleSystem instance = Instantiate(exitEffect, transform.position, Quaternion.identity);

        instance.Play();

    }
}
