using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugController : MonoBehaviour
{
    public bool IsActive;
    public bool CanMove = true;
    public bool Win = false;



    // Update is called once per frame
    void Update()
    {
        if (IsActive)
        {
            GameData.Instance.Win = Win;
            GameData.Instance.CanMove = CanMove;
        }
    }
}
