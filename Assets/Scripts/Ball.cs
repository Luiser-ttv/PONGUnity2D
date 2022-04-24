using UnityEngine;
using System.Collections;
using TMPro;

public class Ball : MonoBehaviour {
    public float speed = 30;

    public TMP_Text WinText;

    public TMP_Text RestartText;

    private bool stopBall = false;

    void Start() {
        //Velocidad de inicio.
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    void FixedUpdate()
    {
        if (Input.GetKey("space") && stopBall)
        {
            gameObject.transform.position = new Vector2(-3, 0);
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            WinText.text = "";
            RestartText.text = "";
            stopBall = false;

        }
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                    float racketHeight) {
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    void OnCollisionEnter2D(Collision2D col) {
        //El caso en el que golpea la raqueta de la izquierda
        if (col.gameObject.name == "RacketLeft") {
            //Calcula el hit factor
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);

            //Calcula la dirección de la pelota
            Vector2 dir = new Vector2(1, y).normalized;

            //Aplica la velocidad con las variables dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        //El caso en el que golpea la raqueta derecha
        if (col.gameObject.name == "RacketRight") {
            //Calcula la dirección de la pelota
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);

            //Calcula la dirección de la pelota
            Vector2 dir = new Vector2(-1, y).normalized;

            //Aplica la velocidad con las variables dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        //El caso en el que golpea el muro derecho
        if (col.gameObject.name == "WallRight")
        {
            stopBall = true;
            if (WinText.text == "")
            {
                WinText.text = "LEFT PLAYER WIN";
                RestartText.text = "PRESS SPACE TO RESTART";
            }
            
            gameObject.GetComponent<SpriteRenderer>().enabled = false;

        }
        //El caso en el que golpea el muro izquierdo
        if (col.gameObject.name == "WallLeft")
        {
            stopBall = true;
            if (WinText.text == "")
            {
                WinText.text = "RIGHT PLAYER WIN";
                RestartText.text = "PRESS SPACE TO RESTART";
            }    
            gameObject.GetComponent<SpriteRenderer>().enabled = false;

        }


    }


    
}
