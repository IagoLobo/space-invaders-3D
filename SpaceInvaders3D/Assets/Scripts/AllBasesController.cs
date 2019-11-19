using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllBasesController : MonoBehaviour
{
    private Transform allBases;

    void Start()
    {
        allBases = GetComponent<Transform>();
    }

    void Update()
    {
        // Se todas as bases foram destruídas, acabou o jogo, derrota
        if(allBases.childCount == 0)
        {
            GameOverController.playerWon = false;
            GameOverController.isGameOver = true;
            Destroy(this.gameObject);   // Destrói o objeto que contém todas as bases
        }
    }
}
