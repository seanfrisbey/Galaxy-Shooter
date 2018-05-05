using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private void Start()
    {
        _speed = 25;
    }

    private void Update()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
        if (transform.position.y >= 5.4)
        {
            Destroy(gameObject);
        }
	}
}
