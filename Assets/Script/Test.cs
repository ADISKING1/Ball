using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    #region Singleton class: Test

    public static Test Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    public Trajectory trajectory;

    public GameObject ballPrefab;
    [SerializeField]
    public float pushForce = 4f;
    [SerializeField]
    public float ignoreDistance;

    public Transform BallSpawnPos;

    private bool isDragging;
    private new Camera camera;

    private Vector2 startPos;
    private Vector2 endPos;
    private Vector2 direction;
    private Vector2 force;
    private float distance;


    private void Start()
    {
        camera = Camera.main;
        isDragging = false;
        setBall(Resources.Load<Sprite>("Sprites/DebugBall"), Consts.currentSpriteColor);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            MenuManager.GoToMenu(MenuName.pause);
        else if (Input.GetMouseButtonDown(1))
            SceneManager.LoadScene(0);
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                isDragging = true;
                OnDragStart();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
                OnDragEnd();
            }
            if (isDragging)
            {
                OnDrag();
            }
        }
    }

    void OnDragStart()
    {
        startPos = camera.ScreenToWorldPoint(Input.mousePosition);

        trajectory.Show();
    }
    void OnDrag()
    {
        endPos = camera.ScreenToWorldPoint(Input.mousePosition);
        distance = Vector2.Distance(startPos, endPos);
        direction = (startPos - endPos).normalized;
        force = direction * distance * pushForce;

        trajectory.UpdateDots(BallSpawnPos.position, force, distance < ignoreDistance);

        Debug.DrawLine(startPos, endPos);
    }
    void OnDragEnd()
    {
        if (distance > ignoreDistance)
        {
            GameObject ball = Instantiate(ballPrefab, BallSpawnPos);
            ball.GetComponent<Ball>().ActivateRB();
            ball.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
        }

        trajectory.Hide();
    }

    public void setBall(Sprite sprite, Color color)
    {
        Consts.currentSprite = sprite;
        Consts.currentSpriteColor = Color.white;
    }
}