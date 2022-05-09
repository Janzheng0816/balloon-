using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class score : MonoBehaviour
{
	[SerializeField] int myScore = 0; 
	[SerializeField] Text scoreTxt;
    [SerializeField] Text levelTxt;
    [SerializeField] Text nameTxt;
	[SerializeField] int level;
    // Start is called before the first frame update
    void Start()
    {
		myScore = PersistentData.Instance.GetScore();
        level = SceneManager.GetActiveScene().buildIndex;
		DisplayScore();
        DisplayLevel();
        DisplayName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void UpdateScore(int addend)
    {
        myScore += addend;
        DisplayScore();
        PersistentData.Instance.SetScore(myScore);
	}
	public void DisplayScore()
    {
        scoreTxt.text = "Score: " + myScore;
    }
	public void DisplayLevel()
    {
        int levelToDisplay = level;
        levelTxt.text = "Level " + levelToDisplay;
    }

    public void DisplayName()
    {
        nameTxt.text = "Player:  " + PersistentData.Instance.GetName();
    }
}
