using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lab_Movement : MonoBehaviour
{
	[SerializeField] Rigidbody2D rigid;
	[SerializeField] float movements;
	[SerializeField] float movement2;
	[SerializeField] int speed;
	public bool isFacingRight = true;
	[SerializeField] Animator animator;
	const int IDLE = 0;
	const int FIRE = 1;
    // Start is called before the first frame update
    void Start()
    {
		if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
		speed = 5;
			if (animator == null)
            animator = GetComponent<Animator>();
		animator.SetInteger("fire", IDLE);
    }

    // Update is called once per frame
    void Update()
    {
        movements = Input.GetAxis("Horizontal");
		movement2 = Input.GetAxis("Vertical");
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, -7f, 7f), Mathf.Clamp(transform.position.y, -5f, 5f),
		transform.position.z);
		if (movements >= .01 || movements <= -.01||movement2 >= .01 || movement2 <= -.01)
                animator.SetInteger("fire", FIRE);
            else
                animator.SetInteger("fire", IDLE);
			

    }
	 void FixedUpdate(){
		rigid.velocity = new Vector2(movements * speed, movement2 * speed);
		if (movements < 0 && isFacingRight || movements > 0 && !isFacingRight)
            Flip();
	 }
	 void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

}
