using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    [Range(0f, 10f)]
    [SerializeField]
    private float speed;

    [SerializeField] private AudioSource ballSound;

    private Vector2 startPos;

    private bool isMoving = true;

    private ParticleSystem particles;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        Launch();

        particles = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Launch()
    {
        if (isMoving)
        {
            float x = Random.Range(0, 2) == 0 ? -1 : 1;
            float y = Random.Range(0, 2) == 0 ? -1 : 1;
            rb.velocity = new Vector2(speed * x, speed * y);
        }
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPos;
        Launch();
    }

    public void stop()
    {
        rb.velocity = Vector2.zero;
        isMoving = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        particles.Play();
        ballSound.Play();
    }
}
