using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class EnemyBullet : MonoBehaviour
{
    float spd = 3.5f;
    Vector3 dir;

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * spd * Time.deltaTime;
    }
    public void SetDirection(Vector3 d)
    {
        dir = d.normalized;
        transform.rotation = Quaternion.LookRotation(dir) * Quaternion.Euler(90, 0, 0);
    }
}
