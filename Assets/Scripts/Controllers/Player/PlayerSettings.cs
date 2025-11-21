using System;
using UnityEngine;

[Serializable]
public class PlayerSettings
{
    private static PlayerSettings instance;
    public static PlayerSettings Instance
    {
        get
        {
            if (instance == null)
                instance = new PlayerSettings();
            return instance;
        }
    }
    public float MouseSensitivity = 100;
}
