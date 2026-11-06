using UnityEngine;

public class LevelMover : MonoBehaviour
{
    private bool startedBool = false;
    private float timer = 0;
    public int levelVelocity;
    private bool stopSelfBool = false;

    void Update()
    {
        if (!startedBool)
        {
            timer += Time.deltaTime;

            if (timer >= 1)
            {
                startedBool = true;
            }
        }

        if (startedBool && !stopSelfBool)
        {
            transform.position = new Vector3(transform.position.x - levelVelocity * Time.deltaTime, transform.position.y, 0);
        }
    }
    public void stopSelf()
    {
        stopSelfBool = true;
    }
}