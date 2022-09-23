using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState {spawning, waiting, counting }

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public float timeBetweenWaves = 5f;
    public float waveCountDown;

    private float searchCountDown = 1;

    private SpawnState state = SpawnState.counting;


     void Start()
    {
        waveCountDown = timeBetweenWaves;
    }

     void Update()
    { 

        if (state == SpawnState.waiting)
        {
            if (!enemyIsAlive())
            {
                // Begin a new round
                Debug.Log("Wave completed.");
                return;

            } else
            {
                return;
            }
        }

        if (waveCountDown <= 0)
        {
            if (state != SpawnState.spawning)
            {
                // Start spawning wave
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        } 
        else
        {
            waveCountDown -= Time.deltaTime;
        }

        bool enemyIsAlive()
        {
            searchCountDown -= Time.deltaTime;

            if (searchCountDown <= 0f) 
            {
                searchCountDown = 1f;

                if (GameObject.FindGameObjectWithTag("Enemy") == null)
                {
                    return false;
                }
            }

            return true;
        }

        IEnumerator SpawnWave (Wave _wave)

    {
            Debug.Log("Spawning wave " + _wave.name);

            state = SpawnState.spawning;

            for(int i = 0; i < _wave.count;i++)
            {
                SpawnEnemy(_wave.enemy);
                yield return new WaitForSeconds(1f / _wave.rate);
            }

            state = SpawnState.waiting;

            yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Debug.Log("Spawning enemy " + _enemy.name);
        Instantiate(_enemy, transform.position, transform.rotation);
    }
}
}
