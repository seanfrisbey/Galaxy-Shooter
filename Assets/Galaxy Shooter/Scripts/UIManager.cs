using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _lives;
    [SerializeField] private Sprite[] _livesSprites;
    [SerializeField] private Image _livesImageDisplay;

    public void UpdateLives(int lives)
    {
        _livesImageDisplay.sprite = _livesSprites[lives];
    }

    public void UpdateScore(int score)
    {

    }
}
