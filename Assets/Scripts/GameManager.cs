using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int maxPanelcount;
    public GameObject enemy;
    public GameObject player;
    private int xPos;
    private int zPos;

    GameObject[] playerPanel;
    GameObject[] enemyPanel;
    GameObject restPanel;
    int playerScore;
    int enemyScore;
    int restPanelScore;
    public GameObject scorePlayer;
    public GameObject scoreEnemy;
    public GameObject restPanelText;
    public GameObject playerWinText;
    public GameObject enemyWinText;
    public GameObject drawText;
    TextMesh pText;
    TextMesh eText;
    TextMesh rText;

    public GameObject particle;
    ParticleSystem pSystem;
    public AudioClip WinClip;
    public AudioClip LoseClip;
    public AudioClip DrawClip;
    AudioSource Audio;
    int time;
    // Start is called before the first frame update
    void Start()
    {
        pText = scorePlayer.GetComponent<TextMesh>();
        eText = scoreEnemy.GetComponent<TextMesh>();
        rText = restPanelText.GetComponent<TextMesh>();
        playerWinText.SetActive(false);
        enemyWinText.SetActive(false);
        drawText.SetActive(false);
        Audio = GetComponent<AudioSource>();
        pSystem = particle.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        restPanelScore = maxPanelcount - (playerScore + enemyScore);
        rText.text = "RestPanels:" + restPanelScore.ToString();

        playerPanel = GameObject.FindGameObjectsWithTag("PlayerPanel");
        if(playerPanel!=null)
        {
            playerScore = playerPanel.Length;
            pText.text = "Player:" + playerScore.ToString();
        }
        if(playerPanel==null)
        {
            pText.text = "Player:" + "0".ToString();
        }
        enemyPanel = GameObject.FindGameObjectsWithTag("EnemyPanel");
        if(enemyPanel!=null)
        {
            enemyScore = enemyPanel.Length;
            eText.text = "Enemy:" + enemyScore.ToString();
        }
        if(playerPanel==null)
        {
            eText.text = "Enemy:" + "0".ToString();
        }
        if (maxPanelcount == enemyScore + playerScore)
        {
            time += 1;
            player.gameObject.SetActive(false);
            enemy.gameObject.SetActive(false);
            if (playerScore > enemyScore)
            {
                if (time == 1)
                {
                    playerWinText.SetActive(true);
                    Instantiate(particle,this.gameObject.transform);
                    particle.AddComponent<ParentNuller>();
                    pSystem.Play();
                    Audio.PlayOneShot(WinClip);
                    enemy.SetActive(false);
                }
            }
            else if (enemyScore > playerScore)
            {
                if (time == 1)
                {
                    enemyWinText.SetActive(true);
                    Instantiate(particle, this.gameObject.transform);
                    particle.AddComponent<ParentNuller>();
                    pSystem.Play();
                    Audio.PlayOneShot(LoseClip);
                    player.SetActive(false);
                }
            }
            else
            {
                if (time == 1)
                {
                    drawText.SetActive(true);
                    Audio.PlayOneShot(DrawClip);
                }
            }

        }
    }
}
