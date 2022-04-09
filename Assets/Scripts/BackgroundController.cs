using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public WorldController worldController;
    public float velocity = 5f;

    private float textureUnitSizeY;

    void Start()
    {
        Sprite spriteRenderer = GetComponent<SpriteRenderer>().sprite;
        textureUnitSizeY = spriteRenderer.texture.height / spriteRenderer.pixelsPerUnit;
    }

    void Update()
    {
        Vector3 position = transform.position;
        position.y = (worldController.currentPosition * velocity) % (textureUnitSizeY * transform.localScale.y);
        transform.position = position;
    }
}
