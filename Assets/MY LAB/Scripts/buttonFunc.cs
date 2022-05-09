using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttonFunc : MonoBehaviour
{	
	[SerializeField] InputField playerNameInput;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void Instructions()
    {
        SceneManager.LoadScene("Instruction");
    }
	public void playGame()
	{
		string s = playerNameInput.text;
        PersistentData.Instance.SetName(s);
		SceneManager.LoadScene("level 1");
	}
	public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
	public void HighScore()
    {
        SceneManager.LoadScene("HighScore");
    }
}	