using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;

public class BobPlayerScript : MonoBehaviour
{
    private Animator BobPlayerAnimator;
    //int BobDirection = 20;
    //int OldBobDirection = 15;

	bool bobstill;

    int startDestinationX, startDestinationY;

	private PathFollower pathfinder;

    public static bool nearMemoryGame 	= false;
    public static bool nearCatchTheCat 	= false;
    public static bool nearLabyrinth 	= false;
    public static bool Runner 			= false;
    public static bool nearBobApartment = false;
    public static bool nearShop 		= false;

    public static float aboveButton;


    static public int Frame = 0;

    //static int reittiX, reittiY, reitinpituus, midWayDestinationX, midWayDestinationY;

    public static int DestinationButtonNumberX;
    public static int DestinationButtonNumberY;
    public static int StandingButtonNumberX = 0;
    public static int StandingButtonNumberY = 1;

    //    private map_manager map;

    public static Vector3 destination;

    static float lerpStartTime;
    float timeStartedLerping;
    float timeTakenDuringLerp;
    //float BobNopeus = 10;

    static Vector3 startPosition;

    public Transform target;

    public static bool Moving;

    //static GameObject BobPlayer;

    GameObject memoryGame;

    Collider2D Rakennus1; //Objektiin luotu tag
    Collider2D Rakennus2;

    Button Button1, Button2, Button3, Button4, Button5;

    public Button puhekupla1, puhekupla2, puhekupla3, puhekupla4, puhekupla5;

    // Use this for initialization
    void Start ()
    {

        nearShop = false;
        ReadFile("tiedosto");
        puhekupla1.interactable = false;
        puhekupla2.interactable = false;
        puhekupla3.interactable = false;
        puhekupla4.interactable = false;
        puhekupla5.interactable = false;

        nearMemoryGame = false;
        Frame = 0;
        BobPlayerAnimator = GetComponent<Animator>();

        startDestinationX = PlayerPrefs.GetInt("Bobin paikka X");
        startDestinationY = PlayerPrefs.GetInt("Bobin paikka Y");

        StandingButtonNumberX = PlayerPrefs.GetInt("Bobin paikka X");
        StandingButtonNumberY = PlayerPrefs.GetInt("Bobin paikka Y");

        //Debug.Log("StandingButtonNumberX = " + StandingButtonNumberX);
        //Debug.Log("StandingButtonNumberY = " + StandingButtonNumberY);

        GameObject startButton = GameObject.Find("Tile" + startDestinationX + startDestinationY);
        //Debug.Log("Start button = " + startButton);
        
		if (startButton == null)
        {
            startButton = GameObject.Find("Tile" + 0 + 1);
            Debug.Log("Ei löytynyt");
        }

        //aboveButtonScale();
        //gameObject.transform.position = destination;

        Vector2 kierto;

        kierto.x = startButton.transform.position.x;
        kierto.y = startButton.transform.position.y;


		pathfinder = this.GetComponent<PathFollower> ();
		pathfinder.setParent (this.transform.parent.gameObject);
		Debug.Log ("Bobin alotusnode: " + pathfinder.getCurrentNode());

		BobScale();
		speechBubbleCheck ();
    }

    int ReadFile(string file)
    { 
    if(File.Exists(file))
    {
    var sr = File.OpenText(file);
    var line = sr.ReadLine();
        while(line != null)
        {
        Debug.Log(line); // prints each line of the file
        line = sr.ReadLine();
        }
            return 5;
    }
    else
    {
        return 5;
    }
    }

    // Update is called once per frame
    void FixedUpdate ()
	{
		if (Moving) { 
			//movePath ();
			Moving = pathfinder.run ();
			Animate ();
			BobScale ();

			if (!Moving) {
				speechBubbleCheck ();
			}
		} else {

			if(bobstill == false)
			{
				BobPlayerAnimator.SetTrigger("BobStanding");
				bobstill = true;
			}
			
		}

    }

	public void startMoving ( List<Node> path, int destinationButtonX, int destinationButtonY )
	{
		if (path.Count == 0) {
			return;
		}
		Moving = true;
		pathfinder.init ( path );
		StandingButtonNumberX = destinationButtonX;
		StandingButtonNumberY = destinationButtonY;
		speechBubbleCheck ();
	}

	public void speechBubbleCheck () {
		if (Moving) {
			puhekupla1.interactable = false;
			puhekupla2.interactable = false;
			puhekupla3.interactable = false;
			puhekupla4.interactable = false;
			puhekupla5.interactable = false;
			return;
		}

		if (StandingButtonNumberX == 2 && StandingButtonNumberY == 3) {
			puhekupla1.interactable = true;
			puhekupla2.interactable = false;
			puhekupla3.interactable = false;
			puhekupla4.interactable = false;
			puhekupla5.interactable = false;

		} else if (StandingButtonNumberX == 0 && StandingButtonNumberY == 1) {
			puhekupla1.interactable = false;
			puhekupla2.interactable = false;
			puhekupla3.interactable = true;
			puhekupla4.interactable = false;
			puhekupla5.interactable = false;
		} else if (StandingButtonNumberX == 2 && StandingButtonNumberY == 0) {
			puhekupla1.interactable = false;
			puhekupla2.interactable = false;
			puhekupla3.interactable = false;
			puhekupla4.interactable = false;
			puhekupla5.interactable = true;
		} else if (StandingButtonNumberX == 0 && StandingButtonNumberY == 2) {
			puhekupla1.interactable = false;
			puhekupla2.interactable = true;
			puhekupla3.interactable = false;
			puhekupla4.interactable = false;
			puhekupla5.interactable = false;
		} else if (StandingButtonNumberX == 0 && StandingButtonNumberY == 3) {
			puhekupla1.interactable = false;
			puhekupla2.interactable = false;
			puhekupla3.interactable = false;
			puhekupla4.interactable = true;
			puhekupla5.interactable = false;
		}
	}
		
	public Node getCurrentNode ( )
	{
		return pathfinder.getCurrentNode ();
	}

    void BobScale()     //Skaalataan Bobia perspektiivin mukaan
    {
		transform.parent.gameObject.transform.localScale = new Vector2(
			Mathf.Abs(transform.parent.gameObject.transform.position.y * 0.05F), 
			Mathf.Abs(transform.parent.gameObject.transform.position.y * 0.05F)
		);
    }

	int animationState = -1;

	void Animate()
	{
		//Escape
		if (!Moving) {
			BobPlayerAnimator.SetTrigger("BobStanding");
			animationState = -1;
			return;
		}

		Vector2 dir = pathfinder.getLastDirection ();
		double constant = 0.35; //Adjust the angles at which Bob picks between "up" or "down" animations instead of "left" or "right"
		if (dir.y < 0) {
			if (dir.x > constant) {
				if (animationState != 0) {
					BobPlayerAnimator.SetTrigger ("BobUp");
					animationState = 0;
				}
			} else if (dir.x < -constant) {
				if (animationState != 1) {
					BobPlayerAnimator.SetTrigger ("BobDown");
					animationState = 1;
				}
			} else {
				if (animationState != 2) {
					BobPlayerAnimator.SetTrigger ("BobLeft");
					animationState = 2;
				}
			}
		} else {
			
			if (dir.x > constant) {
				if (animationState != 0) {
					BobPlayerAnimator.SetTrigger ("BobUp");
					animationState = 0;
				}
			} else if (dir.x < -constant) {
				if (animationState != 1) {
					BobPlayerAnimator.SetTrigger ("BobDown");
					animationState = 1;
				}
			} else {
				if (animationState != 3) {
					BobPlayerAnimator.SetTrigger ("BobRight");
					animationState = 3;
				}
			}
		}
	}

    void BobOnButton()
    {
        destination.y = destination.y + aboveButton;
        //gameObject.transform.position = destination;

        //StartLerping();
    }

    public void aboveButtonScale()
    {
        aboveButton = gameObject.transform.position.y * -0.075F;

        Debug.Log("Above Button = " + aboveButton);
    }
		
}
