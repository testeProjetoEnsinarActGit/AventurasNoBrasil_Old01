using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

    // Use this for initialization
    
    public Rigidbody2D rigidbody2D = null;
    public Transform playerr;


    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(Vector2.right * 15 * Time.deltaTime);
            transform.localEulerAngles = new Vector2(0,0);
            // cenario.Update(teste);
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(Vector2.left * 15 * Time.deltaTime);
            transform.localEulerAngles = new Vector2(0, 0);
        }
    }
  
    }



