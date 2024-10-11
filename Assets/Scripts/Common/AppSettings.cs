using UnityEngine.SceneManagement;

public enum Difficulty {
    Normal,
    Hard
}

public static class AppSettings {
    public static Difficulty gameDifficulty = Difficulty.Normal;
    public static bool isMusicOn = true;

    public static void ExitToMainScreen() => SceneManager.LoadScene("LandingScene");
}