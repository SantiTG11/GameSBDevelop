using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class Drag : MonoBehaviour
{
    public Vector3 screenPosition;
    public Vector3 worldPosition;
    SpriteRenderer sprite;
    public bool envioPaquete = false;
    public int estadoEnviado;

    public GameObject[] estado = new GameObject[10];
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            screenPosition = Input.mousePosition;
            screenPosition.z = Camera.main.nearClipPlane + 1;
            worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

            if ((transform.position.x - worldPosition.x < 1 && transform.position.x - worldPosition.x > -1) && (transform.position.y - worldPosition.y < 1 && transform.position.y - worldPosition.y > -1))
            {
                transform.position = worldPosition;
            }
        }
        else
        {
            //Chequeador de Estados
            for(int i = 0; i < 10; i++)
            {
                if (estado[i].transform.position.x - transform.position.x > -0.5 && estado[i].transform.position.x - transform.position.x < 0.5)
                {
                    if (estado[i].transform.position.y - transform.position.y > -0.5 && estado[i].transform.position.y - transform.position.y < 0.5)
                    {

                        sprite.color = new Color(147, 58, 39, 1);
                        envioPaquete = true;
                        estadoEnviado = i;
                        //En lugar de cambiar color, debo de activar un bool, que termine ejecutando un script que haga los cambios en cada estado.
                    }
                }
            }
            //transform.position = new Vector3(9, -3, 1);
        }




    }
}

