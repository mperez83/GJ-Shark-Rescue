using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public InstanceMaster instanceMaster;

    public float pushForce;
    public float rotateSpeed;
    public float maxSpeed;

    public float strokeCooldownLength;
    float strokeCooldownTimer;

    public float maxAir;
    float air;
    public Image airMeter;

    public GameObject shopPanel;

    public List<Trash> trashList;

    Rigidbody2D rb;
    Animator anim;



    void Start()
    {
        air = maxAir;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //Handle rotate stuff
        float rotateDirection = Input.GetAxisRaw("Horizontal");
        transform.Rotate(new Vector3(0, 0, (rotateSpeed * -rotateDirection) * Time.deltaTime));

        //Handle swim stuff
        strokeCooldownTimer -= Time.deltaTime;
        if (strokeCooldownTimer < 0) strokeCooldownTimer = 0;

        if (Input.GetKey(KeyCode.Space))
        {
            if (strokeCooldownTimer <= 0)
            {
                strokeCooldownTimer = strokeCooldownLength;
                rb.AddForce(-transform.right * pushForce);
            }
        }

        //Limit speed
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        //Handle air
        if (transform.position.y > 1.8f)
        {
            air += Time.deltaTime * 3;
            if (air > maxAir) air = maxAir;
            airMeter.fillAmount = air / maxAir;
        }
        else
        {
            air -= Time.deltaTime;
            airMeter.fillAmount = air / maxAir;
            if (air <= 0)
            {
                instanceMaster.EndGame();
            }
        }
    }

    public void Explode()
    {
        rb.velocity = Vector2.zero;
        Destroy(GetComponent<BoxCollider2D>());
        anim.Play("Duck_Explode");
    }

    public void EndExplode()
    {
        instanceMaster.EndGame();
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collector"))
        {
            foreach (Trash trash in trashList)
            {
                instanceMaster.AddToScore(trash.GetScore());
                Destroy(trash.gameObject);
            }
            shopPanel.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Collector"))
        {
            shopPanel.SetActive(false);
        }
    }
}