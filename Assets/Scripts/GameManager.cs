using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player, scoreDisplay;
    public static GameManager Instance;

    public int currentFocus;

    int currentScore;

    void Awake()
    {
        currentFocus = 6;
        currentScore = 0;
        scoreDisplay.GetComponent<Text>().text = "Score: " + currentScore;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Ray mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(mousePosition, out hit))
        {
            if (hit.collider.gameObject.tag == "Bomb" && Vector3.Distance(hit.collider.gameObject.transform.position, player.transform.position) < 3.5f){
                TooltipUI.Show("Left Click");
                /*Debug.Log(Vector3.Distance(hit.collider.gameObject.transform.position, player.transform.position));
                Debug.Log("Target Name: " + hit.collider.gameObject.name);
                Debug.Log("Target Tag: " + hit.collider.gameObject.tag);*/
            }
            else
            {
                TooltipUI.Hide();
            }
        }
    }

    public void UpdateScore(int scoreChange)
    {
        currentScore += scoreChange;
        scoreDisplay.GetComponent<Text>().text = "Score: " + currentScore;
    }

    public int GetScore()
    {
        return currentScore;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
