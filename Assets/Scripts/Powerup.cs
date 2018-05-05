using System.Diagnostics.Eventing.Reader;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] private float _speed = 3;
    [SerializeField] private int powerupId;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player") return;

        var player = other.GetComponent<Player>();
        if (player != null)
        {
            switch (powerupId)
            {
                case 0:
                    player.TripleShotPowerup();
                    break;
                case 1:
                    player.SpeedPowerup();
                    break;
                case 2:
                    break;
            }
        }

        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y <= -5.7)
        {
            Destroy(gameObject);
        }
	}
}
