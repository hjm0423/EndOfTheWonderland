using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D rigid;

    public int jumpPower;

    Vector2 jumpVector = new Vector3(0, 1);

    bool isGround = true;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();      //Rigidbody 컴포넌트를 받아옴
    }

    void Update()
    {
       
        Jumping();
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        isGround = true;
        jumpPower = 0;
    }


    void Jumping()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            jumpPower++;
        }

        if (Input.GetKeyUp(KeyCode.Space) && isGround)
        {
            if (jumpPower >= 10)
            {
                jumpPower = 10;
            }

            rigid.AddForce(jumpVector * jumpPower);
            

            isGround = false;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            jumpVector = new Vector3(-1, 1);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            jumpVector = new Vector3(1, 1);
        }
    }
}



