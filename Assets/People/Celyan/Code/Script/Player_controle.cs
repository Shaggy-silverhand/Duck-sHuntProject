using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controle : MonoBehaviour

//definition des champ de regalge de la vitesse
{
    [SerializeField] float mouvement_speed = 0.10f;
    [SerializeField] float jump_speed = 10f;
    [SerializeField] float dash_speed = 4f;
    [SerializeField] float dash_duration = 1f;
    [SerializeField] float couldown = 10f;
    [SerializeField] Animator Animator_player;
    [SerializeField] SpriteRenderer sprite_renderer;
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] private ParticleSystem Particle_VFX;
    [SerializeField] bool Freeze = false;

    bool dashUp = true;
    bool isGrounded;
    float vitesseInit;



    // ***************************************************************************************** \\
    // START
    // ***************************************************************************************** \\
    void Start() {

        //stoquage de la vitesse initial pour le dash
        mouvement_speed = (mouvement_speed * Time.deltaTime);
        vitesseInit = mouvement_speed;

    }


    // ***************************************************************************************** \\
    // UPDATE
    // ***************************************************************************************** \\
    void Update() {

        // Détection des entrées utilisateur et application des commandes associer
        if (!Freeze) {
            player_mouvement();
        }

    }

    // ***************************************************************************************** \\
    // Cinematic setting
    // ***************************************************************************************** \\

    public void FreezOn() { Freeze = true; }

    public void FreezOff() { Freeze = false; }

    // ***************************************************************************************** \\
    // Ground détection
    // ***************************************************************************************** \\

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("World") || other.gameObject.CompareTag("Platforme")) {
            isGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("World") || other.gameObject.CompareTag("Platforme")) {
            isGrounded = false;
        }
    }

    // ***************************************************************************************** \\
    // fonction d'action 
    // ***************************************************************************************** \\
    void go_left() {
        //Transform
        transform.Translate(-mouvement_speed, 0, 0, Space.World);
        //BoxCollider2D
        this.GetComponent<BoxCollider2D>().offset = new Vector2(0.08f, -0.07f);
    }

    void go_right() {
        //Transform
        transform.Translate(mouvement_speed, 0, 0, Space.World);
        //BoxCollider2D
        this.GetComponent<BoxCollider2D>().offset = new Vector2(-0.08f, -0.07f);
    }

    void go_attack(){

        StartCoroutine(Fonction_Attack());
        mouvement_speed = 0;
    }

    void go_slide(bool set) {

        if (set)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {

                this.GetComponent<BoxCollider2D>().offset = new Vector2(0.08f, -0.19f);
            }
            else
            {

                this.GetComponent<BoxCollider2D>().offset = new Vector2(-0.08f, -0.19f);
            }

            this.GetComponent<BoxCollider2D>().size = new Vector2(0.45f, 0.3f);
        }
        else {
            this.GetComponent<BoxCollider2D>().size = new Vector2(0.30f, 0.52f);
        }

    }

    void go_dash() {
        StartCoroutine(Fonction_Dash());
    }
    void go_jump() {
        if (isGrounded) {
            rigidbody.velocity = Vector2.up * jump_speed;
        }
        

    }

    // ***************************************************************************************** \\
    // fonction d'animation 
    // ***************************************************************************************** \\
    void animate_left() {
        //animation
        Animator_player.SetBool("Bool_Run", true);
        sprite_renderer.flipX = true;
        //fx-particle
        Particle_VFX.Play();
        Particle_VFX.transform.eulerAngles = new Vector3(0, 90, 0);
    }
    void animate_right() {
        //animation
        Animator_player.SetBool("Bool_Run", true);
        sprite_renderer.flipX = false;
        //fx-particle
        Particle_VFX.Play();
        Particle_VFX.transform.eulerAngles = new Vector3(0, -90, 0);
    }

    void animate_run_stop() {
        Animator_player.SetBool("Bool_Run", false);

        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)) {
            Particle_VFX.Pause();
            Particle_VFX.Clear();
        }
    }
    void animate_attaque (bool set) {
        //animation
        Animator_player.SetBool("Bool_Attack", set);
    }
    void animate_slide(bool set) {
        //animation
        Animator_player.SetBool("Bool_Slide", set);
    }

    void animate_dash(bool set) {
        //animation
        Animator_player.SetBool("Bool_Dash", set);
    }
    void animate_jump(bool set) {
        //animation
        Animator_player.SetBool("Bool_Jump", set);
    }


    // ***************************************************************************************** \\
    // fonction d'appelle 
    // ***************************************************************************************** \\
    void player_mouvement() {

        //run
        if (Input.GetKey(KeyCode.LeftArrow)) {

            go_left();
            animate_left();
        }
        else if (Input.GetKey(KeyCode.RightArrow)) {

            go_right();
            animate_right();
        }

        //jump
        if (Input.GetKey(KeyCode.UpArrow)) {

            go_jump();
            animate_jump(true);
        };

        //runStop
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)) {

            animate_run_stop(); 
        }

        //attaque
        if (Input.GetKey(KeyCode.Keypad1)) {

            go_attack();
            animate_attaque(true);
            
        } 
        else if (Input.GetKeyUp(KeyCode.Keypad1)) {

            animate_attaque(false);        
        };

        //slide
        if (Input.GetKey(KeyCode.Keypad2)) {

            go_slide(true);
            animate_slide(true);
        }
        else if (Input.GetKeyUp(KeyCode.Keypad2)) {

            go_slide(false);
            animate_slide(false);
        };

        //dash
        if (Input.GetKeyDown(KeyCode.Keypad3) && dashUp) {

            go_dash();
            animate_dash(true);
        }
        else if (Input.GetKeyUp(KeyCode.Keypad3)) {

            animate_dash(false);
        };

    }

    // ************** Dash ************** \\

    IEnumerator Fonction_Dash() {

        dashUp = false;
        Debug.Log("dash actif");

        //multiplication de la vitesse
        mouvement_speed = mouvement_speed * dash_speed;

        Debug.Log("Vitesse multiplier");

        // pause/durée
        yield return new WaitForSeconds(dash_duration);

        Debug.Log("Vitesse retablie");

        //Retablisement de la vitesse enregistréeé
        mouvement_speed = vitesseInit;

        //couldown
        yield return new WaitForSeconds(couldown);
        dashUp = true;

        Debug.Log("couldown terminer");
    }

    // ************** Attaque ************** \\
    IEnumerator Fonction_Attack () {

        mouvement_speed = 0;
        yield return new WaitForSeconds(1.05f);
        mouvement_speed = vitesseInit;
    }



}
