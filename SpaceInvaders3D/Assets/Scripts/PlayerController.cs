using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform player;   // Componente que possui a posição do objeto Player
    public float speed; // Velocidade de movimentação do Player
    public float maxBound, minBound;    // Limite máximo e mínimo de movimentação do Player

    public GameObject shot;
    public float fireRate;
    private float fireCooldown = 0f;

    void Start()
    {
        // Pegamos a referência do componente Transform para manter na variável privada
        player = GetComponent<Transform>();
    }

    // Usamos FixedUpdate porque estamos trabalhando com física
    void FixedUpdate()
    {
        // Pega o input horizontal do teclado/controle e guarda numa varíavel float
        float h = Input.GetAxis("Horizontal");

        // Caso o player atinja seus limites, zere o input, ele irá parar
        if(player.position.x < minBound && h < 0)   h = 0;
        else if (player.position.x > maxBound && h > 0) h = 0;

        // Por fim, atualiza a posição do Player
        player.position += Vector3.right * h * speed;
    }

    void Update()
    {
        if(Input.GetButton("Fire1") && fireCooldown > fireRate)
        {
            fireCooldown = 0f;
            Instantiate(shot, player.position, player.rotation);
        }
        else
        {
            fireCooldown += Time.deltaTime;
        }
    }
}
