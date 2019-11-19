using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int HP;  // Vida do inimigo

    void OnTriggerEnter(Collider other)
    {
        // Se for atingido por uma bala do player, deve tirar parte da sua vida
        if(other.tag == "Bullet")
        {
            this.HP--;  // Diminui a vida
            if(this.HP <= 0)    Destroy(this.gameObject);   // Se sua vida atual for zero, destruir inimigo
        }
        // Caso o inimigo encoste na base, deve destruí-la
        else if(other.tag == "Base")
        {
            Destroy(other.gameObject);  // Destrói a base
        }
    }
}
