using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float pushForce;
    public float rotateSpeed;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float rotateDirection = Input.GetAxisRaw("Horizontal");
        transform.Rotate(new Vector3(0, 0, (rotateSpeed * -rotateDirection) * Time.deltaTime));

        //Vector3 dir = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;
        //rigidbody2D.AddForce(dir * force);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * pushForce);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collector"))
        {
            print("yay");
        }
    }
}