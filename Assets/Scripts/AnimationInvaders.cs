using UnityEngine;

public class AnimationInvaders : MonoBehaviour
{
    public Sprite[] animationSprites; // Array to keep the sprites

    public float animationTime = 0.6f; // circle to the next sprite

    private SpriteRenderer _spriteRenderer; // reference to component

    private int _animationFrame; // animation frame to reference

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(AnimateSprites), this.animationTime, this.animationTime);
    }

    private void AnimateSprites()
    {
        _animationFrame++; // Animation frame increase until 2

        if (_animationFrame >= this.animationSprites.Length) // if animation frame is bigger or equal to 2
        {
            _animationFrame = 0; // set 0
        }

        _spriteRenderer.sprite = animationSprites[_animationFrame]; // spriterenderer get value of array between 1 and 2
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player Bullet")
        {
            // gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
