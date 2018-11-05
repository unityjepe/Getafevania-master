﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mosca : MonoBehaviour {
    bool haciaDerecha = true;
    public Transform limiteDerecho;
    public Transform limiteIzquierdo;
    // Use this for initialization
    void Start () {
        transform.position = limiteDerecho.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (haciaDerecha == true) {
            transform.Translate(Vector2.right * Time.deltaTime);
            if (transform.position.x > limiteDerecho.position.x) {
                haciaDerecha = false;
                CambiarOrientacion();
            }
        } else {
            transform.Translate(Vector2.left * Time.deltaTime);
            if (transform.position.x < limiteIzquierdo.position.x) {
                haciaDerecha = true;
                CambiarOrientacion();
            }
        }
	}
    void CambiarOrientacion() {
        if (haciaDerecha) {
            transform.localScale = new Vector2(-1, 1);
        } else {
            transform.localScale = new Vector2(1, 1);
        }
        
    }
}
