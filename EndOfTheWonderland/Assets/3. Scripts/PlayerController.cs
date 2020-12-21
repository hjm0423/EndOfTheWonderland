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

    float touchTime = 0f;
    private void Start()
    {
        StartCoroutine(ChaekGround());
    }

    void Update()
    {
        if (Input.touchCount > 0 && isJump)
        {
            touchTime += Time.deltaTime;
            touch = Input.GetTouch(0);

            if (touchTime > 0.25f)
            {
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
                    SoundManager.Instance.PlaySound(SoundManager.SoundName.Jump);
                    PlayerAnim.characterState = PlayerAnim.CharacterState.Jump;
                }
            }
        }
        else
        {
            touchTime = 0f;
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


    IEnumerator ChaekGround()
    {
        while (true)
        {
            raycastHit = Physics2D.Raycast(transform.position, new Vector2(0, -1f), 2f, 1 << LayerMask.NameToLayer("Object"));

            if (raycastHit)
            {
                Debug.Log(raycastHit.collider.name);
                isJump = true;
                PlayerAnim.characterState = PlayerAnim.CharacterState.Idle;
            }

            yield return new WaitForSeconds(1.5f);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SoundManager.Instance.PlaySound(SoundManager.SoundName.Collision);
        PlayerAnim.characterState = PlayerAnim.CharacterState.Enter;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        SoundManager.Instance.PlaySound(SoundManager.SoundName.Collision);
        PlayerAnim.characterState = PlayerAnim.CharacterState.Idle;
    }
}
