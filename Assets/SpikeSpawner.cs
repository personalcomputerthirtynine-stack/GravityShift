using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    private bool startable = true;
    public GameObject spikeObject;
    private float timer;
    public float frequency;
    private GameObject newchild;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startable)
        {
            newchild = Instantiate(spikeObject, transform.position, transform.rotation);
            newchild.transform.SetParent(transform, true);
            startable = false;
            timer = 0f;
        } else
        {
            if (timer >= frequency)
            {
                startable = true;
            } else
            {
                timer += Time.deltaTime;
            }
        }
    }
}
