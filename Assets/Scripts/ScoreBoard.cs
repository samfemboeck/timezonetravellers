using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreBoard : MonoBehaviour
{
    public Text ScoreText;
    float _initialBalloonCount;
    float _balloonsPopped = 0;

    void Start()
    {
        _initialBalloonCount = Balloon.Instances;
        ScoreText.text = "Pop Count: " + _balloonsPopped;
    }

    void IncrementScore() => ScoreText.text = "Pop Count: " + ++_balloonsPopped;
}
