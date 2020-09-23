using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollWheelMovement : MonoBehaviour
{
    [SerializeField] private GameObject _mainCam = null;
    
    // Update is called once per frame
    void Update()
    {
        int speed = 120;
        
        var d = Input.GetAxis("Mouse ScrollWheel");
        if (d > 0f)
        {
            _mainCam.transform.Translate(_mainCam.transform.forward * Time.deltaTime * speed);
        }
        else if (d < 0f)
        {
            // Scroll down
            _mainCam.transform.Translate(-_mainCam.transform.forward * Time.deltaTime * speed);
        }
    }
}
