using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallistaControl : MonoBehaviour
{

    float fMinX;
    float fMaxX;
    public int Direction = -1;
    public GameObject arrow;
    private GameObject newArrow;
    private float rayLeft;
    private float rayRight;

    // Use this for initialization
    void Start()
    {
        fMinX = transform.position.x - 1;
        fMaxX = transform.position.x + 1;
        rayLeft = transform.position.x - 1f;
        rayRight = transform.position.y + 1f;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        switch (Direction)
        {
            case -1:
                // Moving Left
                if (transform.position.x > fMinX)
                {
                    transform.Translate(new Vector2(-0.02f, 0f));
                    RaycastHit2D hit = Physics2D.Raycast(new Vector3(transform.position.x - 5f, 0), transform.position);
                    Debug.DrawRay(transform.position, new Vector3(transform.position.x - 5f, 0));

                    if (hit.collider.name == "Player")
                    {
                        Debug.Log("Hit left");
                        newArrow = Instantiate(arrow, transform.position, Quaternion.identity);
                        newArrow.transform.parent = gameObject.transform;

                    }

                }
                else
                {
                    // Hit left boundary, change direction
                    Direction = 1;
                }
                break;

            case 1:
                // Moving Right
                if (transform.position.x < fMaxX)
                {
                    transform.Translate(new Vector2(0.02f, 0f));
                    RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector3(transform.position.x + 5f, 0));
                    Debug.DrawRay(transform.position, new Vector3(transform.position.x + 5f, 0));
                    if (hit.collider.name == "Player")
                    {
                        Debug.Log("Hit right");
                        newArrow = Instantiate(arrow, transform.position, Quaternion.identity);
                        newArrow.transform.parent = gameObject.transform;

                    }
                }
                else
                {
                    // Hit right boundary, change direction
                    Direction = -1;
                }
                break;
        }




    }
}
