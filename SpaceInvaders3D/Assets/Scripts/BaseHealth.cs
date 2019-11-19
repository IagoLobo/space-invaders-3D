using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    [HideInInspector]
    public int HP = 3;  // Vida da base

    void Update()
    {
        // Se vida for menor ou igual a zero, destruir base
        if(this.HP <= 0)    Destroy(this.gameObject);       
    }
}
