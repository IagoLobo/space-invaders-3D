using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Transform bullet;   // Componente que possui a posição do objeto Bullet
    public float speed; // Velocidade da bala

    void Start()
    {
        // Pegamos a referência do componente Transform para manter na variável privada
        bullet = GetComponent<Transform>();
    }

    // Usamos FixedUpdate porque estamos trabalhando com física
    void FixedUpdate()
    {
        // Atualizamos a posição da bala
        bullet.position += Vector3.up * speed;

        // Se a bala sair da tela e não atingir nenhum inimigo, ela deve ser deletada
        // para evitar problemas de processamento, senão ela continua infinitamente
        if(bullet.position.y >= 12) Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        // Caso a bala entre em contato com o inimigo, é pra matá-lo
        if(other.tag == "Enemy")
        {
            Destroy(this.gameObject);   // Destrói essa bala que bateu no inimigo
        }
        // Caso a bala entre em contato com a sua base, destrua a bala apenas
        else if(other.tag == "Base")
        {
            Destroy(this.gameObject);   // Destrói essa bala que bateu na base
        }
    }
}
