using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    private ShieldController shield;
    private HealthAndGameoverController gamemode;

    private void Start()
    {
        gamemode = GetComponent<HealthAndGameoverController>();
        shield = GetComponentInChildren<ShieldController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.collider.tag)
        {
            case Constants.Tags.Enemy:
                OnEnemyCollided(collision);
                break;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        switch (collision.collider.tag)
        {
            case Constants.Tags.Enemy:
                OnEnemyCollided(collision);
                break;
        }
    }

    private void OnEnemyCollided(Collision2D collision)
    {
        shield.StartFadeAnimation();
        gamemode.TakeDamageOnCollision(collision.relativeVelocity.magnitude * collision.otherRigidbody.mass);
    }
}
