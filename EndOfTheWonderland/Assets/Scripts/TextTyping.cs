using RESC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTyping: MonoBehaviour
{
    /*List<CSVDataHolder> csvDataList = new List<CSVDataHolder>();

     public Text chinseText;
     public Text pinyiText;
     public Text koreanText;

     string chinseWriterText = "";
     string pinyiWriterText = "";
     string koreanWriterText = "";

     void OnEnable()
     {
         StartCoroutine(SceneText());
     }


     IEnumerator NormalChat(string chinse, string pinyi, string korean)
     {
         int index = 0;

         chinseWriterText = "";
         pinyiWriterText = "";
         koreanWriterText = "";

         //텍스트 타이핑 효과
         for (index = 0; index < Mathf.Max(chinse.Length, pinyi.Length, korean.Length); index++)
        {
            if (index < chinse.Length)
            {
                chinseWriterText += chinse[index];
                chinseText.text = chinseWriterText;
            }

            if (index < pinyi.Length)
            {
                pinyiWriterText += pinyi[index];
                pinyiText.text = pinyiWriterText;
            }

            if (index < korean.Length)
            {
                koreanWriterText += korean[index];
                koreanText.text = koreanWriterText;
            }
           
            yield return null;
        }

         //키를 다시 누를 떄 까지 무한정 대기
         while (true)
         {
             if (/*anyButton.GetState(SteamVR_Input_Sources.Any) ||*/ /*Input.GetMouseButtonDown(0))
             {
                 break;
             }

             yield return null;
         }
     }

     IEnumerator SceneText()
     {
         for (int i = 0; i < csvDataList.Count; i++)
         {
             yield return StartCoroutine(NormalChat(csvDataList[i].chinese, csvDataList[i].pinyin , csvDataList[i].korean));
         }

         gameObject.SetActive(false);
     }

     public void SetDataHolderList(List<CSVDataHolder> csvList)
     {
        csvDataList = csvList;
     }


     private void OnDisable()
     {
         StopCoroutine(SceneText());
     }*/
}
