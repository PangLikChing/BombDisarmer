using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step2TransitionHelper : MonoBehaviour
{
    [SerializeField] GameObject[] resultBoxes = new GameObject[6];
    Step2Calculator step2Calculator;
    GameManager gameManager;
    Animation transitionAnimation;
    GameObject[] calculators = new GameObject[4];
    public bool played = false;
    // Start is called before the first frame update

    void Awake()
    {
        for (int i = 0; i < 4; i++)
        {
            calculators[i] = gameObject.transform.GetChild(i).gameObject;
        }

        //Result Boxes
        for (int i = 0; i < resultBoxes.Length; i++)
        {
            resultBoxes[i] = gameObject.transform.GetChild(i + 4).gameObject;
        }

        transitionAnimation = gameObject.GetComponent<Animation>();

        gameManager = FindObjectOfType<GameManager>();
        step2Calculator = gameObject.transform.GetComponent<Step2Calculator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //If all result boxes are active
        if (step2Calculator.activeBox == gameManager.currentFocus && played == false)
        {
            StartCoroutine(playAnimation());
        }
    }

    IEnumerator playAnimation()
    {
        //Transition to Step 2
        yield return new WaitForSeconds(1.5f);
        transitionAnimation.Play();
        played = true;

        //Display Calculators
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < 4; i++)
        {
            calculators[i].SetActive(true);
        }
    }
}
