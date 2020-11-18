using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public int FSalto;
    public int Velo;
    public bool ifPiso = false;
    private AudioSource sonido;
    public AudioClip salto;
    public AudioClip caida;
    // Start is called before the first frame update
    void Start()
    {
        sonido = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && ifPiso)
        {
            sonido.PlayOneShot(salto, 1f);
            ifPiso=false;
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, FSalto));

        }
        this.GetComponent<Rigidbody2D>().velocity=new Vector2(Velo,this.GetComponent<Rigidbody2D>().velocity.y);
    }
    //private void OnTriggerEnter2D(Collider2D col)
    //{
    //    ifPiso = true;
    //    if(col.tag == "Obst")
    //    {
    //        GameObject.Destroy(this.gameObject);
    //    }

    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    ifPiso = true;

    //}
    private void OnCollisionEnter2D(Collision2D c1)
    {
        ifPiso = true;
        sonido.PlayOneShot(caida, 1f);
        if (c1.collider.gameObject.tag == "Obst")
        {
            GameObject.Destroy(this.gameObject);
    }

}
}
