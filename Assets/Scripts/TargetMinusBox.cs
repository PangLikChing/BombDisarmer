using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetMinusBox : MonoBehaviour
{
    int target;
    Vector3 originalPosition;
    [SerializeField] GameObject targetGameObject;
    TargetText targetText;

    void Awake()
    {
        targetText = targetGameObject.transform.GetComponent<TargetText>();
        originalPosition = transform.position;
    }

    void OnEnable()
    {
        Disable();
    }

    void Disable()
    {
        targetText.UpdateText();
        Debug.Log("updated");
        gameObject.transform.position = originalPosition;
        gameObject.GetComponent<TargetMinusBox>().enabled = false;
        //gameObject.SetActive(false);
    }
}
