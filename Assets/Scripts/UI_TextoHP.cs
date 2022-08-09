using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_TextoHP : MonoBehaviour
{
    public int HP;
    private Text meuTexto;
    // Start is called before the first frame update
    void Start()
    {
        meuTexto = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        string info = "HP: " + HP.ToString();
        meuTexto.text = info;
    }
}
