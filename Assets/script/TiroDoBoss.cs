using UnityEngine;

public class TiroBoss : MonoBehaviour
{
    public float velocidade = 5f;

    void Update()
    {
        transform.position += Vector3.down * velocidade * Time.deltaTime;

        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }
}