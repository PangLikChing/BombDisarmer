using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Step2NumberBoxes : MonoBehaviour
{
    Vector3 originalPosition;

    void Awake()
    {
        originalPosition = transform.position;
    }

    void OnEnable()
    {
        transform.position = originalPosition;
        transform.GetComponent<Button>().interactable = false;
    }
}
