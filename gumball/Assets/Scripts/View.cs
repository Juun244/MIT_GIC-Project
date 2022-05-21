using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour
{
    public GameObject player;
    public Vector3 Offset;

    // Start is called before the first frame update
    void Awake()
    {
        CameraSet();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CameraSet()
    {
        transform.position = player.transform.position + Offset;
        transform.rotation = Quaternion.Euler(75, 0, 0);
        
    }
}
