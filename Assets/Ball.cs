using UnityEngine;
public class Ball : MonoBehaviour
{

    public Rigidbody2D rigidbody2D;
    public float ballSpeed = 5f;
    public Vector2 lastVelocity;

    void ballMovement()
    {
        rigidbody2D.velocity = Vector3.zero;
        rigidbody2D.isKinematic = true;
        transform.position = Vector3.zero;
        rigidbody2D.isKinematic = true;

        rigidbody2D.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * ballSpeed;
        lastVelocity = rigidbody2D.velocity;
    }

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        ballMovement();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ballMovement();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rigidbody2D.velocity = Vector2.Reflect(lastVelocity, collision.contacts[0].normal);
        lastVelocity = rigidbody2D.velocity;
    }
}
