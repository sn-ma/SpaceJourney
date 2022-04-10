using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDespawnerController : MonoBehaviour
{
    public List<GameObject> prefabs;
    public float spawnChancePerSecond = 1f;
    public float despawnDistance = 20f;

    private Sprite sprite;
    private HashSet<GameObject> spawned = new HashSet<GameObject>();
    private HashSet<GameObject> toBeRemoved = new HashSet<GameObject>();

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>().sprite;
    }

    void FixedUpdate()
    {
        if (Random.Range(0f, 1f) < spawnChancePerSecond * Time.fixedDeltaTime)
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

            spawned.Add(Instantiate(prefab, pos, Quaternion.identity));
        }

        if (spawned.Count != 0)
        {
            foreach (GameObject obj in spawned)
            {
                if ((transform.position - obj.transform.position).sqrMagnitude > Mathf.Pow(despawnDistance, 2f))
                {
                    toBeRemoved.Add(obj);
                }
            }
            foreach (GameObject obj in toBeRemoved)
            {
                spawned.Remove(obj);
                Destroy(obj);
            }
            toBeRemoved.Clear();
        }
    }
}
