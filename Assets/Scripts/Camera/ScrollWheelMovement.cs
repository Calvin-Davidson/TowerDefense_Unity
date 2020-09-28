using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollWheelMovement : MonoBehaviour
{
    [SerializeField] private GameObject mainCam = null;
    
    // Update is called once per frame
    void Update()
    {

        int speed = 120;
        
        var d = Input.GetAxis("Mouse ScrollWheel");
        if (d > 0f)
        {
            Vector3 forward = mainCam.transform.forward;
            mainCam.transform.Translate( forward * (Time.deltaTime * speed));
        }
        else if (d < 0f)
        {
            Vector3 forward = mainCam.transform.forward;
            mainCam.transform.Translate(-forward * (Time.deltaTime * speed));
        }
    }
}
