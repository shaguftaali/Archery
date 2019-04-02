using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookScript : MonoBehaviour
{
    [SerializeField]
    float lookSenstivity;

    [SerializeField]
    float lookSmoothDamp=0.1f;

    float xRotationV;
    float yRotationV;

    float xRotation;
    float yRotation;

    float currentXRotation;
    float currentYRotation;


   
    // Update is called once per frame
    void Update()
    {
        xRotation += Input.GetAxis("Mouse X") * lookSenstivity;
        yRotation += Input.GetAxis("Mouse Y") * lookSenstivity;

        xRotation = Mathf.Clamp(xRotation, -90, 90);
        yRotation = Mathf.Clamp(yRotation, -90, 90);

        currentXRotation = Mathf.SmoothDamp(currentXRotation, xRotation, ref xRotationV, lookSmoothDamp);
        currentYRotation = Mathf.SmoothDamp(currentYRotation, yRotation, ref yRotationV, lookSmoothDamp);
    }
}
