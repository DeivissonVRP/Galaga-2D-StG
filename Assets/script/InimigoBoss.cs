using UnityEngine;
using UnityEngine.UI;

public class InimigoBoss : MonoBehaviour
{
    public int vida = 100;
    public Slider barraVida;

    public float velocidade = 2f;
    public float limiteX = 5f;
    public bool indoDireita = true;

    public GameObject prefabTiro;

    public float intervaloAtaque = 2f;
    private float proximoAtaque;

    private int tipoAtaque = 0;

    void Start()
    {
        if (barraVida != null)
        {
            barraVida.maxValue = vida;
            barraVida.value = vida;
        }
    }

    void Update()
    {
        // Movimento horizontal
        if (indoDireita)
        {
            transform.position += Vector3.right * velocidade * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * velocidade * Time.deltaTime;
        }

        if (transform.position.x >= limiteX)
            indoDireita = false;

        if (transform.position.x <= -limiteX)
            indoDireita = true;

        // Ataques periódicos
        if (Time.time >= proximoAtaque)
        {
            Atacar();
            proximoAtaque = Time.time + intervaloAtaque;
        }
    }

    void Atacar()
    {
        if (prefabTiro == null)
        {
            Debug.LogWarning("Prefab do tiro não foi conectado!");
            return;
        }

        if (tipoAtaque == 0)
        {
            // Ataque central
            Instantiate(prefabTiro, transform.position, Quaternion.identity);
            Debug.Log("Boss: Ataque central!");
        }
        else
        {
            // Ataque triplo
            Instantiate(prefabTiro, transform.position + Vector3.left * 1.5f, Quaternion.identity);
            Instantiate(prefabTiro, transform.position, Quaternion.identity);
            Instantiate(prefabTiro, transform.position + Vector3.right * 1.5f, Quaternion.identity);

            Debug.Log("Boss: Ataque triplo!");
        }

        tipoAtaque = 1 - tipoAtaque;
    }

    public void TomarDano()
    {
        vida--;

        if (barraVida != null)
            barraVida.value = vida;

        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }
}