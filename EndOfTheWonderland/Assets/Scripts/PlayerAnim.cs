using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    // 가만히 있기, 점프, 충돌(벽에)
    public enum CharacterState {Idle, Jump, Enter};
    Animation anim;

    SpriteRenderer spriteRenderer;

    bool idelBoolean = false;
    bool skillSwitch = true;

    public Sprite[] IdleSprite;
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
                    break;

                case CharacterState.Enter:
                    break;


                default:
                    break;
            }
            yield return new WaitForSeconds(0.3f);
        }
       
    }

    IEnumerator CheckCharacter()
    {

        yield return new WaitForSeconds(0.2f);
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

    public void CharacterScaleChange()
    {
        if (skillSwitch)
        {
            anim.clip = animClip[0];
        }
        else
        {
            anim.clip = animClip[1];
        }

        anim.Play();
        skillSwitch = !skillSwitch;
    }

}
