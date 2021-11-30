using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TARGET : MonoBehaviour
{
    private float timeDestroy = 2f;
    private GameManager gameManagerScript;

    [SerializeField] private int points;
    public ParticleSystem explosionParticle;

    private void Start()
    {
        //DESTRUYE EL OBJETO TRAS (2s)
        Destroy(gameObject, timeDestroy);

        gameManagerScript = FindObjectOfType<GameManager>();
    }

    private void OnMouseDown()
    {
        if (gameObject.CompareTag("GOOD"))
        {
            
        }
        
        else if (gameObject.CompareTag("Bad"))
        {
            Destroy(gameObject);

            gameManagerScript.missCounter += 1;
            if (gameManagerScript.missCounter > gameManagerScript.totalMisses)
            {
                gameManagerScript.gameOver = true;

            }
            //RESTAR PUNTS
            //QUITAR VIDAS
            //MUSIQUITA DE GAMEOVER O MAL HECHO
            //SISTEMA DE PARTICULAS
        }

        if (!gameManagerScript.gameOver)
        {
            //DAR PUNTOS
            gameManagerScript.UpdateScore(points);

        }
        Destroy(gameObject);

        Instantiate(explosionParticle, transform.position,
            explosionParticle.transform.rotation);
    }

    private void OnDestroy()
    {
        gameManagerScript.targetPositions.Remove(transform.position);

    }

    public void GameOver()
    {
        gameOver = true;
        gameOverText.gameObject.SetActive(true);

    }

}
