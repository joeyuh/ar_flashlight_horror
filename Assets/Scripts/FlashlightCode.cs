using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FlashlightCode : MonoBehaviour
{
    //Great code, nice
    // Start is called before the first frame update
    public GameObject ON;
    public GameObject OFF;
    public GameObject flashlight;
    public GameObject player;
    public Slider slider;
    public Image sliderColor;
    public bool inRange;
    
    [Header("Max angle")] public int horizontal = 45;
    public int vertical = 15;

    [Header("Max time")] public float maxTime = 60f;

    private float _timeRemaining;
    
    public float TimeRemaining
    {
        // get => _timeRemaining;
        set => _timeRemaining = value;
    }
    

    private bool _isOn;

    private readonly Vector2 _center = new Vector2(Screen.width / 2f, Screen.height / 2f);

    private Vector3 Angle(Vector3 mouse)
    {
        if (mouse.x < 0) mouse.x = 0;
        if (mouse.y < 0) mouse.y = 0;
        if (mouse.x > Screen.width) mouse.x = Screen.width;
        if (mouse.y > Screen.height) mouse.y = Screen.height;
        mouse.x -= _center.x;
        mouse.y -= _center.y;
        mouse.x /= _center.x;
        mouse.y /= _center.y;
        mouse.x *= Mathf.Deg2Rad * horizontal;
        mouse.y *= Mathf.Deg2Rad * vertical;
        Vector3 p = player.transform.eulerAngles;
        return new Vector3(-Mathf.Rad2Deg * Mathf.Sin(mouse.y) + p.x,
            Mathf.Rad2Deg * Mathf.Sin(mouse.x) + p.y, 0);
    }

    void Start()
    {
        _timeRemaining = maxTime;
        ON.SetActive(false);
        OFF.SetActive(true);
        _isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouse = Input.mousePosition;
        flashlight.transform.eulerAngles = Angle(mouse);

        if (_timeRemaining > 0)
        {
            _timeRemaining -= Time.deltaTime;
            slider.value = _timeRemaining / maxTime;
            if (_timeRemaining < maxTime * 0.2f)
            {
                sliderColor.color = Color.red;
            }
        }
        else
        {
            ON.SetActive(false);
            OFF.SetActive(true);
            _isOn = false;
            _timeRemaining = 0;
            slider.value = 0;
            sliderColor.color = Color.black;
            return;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_isOn)
            {
                ON.SetActive(false);
                OFF.SetActive(true);
            }

            if (!_isOn)
            {
                ON.SetActive(true);
                OFF.SetActive(false);
            }

            _isOn = !_isOn;
        }
    }
}