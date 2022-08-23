using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public int qtdTiros = 30;
    public int maxTiros= 30;
    //Pegar o Arquivo de Som
    public AudioSource SomDeTiro;
    public AudioClip ArmaCheia;
    public AudioClip ArmaVazia;

    public bool DanoTiro()
    {
        if (qtdTiros > 0)
        {

            qtdTiros--;
            //Toda Vez que Atira / Faz o Som de Tiro
            SomDeTiro.clip = ArmaCheia;
            SomDeTiro.Play();
            RaycastHit Bateu;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Bateu, 5f))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * Bateu.distance, Color.yellow);
                Debug.Log("Bati Em Alguma Coisa");
                Destroy(Bateu.collider.gameObject);
                GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>().Matar(1);
                return true;
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 5, Color.white);
                Debug.Log("Não Bati Em nada");
                return false;
            }
            
        }
        else
        {
            Debug.Log("Nao Tenho Bala");
            SomDeTiro.clip = ArmaVazia;
            SomDeTiro.Play();
            return false;
        }
    }

}

