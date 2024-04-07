using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private bool isStarting = false;

    public AudioSource startAudio;
    public void PlayGame()
    {
        if(!isStarting)
            StartCoroutine(startGame());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public IEnumerator startGame()
    {
        isStarting = true;

        startAudio.Play();
        yield return new WaitForSeconds(3f);

        SceneManager.LoadSceneAsync("Game");
    }
}
