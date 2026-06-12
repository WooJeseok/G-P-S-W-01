using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float spd = 1.0f;
    Vector3 direct = Vector3.down;

    public GameObject prefabsExplosion;

    void Start()
    {
        GameObject playerObj = GameObject.Find("Character");

        int rnd = Random.Range(0, 3);

        if (rnd == 0 && playerObj != null)
        {
            Vector3 dir = playerObj.transform.position - transform.position;
            direct = dir.normalized;
        }
        else
        {
            direct = Vector3.down;
        }
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
            MonsterDropper dropper = GetComponent<MonsterDropper>();
            if (dropper != null) dropper.Drop();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}