using UnityEngine;
using System.Collections;

public class cenario : MonoBehaviour {

    
    public Transform action;
    public float smooth = 0.5f;
    private float velocidade = 0.5f;
    
    void Start()
    {
        //Nada para iniciar
    }

    void Update()
    {
        float novaPosicao2D = Mathf.SmoothDamp(transform.position.x,action.transform.position.x, ref velocidade, smooth);
        transform.position = new Vector3(novaPosicao2D, transform.position.y, transform.position.z);
    }
}
