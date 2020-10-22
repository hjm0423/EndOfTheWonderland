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
    public AnimationClip[] animClip;

    bool swich = true;

    Vector3 dragStartPos;
    Touch touch;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
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
        Vector3 dragingPos = Camera.main.ScreenToWorldPoint(touch.position);
        dragingPos.z = 0f;
        lr.positionCount = 2;
        lr.SetPosition(1, dragingPos);
    }

    void DragRelese()
    {
        lr.positionCount = 0;

        Vector3 dragReleasePos = Camera.main.ScreenToWorldPoint(touch.position);
        dragReleasePos.z = 0f;

        Vector3 force = dragStartPos - dragReleasePos;
        Vector3 clampedForce = Vector3.ClampMagnitude(force, maxDrag) * power;

        rb.AddForce(clampedForce, ForceMode2D.Impulse);
    }
    
    public void CharacterScaleChange()
    {
        if (swich)
        {
            anim.clip = animClip[0];
        }
        else
        {
            anim.clip = animClip[1];
        }

        anim.Play();
        swich = !swich; 
    }
}
