using UnityEngine;

public class ShrinkByVelocity : MonoBehaviour
{
    public float scaleFactor = 0.5f;

    private new Rigidbody2D rigidbody2D;
    private Inertial2DMovement movement;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        movement = GetComponent<Inertial2DMovement>();
    }

    void Update()
    {
        Vector2 relativeVelocity = rigidbody2D.velocity / movement.maxVelocity;
        Vector3 scale = transform.localScale;

        scale.y = 1 + relativeVelocity.y * scaleFactor;
        scale.x = 2 - scale.y;

        transform.localScale = scale;
    }
}
