using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] inimigos;

    public int inimigosPorOnda = 5;

    public float intervaloSpawn = 2f;
    public float intervaloOndas = 5f;

    public float limiteX = 7f;
    public float posicaoY = 6f;

    void Start()
    {
        StartCoroutine(SpawnarOndas());
    }

    IEnumerator SpawnarOndas()
    {
        while (true)
        {
            Debug.Log("INICIANDO NOVA ONDA!");

            for (int i = 0; i < inimigosPorOnda; i++)
            {
                SpawnarInimigo();

                yield return new WaitForSeconds(intervaloSpawn);
            }

            Debug.Log("ONDA FINALIZADA!");

            yield return new WaitForSeconds(intervaloOndas);
        }
    }

    void SpawnarInimigo()
    {
        if (inimigos == null || inimigos.Length == 0)
        {
            Debug.LogWarning("Nenhum inimigo foi configurado!");
            return;
        }

        GameObject inimigo = inimigos[Random.Range(0, inimigos.Length)];

        if (inimigo == null)
        {
            Debug.LogWarning("Existe um prefab vazio na lista!");
            return;
        }

        float posicaoX = Random.Range(-limiteX, limiteX);

        Vector3 posicao = new Vector3(posicaoX, posicaoY, 0);

        Instantiate(inimigo, posicao, Quaternion.identity);
    }
}
