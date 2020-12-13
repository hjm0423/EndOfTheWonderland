using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapPooling : MonoBehaviour
{
    public Transform[] poolingObject;
    public Transform[] poolingObject2;

    public Transform[] poolingMapOb;

    float playerY;
    Transform playerTr;

    int pollingIndex = 1;
    int pollingIndex2 = 1;

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
                poolingObject = UpPoolingObject(poolingObject);
                poolingObject2 = UpPoolingObject(poolingObject2);

                pollingIndex++;
            }
            else if (playerY / 10 < pollingIndex - 1)
            {
                poolingObject = DownPoolingObject(poolingObject);
                poolingObject2 = DownPoolingObject(poolingObject2);

                pollingIndex--;
            }

            if (playerY / 2.5 > pollingIndex2 + 1 )
            {
                poolingMapOb = UpPoolingObject(poolingMapOb);

                pollingIndex2++;
            }
            else if (playerY / 2.5 < pollingIndex2 - 1 && pollingIndex2 != 0)
            {
                poolingMapOb = DownPoolingObject(poolingMapOb);

                pollingIndex2--;
            }
            yield return null;
        }
    }

    Transform[] UpPoolingObject(Transform[] poolingObj)
    {
        float y = poolingObj[poolingObj.Length - 1].position.y + poolingObj[0].localScale.x;
        poolingObj[0].position = new Vector3(poolingObj[0].position.x, y, poolingObj[0].position.z);

        Transform _poolingObjTr = poolingObj[0];

        for (int i = 0; i < poolingObj.Length - 1; i++)
        {
            poolingObj[i] = poolingObj[i + 1];
        }

        poolingObj[poolingObj.Length - 1] = _poolingObjTr;

        return poolingObj;
    }

    Transform[] DownPoolingObject(Transform[] poolingObj)
    {
        float y = poolingObj[0].position.y - poolingObj[poolingObj.Length - 1].localScale.x;
        poolingObj[poolingObj.Length - 1].position = new Vector3(poolingObj[poolingObj.Length - 1].position.x, y, poolingObject[poolingObject.Length - 1].position.z);

        Transform _poolingObjTr = poolingObj[poolingObj.Length - 1];

        for (int i = poolingObj.Length - 1; i > 0; i--)
        {
            poolingObj[i] = poolingObj[i - 1];
        }

        poolingObj[0] = _poolingObjTr;

        return poolingObj;
    }
}
