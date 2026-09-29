
using UnityEngine;

public class inimigoA : MonoBehaviour
{
    public float velocidade = 2f;
    void Start()
    {
    

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * velocidade * Time.deltaTime);

    }
}