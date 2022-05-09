using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onFire : MonoBehaviour
{
    public GameObject bullet;
	public Transform bulletPoint;
	public float bulletSpeed;
	public float coolDown;
	private bool isFire;
	private bool isRight= true;
	
	
	void Start()
	{	
		
		isFire = false;
	
	
	}
    // Update is called once per frame
    void Update()
    {
		
        if(Input.GetButtonDown("Fire1")&& !isFire)
		{
			StartCoroutine(fire());
		}
		
		
    }

	IEnumerator fire(){
		isRight = GetComponent<lab_Movement>().isFacingRight;
		int direction()
		{
			if (isRight)
			{
				return 1;
			}
			else
			{
				return -1;
			}
		}
		isFire = true;
		GameObject newBullet= Instantiate(bullet, bulletPoint);
		newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(direction()*bulletSpeed, 0);
		newBullet.transform.parent=null;
		yield return new WaitForSeconds(coolDown);
		isFire = false;

	}

}
