using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersManager : MonoBehaviour {

    public List<GameObject> Characters;
    public Vector3 StartSpawnPosition;
    private Vector3 currentPosition;
    private int playerSelected;
    private int previousPlayer;

	// Use this for initialization
	void Start ()
    {
        foreach (GameObject character in Characters)
        {
            character.SetActive(false);
        }
        playerSelected = 0;
        Characters[playerSelected].SetActive(true);
        Characters[playerSelected].transform.position = StartSpawnPosition;

    }
	
	// Update is called once per frame
	void Update ()
    {
        currentPosition = Characters[playerSelected].transform.position;

        SwitchCaracter();

		
	}

    void SwitchCaracter()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("Switch+1"))
        {
            Characters[playerSelected].SetActive(false);
            playerSelected += 1;
            if (playerSelected > Characters.Count - 1)
            {
                playerSelected = 0;
            }
            Characters[playerSelected].SetActive(true);
            Characters[playerSelected].transform.position = currentPosition;

        }

        if (Input.GetKeyDown(KeyCode.Q) || Input.GetButtonDown("Switch-1"))
        {
            Characters[playerSelected].SetActive(false);
            playerSelected -= 1;
            if (playerSelected < 0)
            {
                playerSelected = Characters.Count - 1;
            }
            Characters[playerSelected].SetActive(true);
            Characters[playerSelected].transform.position = currentPosition;

        }
    }
}
