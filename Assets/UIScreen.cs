using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScreen : MonoBehaviour
{
    public Button FirstSelection;
    public GameObject objectThatCalled;
    public Transform screenToOpen;

    // Start is called before the first frame update
    void Start()
    {
        screenToOpen = transform.GetChild(0);
        CloseScreen();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public virtual void Initialize()
    {
        var screens = FindObjectsOfType<UIScreen>();
        foreach (var screen in screens)
        {
            screen.CloseScreen();
        }
    }
    public virtual void OpenScreen()
    {
        Debug.LogWarning($"OPEN {name} + {gameObject.name}");
        screenToOpen.gameObject.SetActive(true);
    }

    public virtual void CloseScreen()
    {
        Debug.LogWarning($"CLOSE {name} + {gameObject.name}");
        screenToOpen.gameObject.SetActive(false);
    }

}
