using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D rgb2D;
	Vector3 offset;
	Vector2 mousePosition;
	//Vector3 rgb2DMoveP;
	//Vector3 rgb2DMoveN;
	public float moveSpeed;
	public Sprite spriteCenter;
	public Sprite spriteLeft;
	public Sprite spriteRight;
	public SpriteRenderer spriteRenderer;
	private float different;
	Vector3 normal;
	bool isFrozen = false;
	public float freezeTime = 2f;
	private float freezeTimer;
	bool gyroToggle;
	ShelfGameManager shelfmanager;
    private Animator animator;
    bool moving;
    Vector2 wanhaPosition;
    private AudioSource itemCatchSound;

	// Use this for initialization
	void Start () 
	{
        itemCatchSound = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
		rgb2D = GetComponent<Rigidbody2D> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
		shelfmanager = FindObjectOfType<ShelfGameManager> ();


        
		//gyroToggle = ShelfGameManager.gyroOn;
		//rgb2DMoveP.x = 5;
		//rgb2DMoveN.x = -5;

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (wanhaPosition.x > rgb2D.transform.position.x)
        {
            //spriteRenderer.sprite = spriteLeft;
            animator.SetTrigger("BobVasen");
        }
        else if (wanhaPosition.x < rgb2D.transform.position.x)
        {
            //spriteRenderer.sprite = spriteRight;
            animator.SetTrigger("BobOikee");
        }
        else if (wanhaPosition.x == rgb2D.transform.position.x)
        {
            //spriteRenderer.sprite = spriteCenter;
            animator.SetTrigger("BobEteen");
        }

        wanhaPosition = rgb2D.transform.position;



        gyroToggle = ShelfGameManager.gyroOn;
        if (isFrozen && freezeTimer > 0) {
			freezeTimer -= Time.deltaTime;
		} 
		else {
			Unfreeze ();
		}
		if (gyroToggle == true) {
			if (isFrozen == false) {
				
                if (moving == false)
                {
                    moving = true;
                    transform.Translate(Input.acceleration.x / 2, 0f, 0f);
                    Debug.Log("Acceleration: " + Input.acceleration.x);

                    if (Input.acceleration.x >= 0.2f)
                    {
                        //spriteRenderer.sprite = spriteRight;
                        animator.SetTrigger("BobOikee");
                    }
                    else if (Input.acceleration.x <= -0.2f)
                    {
                        //spriteRenderer.sprite = spriteLeft;
                        animator.SetTrigger("BobVasen");
                    }
                    else if (Input.acceleration.x < 0.2f && Input.acceleration.x > -0.2f)
                    {
                        //spriteRenderer.sprite = spriteCenter;
                        animator.SetTrigger("BobEteen");
                    }

                    transform.position = new Vector2(Mathf.Clamp(transform.position.x, ShelfGameManager.xMinPoint, ShelfGameManager.xMaxPoint), transform.position.y);
                    //Invoke("stopMove", 1f);

                }
                else
                {
                    moving = false;
                }
				
			}
		}
	}

	//Gets mouse/touch position and moves player in clamped values 
	void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, 0, 0);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);

		different = curPosition.x - gameObject.transform.position.x;

		if (isFrozen == false) {

            if(moving == false)
            {
                

                moving = true;
                
                //transform.position = new Vector3 (Mathf.Clamp (transform.position.x + different, xMin, xMax), transform.position.y);
                rgb2D.MovePosition(new Vector2(Mathf.Clamp(transform.position.x + different, ShelfGameManager.xMinPoint, ShelfGameManager.xMaxPoint), transform.position.y));

                


            }
            else
            {
                moving = false;
            }
			
		} 
		else if (isFrozen == true) {
			spriteRenderer.sprite = spriteCenter;
		}		
	}

    void stopMove()
    {
        moving = false;
    }

	void OnMouseUp()
	{
		spriteRenderer.sprite = spriteCenter;
	}

	public void Freeze()
	{
		isFrozen = true;
		freezeTimer = freezeTime;

		spriteRenderer.color = new Color (0, 200, 255);

        animator.speed = 0;
    }

	private void Unfreeze()
	{
		isFrozen = false;
		spriteRenderer.color = new Color (255, 255, 255);

        animator.speed = 1;
    }

    //Toggles gyro movement
    
    public void GyroToggle(bool gyro)
	{
		if (gyro == true) {
			gyroToggle = true;
		}
		else if (gyro == false) {
			gyroToggle = false;
		}
	}


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Dropped")
        {
            if (!itemCatchSound.isPlaying)
            {
                itemCatchSound.Play();
            }

        }


    }


}
