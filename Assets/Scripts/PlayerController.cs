using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    [Range(10,30)]
    public float speed = 10.0f;
    public float xRange = 10.0f;
    public GameObject projectilePrefab;

    public int contBar = 6;
    public int i = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while(i <= 504){
            Debug.Log(i);
            i++;
        }

        AtivateProjectile();
        LimitAreaPlayer();
        MovePlayer();

    }

    private void AtivateProjectile()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //instanciar uma cópia do objeto na tela
            //Objeto, Posição (referenciando a posicao do player), Rotação
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }

    private void MovePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
    }

    private void LimitAreaPlayer()
    {
        //Condição para limitar a posição do objeto
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }
}
