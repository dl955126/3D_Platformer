using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //on collision game over
    private void OnTriggerEnter(Collider collision)
    {
        gameManager.GameOver();
    }
}
