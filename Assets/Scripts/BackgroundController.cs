using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField]
    private float slowdownCoefficient = 2f;

    [SerializeField]
    private WorldVelocityController worldVelocityController;

    private float textureUnitSizeY;

    void Start()
    {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        textureUnitSizeY = sprite.texture.height * transform.localScale.y / sprite.pixelsPerUnit;
    }

    void Update()
    {
        Vector3 position = transform.localPosition;
        position.y -= worldVelocityController.velocity * Time.deltaTime / slowdownCoefficient;
        position.y %= textureUnitSizeY;
        transform.localPosition = position;
    }
}
