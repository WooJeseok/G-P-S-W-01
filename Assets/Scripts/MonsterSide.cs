using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSide : MonoBehaviour
{
    public float spd = 1.0f;
    Vector3 direct;

    public GameObject prefabsExplosion;
    public void SetDirection(Vector3 dir)
    {
        direct = dir.normalized;
    }

    void Update()
    {
        transform.position += direct * spd * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            GameObject gameManager = GameObject.Find("GameManager");
            ScoreManager scoreManager = gameManager.GetComponent<ScoreManager>();

            scoreManager.nowScore++;
            scoreManager.nowScoreUI.text = "Now Score : " + scoreManager.nowScore;

            if (scoreManager.nowScore > scoreManager.bestScore)
            {
                scoreManager.bestScore = scoreManager.nowScore;
                PlayerPrefs.SetInt("bestscore", scoreManager.bestScore);
                scoreManager.bestScoreUI.text = "Best Score : " + scoreManager.bestScore;
            }

            Instantiate(prefabsExplosion, transform.position, Quaternion.identity);

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.CompareTag("Player"))
        {
            Instantiate(prefabsExplosion, transform.position, Quaternion.identity);

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
