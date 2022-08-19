using UnityEngine;

public class playermovement : MonoBehaviour
{
    Rigidbody2D rgb;
    Vector3 velocity;
    public Animator animator;

    float speedAmount = 5f;
    float jumpAmount = 5f;

    public oyunkontrol oyunK;

    public AudioSource JumpSoundEffect;
    public AudioSource ChristalSoundEffect;
    public AudioSource GameoverSoundEffect;
    public AudioSource NextLevelSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (oyunK.oyunAktif)
        {

        velocity= new Vector3(Input.GetAxis("Horizontal"),0f);
        transform.position += velocity * speedAmount * Time.deltaTime;
        

        animator.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        

        if (Input.GetButtonDown("Jump") && !animator.GetBool("is.jumping"))
        {
            rgb.AddForce(Vector3.up * jumpAmount, ForceMode2D.Impulse);
            animator.SetBool("is.jumping", true);
            JumpSoundEffect.Play();
        }

        if(animator.GetBool("is.jumping") && Mathf.Approximately(rgb.velocity.y, 0))
        {
            animator.SetBool("is.jumping", false);
        }


        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

        else if(Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        }

    }
    void OnCollisionEnter2D(Collision2D cls)
    {
        string Tagİsmi = cls.gameObject.tag;

        if (Tagİsmi.Equals("Kristal"))
        {
            oyunK.KristalSayisiKontrol();
            Destroy(cls.gameObject);
            ChristalSoundEffect.Play();
        }
        else if (Tagİsmi.Equals("Diken"))
        {
            oyunK.oyunAktif = false;
            GameoverSoundEffect.Play();
            animator.SetTrigger("death");
    
           
        }
        if (cls.gameObject.tag.Equals("Zemin"))
        {
            animator.SetBool("is.jumping", false);
        }

        if (cls.gameObject.tag.Equals("level"))
        {

            NextLevelSoundEffect.Play();
        }

            
            


    }

    void OnCollisionExit2D(Collision2D cls)
    {
        if (cls.gameObject.tag.Equals("Zemin"))
        {
            animator.SetBool("is.jumping", true);
        }

    }
}
