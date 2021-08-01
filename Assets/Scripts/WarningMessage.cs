using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningMessage : MonoBehaviour
{
    Animation fadeOut;

    void OnEnable()
    {
        fadeOut = GetComponent<Animation>();
        fadeOut.Play();
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }
}
