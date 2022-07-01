using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomiseScale : MonoBehaviour
{
    [SerializeField]
    private float minScale = 0.5f;

    [SerializeField]
    private float maxScale = 1.5f;

    void Start()
    {
        float scale = Random.Range(minScale, maxScale);
        transform.localScale = new Vector3(scale, scale, scale);
    }
}
