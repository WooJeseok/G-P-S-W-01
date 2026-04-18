using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movemunt : MonoBehaviour
{
    public float spd = 5;
    public GameObject prefabsExplosion;
    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 direct = new Vector3(h, v, 0);
        transform.position = transform.position + direct * spd * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            Instantiate(prefabsExplosion, transform.position, Quaternion.identity);

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
