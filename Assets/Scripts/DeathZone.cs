using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    GameManager gameManager;
    GameObject gameOverScreen, finalScore;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameOverScreen = transform.Find("Game Over Screen").gameObject;
        finalScore = gameOverScreen.transform.Find("Score").gameObject;
    }

    void OnTriggerEnter(Collider other)
    {
        //game over screen
        if (other.tag == "Player")
        {
            finalScore.GetComponent<Text>().text = "Score: " + gameManager.GetScore();
            gameOverScreen.SetActive(true);
        }
    }

    public void Restart()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
}
