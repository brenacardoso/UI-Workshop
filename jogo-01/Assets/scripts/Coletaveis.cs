using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletaveis : MonoBehaviour
{
    public GameObject efeitoDaExplosao;

    void OnTriggerEnter2D(Collider2D outroObjeto)
    {
        // 1. Identificar que o jogador colideu com este objeto
        if(outroObjeto.gameObject.CompareTag("Player")){

            SFXManager.referencia.somDaColeta.Play();
            // 3. Criar o objeto de explosao
            Instantiate(efeitoDaExplosao, transform.position, transform.rotation);
            
            // 2. Coletar o este objeto
            Destroy(this.gameObject);

            // 3. Avisar ao componente player que ele coletou uma fruta
            var componenteJogador = outroObjeto.gameObject.GetComponent<Jogador>();
            componenteJogador.ColetouFruta();
        }
    }
}
