using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject winningBlock;
    public float maxDarkTime;
    public float pickupRange;
    public TextMeshProUGUI hintBox;

    private FlashlightCode _flashlightCode;
    private float _darkTime;
    private bool _gameOver = false;
    private bool _gameWin = false;

    // Start is called before the first frame update
    void Start()
    {
        _flashlightCode = player.GetComponent<FlashlightCode>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameOver)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Scene thisScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(thisScene.name);
            }
        }

        if (_gameWin)
        {
            
        }
        if (!_flashlightCode.ON.activeSelf)
        {
            _darkTime += Time.deltaTime;
        }
        else
        {
            _darkTime = 0f;
        }

        if (_darkTime > maxDarkTime)
        {
            _gameOver = true;
            hintBox.text = "Game Over\nPress E to Restart";
            player.SetActive(false);
        }
        
        float distance = Vector3.Distance(player.transform.position, winningBlock.transform.position);
        if (winningBlock.activeSelf && distance < pickupRange)
        {
            _gameWin = true;
            hintBox.text = "You Win";
            player.SetActive(false);
        }

    }
}