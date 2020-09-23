using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasHideAndShow : MonoBehaviour
{
    private Canvas _canvas;

    void Awake()
    {
        _canvas = GetComponent<Canvas>();
    }
    
    public void Show()
    {
       _canvas.enabled = true;
    }

    public void Hide()
    {
        _canvas.enabled = false;        
    }
}
