using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMove : MonoBehaviour
{
    Transform tr;
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {        
        if (Input.GetMouseButton(0))
        {
            tr.Translate(Vector3.up * Time.deltaTime * 10, Space.Self);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
