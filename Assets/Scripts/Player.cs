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

    float salsaForceBuff = 1;
    float salsaRotateBuff = 1;
    float salsaStrokeBuff = 1;

    public float strokeCooldownLength;
    float strokeCooldownTimer;

    public float maxAir;
    float air;
    public Image airMeter;

    public GameObject shopPanel;

    public List<Trash> trashList;

    SpriteRenderer sr;
    Rigidbody2D rb;
    Animator anim;
    AudioSource audioSource;
    public AudioClip swimBelow;
    public AudioClip explodeSound;
    public AudioClip trashBinSound;



    void Start()
    {
        air = maxAir;
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //Handle rotate stuff
        float rotateDirection = Input.GetAxisRaw("Horizontal");
        transform.Rotate(new Vector3(0, 0, (rotateSpeed * salsaRotateBuff * -rotateDirection) * Time.deltaTime));

        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
            sr.flipY = true;
        else
            sr.flipY = false;

        //Handle swim stuff
        strokeCooldownTimer -= Time.deltaTime * salsaStrokeBuff;
        if (strokeCooldownTimer < 0) strokeCooldownTimer = 0;

        if (Input.GetKey(KeyCode.Space))
        {
            if (strokeCooldownTimer <= 0)
            {
                strokeCooldownTimer = strokeCooldownLength;
                rb.AddForce(-transform.right * pushForce * salsaForceBuff);
                audioSource.clip = swimBelow;
                audioSource.Play();
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
                if (!instanceMaster.GetGameEnded()) instanceMaster.EndGame(1);
            }
        }
    }



    public void Explode()
    {
        rb.velocity = Vector2.zero;
        pushForce = 0;
        Destroy(GetComponent<BoxCollider2D>());
        anim.Play("Duck_Explode");
        audioSource.clip = explodeSound;
        audioSource.Play();
    }

    public void EndExplode()
    {
        instanceMaster.EndGame(2);
    }

    IEnumerator SalsaPower()
    {
        salsaForceBuff = 5;
        salsaRotateBuff = 2;
        salsaStrokeBuff = 2;
        rb.drag *= 2;
        sr.color = new Color(128, 0, 0);
        yield return new WaitForSeconds(8);
        salsaForceBuff = 1;
        salsaRotateBuff = 1;
        salsaStrokeBuff = 1;
        rb.drag /= 2;
        sr.color = new Color(255, 255, 255);
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
            audioSource.clip = trashBinSound;
            audioSource.Play();
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