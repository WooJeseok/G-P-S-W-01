using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float spd = 1.0f;
    public GameObject target;
    Vector3 direct = Vector3.down;
    public GameObject prefabsExplosion;
    // Update is called once per frame
    private void Start()
    {
        target = GameObject.Find("Character");
        int rndNum = Random.Range(0, 10);
        if (rndNum % 3 == 0 && target != null)
        {
            direct = target.transform.position - transform.position;
            direct.Normalize();
        }
    }
    void Update()
    {
        transform.position = transform.position + direct * spd * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject explosionObi = Instantiate(prefabsExplosion);
        explosionObi.transform.position = transform.position;
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
