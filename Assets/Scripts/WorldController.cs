using UnityEngine;

public class WorldController : MonoBehaviour
{
    public float moveVelocity = 100f;
    public float currentPosition = 0f;

    void Update()
    {
        currentPosition -= moveVelocity * Time.deltaTime;
    }
}
