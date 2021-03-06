﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    Vector2 velocity;
    float movementDrag = 0.5f;
    public int scoreValue = 1;
    public bool isSalsa;

    [HideInInspector]
    public Player player;

    AudioSource audioSource;



    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-4f, 4f), Random.Range(-4f, 4f)));
        GetComponent<Rigidbody2D>().AddTorque(Random.Range(-10f, 10f));
    }

    void Update()
    {
        if (player != null)
        {
            Vector2 targetPos = player.transform.position;
            transform.position = Vector2.SmoothDamp(transform.position, targetPos, ref velocity, movementDrag);
        }
    }



    public int GetScore()
    {
        return scoreValue;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (player == null && other.CompareTag("Player"))
        {
            if (!isSalsa)
            {
                player = other.GetComponent<Player>();
                player.trashList.Add(this);
                audioSource.Play();
            }
            else
            {
                player = other.GetComponent<Player>();
                player.StartCoroutine("SalsaPower");
                Destroy(gameObject);
            }
        }

        if (other.CompareTag("Werewolf Shark"))
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        if (player != null) player.trashList.Remove(this);
    }
}