using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] public static float _speed = 3f;
    private float _oldMousePositionX;
    private float _eulerY;

    public static PlayerMove Instance;

    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _oldMousePositionX = Input.mousePosition.x;
        _speed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0f)
        {
            return;
        }

        Vector3 newPosition = transform.position + transform.forward * Time.deltaTime * _speed;
        newPosition.x = Mathf.Clamp(newPosition.x, -2f, 2f);
        transform.position = newPosition;


        float deltaX = Input.mousePosition.x - _oldMousePositionX;
        _oldMousePositionX = Input.mousePosition.x;

        _eulerY += deltaX;
        _eulerY = Mathf.Clamp(_eulerY, -60, 60);
        transform.eulerAngles = new Vector3(0, _eulerY, 0);
    }

    public void MoveForward(float distance)
    {
        transform.position += transform.forward * distance;
        Time.timeScale = 1f;
    }
}
