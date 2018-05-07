using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _singleLaserPrefab;
    [SerializeField] private GameObject _tripleLaserPrefab;
    [SerializeField] private GameObject _explosionPrefab;
    [SerializeField] private GameObject _shield;

    private float _speed = 5;
    private float _fireRate = 0.25f;
    private float _speedMulitplier = 1;
    private float _verticalPositiveLimit = -1.0f;
    private float _verticalNegativeLimit = -4.1f;
    private float _horizontalLimit = 9.5f;
    private float _lastFireTime;
    private float _lastTripleShotTime;
    private int _lives = 3;
    private bool _canTripleShot;
    private bool _hasShield;
    private UIManager _uiManager;

    private void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);

        _uiManager?.UpdateLives(_lives);
	}
	
	private void Update()
    {
        CaptureMovement();
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && (Time.time - _lastFireTime >= _fireRate)) FireNewLaser();
    }

    private void CaptureMovement()
    {
        var speedMagnitude = _speed * _speedMulitplier;
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * speedMagnitude * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * speedMagnitude * verticalInput * Time.deltaTime);

        if ((transform.position.x > _horizontalLimit))
        {
            transform.position = new Vector3(-_horizontalLimit, transform.position.y, transform.position.z);
        }
        if ((transform.position.x < -_horizontalLimit))
        {
            transform.position = new Vector3(_horizontalLimit, transform.position.y, transform.position.z);
        }

        if ((transform.position.y > _verticalPositiveLimit))
        {
            transform.position = new Vector3(transform.position.x, _verticalPositiveLimit, transform.position.z);
        }
        if ((transform.position.y < _verticalNegativeLimit))
        {
            transform.position = new Vector3(transform.position.x, _verticalNegativeLimit, transform.position.z);
        }
    }

    private void FireNewLaser()
    {
        Instantiate(_canTripleShot ? _tripleLaserPrefab : _singleLaserPrefab, transform.position + new Vector3(0.0f, 0.9f, 0.0f), Quaternion.identity);
        _lastFireTime = Time.time;
    }

    public void Damage()
    {
        if (_hasShield)
        {
            _hasShield = false;
            _shield.SetActive(false);
            return;
        };

        _lives--;
        _uiManager?.UpdateLives(_lives);
        if (_lives >= 1) return;

        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    #region Powerups
    public void TripleShotPowerup()
    {
        _canTripleShot = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    public void SpeedPowerup()
    {
        _speedMulitplier = 2;
        StartCoroutine(SpeedPowerDownRoutine());
    }

    public void ShieldPowerup()
    {
        _hasShield = true;
        _shield.SetActive(true);
    }
    #endregion

    #region Coroutines
    private IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        _canTripleShot = false;
    }

    private IEnumerator SpeedPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        _speedMulitplier = 1;
    }
    #endregion
}
