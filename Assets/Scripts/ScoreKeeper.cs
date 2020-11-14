using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreKeeper : MonoBehaviour
{
    public Text scoreText;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Pop Count: " + score;
        FindObjectOfType<MusicPlayer>().playhappymusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addscore()
    {
        score++;
        scoreText.text = "Pop Count: " + score;
    }
}
