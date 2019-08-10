using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Player player;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = player.transform.position;
    }
}