using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreKeeper : MonoBehaviour
{
    
    public Text scoretext;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoretext.text = "Pop Count= " + score;
    }

    public void addscore()
    {
        score++;
        scoretext.text = "Pop Count= " + score;
    }
}
