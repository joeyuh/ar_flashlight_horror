using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject winningBlock;
    public float maxDarkTime;
    public float pickupRange;
    public TextMeshProUGUI hintBox;

    public bool disabled = false;
    // Start is called before the first frame update

    private FlashlightCode _flashlightCode;
    private float _darkTime;

    private void GameOver()
    {
        hintBox.text = "Game Over";
        player.SetActive(false);
    }

    private void GameWon()
    {
        hintBox.text = "You Win";
        player.SetActive(false);
    }
    void Start()
    {
        _flashlightCode = player.GetComponent<FlashlightCode>();
    }

    // Update is called once per frame
    void Update()
    {
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
            GameOver();
        }
        
        float distance = Vector3.Distance(player.transform.position, winningBlock.transform.position);
        if (winningBlock.activeSelf && distance < pickupRange)
        {
            GameWon();
        }

    }
}