using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerenciador : MonoBehaviour
{
    public UI_Municao minhaMunicao;
    public Arma minhaArma;
    public UI_TextoScore meuScore;
    private int score;


 
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
