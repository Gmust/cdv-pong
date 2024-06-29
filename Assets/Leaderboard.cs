using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private Transform container;
    [SerializeField] private GameObject userEntryPrefab;
    [SerializeField] private InputField userNameInput;
    [SerializeField] private InputField userScoreInput;
    [SerializeField] private Button createUserButton;

    private List<User> users = new List<User>();

    void Start()
    {
        if (createUserButton != null)
        {
            createUserButton.onClick.AddListener(AddUserToLeaderboard);
        }
        else
        {
            Debug.LogError("Create User Button is not assigned.");
        }
        LoadLeaderboard();
        UpdateLeaderboardUI();
    }

    public void AddUserToLeaderboard()
    {
        string name = userNameInput.text;
        string score = userScoreInput.text;
        if (!string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(score))
        {
            User newUser = new User(name, int.Parse(score));
            users.Add(newUser);
            UpdateLeaderboardUI();
            ClearInputFields();
            SaveLeaderboard();
        }
        else
        {
            Debug.LogError("User name is empty or null.");
        }
    }

    private void UpdateLeaderboardUI()
    {
        if (container == null)
        {
            Debug.LogError("Container is not assigned.");
            return;
        }

        if (userEntryPrefab == null)
        {
            Debug.LogError("User Entry Prefab is not assigned.");
            return;
        }

        foreach (Transform child in container)
        {
            Destroy(child.gameObject);
        }

        users.Sort((x, y) => y.Score.CompareTo(x.Score));

        foreach (User user in users)
        {
            GameObject userEntry = Instantiate(userEntryPrefab, container);
            UserEntryUI entryUI = userEntry.GetComponent<UserEntryUI>();
            if (entryUI != null)
            {
                entryUI.Setup(user.Name, user.Score);
            }
            else
            {
                Debug.LogError("UserEntryUI component is missing on the userEntryPrefab.");
            }
        }
    }

    private void ClearInputFields()
    {
        if (userNameInput != null)
        {
            userNameInput.text = "";
            userScoreInput.text = "";
        }
        else
        {
            Debug.LogError("User Name Input is not assigned.");
        }
    }

    public void SaveScores(string player1, int player1Score, string player2, int player2Score)
    {
        users.Add(new User(player1, player1Score));
        users.Add(new User(player2, player2Score));
        // UpdateLeaderboardUI();
        SaveLeaderboard();
    }

    private void SaveLeaderboard()
    {
        PlayerPrefs.SetInt("UsersCount", users.Count);
        for (int i = 0; i < users.Count; i++)
        {
            PlayerPrefs.SetString($"Username_{i}", users[i].Name);
            PlayerPrefs.SetInt($"UserScore_{i}", users[i].Score);
        }

        PlayerPrefs.Save();
    }

    private void LoadLeaderboard()
    {
        int usersCount = PlayerPrefs.GetInt("UsersCount", 0);

        for (int i = 0; i < usersCount; i++)
        {
            string name = PlayerPrefs.GetString($"Username_{i}", "");
            int score = PlayerPrefs.GetInt($"UserScore_{i}", 0);
            if (!string.IsNullOrEmpty(name))
            {
                users.Add(new User(name, score));
            }
        }


    }

}
