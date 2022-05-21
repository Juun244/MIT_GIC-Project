using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controll : MonoBehaviour
{
    public float speed;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LeftMove();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RightMove();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            UpMove();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            DownMove();
        }
        transform.position = Vector3.Lerp(transform.position, target.transform.position, speed);
    }
    public void LeftMove()
    {
        if (transform.position.x > 0)
        {
            target.transform.position = target.transform.position + new Vector3(-1.25f, 0, 0);
            //transform.position = Vector3.Slerp(transform.position, target, speed);
        }
    }

    public void RightMove()
    {
        if (transform.position.x < 10)
        {
            target.transform.position = target.transform.position + new Vector3(1.25f, 0, 0);
            //transform.position = Vector3.Slerp(transform.position, target, speed);
        }
    }
    public void UpMove()
    {
        if (transform.position.z < 10)
        {
            target.transform.position = target.transform.position + new Vector3(0, 0, 1.25f);
            //transform.position = Vector3.Slerp(transform.position, target, speed);
        }
    }
    
    public void DownMove()
    {
        if (transform.position.z > 0)
        {
            target.transform.position = target.transform.position + new Vector3(0, 0, -1.25f);
            //transform.position = Vector3.Slerp(transform.position, target, speed);
        }
    }
}
