using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueJogador : MonoBehaviour
{
    [SerializeField]
    private Transform pontoAtaque;

    [SerializeField]
    private float raioAtaque;

    [SerializeField]
    private LayerMask layersAtaque;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Atacar();
        }
    }

    private void OnDrawGizmos()
    {
        if (this.pontoAtaque != null)
        {
            Gizmos.DrawWireSphere(this.pontoAtaque.position, this.raioAtaque);
        }
    }

    private void Atacar()
    {
        Collider2D colliderInimigo = Physics2D.OverlapCircle(this.pontoAtaque.position, this.raioAtaque, this.layersAtaque);
        if (colliderInimigo != null)
        {
            Debug.Log("Atacando objeto" + colliderInimigo.name);

            // Causar um dano no inimigo
            Inimigo inimigo = colliderInimigo.GetComponent<Inimigo>();
            if (inimigo != null)
            {
                inimigo.ReceberDano();
            }
        }
    }
}
