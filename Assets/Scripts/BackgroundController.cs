using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float slowdownCoefficient = 2f;

    private UpMovementController cameraController;
    private float textureUnitSizeY;

    void Start()
    {
        cameraController = Camera.main.GetComponent<UpMovementController>();

        Sprite spriteRenderer = GetComponent<SpriteRenderer>().sprite;
        textureUnitSizeY = spriteRenderer.texture.height * transform.localScale.y / spriteRenderer.pixelsPerUnit;
    }

    void Update()
    {
        Vector3 position = transform.localPosition;
        position.y -= cameraController.velocity * Time.deltaTime / slowdownCoefficient;
        position.y %= textureUnitSizeY;
        transform.localPosition = position;
    }
}
