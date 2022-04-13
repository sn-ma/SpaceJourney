using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateInRandomDirection3D : MonoBehaviour
{
    public Vector3 maxAngles = new Vector3(3f, 3f, 3f);

    private Vector3 eulers = new Vector3();

    void Start()
    {
        eulers.x = Random.Range(-maxAngles.x, maxAngles.x);
        eulers.y = Random.Range(-maxAngles.y, maxAngles.y);
        eulers.z = Random.Range(-maxAngles.z, maxAngles.z);

        transform.Rotate(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
    }

    void Update()
    {
        transform.Rotate(eulers * Time.deltaTime);
    }
}
