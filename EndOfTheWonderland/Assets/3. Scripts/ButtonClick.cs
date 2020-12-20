using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    public void StartButtonClick()
    {
        SceneManager.LoadScene(1);
        SoundManager.Instance.PlaySound(SoundManager.SoundName.ButtonClick);
    }

    public void ExitButtonClick()
    {
        SoundManager.Instance.PlaySound(SoundManager.SoundName.ButtonClick);
        Application.Quit();
    }
}
