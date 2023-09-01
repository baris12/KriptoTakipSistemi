namespace KriptoTakipSistemi
{
    public enum TIME_FRAME
    {
        ONE_MIN = 0,
        FIVE_MIN,
        FIFTEEN_MIN,
        THIRTY_MIN,
        ONE_HOUR,
        TWO_HOUR,
        FOUR_HOUR,
        ONE_DAY,
        ONE_WEEK,
        ONE_MONTH
    }

    enum PAGE
    {
        NONE,
        DASHBOARD,
        ALARMS,
        ANALYSIS,
        TRADING,
        USER_SETTINGS,
        SYSTEM_SETTINGS
    }

    enum THEME
    {
        DEFAULT,
        GREEN,
        BLUE,
        BROWN,
        GRAY,
        LIGHT,
        LIGHT2,
    }
}
