
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    private bool jumpable = false;
    public Rigidbody2D myRigidbody;
    public int jumpVelocity;
    private bool failLevel = false;
    private bool winLevel = false;
    private float timer = 0;
    public string nextLevel;
    public AudioSource backgroundMusic;
    public GameObject levelMoverObject;
    private LevelMover levelMoverScript;
    public AudioSource winMusic;
    public AudioSource loseMusic;

    void Start()
    {
        levelMoverScript = levelMoverObject.GetComponent<LevelMover>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && jumpable && !failLevel)
        {
            myRigidbody.velocity = new Vector2(0, jumpVelocity * myRigidbody.gravityScale / 2);
        }

        if (Input.GetKeyDown(KeyCode.RightShift) && jumpable && !failLevel)
        {
            myRigidbody.gravityScale *= -1;
        }

        if (failLevel)
        {
            backgroundMusic.Stop();
            timer += Time.deltaTime;
            levelMoverScript.stopSelf();

            if (timer >= 2.75f)
            {
                failLevel = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        transform.rotation = Quaternion.Euler(0, 0, 0);

        if (winLevel)
        {
            backgroundMusic.Stop();
            timer += Time.deltaTime;

            if (timer >= 1.5f)
            {
                winLevel = false;
                SceneManager.LoadScene(nextLevel);
            }
        }

        transform.position = new Vector3(-6.02f, transform.position.y, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        Debug.Log(collision.gameObject.tag);
        if (collision.collider.gameObject.CompareTag("TopCollider"))
        {
            jumpable = true;
            Debug.Log("Jumpable");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TopCollider"))
        {
            jumpable = false;
            Debug.Log("Not Jumpable");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Killer"))
        {
            failLevel = true;
            loseMusic.Play();
        }

        if (collision.gameObject.CompareTag("Winbox"))
        {
            winLevel = true;
            winMusic.Play();
        }
    }
}
