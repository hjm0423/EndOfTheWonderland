using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextTyping : MonoBehaviour
{
    public string[] textString;
    public TextMeshProUGUI text;
    public PlayerController playerController;
    Touch touch;
    string stringText = "";

    void OnEnable()
    {
        StartCoroutine(SceneText());
    }


    IEnumerator NormalChat(string word)
    {
        int index = 0;
        stringText = "";

        for (index = 0; index < word.Length; index++)
        {
            stringText += word[index];
            text.text = stringText;

            yield return null;
        }

        while (true)
        {
            if (Input.touchCount > 0)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    break;
                }
            }
            yield return null;
        }
    }

    IEnumerator SceneText()
    {
        for (int i = 0; i < textString.Length; i++)
        {
            yield return StartCoroutine(NormalChat(textString[i]));
        }

        text.transform.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        StopCoroutine(SceneText());
        playerController.enabled = true;
    }
}
