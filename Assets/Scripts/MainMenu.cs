using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private bool isStarting = false;

    public AudioSource startAudio;

    public Image sceneTransition;
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
        sceneTransition.raycastTarget = true;

        startAudio.Play();

        float t = 0;
        while(t < 3)
        {
            // Game start transition
            t += Time.deltaTime;
            Debug.Log(t);
            sceneTransition.color = new Color(0, 0, 0, t / 2);

            if(t > 1)
                startAudio.volume -= 0.3f * Time.deltaTime;

            yield return 0;
        }
        //yield return new WaitForSeconds(3f);

        SceneManager.LoadSceneAsync("Game");
    }
}
