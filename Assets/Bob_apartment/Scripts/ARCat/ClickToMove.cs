using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour
{

    private Vector3 targetPosition;
    private Vector3 directionVector;
    private bool moving;
    public float smooth = 0.1f;

    void Update()
    {
        // Check if user tapped on screen
        if (Input.GetMouseButtonDown(0))
        {

            // Check if it hit and object
            RaycastHit hit;
            if (!Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
                return;
            // Check if it hit a collider
            if (!hit.transform)
                return;

            // Check that it collides with the floor and save hit position
            if (hit.transform.tag == "Floor")
            {
                if (transform.position != targetPosition && moving == true)
                {
                    GetComponent<Animator>().Play("Run");
                    smooth = 0.2f;
                } else
                {
                    smooth = 0.1f;
                    GetComponent<Animator>().Play("Walk");
                }
                targetPosition = hit.point;
                
                transform.LookAt(targetPosition);
                moving = true;
                
            }
            if (hit.transform.tag == "Cat")
            {
                hit.transform.gameObject.SendMessage("OnMouseDown");
            }
			if (hit.transform.tag == "BackArrow") {
				//TODO refactor by combining all onMouseDown messages to one.
				hit.transform.gameObject.SendMessage ("OnMouseDown");
			}
            if (hit.transform.tag == "ResetAR")
            {
                hit.transform.gameObject.SendMessage("OnMouseDown");
            }

        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, smooth);

        if (transform.position == targetPosition && moving == true) { 
            GetComponent<Animator>().Play("Idle_A");
            moving = false;

        }
    }
    /*
    public void ResetTarget()
    {
        targetPosition = new Vector3(0, 0, 2);
    }
    */
}