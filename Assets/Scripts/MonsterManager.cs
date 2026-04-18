using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public GameObject monsterDownPrefab;
    public GameObject monsterSidePrefab;

    public Transform spawnTopArea;
    public Transform spawnLeftArea;
    public Transform spawnRightArea;

    float nowTime;
    public float minTime = 1f;
    public float maxTime = 3f;
    float createTime;

    private void Start()
    {
        createTime = Random.Range(minTime, maxTime);
    }

    void Update()
    {
        nowTime += Time.deltaTime;

        if (nowTime > createTime)
        {
            SpawnRandom();
            createTime = Random.Range(minTime, maxTime);
            nowTime = 0;
        }
    }

    void SpawnRandom()
    {
        int rnd = Random.Range(0, 3);

        if (rnd == 0) SpawnTop();
        else if (rnd == 1) SpawnLeft();
        else SpawnRight();
    }

    void SpawnTop()
    {
        Vector3 pos = GetRandomPosition(spawnTopArea);
        Instantiate(monsterDownPrefab, pos, Quaternion.identity);
    }

    void SpawnLeft()
    {
        Vector3 pos = GetRandomPosition(spawnLeftArea);

        Vector3 dir = Vector3.right;

        Quaternion rot = Quaternion.LookRotation(dir);
        rot *= Quaternion.Euler(0, -90, -90);
        GameObject m = Instantiate(monsterSidePrefab, pos, rot);
        m.GetComponent<MonsterSide>().SetDirection(dir);
    }

    void SpawnRight()
    {
        Vector3 pos = GetRandomPosition(spawnRightArea);

        Vector3 dir = Vector3.left;

        Quaternion rot = Quaternion.LookRotation(dir);
        rot *= Quaternion.Euler(0, 90, 90);
        GameObject m = Instantiate(monsterSidePrefab, pos, rot);
        m.GetComponent<MonsterSide>().SetDirection(dir);
    }

    Vector3 GetRandomPosition(Transform area)
    {
        Vector3 center = area.position;
        Vector3 size = area.localScale;

        float x = Random.Range(center.x - size.x / 2, center.x + size.x / 2);
        float y = Random.Range(center.y - size.y / 2, center.y + size.y / 2);

        return new Vector3(x, y, center.z);
    }
}
