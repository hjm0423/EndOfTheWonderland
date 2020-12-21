using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    // 가만히 있기, 점프, 충돌(벽에)
    public enum CharacterState { Idle, Jump, Enter };
    Animation anim;

    SpriteRenderer spriteRenderer;

    bool idelBoolean = false;
    bool skillSwitch = true;

    public Sprite[] IdleSprite;

    public Sprite jumpSprite;
    public Sprite collisionSprite;

    public AnimationClip[] animClip;

    public static CharacterState characterState = CharacterState.Idle;

    void Start()
    {
        anim = GetComponent<Animation>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        StartCoroutine(CheckState());
    }

    // Update is called once per frame
    IEnumerator CheckState()
    {
        while (true)
        {
            switch (characterState)
            {
                case CharacterState.Idle:
                    IdelAnim();
                    break;
                case CharacterState.Jump:
                    JumpAnim();
                    break;
                case CharacterState.Enter:
                    CollisionAnim();
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(0.1f);
        }

    }

 
    void IdelAnim()
    {
        if (idelBoolean)
        {
            spriteRenderer.sprite = IdleSprite[0];
        }
        else
        {
            spriteRenderer.sprite = IdleSprite[1];
        }

        idelBoolean = !idelBoolean;
    }

    void JumpAnim()
    {   
        spriteRenderer.sprite = jumpSprite;
    }

    void CollisionAnim()
    {
        spriteRenderer.sprite = collisionSprite;
    }

    public void CharacterScaleChange()
    {
        if (skillSwitch)
        {
            anim.clip = animClip[0];
            SoundManager.Instance.PlaySound(SoundManager.SoundName.Small);
        }
        else
        {
            anim.clip = animClip[1];
            SoundManager.Instance.PlaySound(SoundManager.SoundName.Big);
        }

        anim.Play();
        skillSwitch = !skillSwitch;
    }

}
