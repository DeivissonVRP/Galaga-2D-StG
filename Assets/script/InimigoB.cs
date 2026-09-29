
using UnityEngine;

public class InimigoB : MonoBehaviour
{
    public float velocidade = 2f;
    public float amplitude = 2f;
   private UnityEngine.Vector3 posicaoInicial;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posicaoInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * velocidade * Time.deltaTime);
        transform.position = new Vector3(posicaoInicial.x + Mathf.Sin(Time.time * velocidade) * amplitude, transform.position.y, transform.position.z);
        
        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }
}
