using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject winningBlock;
    public float maxDarkTime;
    public float pickupRange;
    public TextMeshProUGUI hintBox;
    public int maxSceneCount;

    private FlashlightCode _flashlightCode;
    private float _darkTime;
    private bool _gameOver = false;
    private bool _gameWin = false;

    public bool GameOver => _gameOver;
    public bool GameWin => _gameWin;

    private Scene _thisScene;
    private int _sceneNumber;

    // Start is called before the first frame update
    void Start()
    {
        _thisScene = SceneManager.GetActiveScene();
        _flashlightCode = player.GetComponent<FlashlightCode>();
        _sceneNumber = Int32.Parse(_thisScene.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameOver)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(_thisScene.name);
            }
        }

        if (_gameWin)
        {
            if (_sceneNumber + 1 <= maxSceneCount)
            {
                hintBox.text = "You Win\nPress E to Load Next Level";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SceneManager.LoadScene((_sceneNumber + 1).ToString());
                }
            }
        }

        if (!_flashlightCode.ON.activeSelf)
        {
            _darkTime += Time.deltaTime;
        }
        else
        {
            _darkTime = 0f;
        }

        if (!_gameOver && _darkTime > maxDarkTime)
        {
            _gameOver = true;
            hintBox.text = "Game Over\nPress E to Restart";
            player.SetActive(false);
        }

        float distance = Vector3.Distance(player.transform.position, winningBlock.transform.position);
        if (!_gameWin && winningBlock.activeSelf && distance < pickupRange)
        {
            _gameWin = true;
            hintBox.text = "You Win";
            player.SetActive(false);
        }
    }
}