using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Jogador : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI timerDisplay;
    public float velocidade;
    private int contador = 0;
    public  UnityEngine.UI.Text contar;
    public  UnityEngine.UI.Text Vitoria;
    private bool isGrounded = true;
    public float forcaSalto = 4f;
    private float startTime; 
    private float t;
    private string min, seconds;

     private Rigidbody rb;
    // Start is called before the first frame update
void Start()
{
    
    contador = 0;
    Vitoria.text = "";
    Contador();
    
    //Fisica é adicionada ao componente Rigidbody
    //Guardar a referencia do objeto Rigidbody (se este axistir)
    rb = GetComponent<Rigidbody> ();
    startTime = Time.time;

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
    if(Input.GetKey(KeyCode.Space) && isGrounded){
        rb.AddForce(Vector3.up * forcaSalto, ForceMode.Impulse);
        isGrounded= false;
    }

    t = Time.time - startTime; 
    min = ((int)t / 60).ToString(); 
    seconds = (t % 60).ToString("f2");
    timerDisplay.text = "Tempo: " + min + ":" + seconds.ToString().Replace(",", ":");
    if(min=="2"){
        Vitoria.text = "Acabou o Tempo! Perdeste!";
    }
    }


private void OnCollisionEnter(Collision other) {
    if (other.gameObject.name == "Fundo")
    {
        isGrounded = true;
    }
}



private void OnTriggerEnter (Collider other)
{
    if (other.gameObject.tag == "amarela")
    {
        contador += 2;
    } else if (other.gameObject.tag == "verde")
    {
        contador += 1;
    } else if (other.gameObject.tag == "vermelha")
    {
        contador += 5;
    }
    Contador();
    //se o GameObject for um Coletável if (other.gameObject. CompareTag("Coletavel"))
    {
    //então desativa
    other.gameObject.SetActive(false);
    }

    
}

void Contador()
{
    
    contar.text = "Contador: " + contador.ToString();
    if(contador >= 28){
    Vitoria.text = "Ganhou! Parabéns";
    }
}

}