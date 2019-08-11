using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WerewolfShark : MonoBehaviour
{
    public Player player;

    public float accelerationForce;
    public float maxSpeed;

    SpriteRenderer sr;
    Rigidbody2D rb;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 dir = transform.position - player.transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
            sr.flipY = true;
        else
            sr.flipY = false;
    }

    void FixedUpdate()
    {
        rb.AddForce(-transform.right * accelerationForce);

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().Explode();
        }
    }
}