using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] Transform _enemyPrefab;
    [SerializeField] Transform _spawnPoint;
    [SerializeField] Text _waveCountDownTimerText;

    [SerializeField] float _timeBetweenWaves = 5f;
    [SerializeField] float _countDown = 2f;
    private int _waveNumber = 0;


    void Update()
    {
        if (_countDown <= 0)
        {
           StartCoroutine(SpawnWave());
            _countDown = _timeBetweenWaves;
        }

        _countDown -= Time.deltaTime;
        _waveCountDownTimerText.text=Mathf.Round(_countDown).ToString();

    }

   IEnumerator SpawnWave()
    {
        _waveNumber++;
        for (int i = 0; i < _waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.4f);
        }
    }



    void SpawnEnemy()
    {
        Instantiate(_enemyPrefab,_spawnPoint.position,_spawnPoint.rotation);
    }




}
