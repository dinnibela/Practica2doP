using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;

public class Controller : MonoBehaviour
{
    public GameObject Jugador;
    public Camera Camara;
    public GameObject[] BloquePreFab;
    public float puntero;
    public float Generacion = 5;
    public Text TxtJuego;
    public bool perdiste;

    private AudioSource sonido;
    public AudioClip Golpe;
    public AudioSource Musica;
    
    // Start is called before the first frame update
    void Start()
    {
        puntero = -7;
        perdiste = false;
        sonido = GetComponent<AudioSource>();
        Musica.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(Jugador != null)
        {
            Camara.transform.position = new Vector3(Jugador.transform.position.x, Camara.transform.position.y, Camara.transform.position.z);
            TxtJuego.text = "Puntaje: " + Mathf.Floor(Jugador.transform.position.x);
        }
        else
        {
            if(!perdiste)
            {
                perdiste = true;
                TxtJuego.text += " \n PERDISTE \n Presione R para Volver";
                sonido.PlayOneShot(Golpe, 1f);
                Musica.Stop();

            }
            if (perdiste)
            {
                if (Input.GetKeyDown("r"))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
        
        while(Jugador!=null && puntero< Jugador.transform.position.x + Generacion)
        {
            int indiceBloque = Random.Range(0, BloquePreFab.Length - 1);
            if(puntero<0)
            {
                indiceBloque = 5;

            }
            GameObject objetoBloque = Instantiate(BloquePreFab[indiceBloque]);
            objetoBloque.transform.SetParent(this.transform);
            Bloque bloque = objetoBloque.GetComponent<Bloque>();
            objetoBloque.transform.position = new Vector2(puntero + bloque.tamano / 2,0);
            puntero += bloque.tamano;
            
        }
        
    }
}
