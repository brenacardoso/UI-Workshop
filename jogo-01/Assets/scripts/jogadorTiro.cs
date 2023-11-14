using UnityEngine;

public class JogadorTiro : MonoBehaviour
{

    private Rigidbody2D rigidBody;

    [Header("Movimentação")]
    public float velocidadeDoJogador;
    
    [Header("Pulo")]
    public bool jogadorEstaTocandoNoChao;
    public float alturaDoPulo;
    public float tamanhoDoVerificadorDeChao;
    public Transform verificadorDeChao;
    public LayerMask camadaDoChao;

    [Header("Tiro")]
    public Transform arcoEFecha;
    public GameObject objFlecha;
    public float forcaDaFlecha;
    
    public float quantidadeDeFlecha;
    
    void Awake() {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        MovimentarJogador();
        PuloDoJogador();
        FlechadaDoJogador();
    }


    private void FlechadaDoJogador() {
        if(Input.GetButtonDown("Fire1")) {


            if(quantidadeDeFlecha > 0) {
                 // Cria o elemento
                GameObject flechaTemporaria = Instantiate(objFlecha);
                // Posição inicial
                flechaTemporaria.transform.position = arcoEFecha.position;

                quantidadeDeFlecha = quantidadeDeFlecha - 1;

                // Adiciono a força da flecha
                Rigidbody2D flechaTemporariaRigidbody = flechaTemporaria.GetComponent<Rigidbody2D>();
                flechaTemporariaRigidbody.velocity = new Vector2(forcaDaFlecha, 0);

                Destroy(flechaTemporaria.gameObject, 3f);

                
            }
           
        }
    }

    private void PuloDoJogador() {

        jogadorEstaTocandoNoChao = Physics2D.OverlapCircle(verificadorDeChao.position, tamanhoDoVerificadorDeChao, camadaDoChao);


        if(Input.GetButtonDown("Jump")) {
            if(jogadorEstaTocandoNoChao == true) {
                rigidBody.AddForce(new Vector2(0f, alturaDoPulo), ForceMode2D.Impulse);
            }
        }
    }

    private void MovimentarJogador() {
        /*
         1. Float: 1.3 4.5
         2. Boolean: true ou false
         3. Number: Numero inteiro: 1,2,3,5
         4. String: Texto
        */
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float eixoX = movimentoHorizontal * velocidadeDoJogador;

        float eixoY = rigidBody.velocity.y;

        rigidBody.velocity = new Vector2(eixoX, eixoY);

        if(movimentoHorizontal > 0) {
            // Jogador para a direito
            transform.localScale = new Vector3(1f, 1f, 1f);

        } else if(movimentoHorizontal < 0){
            // jogador para esquerda
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
