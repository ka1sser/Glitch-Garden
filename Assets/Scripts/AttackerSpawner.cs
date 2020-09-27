using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [Header("Spawn Configurations")]
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackerPrefab;

    bool spawn = true;

    private void Start()
    {
        StartCoroutine(StartSpawning());
    }

    IEnumerator StartSpawning()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        var spawnDecider = Random.Range(0, attackerPrefab.Length);
        Spawn(spawnDecider);
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void Spawn(int arrayNumber)
    {
        Attacker newAttacker = Instantiate
                    (attackerPrefab[arrayNumber], transform.position, Quaternion.identity)
                    as Attacker;
        newAttacker.transform.parent = transform;
    }
}
