using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource startSoundEffect;
    private float timer = 0;
    private float timer2 = 0;
    private bool startGameActive = false;
    private bool startTutori = false;
    private bool gohome = false;
    private bool fullScreener = true;

    void Update()
    {
        if (startGameActive)
        {
            timer += Time.deltaTime;
            if (timer >= 2f)
            {
                startGameActive = false;
                SceneManager.LoadScene("levela");
            }
        }
        if (startTutori)
        {
            timer += Time.deltaTime;
            if (timer >= 2f)
            {
                startGameActive = false;
                SceneManager.LoadScene("Tutorial");
            }
        }
        if (gohome)
        {
            timer += Time.deltaTime;
            if (timer >= 2f)
            {
                startGameActive = false;
                SceneManager.LoadScene("Menu");
            }
        }
        if (fullScreener)
        {
            timer2 += Time.deltaTime;
            if (timer2 >= 0.1f)
            {
                Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow);
                fullScreener = false;
            }
        }
    }

    public void startGame()
    {
        backgroundMusic.Stop();
        startSoundEffect.Play();
        startGameActive = true;
    }

    public void startTutor()
    {
        backgroundMusic.Stop();
        startSoundEffect.Play();
        startTutori = true;
    }

    public void goBackToMainMenu()
    {
        backgroundMusic.Stop();
        startSoundEffect.Play();
        gohome = true;
    }

    public void exitUnity()
    {
        Application.Quit();
    }
}
