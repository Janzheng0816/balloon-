using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{	
	public float flyTime;
	

	void Start(){
		StartCoroutine(timer());
		
	}
	

	IEnumerator timer(){
		yield return new WaitForSeconds(flyTime);
		Destroy(gameObject);
	}
	
		
}
