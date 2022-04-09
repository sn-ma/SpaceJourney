using UnityEngine;

public class RotateByVelocity : MonoBehaviour
{
    public float rotationStrength = 5f;

    private new Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 velocity = rigidbody2D.velocity;
        transform.eulerAngles = new Vector3(rotationStrength * velocity.y, -rotationStrength * velocity.x, 0f);
    }
}
