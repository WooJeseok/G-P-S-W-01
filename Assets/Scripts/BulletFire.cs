using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
    public GameObject bulletObject;
    public GameObject bulletFireObject;
    public int bulletCount = 20;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            GameObject bullet = Instantiate(
                bulletObject,
                bulletFireObject.transform.position,
                Quaternion.identity
            );

            bullet.GetComponent<Bullet>().SetDirection(Vector3.up);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            FireCircle();
        }
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

            bullet.GetComponent<Bullet>().SetDirection(dir);
        }
    }
}
