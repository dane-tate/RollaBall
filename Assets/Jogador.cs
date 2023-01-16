using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{

    public float velocidade;

     private Rigidbody rb;
    // Start is called before the first frame update
void Start()
{
    //Fisica é adicionada ao componente Rigidbody
    //Guardar a referencia do objeto Rigidbody (se este axistir)
    rb = GetComponent<Rigidbody> ();
}
    //O método FixedUpdate é chamado antes de ser efetuado qualquer cálculo de física.
    //Física deve ser adicionada neste método
void FixedUpdate ()
    {
    //Variáveis que vão armazenar a posição do jogardor
    //A função GetAxis permite aceder ao eixo que queremos manipular
    float moverNaHorizontal = Input.GetAxis ("Horizontal");
    float moverNaVertical = Input.GetAxis("Vertical");
    //RigidBody Vector3 guarda as coordenadas nos eixos. em 3D(x,y, z)
    //como não queremos movimento no eixo do y configuramos da seguinte forma 0.0f
    Vector3 movimento = new Vector3 (moverNaHorizontal, 0.0f, moverNaVertical);
    //Método Addforce permite adicionar uma força ao objeto que neste caso é
    //movimento * velocidade
    rb. AddForce (movimento * velocidade);
    }
}
