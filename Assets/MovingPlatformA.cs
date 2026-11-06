using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformA : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float firstWait;
    public float moveTime;
    private bool finishWait;
    private float timer = 0f;
    public float moveSpeed;
    public AudioSource nopeSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (finishWait)
        {
            if (timer < moveTime)
            {
                myRigidbody.velocity = new Vector2(0, myRigidbody.velocity.y + moveSpeed * Time.deltaTime);
                timer += Time.deltaTime;
            } else
            {
                myRigidbody.velocity = new Vector2(0, 0);
            }
        } else
        {
            if (timer >= firstWait)
            {
                finishWait = true;
                timer = 0f;
                Debug.Log("Played \"Nope Sound Effect \"");
                nopeSoundEffect.Play();
            } else
            {
                timer += Time.deltaTime;
            }
        }
    }
}
