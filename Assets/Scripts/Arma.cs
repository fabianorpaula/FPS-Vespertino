using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public bool DanoTiro()
    {
        RaycastHit Bateu;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Bateu, 5f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * Bateu.distance, Color.yellow);
            Debug.Log("Bati Em Alguma Coisa");
            Destroy(Bateu.collider.gameObject);
            return true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 5, Color.white);
            Debug.Log("N�o Bati Em nada");
            return false;
        }
    }

}

