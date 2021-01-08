using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishBehaviour : MonoBehaviour
{
    public GameBehaviour GameManager;

    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameBehaviour>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        // Récupération de la potion par le joueur
        if (collision.gameObject.name == "Player")
        {
            // Destruction de l'objet parent
            GameManager.Finish() ;
        }
    }
}
