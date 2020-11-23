using System;
using UnityEngine;
using Common;

public class TimeTesting : MonoBehaviour
{
    private void Start()
    {
        TimePlayed.Initialize();
    }
    
    [ContextMenu("Update Time")]
    private void DisplayTimePlayed()
    {
        Debug.Log(TimePlayed.GetTimePlayed());
    }

    private void OnDestroy()
    {
        TimePlayed.SaveDestroyedTime();
        TimePlayed.SaveTimePlayed();
    }
}
