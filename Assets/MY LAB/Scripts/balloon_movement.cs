using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class balloon_movement : MonoBehaviour
{
	[SerializeField] float speed;
	[SerializeField] Rigidbody2D myBalloon;
	[SerializeField] AudioSource audio;
	[SerializeField] int popTime = 50;
	[SerializeField] GameObject controller;
	[SerializeField] GameObject findPlane;
	[SerializeField] Animator animator;
	const int IDLE = 0;
    const int POP = 1;
	
	float xMin = -7f, xMax = 7f;
	float yMin = -4.5f, yMax = 4.5f;
	[SerializeField] float growRate = 5f;
	int sizeCount = 0; 
	
    // Start is called before the first frame update
    void Start()
    {
        myBalloon = GetComponent<Rigidbody2D>();
		myBalloon.velocity = new Vector2 (-speed, Random.Range(yMin,yMax));
		if (audio == null)
        {
            audio = GetComponent<AudioSource>();
        }
		InvokeRepeating("growBalloon", 1.0f, 0.3f);
		if (controller == null)
        {
            controller = GameObject.FindGameObjectWithTag("GameController");
		}
		if (findPlane == null)
        {
            findPlane = GameObject.FindGameObjectWithTag("plane");
		}
		if (animator == null)
            animator = GetComponent<Animator>();
		animator.SetInteger("ballonact", IDLE);
		
    }

    // Update is called once per frame
    void Update()
    {
		if(transform.position.x <= xMin)
		{
			myBalloon.velocity = new Vector2 (speed, Random.Range(yMin,yMax));	
		}
		if(transform.position.y <= yMin)
		{
			myBalloon.velocity = new Vector2 (speed, Random.Range(0,yMax));	
		}
		
		if(transform.position.x >= xMax )
		{
			myBalloon.velocity = new Vector2 (-speed, Random.Range(yMin,yMax));	
		}
		if(transform.position.y >= yMax 
		){
			myBalloon.velocity = new Vector2 (-speed, Random.Range(yMin,0));	
		}
		if (sizeCount == popTime)
		{
			AudioSource.PlayClipAtPoint(audio.clip, transform.position);
			animator.SetInteger("ballonact", POP);			
			Destroy(gameObject);
			//StartCoroutine(WaitForLoad());
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
		if (SceneManager.GetActiveScene().buildIndex ==3)
		{
			flee();
		}
	}
    
	private void OnTriggerEnter2D (Collider2D collider)
    {   
        AudioSource.PlayClipAtPoint(audio.clip, transform.position);
		if (collider.gameObject.tag == "bullet"){
			controller.GetComponent<score>().UpdateScore(sizeCount);
			animator.SetInteger("ballonact", POP);
			Destroy(gameObject);
			//StartCoroutine(WaitForLoad());
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex+1);
		}
    }
	private void growBalloon(){
		sizeCount++;
		myBalloon.transform.localScale += myBalloon.transform.localScale * growRate;
		
	}
	IEnumerator WaitForLoad() {
		Debug.Log("hello");
     yield return new WaitForSeconds(2f);
	 SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex+1);    
	}
	
	void flee(){
	
	
		float maxDistance = 2.0f;
		Vector2 currentVelocity;
		Vector2 disireVelocity;
		Vector2 steerVelocity;
		float maxVelocity = 0.05f; 
		float maxForce = 0.05f;
		
		Vector2 seeker = findPlane.GetComponent<Rigidbody2D>().transform.position;
		currentVelocity = myBalloon.velocity;
		if ((Vector2.Distance(transform.position, seeker))< maxDistance){			
			disireVelocity = currentVelocity - seeker;
			steerVelocity = disireVelocity - currentVelocity;
			steerVelocity = Vector2. ClampMagnitude(steerVelocity, maxForce);
			steerVelocity /= myBalloon.mass;
			currentVelocity += steerVelocity;
			currentVelocity = Vector2. ClampMagnitude(currentVelocity, maxVelocity);
			Vector3 v3 = currentVelocity ;
			transform.position += v3;
		}
	}

}
