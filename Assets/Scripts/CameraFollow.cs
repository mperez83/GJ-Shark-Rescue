using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Player player;
    public float camUpperBound;
    public float camLowerBound;
    public float camLeftBound;
    public float camRightBound;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

        if (transform.position.y > camUpperBound)
        {
            transform.position = new Vector3(transform.position.x, camUpperBound, transform.position.z);
        }

        if (transform.position.y < camLowerBound)
        {
            transform.position = new Vector3(transform.position.x, camLowerBound, transform.position.z);
        }

        if (transform.position.x < camLeftBound)
        {
            transform.position = new Vector3(camLeftBound, transform.position.y, transform.position.z);
        }

        if (transform.position.x > camRightBound)
        {
            transform.position = new Vector3(camRightBound, transform.position.y, transform.position.z);
        }
    }
}