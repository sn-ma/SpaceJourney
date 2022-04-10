using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDespawnerController : MonoBehaviour
{
    public List<GameObject> prefabs;
    public float spawnChancePerSecond = 1f;
    public float despawnDistance = 20f;

    private Sprite sprite;
    private Queue<GameObject> spawned = new Queue<GameObject>();

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>().sprite;
    }

    void Update()
    {
        if (Random.Range(0f, 1f) < spawnChancePerSecond * Time.deltaTime)
        {
            Bounds bounds = sprite.bounds;
            Vector3 minPos = bounds.center - bounds.size / 2f;
            Vector3 maxPos = bounds.center + bounds.size / 2f;
            minPos.Scale(transform.localScale);
            maxPos.Scale(transform.localScale);
            minPos += transform.position;
            maxPos += transform.position;

            Vector3 pos = new Vector3();
            pos.x = Random.Range(minPos.x, maxPos.x);
            pos.y = Random.Range(minPos.y, maxPos.y);
            pos.z = 0f;

            GameObject prefab = prefabs[Random.Range(0, prefabs.Count - 1)];

            spawned.Enqueue(Instantiate(prefab, pos, Quaternion.identity));
        }

        while (spawned.Count != 0)
        {
            GameObject obj = spawned.Peek();
            if ((transform.position - obj.transform.position).sqrMagnitude < Mathf.Pow(despawnDistance, 2f))
            {
                break;
            } else
            {
                spawned.Dequeue();
                Destroy(obj);
            }
        }
    }
}
