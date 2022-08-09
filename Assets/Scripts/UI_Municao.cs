using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Municao : MonoBehaviour
{
    public int qtdMunicao;
    public int maxMunicao;
    private Text meuTexto;
    // Start is called before the first frame update
    void Start()
    {
        meuTexto = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        string info = "AMMO: " + qtdMunicao.ToString()+ " / "+maxMunicao.ToString();
        meuTexto.text = info;
    }
}
