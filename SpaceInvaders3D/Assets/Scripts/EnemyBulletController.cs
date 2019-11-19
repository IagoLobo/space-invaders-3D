using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    private Transform enemyBullet;  // Componente que possui a posição do objeto EnemyBullet
    public float speed; // Velocidade da bala do inimigo

    void Start()
    {
        // Pegamos a referência do componente Transform para manter na variável privada
        enemyBullet = GetComponent<Transform>();
    }

    // Usamos FixedUpdate porque estamos mexendo com física
    void FixedUpdate()
    {
        enemyBullet.position += Vector3.up * -speed;    // Movimenta a bala do inimigo

        // Se a bala sair da tela e não atingir nenhuma base ou o player, ela deve ser
        // deletada para evitar problemas de processamento, senão continua infinitamente
        if(enemyBullet.position.y < -12)    Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        // Se colidir com o jogador, é game over
        if(other.tag == "Player")
        {
            GameOverController.isGameOver = true;
            Destroy(other.gameObject);  // Destrói a nave do jogador
            Destroy(this.gameObject);   // Destrói essa bala
        }
        // Se colide com a base, tirar vida da base
        else if(other.tag == "Base")
        {
            // Pega referência da base atingida
            BaseHealth baseHP = other.gameObject.GetComponent<BaseHealth>();
            baseHP.HP--;    // Diminui vida da base
            Destroy(this.gameObject);   // Destrói essa bala
        }
    }
}
