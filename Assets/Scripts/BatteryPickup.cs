using TMPro;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    public GameObject player;
    public GameObject battery;
    public bool disabled = false;
    public float pickupRange;

    private FlashlightCode _flashlightCode;
    private bool _counted;

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
            if (!_counted)
            {
                _flashlightCode.inRangeCount++;
                _counted = true;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                _flashlightCode.TimeRemaining = _flashlightCode.maxTime;
                disabled = true;
            }
        }
        else
        {
            if (_counted)
            {
                _flashlightCode.inRangeCount--;
                _counted = false;
            }
        }
    }
}