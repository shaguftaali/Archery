using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    Transform trans;



    [SerializeField]
    float lookSenstivity;

    [SerializeField]
    float rotationSpeed=0.1f;

    float xRotation;
    float yRotation;

    float targetRotationX;
    float targetRotationY;

    float targetXRotationV;
    float targetYRotationV;
    float holdHeight;
    float holdSide;

   

    [SerializeField]
    GameObject dummyArrow;

    [SerializeField]
    Arrow arrow;

    [SerializeField]
    Transform crosshair;


    // Start is called before the first frame update
    void Start()
    {
        trans = transform;
    }
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            UpdateBowMovement();

        }
        if(Input.GetMouseButtonUp(0))
        {
            //dummyArrow.SetActive(false);
            //arrow.Shoot(crosshair.forward, dummyArrow.transform.position, dummyArrow.transform.rotation);
            arrow.Shoot(crosshair.forward, crosshair.position, crosshair.rotation);

        }

        Debug.DrawRay(crosshair.position, crosshair.forward * 50, Color.red);
    }
        // Update is called once per frame
    void UpdateBowMovement()
    {
        xRotation -= Input.GetAxis("Mouse Y") * lookSenstivity;
        yRotation += Input.GetAxis("Mouse X") * lookSenstivity;

        xRotation = Mathf.Clamp(xRotation, -90, 90);
        yRotation = Mathf.Clamp(yRotation, -90, 90);

        targetRotationX = Mathf.SmoothDamp(targetRotationX, xRotation, ref targetXRotationV, rotationSpeed);
        targetRotationY = Mathf.SmoothDamp(targetRotationY, yRotation, ref targetYRotationV, rotationSpeed);

        trans.rotation = Quaternion.Euler(targetRotationX, targetRotationY, 0);
    }

    
}
