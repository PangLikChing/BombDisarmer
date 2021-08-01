using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step1TransitionHelper : MonoBehaviour
{
    [SerializeField] GameObject row, resultBox, operationButtons;
    [SerializeField] bool end;
    // Start is called before the first frame update

    void OnEnable()
    {
        //operationButtons.SetActive(false);
        end = false;
    }

    void Update()
    {
        if(end == true)
        {
            row.SetActive(false);
            resultBox.SetActive(true);
        }
    }
}
