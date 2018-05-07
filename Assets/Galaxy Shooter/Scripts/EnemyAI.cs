using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private GameObject _enemyExplosionPrefab;

    private float _bottomLimit = -6.5f;

    private void Start()
	{
		
	}

    private void Update()
	{
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

	    if (!(transform.position.y <= _bottomLimit)) return;

	    Destroy(gameObject);
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Laser":
                Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
                Destroy(other.gameObject);
                Destroy(gameObject);
                break;
            case "Player":
                Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
                var player = other.GetComponent<Player>();
                if (player != null)
                {
                    player.Damage();
                }
                Destroy(gameObject);
                break;
            default:
                Debug.Log($"Unhandled collision: {other.tag}");
                break;
        }
    }
}
