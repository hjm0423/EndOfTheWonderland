using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapPooling : MonoBehaviour
{
    public Transform[] poolingObject;
    public Transform[] poolingObject2;

    float playerY;
    Transform playerTr;

    int pollingIndex = 1;

    private void Awake()
    {
        playerTr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Start()
    {
        StartCoroutine(Pooling());
    }

    IEnumerator Pooling()
    {
        while (true)
        {
            playerY = playerTr.position.y;

            if (playerY / 10 > pollingIndex + 1)
            {
                float y = poolingObject[poolingObject.Length - 1].position.y + poolingObject[0].localScale.x;
                poolingObject[0].position = new Vector3(poolingObject[0].position.x, y, poolingObject[0].position.z);
                poolingObject2[0].position = new Vector3(poolingObject2[0].position.x, y, poolingObject2[0].position.z);

                Transform _poolingObjTr = poolingObject[0];
                Transform _poolingObjTr2 = poolingObject2[0];

                for (int i = 0; i < poolingObject.Length -1; i++)
                {
                    poolingObject[i] = poolingObject[i + 1];
                    poolingObject2[i] = poolingObject2[i + 1];
                }

                poolingObject[poolingObject.Length - 1] = _poolingObjTr;
                poolingObject2[poolingObject2.Length - 1] = _poolingObjTr2;

                pollingIndex++;
            }
            else if (playerY / 10 < pollingIndex - 1)
            {
                float y = poolingObject[0].position.y - poolingObject[poolingObject.Length - 1].localScale.x;
                poolingObject[poolingObject.Length - 1].position = new Vector3(poolingObject[poolingObject.Length - 1].position.x, y, poolingObject[poolingObject.Length - 1].position.z);
                poolingObject2[poolingObject.Length - 1].position = new Vector3(poolingObject2[poolingObject2.Length - 1].position.x, y, poolingObject2[poolingObject2.Length - 1].position.z);

                Transform _poolingObjTr = poolingObject[poolingObject.Length - 1];
                Transform _poolingObjTr2 = poolingObject2[poolingObject2.Length - 1];

                for (int i = poolingObject.Length - 1; i > 0; i--)
                {
                    poolingObject[i] = poolingObject[i - 1];
                    poolingObject2[i] = poolingObject2[i - 1];
                }

                poolingObject[0] = _poolingObjTr;
                poolingObject2[0] = _poolingObjTr2;

                pollingIndex--;
            }
            yield return null;
        }
    }
}
