using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartController : MonoBehaviour
{
    public void OnStartButtonPresssed()
    {
        GameManager.instance.StartGame();
    }
}
