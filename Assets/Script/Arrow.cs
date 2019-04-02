using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    Rigidbody rig;

    [SerializeField]
    float velocity;


    // Update is called once per frame
    void Update()
    {
        //transform.rotation = Quaternion.LookRotation(rig.velocity.normalized);
    }

    public void Shoot(Vector3 dir,Vector3 pos, Quaternion rot)
    {
        gameObject.SetActive(true);
        transform.position = pos;
        transform.rotation = rot;
        rig.velocity = dir * velocity;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("AAAAAAAAAAA");
        rig.velocity = Vector3.zero;
    }

}
