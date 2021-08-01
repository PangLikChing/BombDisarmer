using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlusCalculator : MonoBehaviour
{
    GameObject box1, box2, resultBox;
    ItemSlot itemSlot1, itemSlot2;
    GameManager gameManager;
    [SerializeField] TargetText targetText;
    Animation transitionAnimation;
    Step2Calculator step2Calculator;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        step2Calculator = gameObject.transform.parent.GetComponent<Step2Calculator>();
        resultBox = gameObject.transform.Find("Target Minus Box").gameObject;
        transitionAnimation = gameObject.GetComponent<Animation>();
    }

    void OnEnable()
    {
        //box1 and box2 are the boxes dragged to the calculator
        box1 = null;
        box2 = null;

        //itemSlot1 and itemSlot2 are boxes holding box1 and box2
        itemSlot1 = transform.GetChild(0).gameObject.GetComponent<ItemSlot>();
        itemSlot2 = transform.GetChild(1).gameObject.GetComponent<ItemSlot>();

        itemSlot1.full = false;
        itemSlot2.full = false;
    }

    void FixedUpdate()
    {
        if (itemSlot1.occupyingObject != null)
        {
            //Initialise box1 to be the gameObject in the left box
            box1 = itemSlot1.occupyingObject;
        }
        if (itemSlot2.occupyingObject != null)
        {
            //Initialise box2 to be the gameObject in the right box
            box2 = itemSlot2.occupyingObject;
        }

        if (box1 != null && box2 != null)
        {
            if (itemSlot1.full == true && itemSlot2.full == true)
            {
                int result;

                //Addition for box1 and box2
                result = int.Parse(box1.GetComponentInChildren<Text>().text) + int.Parse(box2.GetComponentInChildren<Text>().text);
                box1.GetComponentInChildren<Text>().text = result.ToString();

                //remove box2
                box2.SetActive(false);
                step2Calculator.activeBox -= 1;

                //Reset the calcluator
                itemSlot2.full = false;
                itemSlot2.occupyingObject = null;
                

                //Stage complete
                if (step2Calculator.activeBox == 1)
                {
                    itemSlot1.full = false;
                    itemSlot1.occupyingObject = null;
                    step2Calculator.activeBox -= 1;
                    targetText.target -= int.Parse(box1.GetComponentInChildren<Text>().text);
                    resultBox.GetComponentInChildren<Text>().text = int.Parse(box1.GetComponentInChildren<Text>().text).ToString();
                    box1.SetActive(false);
                    resultBox.SetActive(true);
                    transitionAnimation.Play();
                }
            }
        }
    }
}
