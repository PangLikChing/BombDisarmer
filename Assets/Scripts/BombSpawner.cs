using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] GameObject bomb;
    [SerializeField] public GameObject[] bombs;
    [SerializeField] float spawnRate = 30.0f;
    public int[] isSpawn = new int[9];
    public int bombCount = 0;
    public Vector3[] originalPosition = new Vector3[9];
    WaitForSeconds spawnDelay;

    private void Awake()
    {
        //Initalize spawnDelay
        spawnDelay = new WaitForSeconds(spawnRate);
        for (int i = 0; i < 9; i++)
        {
            originalPosition[i] = bombs[i].transform.position;
        }
    }

    IEnumerator Start()
    {
        //Spwaning
        while (true)
        {
            if (bombCount < 9)
            {
                bombSpawn();
            }
            yield return spawnDelay;
        }
    }

    void bombSpawn()
    {
        int randomize = Random.Range(0, 9);
        if (isSpawn[randomize] == 0)
        {
            //bombs[randomize].GetComponent<Bomb>().originalPosition = bombs[randomize].transform.position;
            bombs[randomize].transform.position += new Vector3 (Random.Range(-3.0f, 4.0f), 0, Random.Range(-3.0f, 4.0f));
            bombs[randomize].SetActive(true);
            isSpawn[randomize] = 1;
            bombCount += 1;
        }
        else
        {
            bombSpawn();
        }
    }
}
