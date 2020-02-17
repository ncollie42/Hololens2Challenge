using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class alarm : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform player;
    public float triggerRadious = .4f;
    [SerializeField] LayerMask camMask;
    [SerializeField] GameObject fill;
    RectTransform rect;
    Image image;
    float width = 0;
    [SerializeField] float fillSpeed = 25;
    [SerializeField] main game;

    void Start()
    {
        rect = fill.GetComponent<RectTransform>();
        image = fill.GetComponent<Image>();
    }
    bool running = true;
    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            bool Touched = Physics.CheckSphere(player.transform.position, triggerRadious, camMask);
            if (Touched)
            {
                width += Time.deltaTime * fillSpeed;
                byte color = System.Convert.ToByte(width * 2.50);
                Color32 tmp = new Color32(255, color, color, 255);
                image.color = tmp;
                rect.sizeDelta = new Vector2(width, 100);
                if (width >= 75 && main.curentState == main.gameSate.running)
                    game.panicMode();
            }
            else
            {
                if (width <= 0)
                    width = 0;
                else
                {
                    width -= Time.deltaTime * (fillSpeed / 16);
                    rect.sizeDelta = new Vector2(width, 100);
                    if (width <= 75 && main.curentState == main.gameSate.panic)
                        game.normalMode();
                }

            }
            if (width >= 100)
            {
                game.gameLost();
                running = false;
            }

        }
        


    }
}