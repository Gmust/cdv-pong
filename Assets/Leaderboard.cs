using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private Transform container;
    [SerializeField] private GameObject entry;
    [SerializeField] private TMP_InputField userNameInput;
    [SerializeField] private Button createUserButton;


    private List<User> users = new List<User>();

    void Start()
    {
        createUserButton.onClick.AddListener(AddUserRoLeaderboard);
    }


    public void AddUserRoLeaderboard()
    {
        string name = userNameInput.text;
        if (string.IsNullOrEmpty(name))
        {
            User newUser = new User(name, 0);
            users.Add(newUser);
            UpdateLeaderboardUI();
            ClearInputFields();
        }
    }


    private void UpdateLeaderboardUI()
    {
        foreach (Transform child in container)
        {
            Destroy(child.gameObject);
        }

        users.Sort((x, y) => y.Score.CompareTo(x.Score));

        foreach (User user in users)
        {
            GameObject userEntry = Instantiate(entry, container);
            userEntry.GetComponent<UserEntryUI>().Setup(user.Name, user.Score);
        }

    }

    private void ClearInputFields()
    {
        userNameInput.text = "";
    }

    public void SaveScores(string player1, int player1Score, string player2, int player2Score)
    {
        users.Add(new User(player1, player1Score));
        users.Add(new User(player2, player2Score));
        UpdateLeaderboardUI();
    }

}


