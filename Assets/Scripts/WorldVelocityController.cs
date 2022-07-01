using UnityEngine;

public class WorldVelocityController : MonoBehaviour
{
    [SerializeField]
    public float velocity = 10f;

    [SerializeField]
    private float acceleration = 0f;

    void Update()
    {
        velocity += acceleration * Time.deltaTime;
    }
}
