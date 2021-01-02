using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    [SerializeField]
    private int dotCount = 10;
    [SerializeField]
    private float dotSpacing = 0.1f;
    [SerializeField]
    private Color ignoreColor = Color.red;
    [SerializeField]
    private Color validateColor = Color.white;
    [SerializeField]
    private GameObject dotsParent = null;
    private float timeStamp;
    private Transform[] dots;
    private Vector2 dotPos;

    public GameObject dotPrefab;

    private void Start()
    {
        PrepareDots();
        Hide();
    }

    void PrepareDots()
    {
        dots = new Transform[dotCount];
        for (int i = 0; i < dotCount; i++)
        {
            dots[i] = Instantiate(dotPrefab, null).transform;
            dots[i].transform.parent = dotsParent.transform;
        }
    }
    public void UpdateDots(Vector3 ballPos, Vector2 force, bool ignore)
    {
        SpriteRenderer[] spriteRenderers = dotsParent.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer spriteRenderer in spriteRenderers)
        {
            if (ignore)
                spriteRenderer.color = ignoreColor;
            else
                spriteRenderer.color = validateColor;
        }

        timeStamp = dotSpacing;
        for (int i = 0; i < dotCount; i++)
        {
            dotPos.x = (ballPos.x + force.x * timeStamp);
            dotPos.y = (ballPos.y + force.y * timeStamp) - (Physics2D.gravity.magnitude * timeStamp * timeStamp * Consts.gravityScale) / 2f;
            if (i != 0 && dotPos.y <= dots[i - 1].position.y)
                dotPos = dots[i - 1].position;
            dots[i].position = dotPos;
            timeStamp += dotSpacing;
        }
    }

    public void Show()
    {
        dotsParent.SetActive(true);
    }

    public void Hide()
    {
        dotsParent.SetActive(false);
    }
}
