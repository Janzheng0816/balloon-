using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_movement : MonoBehaviour
{	[SerializeField] int speed;
	[SerializeField] Rigidbody2D myBullet;
	float xMin = -7, xMax = 7;
	bool isRight;
    // Start is called before the first frame update
    void Start()
    {
        myBullet = GetComponent<Rigidbody2D>();
		speed = 2;
		myBullet.velocity = new Vector2 (speed, 0);
		
    }

    // Update is called once per frame
    void Update()
    {
		if(transform.position.x < xMin){
			Destroy(this.gameObject);	
		}
		
		if(transform.position.x > xMax ){
			Destroy(this.gameObject);
			
		}
    }
	
}
