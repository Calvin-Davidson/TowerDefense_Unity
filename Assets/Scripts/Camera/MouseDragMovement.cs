using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDragMovement : MonoBehaviour
{
    [SerializeField] private GameObject _mainCam;
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (!Input.GetKey(KeyCode.LeftShift)) return;
            
            print("Mouse 0 is pressed");
            
            float xDrag = -Input.GetAxis("Mouse X");
            float yDrag = -Input.GetAxis("Mouse Y");


            Vector3 movement = new Vector3(0, 0, 0);
            movement.x += xDrag * 100 * Time.deltaTime;
            movement.z = 0;
            movement.y += yDrag * 100 * Time.deltaTime;
            
            _mainCam.transform.Translate(movement);        
        }
    }
}
