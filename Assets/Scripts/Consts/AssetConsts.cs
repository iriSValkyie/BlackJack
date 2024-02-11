namespace BlackJack
{
    public static class AssetConsts
    {
        //カード
        
        //ベースprefab
        public static string CARD_BASE_PREFAB_PATH = "Prefab/BackColor_{0}/";

        public static string CARD_BASE_PREFAB_NAME = "{0}_PlayingCards_Blank_00";
        
        //マテリアル
        public static string CARD_BASE_MATERIAL_PATH = "Materials/BackColor_{0}/";
        
        public static string CARD_BASE_MATERIAL_NAME = "{0}_PlayingCards_{1}_00";
        
        public static string[] CARD_KIND_NAMES = {
            "Spade",
            "Diamond",
            "Club",
            "Heart",
        };

        public static string[] CARD_COLORS = {
            "Black",
            "Blue",
            "Red",
        };
        
        //チップ
        public static string CHIP_BASE_PATH = "Prefab/CasinoItem/CasinoChip_";

        public static string[] CHIP_COLORS = {
            "Black_00",
            "Blue_00",
            "Green_00",
            "Red_00",
            "White_00"
        };
    }
}