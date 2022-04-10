using System.Collections.Generic;
using UnityEngine;

public class SpawnerDespawnerController : MonoBehaviour
{
    [System.Serializable]
    public struct PrefabAndProbability
    {
        public GameObject prefab;
        public float probabilityPerSecond;
    }

    public List<PrefabAndProbability> prefabsAndProbabilities;
    public float despawnDistance = 20f;
    public Transform spawnedParent;

    private Sprite sprite;
    private HashSet<GameObject> spawned = new HashSet<GameObject>();
    private HashSet<GameObject> toBeRemoved = new HashSet<GameObject>();

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>().sprite;
    }

    void FixedUpdate()
    {
        foreach (PrefabAndProbability entity in prefabsAndProbabilities)
        {
            if (Random.Range(0f, 1f) < entity.probabilityPerSecond * Time.fixedDeltaTime)
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

                spawned.Add(Instantiate(entity.prefab, pos, Quaternion.identity, spawnedParent));
            }
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
