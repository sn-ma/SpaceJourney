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
        OnCollided(collision);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        OnCollided(collision);
    }

    private void OnCollided(Collision2D collision)
    {
        switch (collision.collider.tag)
        {
            case Constants.Tags.Enemy:
                OnEnemyCollided(collision);
                break;
            case Constants.Tags.HealthPoints:
                OnHealthPointPickedUp(collision);
                break;
        }
    }

    private void OnEnemyCollided(Collision2D collision)
    {
        shield.StartFadeAnimation();
        gamemode.TakeDamageOnCollision(collision.relativeVelocity.magnitude * collision.otherRigidbody.mass);
    }

    private void OnHealthPointPickedUp(Collision2D collision)
    {
        Destroy(collision.gameObject);
        gamemode.TakeHeal();
    }
}
