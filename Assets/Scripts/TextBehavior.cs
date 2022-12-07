using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBehavior : MonoBehaviour
{
    public KindOfText Kind;
    public TMP_Text text;
    float Timer;

    // Start is called before the first frame update
    void Start()
    {
        Timer = 30;
    }

    // Update is called once per frame
    void Update()
    {
        switch (Kind)
        {
            case KindOfText.Input:
                text.text = "Input: " + GameData.Instance.PlayerInput;
                break;
            case KindOfText.Previous:
                text.text = "Previous: " + GameData.Instance.Previous;
                break;
            case KindOfText.Timer:
                if (GameData.Instance.ResetTimer)
                {
                    Timer = 30;
                    GameData.Instance.ResetTimer = false;
                }
                else
                {
                    if (!GameData.Instance.Win) Timer -= 1 * Time.deltaTime;
                    if (Timer < 0)
                    {
                        GameData.Instance.CanMove = false;
                    }
                }
                text.text = "Timer: " + Timer;
                break;
        }
    }
}
public enum KindOfText
{
    Input,
    Previous,
    Timer
}