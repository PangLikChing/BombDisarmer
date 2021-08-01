using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetText : MonoBehaviour
{
    public int target;

    GameManager gameManager;
    BombSpawner bombSpawner;
    GameObject disarmMenu;
    [SerializeField] GameObject targetDisplay, step1NumberBoxes, step2NumberBoxes, currentPlatform, currentBomb;
    [SerializeField] Step2TransitionHelper step2TransitionHelper;

    void Awake()
    {
        bombSpawner = FindObjectOfType<GameManager>().GetComponent<BombSpawner>();
    }

    void OnEnable()
    {
        target = GenerateTarget();

        //Display target
        targetDisplay.GetComponent<Text>().text = "Target: " + target;
        gameManager = FindObjectOfType<GameManager>();
        disarmMenu = gameObject.transform.Find("Disarm Menu").gameObject;
        currentBomb = gameObject;
    }

    int GenerateTarget()
    {
        int target1 = Random.Range(0, 10);
        int target2 = Random.Range(0, 10);
        //Debug.Log(target1);
        //Debug.Log(target2);

        //Prevent target = 0
        if (target1 == 0 && target2 == 0)
        {
            GenerateTarget();
        }

        //Generate Target
        if (target2 > target1)
        {
            target = target1 * 10 + target2;
        }
        else
        {
            target = target2 * 10 + target1;
        }

        return target;
    }

    public void UpdateText()
    {
        targetDisplay.GetComponent<Text>().text = "Target: " + target;
        if (target != 0 && target > 0)
        {
            ResetBomb();
        }
        else if (target < 0)
        {
            //Game Over
            Disarmed();
            currentPlatform.SetActive(false);
        }
        else
        {
            //Success
            target = GenerateTarget();
            targetDisplay.GetComponent<Text>().text = "Target: " + target;
            Disarmed();
            gameManager.UpdateScore(1);
        }
    }

    void ResetBomb()
    {
        //Reset Step 1
        for (int i = 0; i < step1NumberBoxes.transform.childCount; i++)
        {
            //Set row active
            GameObject row;
            row = step1NumberBoxes.transform.GetChild(i).gameObject;
            row.transform.gameObject.SetActive(true);

            //Set children in row active
            for (int j = 0; j < row.transform.childCount; j++)
            {
                row.transform.GetChild(j).gameObject.SetActive(true);
            }
        }

        //Hide Step 2
        for (int i = 0; i < step2NumberBoxes.transform.childCount; i++)
        {
            GameObject calculator;
            calculator = step2NumberBoxes.transform.GetChild(i).gameObject;
            if (i < 4)
            {
                calculator.transform.GetChild(3).gameObject.SetActive(false);
            }
            calculator.transform.gameObject.SetActive(false);
        }

        step2TransitionHelper.played = false;
    }

    void Disarmed()
    {
        ResetBomb();
        disarmMenu.SetActive(false);
        currentBomb.SetActive(false);

        for (int i = 0; i < 9; i++)
        {
            if (gameObject.name == bombSpawner.bombs[i].name)
            {
                gameObject.transform.position = bombSpawner.originalPosition[i];
                bombSpawner.isSpawn[i] = 0;
                bombSpawner.bombCount -= 1;
                break;
            }
        }
    }
}