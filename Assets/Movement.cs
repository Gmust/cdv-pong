using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed;

    public Rigidbody2D rigidBody2d;


    private void Start()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigidBody2d.velocity = Vector2.up;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            rigidBody2d.velocity = Vector2.down;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rigidBody2d.velocity = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidBody2d.velocity = Vector2.right;
        }
        else
        {
            rigidBody2d.velocity = Vector2.zero;
        }


    }
}
