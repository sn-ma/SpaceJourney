using System.Collections.Generic;
using UnityEngine;

public class SpawnerDespawnerController : MonoBehaviour
{
    [System.Serializable]
    public struct PrefabAndProbability
    {
        public GameObject prefab;
        public float probabilityPerSecondPerVelocity;
    }

    public List<PrefabAndProbability> prefabsAndProbabilities;
    public float despawnDistance = 20f;
    public Transform spawnedParent;
    public WorldVelocityController worldVelocityController;

    private Sprite sprite;
    private HashSet<GameObject> spawned = new HashSet<GameObject>();
    private HashSet<GameObject> toBeRemoved = new HashSet<GameObject>();

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>().sprite;
    }

    void Update()
    {
        foreach (PrefabAndProbability entity in prefabsAndProbabilities)
        {
            if (MyUtilities.TossACoin(entity.probabilityPerSecondPerVelocity * Time.deltaTime * worldVelocityController.velocity))
            {
                GameObject spawnedObject = Instantiate(entity.prefab, GetRandomPos(), Quaternion.identity, spawnedParent);
                Rigidbody2D rb = spawnedObject.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity += new Vector2(0f, -worldVelocityController.velocity);
                }
                spawned.Add(spawnedObject);
            }
        }

        if (spawned.Count != 0)
        {
            foreach (GameObject obj in spawned)
            {
                if (obj == null || (transform.position - obj.transform.position).sqrMagnitude > Mathf.Pow(despawnDistance, 2f))
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

    private Vector3 GetRandomPos()
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

        return pos;
    }
}
