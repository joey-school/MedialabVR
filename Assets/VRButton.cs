using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRButton : MonoBehaviour
{

    [SerializeField]
    private Button button;

    [SerializeField]
    private CanvasGroup canvasGroup;

    [SerializeField]
    private GameObject[] allButtons;

    public void Click()
    {
        // lol
        if (canvasGroup.alpha == 1f)
        {
            return;
        }

        button.onClick.Invoke();

        Array.ForEach(allButtons, x =>
        {
            x.GetComponent<CanvasGroup>().alpha = 0.5f;
        });

        canvasGroup.alpha = 1f;
    }
}