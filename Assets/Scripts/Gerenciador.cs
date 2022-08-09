using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerenciador : MonoBehaviour
{
    public UI_Municao minhaMunicao;
    public Arma minhaArma;
    public UI_TextoScore meuScore;
    private int score;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        minhaMunicao.qtdMunicao = minhaArma.qtdTiros;
        minhaMunicao.maxMunicao = minhaArma.maxTiros;
        meuScore.score = score;
    }

    public void Matar(int ponto)
    {
        score = score + ponto;
    }
}
