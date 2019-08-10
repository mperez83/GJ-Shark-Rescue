using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    Vector2 velocity;
    float movementDrag = 0.5f;

    [HideInInspector]
    public Player player;

    void Start()
    {

    }

    void Update()
    {
        if (player != null)
        {
            Vector2 targetPos = player.transform.position;
            transform.position = Vector2.SmoothDamp(transform.position, targetPos, ref velocity, movementDrag);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (player == null && other.CompareTag("Player"))
        {
            player = other.GetComponent<Player>();
            player.AddToTrashList(this);
        }
    }
}