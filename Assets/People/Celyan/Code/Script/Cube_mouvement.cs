using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_mouvement : MonoBehaviour

//definition des champ de regalge de la vitesse
{
    [SerializeField] float mouvement_speed = 0.10f;
    float vitesseInit;
    [SerializeField] float jump_speed = 10f;
    [SerializeField] float dash_speed = 4f;
    [SerializeField] float dash_duration = 1f;
    [SerializeField] float couldown = 10f;
    [SerializeField] Animator Animator_player;
    [SerializeField] SpriteRenderer sprite_renderer;
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] private ParticleSystem Particle_VFX;
    bool dashUp = true;


    //fonction de mouvement
    void go_left() {
        transform.Translate(-mouvement_speed, 0, 0, Space.World);
        Animator_player.SetBool("Bool_Run", true);
        sprite_renderer.flipX = true;
        
    }

    void go_right() {
        transform.Translate(mouvement_speed, 0, 0, Space.World);
        Animator_player.SetBool("Bool_Run", true);
        sprite_renderer.flipX = false;
        Particle_VFX.Play();
    }

    void go_attack(){
        Animator_player.SetBool("Bool_Attack", true);
        mouvement_speed = 0;
    }

    void go_slide()
    {
        Animator_player.SetBool("Bool_Slide", true);
    }
    void go_jump() {
        rigidbody.velocity = Vector2.up * jump_speed;
        Animator_player.SetBool("Bool_Jump", true);
    }


    IEnumerator Fonction_Dash() {

        dashUp = false;
        Debug.Log("on est la");

        //multiplication de la vitesse
        mouvement_speed = mouvement_speed * dash_speed;

        Debug.Log("Vitesse appliquer");

        // pause/durée
        yield return new WaitForSeconds(dash_duration);

        Debug.Log("pause");

        //Retablisement de la vitesse enregistréeé
        mouvement_speed = vitesseInit;

        //couldown
        yield return new WaitForSeconds(couldown);
        dashUp = true;

        Debug.Log("couldown");
    }

    IEnumerator Fonction_Attack () {

        mouvement_speed = 0;
        yield return new WaitForSeconds(1.05f);
        mouvement_speed = vitesseInit;
    }


    // Start is called before the first frame update
    void Start() {

        vitesseInit = mouvement_speed;

    }


    // Update is called once per frame
    void Update() {

        // Détection des entrées utilisateur et application des commandes associer
        if (Input.GetKey(KeyCode.LeftArrow)) {
            Particle_VFX.Play();
            Particle_VFX.transform.eulerAngles = new Vector3(0, 90, 0);
            go_left();
            Debug.Log("particule");

        } else if (Input.GetKey(KeyCode.RightArrow)) {
            Particle_VFX.Play();
            Particle_VFX.transform.eulerAngles = new Vector3(0, -90, 0);
            go_right();

        }

        if (Input.GetKeyUp(KeyCode.LeftArrow)) {
            Animator_player.SetBool("Bool_Run", false);
            Particle_VFX.Pause();
            Particle_VFX.Clear();

        } else if (Input.GetKeyUp(KeyCode.RightArrow)) {
            
            Animator_player.SetBool("Bool_Run", false);
            Particle_VFX.Pause();
            Particle_VFX.Clear();

        }

        if (Input.GetKey(KeyCode.UpArrow)) {

            go_jump();

        };

        if (Input.GetKey(KeyCode.Keypad1)) {

            go_attack();
            StartCoroutine(Fonction_Attack());

        } else if (Input.GetKeyUp(KeyCode.Keypad1)) {

            Animator_player.SetBool("Bool_Attack", false);
            
        };

        if (Input.GetKey(KeyCode.Keypad2)) {

            go_slide();

        } else if (Input.GetKeyUp(KeyCode.Keypad2)) {

            Animator_player.SetBool("Bool_Slide", false);

   

        };

        if (Input.GetKeyDown(KeyCode.Keypad3) && dashUp) {

            Debug.Log("3");

            StartCoroutine(Fonction_Dash());

            Animator_player.SetBool("Bool_Dash", true);

        } else if (Input.GetKeyUp(KeyCode.Keypad3)) {

            Animator_player.SetBool("Bool_Dash", false);

        };

    }
}
