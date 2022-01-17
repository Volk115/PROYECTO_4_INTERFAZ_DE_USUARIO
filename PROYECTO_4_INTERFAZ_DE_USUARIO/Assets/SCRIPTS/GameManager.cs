using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameOver;
    public GameObject[] targetPrefabs;
    public Vector3 randomSpawnPos;
    public List<Vector3> targetPositions;
    //public GameObect 

    private float minX = -3.75f;
    private float minY = -3.75f;
    private float spaceBetweenSquares = 2.5f;
    private int numberRows = 4;
    public int missCounter;
    public int totalMisses;

    //SCORE TEXT
    public TextMeshProUGUI scoreText;
    private int score;
    public GameManager gameOverPanel;

    //CADA DOS SEGUNDOS APARECERA UN OBJETO EN PANTALLA
    private float spawnRate = 0.5f;

    public Vector3 RandomSpawnPosition()
    {
        //GENERA UNA POSIION ALEATORIA EN UNO DE LOS CENTROS DE LOS 16 CUADRADOS
        int randomIntX = Random.Range(0, numberRows);
        int randomIntY = Random.Range(0, numberRows);
        float randomPosX = minX + randomIntX * spaceBetweenSquares;
        float randomPosY = minY + randomIntY * spaceBetweenSquares;

        return new Vector3(randomPosX, randomPosY, 0);
    }

    private IEnumerator SpawnRandomTarget()
    {
        while (!gameOver)
        {
            yield return new WaitForSeconds(spawnRate);

            int randomIndex = Random.Range(0, targetPrefabs.Length);
            randomSpawnPos = RandomSpawnPosition();

            while (targetPositions.Contains(randomSpawnPos))
            {
                randomSpawnPos = RandomSpawnPosition();
            }

            Instantiate(targetPrefabs[randomIndex],
                randomSpawnPos,
                targetPrefabs[randomIndex].transform.rotation);
            targetPositions.Add(randomSpawnPos);
        }
    }

    public void UpdateScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = $"Score: {score}";
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame() 
    {
        //ASI CADA VEZ QUE REINICIEMOS EL JUEGO, EL SCORE SERA DE 0
        score = 0;
        UpdateScore(pointsToAdd: 0);
        missCounter = 0;
        gameOverPanel.SetActive(false);
        StartCoroutine("SpawnRandomTarget");
    }
}
