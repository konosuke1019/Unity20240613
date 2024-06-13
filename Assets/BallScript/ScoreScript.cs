using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    GameObject score;
    GameObject block;
    static int totalScore = 0;
    public
    // Start is called before the first frame update
    void Start()
    {
        this.score = GameObject.Find("Score");
    }

    // Update is called once per frame
    public void ScoreManager(int score)
    {
        totalScore += score;
    }
}
