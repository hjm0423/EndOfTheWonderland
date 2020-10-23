using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform playerTrnsform;

    void Update()
    {
        Vector3 position = new Vector3(0f, playerTrnsform.position.y, -10f);
        transform.position = position;
    }
}
