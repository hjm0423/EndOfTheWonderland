using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float power = 10f;
    public float maxDrag = 5f;
    public Rigidbody2D rb;
    public LineRenderer lr;

    public Animation anim;

    RaycastHit2D raycastHit;

    

    bool isJump = true;

    Vector3 dragStartPos;
    Vector3 dragingPos;
    Vector3 dragReleasePos;
    Touch touch;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        raycastHit = Physics2D.Raycast(transform.position, new Vector2(0, -1f), 1f, 1 << LayerMask.NameToLayer("Object"));
        Debug.DrawRay(transform.position, new Vector2(0, -1f));

        if (raycastHit.collider)
        {
            Debug.Log(raycastHit.collider.name);
        }

        if (Input.touchCount > 0 && isJump)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                DragStart();
            }

            if (touch.phase == TouchPhase.Moved)
            {
                Dragging();
            }

            if (touch.phase == TouchPhase.Ended)
            {
                DragRelese();
            }
        }
    }
    void DragStart()
    {
        dragStartPos = transform.position;
        dragStartPos.z = 0f;
        lr.positionCount = 1;
        lr.SetPosition(0, dragStartPos);
    }

    void Dragging()
    {
        dragStartPos = transform.position;
        dragStartPos.z = 0f;

        dragingPos = Camera.main.ScreenToWorldPoint(touch.position);
        dragingPos.z = 0f;

        lr.positionCount = 2;
        lr.SetPosition(0, dragStartPos);
        lr.SetPosition(1, dragingPos);
    }

    void DragRelese()
    {
        lr.positionCount = 0;

        dragReleasePos = Camera.main.ScreenToWorldPoint(touch.position);
        dragReleasePos.z = 0f;

        Vector3 force = dragStartPos - dragReleasePos;
        Vector3 clampedForce = Vector3.ClampMagnitude(force, maxDrag) * power;

        rb.AddForce(clampedForce, ForceMode2D.Impulse);

        isJump = false;
    }
    
   

    
}
