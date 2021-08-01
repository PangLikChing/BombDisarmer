using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Step1NumberBoxes : MonoBehaviour
{
    [SerializeField] GameObject box1, box2, box1Text, box2Text, operationButtons, plusButton, slashImage, minusButton, resultBox;
    Animation animationBox1, animationBox2;
    [SerializeField] Step2Calculator step2Calculator;
    Vector3 box1OriginalPosition, box2OriginalPosition;

    void Awake()
    {
        //Initiate
        box1 = gameObject.transform.Find("Box 1").gameObject;
        box2 = gameObject.transform.Find("Box 2").gameObject;
        operationButtons = gameObject.transform.Find("Operation Buttons").gameObject;

        box1Text = box1.transform.Find("Box 1 Text").gameObject;
        box2Text = box2.transform.Find("Box 2 Text").gameObject;

        plusButton = operationButtons.transform.Find("Plus Button").gameObject;
        slashImage = operationButtons.transform.Find("Slash Image").gameObject;
        minusButton = operationButtons.transform.Find("Minus Button").gameObject;

        animationBox1 = box1.GetComponent<Animation>();
        animationBox2 = box2.GetComponent<Animation>();

        box1OriginalPosition = box1.transform.position;
        box2OriginalPosition = box2.transform.position;
    }

    void OnEnable()
    {
        box1Text.GetComponent<Text>().text = Random.Range(1, 10).ToString();
        box2Text.GetComponent<Text>().text = Random.Range(1, 10).ToString();

        box1.transform.position = box1OriginalPosition;
        box2.transform.position = box2OriginalPosition;
    }

    public void Addition()
    {
        operationButtons.SetActive(false);
        int result = int.Parse(box1Text.GetComponent<Text>().text) + int.Parse(box2Text.GetComponent<Text>().text);
        resultBox.transform.Find("Result Text").gameObject.GetComponent<Text>().text = result.ToString();

        //Animations
        animationBox1.Play();
        animationBox2.Play();

        step2Calculator.activeBox += 1;
    }

    public void Subtraction()
    {
        operationButtons.SetActive(false);
        int result = 0;
        if(int.Parse(box1Text.GetComponent<Text>().text) >= int.Parse(box2Text.GetComponent<Text>().text))
        {
            result = int.Parse(box1Text.GetComponent<Text>().text) - int.Parse(box2Text.GetComponent<Text>().text);
        }
        else
        {
            result = int.Parse(box2Text.GetComponent<Text>().text) - int.Parse(box1Text.GetComponent<Text>().text);
        }
        resultBox.transform.Find("Result Text").gameObject.GetComponent<Text>().text = result.ToString();

        //Animations
        animationBox1.Play();
        animationBox2.Play();

        step2Calculator.activeBox += 1;
    }
}
