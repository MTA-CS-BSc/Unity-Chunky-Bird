using UnityEngine.SceneManagement;

public enum Difficulty {
    Normal,
    Hard
}

public static class AppSettings {
    public static Difficulty difficulty = Difficulty.Normal;
    public static bool isThemeMusicOn = true;
    public static bool isBirdsSoundsOn = true;

    public static void ExitToMainScreen() => SceneManager.LoadScene("LandingScene");
}