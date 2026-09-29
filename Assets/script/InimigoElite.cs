using UnityEngine;

public class inimigoElite : MonoBehaviour
{
    public float limiteX = 7f;
    public int vida = 10;
    public bool indoDireita = true;

    public float velocidade = 5f;
    public float velocidadeDescida = 2f;

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

        // Inverte a direção ao atingir os limites
        if (transform.position.x >= limiteX)
        {
            indoDireita = false;
        }

        if (transform.position.x <= -limiteX)
        {
            indoDireita = true;
        }

        // Movimento contínuo para baixo
        transform.position += Vector3.down * velocidadeDescida * Time.deltaTime;
    }

    public void TomarDano()
    {
        vida--;

        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }
}