using UnityEngine;
using System.Collections;

public class player : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public Transform playerr;
    
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(Vector3.right * 20 * Time.deltaTime);
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(Vector3.left * 20 * Time.deltaTime);
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            //transform.Translate(Vector3.forward * 15 * Time.deltaTime);
            //transform.localEulerAngles = new Vector3(0, 0, 0);
        }

        if (Input.GetAxisRaw("Vertical") < 0)
        {
            // transform.Translate(Vector3.back * 15 * Time.deltaTime);
            //transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        
    }
            

}



