using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Spawn_Manager : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject[] _powerups;

    private float _topLimit = 6.5f;
    private float _sideLimit = 7.75f;

	private void Start()
    {
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnPowerup());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            var randomX = Random.Range(-_sideLimit, _sideLimit);
            Instantiate(_enemy, new Vector3(randomX, _topLimit, 0), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(1, 2));
        }
    }

    private IEnumerator SpawnPowerup()
    {
        while (true)
        {
            var randomX = Random.Range(-_sideLimit, _sideLimit);
            Instantiate(_powerups[Random.Range(0, 3)], new Vector3(randomX, _topLimit, 0), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(5, 10));
        }
    }
}
