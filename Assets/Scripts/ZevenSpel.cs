using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZevenSpel : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Zeven());
    }

    IEnumerator Zeven()
    {
        for (int i = 0; i < 101; i++)
        {
            if (!CheckSeven(i))
            {
                GameData.Instance.CurrentNumber = i;

                if (GameData.Instance.CurrentNumber == 100)
                {
                    GameData.Instance.Win = true;
                }

                while (!GameData.Instance.Enter)
                {
                    yield return new WaitForEndOfFrame();
                }
                GameData.Instance.Enter = false;
                if (GameData.Instance.CurrentNumber != GameData.Instance.PlayerInput)
                {
                    GameData.Instance.CanMove = false;
                }
                else
                {
                    GameData.Instance.Previous = GameData.Instance.CurrentNumber;
                    GameData.Instance.PlayerInput = 0;
                    GameData.Instance.ResetTimer = true;
                }


            }
        }


        yield return null;
    }

    bool CheckSeven(int number)
    {
        bool end = false;
        for (int i = 0; i < 10; i++)
        {
            if (number == 7 + 10 * i)
            {
                end = true;
                return end;
            }
        }
        for (int j = 0; j < 15; j++)
        {
            if (number == 7 * j)
            {
                end = true;
                return end;
            }
        }
        for (int k = 0; k <= 6; k++)
        {
            if (number == 7 + 9 * k)
            {
                end = true;
                return end;
            }
        }
        if (number >= 70 && number <= 79)
        {
            end = true;
            return end;
        }
        return end;
    }
}
