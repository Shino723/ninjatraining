using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodSpawner : MonoBehaviour
{
    public GameObject positiveTargetPrefab;
    public GameObject negativeTargetPrefab;

    public Vector3 spawnAreaSize = new Vector3(10, 0, 10); // X-Z方向にばらけさせる
    public float spawnHeight = 10f; // Y軸の高さ
    public float spawnInterval = 1.0f; // 出現間隔（秒）
    [Range(0f, 1f)] public float positiveProbability = 0.8f; // プラスターゲットの出現確率

    private bool spawningEnabled = true;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnTarget), 1f, spawnInterval);
    }

    private void SpawnTarget()
    {
        // ランダムなX,Z座標（Yは固定）
        Vector3 spawnPos = transform.position + new Vector3(
            Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
            spawnHeight,
            Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
        );

        // 出現確率で選ぶ
        GameObject prefabToSpawn = Random.value < positiveProbability
            ? positiveTargetPrefab
            : negativeTargetPrefab;

        Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Vector3 center = transform.position + new Vector3(0, spawnHeight, 0);
        Gizmos.DrawWireCube(center, new Vector3(spawnAreaSize.x, 0.1f, spawnAreaSize.z));
    }

    public void StopSpawning()
    {
        spawningEnabled = false;
        CancelInvoke(nameof(SpawnTarget)); 

        foreach (var target in GameObject.FindGameObjectsWithTag("Target"))
        {
            Destroy(target);
        }
        foreach (var target in GameObject.FindGameObjectsWithTag("NonTarget"))
        {
            Destroy(target);
        }
        foreach (var target in GameObject.FindGameObjectsWithTag("Ground"))
        {
            Destroy(target);
        }
    }
}
