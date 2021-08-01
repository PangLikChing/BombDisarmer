using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bomb : MonoBehaviour
{
    [SerializeField] BombSpawner bombSpawner;
    [SerializeField] GameObject canvas, currentPlatform, timerText, player;
    GameObject currentBomb;
    

    int bombLife;

    void Start()
    {
        bombSpawner = FindObjectOfType<GameManager>().GetComponent<BombSpawner>();
        canvas = gameObject.transform.Find("Disarm Menu").gameObject;
        currentBomb = gameObject;
    }

    void OnEnable()
    {
        //Count down from 120
        bombLife = 120;

        StartCoroutine(timer());
    }

    void OnMouseDown()
    {
        Ray mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(mousePosition, out hit))
        {
            if (Vector3.Distance(hit.collider.gameObject.transform.position, player.transform.position) < 3.5f)
            {
                canvas.SetActive(true);
            }
        }
    }

    IEnumerator timer()
    {
        while (bombLife > 0)
        {
            yield return new WaitForSeconds(1);

            CountDown();

            //Time is up
            if (bombLife <= 0)
            {
                //Destory
                currentBomb.SetActive(false);
                currentPlatform.SetActive(false);

                //Reset bomb position
                for (int i = 0; i < 9; i++)
                {
                    if (gameObject.name == bombSpawner.bombs[i].name)
                    {
                        gameObject.transform.position = bombSpawner.originalPosition[i];
                        break;
                    }
                }
            }
        }
    }

    void CountDown()
    {
        bombLife -= 1;
        timerText.GetComponent<Text>().text = bombLife.ToString();
    }
}
