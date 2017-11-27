using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    private Hashtable numToWord = new Hashtable() {
        { '0',"zero"},
        { '1',"one"},
        { '2',"two"},
        { '3',"three"},
        { '4',"four"},
        { '5',"five"},
        { '6',"six"},
        { '7',"seven"},
        { '8',"eight"},
        { '9',"nine"},
    };

    private static Image[] _scoreDigits;
    public static int score;
    private string scoreWord;

    void Start () {
        score = 0;
        scoreWord = "";
        Canvas cav = GetComponent<Canvas>();
        _scoreDigits = cav.GetComponentsInChildren<Image>();
	}
	
	public void updateScore () {
        score += 200;
        updateScoreboard(score);
	}

    public void decreaseScore()
    {
        score = score - 150 < 0 ? 0 : score - 150;
        updateScoreboard(score);
    }

    private void updateScoreboard(int score)
    {
        scoreWord = score.ToString();
        if (score < 1000) scoreWord = scoreWord.PadLeft(4, '0');
        for (int i = 0; i < scoreWord.Length; i++)
        {
            _scoreDigits[i].sprite = Resources.Load<Sprite>((string)numToWord[scoreWord[i]]);
        }
    }
}
