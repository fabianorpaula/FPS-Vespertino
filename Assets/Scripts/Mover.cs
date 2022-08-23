using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private Rigidbody Corpo;
    private Transform Tcorpo;
    private AudioSource MeusPassos;//para ouvir passos
    public float sensibilidade = 1000f;
    public float speed = 4;
    public float HP;

    public GameObject ArmaDeFogo;

    


    void Start()
    {
        Corpo = GetComponent<Rigidbody>();
        Tcorpo = GetComponent<Transform>();
        MeusPassos = GetComponent<AudioSource>();
    }

    void Update()
    {
        float movZ = Input.GetAxis("Vertical") * speed;
        float movX = Input.GetAxis("Horizontal") * 2;
        
        if(movZ != 0) {
            MeusPassos.volume = 1;
            GetComponent<Animator>().SetBool("Andando", true);
        }
        else {
            MeusPassos.volume = 0;
            GetComponent<Animator>().SetBool("Andando", false);
        }

        if(speed == 12) { MeusPassos.pitch = 1.3f;}
        else { MeusPassos.pitch = 1; }

        if (Input.GetKey(KeyCode.LeftShift))  { speed = 12;}
        else { speed = 4;}

        Vector3 posicaoCorrigida = movX * transform.right + movZ * transform.forward;
        Corpo.velocity = new Vector3(posicaoCorrigida.x, Corpo.velocity.y, posicaoCorrigida.z);
        //GIRAR
        float mouseX = Input.GetAxis("Mouse X") * sensibilidade * Time.deltaTime; ;
        Tcorpo.Rotate(Vector3.up * mouseX);


        //ATIRANDO
        if (Input.GetMouseButtonDown(0))
        {
            Atirar();
            GetComponent<Animator>().SetTrigger("Atirar");
        }


    }

    void Atirar()
    {
        if (ArmaDeFogo.GetComponent<Arma>().DanoTiro())
        {
            Debug.Log("Acertei");
        }
        else
        {
            Debug.Log("Errei");
        }

        
    }

    private void OnTriggerEnter(Collider colidiu)
    {
        if(colidiu.gameObject.tag == "Municao")
        {
            ArmaDeFogo.GetComponent<Arma>().Recarregar();
            Destroy(colidiu.gameObject);
        }
        if (colidiu.gameObject.tag == "Vida")
        {
            HP = 100;
            Destroy(colidiu.gameObject);
        }
    }

    private void OnCollisionStay(Collision colisao)
    {
        if (colisao.gameObject.tag == "Inimigo")
        {
            HP--;
        }
    }
}
