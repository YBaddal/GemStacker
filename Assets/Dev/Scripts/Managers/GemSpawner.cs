using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    public Vector3 gemPos;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Spawn()
    {
        int rnd = Random.RandomRange(0, GameManager.instance.gemList.Count);
        Gem gem = GameManager.instance.gemList[rnd];

        GameObject obj = Instantiate(gem.gemPrefab,transform);
        obj.name = gem.gemName;
        obj.transform.localScale = Vector3.zero;
        obj.transform.localPosition = gemPos;
        SpawnedGem spawnedGem = obj.AddComponent<SpawnedGem>();
        spawnedGem.gem = gem;
        spawnedGem.Init();
    }
    public void Collected(GameObject collectedObj)
    {
        Spawn();
    }
}
