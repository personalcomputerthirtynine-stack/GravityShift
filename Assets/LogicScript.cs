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
    private bool startGameActive = false;
    private bool startTutori = false;
    private bool gohome = false;

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
}
