using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;

    private float _topLimit = 6.5f;
    private float _bottomLimit = -6.5f;
    private float _sideLimit = 7.75f;

    private void Start()
	{
		
	}

    private void Update()
	{
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

	    if (!(transform.position.y <= _bottomLimit)) return;

	    var randomX = Random.Range(_sideLimit, -_sideLimit);
	    transform.position = new Vector3(randomX, _topLimit, 0);


	}
}
