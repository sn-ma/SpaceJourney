using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float slowdownCoefficient = 2f;

    private UpMovementController cameraController;
    private float textureUnitSizeY;

    void Start()
    {
        cameraController = Camera.main.GetComponent<UpMovementController>();

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        textureUnitSizeY = sprite.texture.height * transform.localScale.y / sprite.pixelsPerUnit;
    }

    void Update()
    {
        Vector3 position = transform.localPosition;
        position.y -= cameraController.velocity * Time.deltaTime / slowdownCoefficient;
        position.y %= textureUnitSizeY;
        transform.localPosition = position;
    }
}
