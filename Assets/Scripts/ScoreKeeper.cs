using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreKeeper : MonoBehaviour
{
    public Text scoreText;
    int score = 0;
    int numberofballoons;
    int currentnumberofballoons;
    // Start is called before the first frame update
    void Start()
    {
        numberofballoons = FindObjectsOfType<Balloon>().Length;
        currentnumberofballoons = numberofballoons;
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
        currentnumberofballoons--;

        scoreText.text = "Pop Count: " + score;
        if(currentnumberofballoons<numberofballoons/3)
        {
            
            FindObjectOfType<MusicPlayer>().playbadmusic(2f);
        }
        if(currentnumberofballoons==0)
        {
            FindObjectOfType<MusicPlayer>().playtransitionmusic(2f);
        }
    }
}
