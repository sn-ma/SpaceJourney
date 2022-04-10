using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    private ShieldController shield;

    private void Start()
    {
        shield = GetComponentInChildren<ShieldController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.collider.tag)
        {
            case Constants.Tags.Enemy:
                shield.StartFadeAnimation();
                break;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        switch (collision.collider.tag)
        {
            case Constants.Tags.Enemy:
                shield.StartFadeAnimation();
                break;
        }
    }
}
