using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    private static Color[] colors = new Color[] { Color.blue, Color.magenta, Color.red, Color.green };

    [SerializeField] private GameObject particleSystemDead;
    [SerializeField] private GameObject particleSystemStar;
    [SerializeField] private GameObject prefabPlayer;
    [SerializeField] private GameObject titleText;
    [SerializeField] private GameObject endText;
    [SerializeField] private GameObject starText;
    [SerializeField] private AudioClip audioClipDeath;
    [SerializeField] private AudioClip audioClipStar;
    [SerializeField] private float cameraOffset;

    private ObjectSpawner spawner;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GetComponent<ObjectSpawner>();
        player = Instantiate(prefabPlayer, Vector3.zero, Quaternion.identity).transform;
        player.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Camera follows player
        if (player != null && player.position.y + cameraOffset > transform.position.y)
        {
            spawner.DecreaseDistance(player.position.y + cameraOffset - transform.position.y);
            transform.position = new Vector3(transform.position.x, player.position.y + cameraOffset, transform.position.z);
        }
    }

    //Player pressed to start the game, activate gravity
    public void StartGame()
    {
        player.GetComponent<Player>().SetGravity();
    }

    //Player lost
    public void EndGame()
    {
        GetComponent<AudioSource>().PlayOneShot(audioClipDeath);
        Instantiate(particleSystemDead, new Vector3(player.transform.position.x, player.transform.position.y, 0), Quaternion.identity);
        Destroy(player.gameObject);
        endText.SetActive(true);
    }

    //Player hit a star
    public void AddStar()
    {
        GetComponent<AudioSource>().PlayOneShot(audioClipStar);
        Instantiate(particleSystemStar, new Vector3(player.transform.position.x, player.transform.position.y, 0), Quaternion.identity);
        int value = int.Parse(starText.GetComponent<TextMeshProUGUI>().text) + 1;
        starText.GetComponent<TextMeshProUGUI>().text = value.ToString();
    }

    //Player and later potentially obstacles could use this to randomize their color
    public static Color RandomColor()
    {
        return colors[Random.Range(0, colors.Length - 1)];
    }


}
