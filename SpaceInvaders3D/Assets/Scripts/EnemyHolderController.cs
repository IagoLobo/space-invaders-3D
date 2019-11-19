using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHolderController : MonoBehaviour
{
    private Transform enemyHolder;      // Componente que possui a posição de todos os inimigos
    public float speed;                 // Velocidade dos inimigos
    public float maxBound, minBound;    // Limite máximo e mínimo de movimentação dos inimigos

    public GameObject enemyShot;        // Objeto do tiro do inimigo
    public float enemyFireRate;

    void Start()
    {
        // Pegamos a referência do componente Transform para manter na variável privada
        enemyHolder = GetComponent<Transform>();
        InvokeRepeating("MoveEnemies", 0.1f, 0.3f); // Inicia o comportamento dos inimigos e repete a cada 0.3 segundos
    }

    void MoveEnemies()
    {
        // Atualizar a posição de todos os inimigos
        enemyHolder.position += Vector3.right * speed;

        // Para cada inimigo dentro do enemyHolder
        foreach(Transform enemy in enemyHolder)
        {
            // Se algum inimigo alcançar o limite de movimentação, troca o lado
            if(enemy.position.x < minBound || enemy.position.x > maxBound)
            {
                speed = -speed; // Troca de lado
                enemyHolder.position += Vector3.down * 0.5f;    // Desce a coluna de inimigos, para ficar mais próximo
                return;
            }

            // Random.value é um valor aleatório entre 0.0f e 1.0f
            // Se ele for maior que o enemyFireRate, o inimigo irá atirar
            if(Random.value > enemyFireRate)    Instantiate(enemyShot, enemy.position, enemy.rotation);
        }

        // Só um inimigo vivo, vamos aumentar a velocidade
        if(enemyHolder.childCount == 1)
        {
            CancelInvoke(); // Cancela o comportamento dos inimigos até agora
            InvokeRepeating("MoveEnemies", 0.1f, 0.25f);    // Inicia um novo comportamento, que é repetido mais rápido
        }

        // Quando não tem mais nenhum inimigo, o jogador ganhou!
        if(enemyHolder.childCount == 0)
        {
            GameOverController.playerWon = true;
            GameOverController.isGameOver = true;
        }
    }
}
