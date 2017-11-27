using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    static ScoreManager manager = new ScoreManager();

    public Sprite zero;
    public Sprite one;
    public Sprite two;
    public Sprite three;
    public Sprite four;
    public Sprite five;
    public Sprite six;
    public Sprite seven;
    public Sprite eight;
    public Sprite nine;

    private static Image[] _scoreDigits;
    private static int score = 0;

    void Start () {
        Debug.Log(two);
        Canvas cav = GetComponent<Canvas>();
        _scoreDigits = cav.GetComponentsInChildren<Image>();
        updateScore();
	}
	
	public void updateScore () {
        score += 200;
        _scoreDigits[2].sprite = (Sprite)Resources.Load("two");
        Debug.Log("score: " + score);
	}
}
