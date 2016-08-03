using UnityEngine;
using System.Collections;

public class NewPlayerPushBlock : MonoBehaviour {

    private CharacterMovementTile thePlayer;
    private TouchControls tcontrols;
    bool nextToBlock = false;
    Collider2D[] hitColliders;
    Collider2D[] blockPosition;
    Vector3 blockjuttu;
    int i;
    float time = 3f;
    RaycastHit2D hitLeft;
    RaycastHit2D hitRight;
    RaycastHit2D hitUp;
    RaycastHit2D hitDown;
    public int layerMask = 1 << 14;

    // Use this for initialization
    void Start () {
        thePlayer = FindObjectOfType<CharacterMovementTile>();
        tcontrols = FindObjectOfType<TouchControls>();
    }
	
	// Update is called once per frame
	void Update () {
        caster(thePlayer.pos, 1f);
        Debug.Log("Player position: " + thePlayer.transform.position);
        
	}

    void caster(Vector2 center, float radius)
    {
        hitColliders = Physics2D.OverlapCircleAll(center, radius);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].tag == "PushBlock")
            {
                //Debug.Log("lel");
                Debug.Log(hitColliders[i].gameObject.name);
                Debug.Log("Block position: " + hitColliders[i].transform.position);
                Debug.Log(hitColliders[i].transform.position - thePlayer.transform.position);
                blockjuttu = hitColliders[i].transform.position - thePlayer.transform.position;


                if (blockjuttu.x == 1 && blockjuttu.y == 0)
                {
                    Debug.Log("Move block to right");

                    Debug.DrawRay(hitColliders[i].transform.position, Vector3.right, Color.red);
                    hitRight = Physics2D.Raycast(hitColliders[i].transform.position, Vector2.right, 1f, layerMask);

                   // print("BlockHit: " + hitRight.collider.gameObject.name);
                    if (hitRight.collider == null)
                    {
                        if (tcontrols.rightButtonHeld == true)
                        {
                            hitColliders[i].transform.position = Vector3.Lerp(hitColliders[i].transform.position, hitColliders[i].transform.position += Vector3.right, time);
                        }
                    }
                }

                if (blockjuttu.x == -1 && blockjuttu.y == 0)
                {
                    Debug.Log("Move block to left");
                    hitLeft = Physics2D.Raycast(hitColliders[i].transform.position, Vector2.left, 1f, layerMask);

                    if (hitLeft.collider == null)
                    {
                        if (tcontrols.leftButtonHeld == true)
                        {
                            hitColliders[i].transform.position = Vector3.Lerp(hitColliders[i].transform.position, hitColliders[i].transform.position += Vector3.left, time);
                        }
                    }
                }

                if (blockjuttu.x == 0 && blockjuttu.y == 1)
                {
                    Debug.Log("Move block to up");
                    hitUp = Physics2D.Raycast(hitColliders[i].transform.position, Vector2.up, 1f, layerMask);

                    if (hitUp.collider == null)
                    {
                        if (tcontrols.upButtonHeld == true)
                        {
                            hitColliders[i].transform.position = Vector3.Lerp(hitColliders[i].transform.position, hitColliders[i].transform.position += Vector3.up, time);
                        }
                    }
                }

                if (blockjuttu.x == 0 && blockjuttu.y == -1)
                {
                    Debug.Log("Move block to down");
                    hitDown = Physics2D.Raycast(hitColliders[i].transform.position, Vector2.down, 1f, layerMask);

                    if (hitDown.collider == null)
                    {
                        if (tcontrols.downButtonHeld == true)
                        {
                            hitColliders[i].transform.position = Vector3.Lerp(hitColliders[i].transform.position, hitColliders[i].transform.position += Vector3.down, time);
                        }
                    }
                }

            }


            i++;
        }
    }

    void MoveBlock()
    {
            if(blockjuttu.x == 1 && blockjuttu.y == 0)
            {
                Debug.Log("Move block to right");
               // hitColliders[i].transform.position = Vector3.Lerp(hitColliders[i].transform.position, , time);
            }

            if (blockjuttu.x == -1 && blockjuttu.y == 0)
            {
                Debug.Log("Move block to left");
            }

            if (blockjuttu.x == 0 && blockjuttu.y == 1)
            {
                Debug.Log("Move block to up");
            }

            if (blockjuttu.x == 0 && blockjuttu.y == -1)
            {
                Debug.Log("Move block to down");
            }
        }

}

