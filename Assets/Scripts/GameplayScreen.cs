using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayScreen : MonoBehaviour
{
    GameObject scoreTextGameObject, exitButtonGameObject;
    [SerializeField] RectTransform canvas, scoreText, exitButton;

    void Awake()
    {
        float canvasWidth = canvas.rect.width;
        float canvasHeight = canvas.rect.height;

        scoreText.position = new Vector2(0 + scoreText.sizeDelta.x / 2, canvasHeight - scoreText.sizeDelta.y / 2);
        exitButton.position = new Vector2(canvasWidth - exitButton.sizeDelta.x / 2, canvasHeight - exitButton.sizeDelta.y / 2);
    }
}
