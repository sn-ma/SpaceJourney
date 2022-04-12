using UnityEngine;

public class WorldVelocityController : MonoBehaviour
{
    public float velocity = 10f;
    public float acceleration = 0f;

    void FixedUpdate()
    {
        velocity += acceleration * Time.fixedDeltaTime;

        Vector3 position = transform.position;
        position.y += velocity * Time.fixedDeltaTime;
        transform.position = position;
    }
}
