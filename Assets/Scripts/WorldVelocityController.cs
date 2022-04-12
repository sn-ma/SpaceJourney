using UnityEngine;

public class WorldVelocityController : MonoBehaviour
{
    public float velocity = 10f;
    public float acceleration = 0f;

    void Update()
    {
        velocity += acceleration * Time.deltaTime;

        Vector3 position = transform.position;
        position.y += velocity * Time.deltaTime;
        transform.position = position;
    }
}
