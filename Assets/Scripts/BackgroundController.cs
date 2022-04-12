using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float slowdownCoefficient = 2f;

    public WorldVelocityController worldVelocityController;
    private float textureUnitSizeY;

    void Start()
    {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        textureUnitSizeY = sprite.texture.height * transform.localScale.y / sprite.pixelsPerUnit;
    }

    void FixedUpdate()
    {
        Vector3 position = transform.localPosition;
        position.y -= worldVelocityController.velocity * Time.fixedDeltaTime / slowdownCoefficient;
        position.y %= textureUnitSizeY;
        transform.localPosition = position;
    }
}
