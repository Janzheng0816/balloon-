using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeController : MonoBehaviour
{
	[SerializeField] Slider volumeSlider; 
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("currentVolume"))
		{
			PlayerPrefs.SetFloat("changeVolume", 0.1f);
			load();
		}
		else
		{
			load();
		} 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void changeVolume()
	{
		AudioListener.volume = volumeSlider.value;
		save();
	}

	private void load()
	{
		volumeSlider.value = PlayerPrefs.GetFloat("currentVolume");
	}
	private void save()
	{
		PlayerPrefs.SetFloat("currentVolume", volumeSlider.value);
	}

}
