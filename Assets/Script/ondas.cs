using UnityEngine;
using System.Collections;

public class ondas : MonoBehaviour {

    private Transform transform;
    public float velocidade;
    public float tempo;

    float numero = 0.00f;
    // Use this for initialization
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        numero = numero + 1;
        Debug.Log(numero);

        if (numero <= tempo)
        {
            transform.Translate(Vector3.left * velocidade);
        }
        else
        {
            transform.Translate(Vector3.right * velocidade);
            if (numero == ((tempo *2)+1))
            {
                numero = 0;
                
            }
        }
    }
}