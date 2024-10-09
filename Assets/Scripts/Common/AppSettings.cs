public enum Difficulty {
    Normal,
    Hard
}

public static class AppSettings {
    public static Difficulty gameDifficulty = Difficulty.Normal;
    public static bool isMusicOn = true;
}