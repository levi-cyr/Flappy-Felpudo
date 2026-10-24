using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
    //prefab do inimigo
    public GameObject enemyPrefab;
    //intervalo entre spawns (segundos)
    public float timeBetweenSpawn = 3f;
    //limites de spawn no cenário
    public float limitX = 10f;
    public float limitY = 3.5f;
    //velocidade de movimento dos inimigos
    public float speed = 3f;
    //limite X para destruir o inimigo ao sair da tela
    public float destroyLimitX = -12f;

    void Start()
    {
        //começa a gerar inimigos repetidamente
        InvokeRepeating("EnemySpawner", 0f, timeBetweenSpawn);
    }

    void EnemySpawner()
    {
        //define posição de spawn (à direita da tela)
        float y = Random.Range(-limitY, limitY);
        Vector2 randomPosition = new Vector2(limitX, y);
        
        //instancia o inimigo
        GameObject enemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
        //inicia o movimento automático (corrotina)
        StartCoroutine(MoveEnemy(enemy));
    }

    public void CancelEnemySpawner() // faz o inimigo parar de spawnar
    {
        CancelInvoke("EnemySpawner"); 
        StopCoroutine("MoveEnemy"); 
    }
    IEnumerator MoveEnemy(GameObject enemy)
    {
        while (enemy != null)
        {
            //move o inimigo da direita para a esquerda
            enemy.transform.Translate(Vector2.left * speed * Time.deltaTime);

            //se o inimigo sair do limite visível, destrói o objeto
            if (enemy.transform.position.x < destroyLimitX)
            {
                Destroy(enemy);
                Debug.Log("Destruiu inimigo");
                yield break; // Sai da corrotina
            }

            yield return null; // Espera o próximo frame
        }
    }
}
