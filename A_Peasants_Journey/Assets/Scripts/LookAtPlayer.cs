using UnityEngine;
using System.Collections;

public class LookAtPlayer : MonoBehaviour

{

    public Camera CameraToLookAt;

    void Start()
    {
        CameraToLookAt = Camera.main; 
        //transform.Rotate( 180,0,0 );
    }

    void Update()
    {
        Vector3 v = CameraToLookAt.transform.position - transform.position;
        v.x = v.z = 0.0f;
        transform.LookAt(CameraToLookAt.transform.position - v);
        transform.Rotate(0, 180, 0);
    }
}