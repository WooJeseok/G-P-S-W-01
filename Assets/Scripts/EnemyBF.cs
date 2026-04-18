using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBF : MonoBehaviour
{
    public GameObject bulletObject;
    public GameObject bulletFireObject;

    public float fireInterval = 2f;
    public int bulletCount = 12;

    void Start()
    {
        StartCoroutine(FireRoutine());
        StartCoroutine(FireCircleOnce());
    }

    IEnumerator FireRoutine()
    {
        yield return new WaitForSeconds(fireInterval);
        while (true)
        {
            FireBullet();
            yield return new WaitForSeconds(fireInterval);
        }
    }
    IEnumerator FireCircleOnce()
    {
        yield return new WaitForSeconds(3f);
        FireCircle();
    }

    void FireBullet()
    {
        GameObject bullet = Instantiate(
            bulletObject,
            bulletFireObject.transform.position,
            Quaternion.identity
        );
        bullet.GetComponent<EnemyBullet>().SetDirection(Vector3.down);
    }
    void FireCircle()
    {
        float angleStep = 360f / bulletCount;

        for (int i = 0; i < bulletCount; i++)
        {
            float angle = angleStep * i;
            float rad = angle * Mathf.Deg2Rad;

            Vector3 dir = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0);

            GameObject bullet = Instantiate(
                bulletObject,
                bulletFireObject.transform.position,
                Quaternion.identity
            );

            bullet.GetComponent<EnemyBullet>().SetDirection(dir);
        }
    }
}

