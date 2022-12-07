using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public bool CanMove;
    public int CurrentNumber;
    public int PlayerInput;
    public int Previous;
    public bool Enter;
    public bool ResetTimer;
    public bool Win;
    public void EnterTrue()
    {
        Enter = true;
    }

    public void ResetData()
    {
        PlayerInput = 0;
        Previous = 0;
        CurrentNumber = 0;
    }


    private GameData() { }

    private static GameData instance;
    public static GameData Instance
    {
        get
        {
            if (instance == null) instance = new GameData();
            return instance;
        }
    }
}
