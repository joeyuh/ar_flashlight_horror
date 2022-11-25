using TMPro;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    public GameObject player;
    public GameObject battery;
    public TextMeshProUGUI hintBox;
    public bool disabled = false;
    public float pickupRange;

    private FlashlightCode _flashlightCode;

    // Start is called before the first frame update
    void Start()
    {
        _flashlightCode = player.GetComponent<FlashlightCode>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, battery.transform.position);

        if (!disabled && distance < pickupRange)
        {
            _flashlightCode.inRange = true;
            hintBox.text = "Press E to pickup the battery.";
            if (Input.GetKeyDown(KeyCode.E))
            {
                _flashlightCode.TimeRemaining = _flashlightCode.maxTime;
                disabled = true;
            }
        }

        if (!_flashlightCode.inRange)
        {
            hintBox.text = "";
        }

        _flashlightCode.inRange = false;
    }
}