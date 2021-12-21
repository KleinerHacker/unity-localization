using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityLocalization.Runtime.localization.Scripts.Runtime;

namespace UnityLocalization.Editor.localization.Scripts.Editor.Actions
{
    public static class LocalizationActions
    {
        [MenuItem("Languages/Afrikaans", false)]
        public static void ChangeToAfrikaans() => UnityLocalize.CurrentLanguage = SystemLanguage.Afrikaans;

        [MenuItem("Languages/Afrikaans", true)]
        public static bool ChangeToAfrikaansCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Afrikaans);


        [MenuItem("Languages/Arabic", false)]
        public static void ChangeToArabic() => UnityLocalize.CurrentLanguage = SystemLanguage.Arabic;

        [MenuItem("Languages/Arabic", true)]
        public static bool ChangeToArabicCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Arabic);


        [MenuItem("Languages/Basque", false)]
        public static void ChangeToBasque() => UnityLocalize.CurrentLanguage = SystemLanguage.Basque;

        [MenuItem("Languages/Basque", true)]
        public static bool ChangeToBasqueCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Basque);


        [MenuItem("Languages/Belarusian", false)]
        public static void ChangeToBelarusian() => UnityLocalize.CurrentLanguage = SystemLanguage.Belarusian;

        [MenuItem("Languages/Belarusian", true)]
        public static bool ChangeToBelarusianCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Belarusian);


        [MenuItem("Languages/Bulgarian", false)]
        public static void ChangeToBulgarian() => UnityLocalize.CurrentLanguage = SystemLanguage.Bulgarian;

        [MenuItem("Languages/Bulgarian", true)]
        public static bool ChangeToBulgarianCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Bulgarian);


        [MenuItem("Languages/Catalan", false)]
        public static void ChangeToCatalan() => UnityLocalize.CurrentLanguage = SystemLanguage.Catalan;

        [MenuItem("Languages/Catalan", true)]
        public static bool ChangeToCatalanCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Catalan);


        [MenuItem("Languages/Chinese", false)]
        public static void ChangeToChinese() => UnityLocalize.CurrentLanguage = SystemLanguage.Chinese;

        [MenuItem("Languages/Chinese", true)]
        public static bool ChangeToChineseCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Chinese);


        [MenuItem("Languages/Czech", false)]
        public static void ChangeToCzech() => UnityLocalize.CurrentLanguage = SystemLanguage.Czech;

        [MenuItem("Languages/Czech", true)]
        public static bool ChangeToCzechCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Czech);


        [MenuItem("Languages/Danish", false)]
        public static void ChangeToDanish() => UnityLocalize.CurrentLanguage = SystemLanguage.Danish;

        [MenuItem("Languages/Danish", true)]
        public static bool ChangeToDanishCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Danish);


        [MenuItem("Languages/Dutch", false)]
        public static void ChangeToDutch() => UnityLocalize.CurrentLanguage = SystemLanguage.Dutch;

        [MenuItem("Languages/Dutch", true)]
        public static bool ChangeToDutchCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Dutch);


        [MenuItem("Languages/English", false)]
        public static void ChangeToEnglish() => UnityLocalize.CurrentLanguage = SystemLanguage.English;

        [MenuItem("Languages/English", true)]
        public static bool ChangeToEnglishCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.English);


        [MenuItem("Languages/Estonian", false)]
        public static void ChangeToEstonian() => UnityLocalize.CurrentLanguage = SystemLanguage.Estonian;

        [MenuItem("Languages/Estonian", true)]
        public static bool ChangeToEstonianCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Estonian);


        [MenuItem("Languages/Faroese", false)]
        public static void ChangeToFaroese() => UnityLocalize.CurrentLanguage = SystemLanguage.Faroese;

        [MenuItem("Languages/Faroese", true)]
        public static bool ChangeToFaroeseCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Faroese);


        [MenuItem("Languages/Finnish", false)]
        public static void ChangeToFinnish() => UnityLocalize.CurrentLanguage = SystemLanguage.Finnish;

        [MenuItem("Languages/Finnish", true)]
        public static bool ChangeToFinnishCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Finnish);


        [MenuItem("Languages/French", false)]
        public static void ChangeToFrench() => UnityLocalize.CurrentLanguage = SystemLanguage.French;

        [MenuItem("Languages/French", true)]
        public static bool ChangeToFrenchCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.French);


        [MenuItem("Languages/German", false)]
        public static void ChangeToGerman() => UnityLocalize.CurrentLanguage = SystemLanguage.German;

        [MenuItem("Languages/German", true)]
        public static bool ChangeToGermanCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.German);


        [MenuItem("Languages/Greek", false)]
        public static void ChangeToGreek() => UnityLocalize.CurrentLanguage = SystemLanguage.Greek;

        [MenuItem("Languages/Greek", true)]
        public static bool ChangeToGreekCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Greek);


        [MenuItem("Languages/Hebrew", false)]
        public static void ChangeToHebrew() => UnityLocalize.CurrentLanguage = SystemLanguage.Hebrew;

        [MenuItem("Languages/Hebrew", true)]
        public static bool ChangeToHebrewCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Hebrew);


        [MenuItem("Languages/Hungarian", false)]
        public static void ChangeToHungarian() => UnityLocalize.CurrentLanguage = SystemLanguage.Hungarian;

        [MenuItem("Languages/Hungarian", true)]
        public static bool ChangeToHungarianCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Hungarian);


        [MenuItem("Languages/Icelandic", false)]
        public static void ChangeToIcelandic() => UnityLocalize.CurrentLanguage = SystemLanguage.Icelandic;

        [MenuItem("Languages/Icelandic", true)]
        public static bool ChangeToIcelandicCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Icelandic);


        [MenuItem("Languages/Indonesian", false)]
        public static void ChangeToIndonesian() => UnityLocalize.CurrentLanguage = SystemLanguage.Indonesian;

        [MenuItem("Languages/Indonesian", true)]
        public static bool ChangeToIndonesianCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Indonesian);


        [MenuItem("Languages/Italian", false)]
        public static void ChangeToItalian() => UnityLocalize.CurrentLanguage = SystemLanguage.Italian;

        [MenuItem("Languages/Italian", true)]
        public static bool ChangeToItalianCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Italian);


        [MenuItem("Languages/Japanese", false)]
        public static void ChangeToJapanese() => UnityLocalize.CurrentLanguage = SystemLanguage.Japanese;

        [MenuItem("Languages/Japanese", true)]
        public static bool ChangeToJapaneseCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Japanese);


        [MenuItem("Languages/Korean", false)]
        public static void ChangeToKorean() => UnityLocalize.CurrentLanguage = SystemLanguage.Korean;

        [MenuItem("Languages/Korean", true)]
        public static bool ChangeToKoreanCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Korean);


        [MenuItem("Languages/Latvian", false)]
        public static void ChangeToLatvian() => UnityLocalize.CurrentLanguage = SystemLanguage.Latvian;

        [MenuItem("Languages/Latvian", true)]
        public static bool ChangeToLatvianCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Latvian);


        [MenuItem("Languages/Lithuanian", false)]
        public static void ChangeToLithuanian() => UnityLocalize.CurrentLanguage = SystemLanguage.Lithuanian;

        [MenuItem("Languages/Lithuanian", true)]
        public static bool ChangeToLithuanianCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Lithuanian);


        [MenuItem("Languages/Norwegian", false)]
        public static void ChangeToNorwegian() => UnityLocalize.CurrentLanguage = SystemLanguage.Norwegian;

        [MenuItem("Languages/Norwegian", true)]
        public static bool ChangeToNorwegianCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Norwegian);


        [MenuItem("Languages/Polish", false)]
        public static void ChangeToPolish() => UnityLocalize.CurrentLanguage = SystemLanguage.Polish;

        [MenuItem("Languages/Polish", true)]
        public static bool ChangeToPolishCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Polish);


        [MenuItem("Languages/Portuguese", false)]
        public static void ChangeToPortuguese() => UnityLocalize.CurrentLanguage = SystemLanguage.Portuguese;

        [MenuItem("Languages/Portuguese", true)]
        public static bool ChangeToPortugueseCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Portuguese);


        [MenuItem("Languages/Romanian", false)]
        public static void ChangeToRomanian() => UnityLocalize.CurrentLanguage = SystemLanguage.Romanian;

        [MenuItem("Languages/Romanian", true)]
        public static bool ChangeToRomanianCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Romanian);


        [MenuItem("Languages/Russian", false)]
        public static void ChangeToRussian() => UnityLocalize.CurrentLanguage = SystemLanguage.Russian;

        [MenuItem("Languages/Russian", true)]
        public static bool ChangeToRussianCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Russian);


        [MenuItem("Languages/SerboCroatian", false)]
        public static void ChangeToSerboCroatian() => UnityLocalize.CurrentLanguage = SystemLanguage.SerboCroatian;

        [MenuItem("Languages/SerboCroatian", true)]
        public static bool ChangeToSerboCroatianCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.SerboCroatian);


        [MenuItem("Languages/Slovak", false)]
        public static void ChangeToSlovak() => UnityLocalize.CurrentLanguage = SystemLanguage.Slovak;

        [MenuItem("Languages/Slovak", true)]
        public static bool ChangeToSlovakCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Slovak);


        [MenuItem("Languages/Slovenian", false)]
        public static void ChangeToSlovenian() => UnityLocalize.CurrentLanguage = SystemLanguage.Slovenian;

        [MenuItem("Languages/Slovenian", true)]
        public static bool ChangeToSlovenianCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Slovenian);


        [MenuItem("Languages/Spanish", false)]
        public static void ChangeToSpanish() => UnityLocalize.CurrentLanguage = SystemLanguage.Spanish;

        [MenuItem("Languages/Spanish", true)]
        public static bool ChangeToSpanishCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Spanish);


        [MenuItem("Languages/Swedish", false)]
        public static void ChangeToSwedish() => UnityLocalize.CurrentLanguage = SystemLanguage.Swedish;

        [MenuItem("Languages/Swedish", true)]
        public static bool ChangeToSwedishCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Swedish);


        [MenuItem("Languages/Thai", false)]
        public static void ChangeToThai() => UnityLocalize.CurrentLanguage = SystemLanguage.Thai;

        [MenuItem("Languages/Thai", true)]
        public static bool ChangeToThaiCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Thai);


        [MenuItem("Languages/Turkish", false)]
        public static void ChangeToTurkish() => UnityLocalize.CurrentLanguage = SystemLanguage.Turkish;

        [MenuItem("Languages/Turkish", true)]
        public static bool ChangeToTurkishCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Turkish);


        [MenuItem("Languages/Ukrainian", false)]
        public static void ChangeToUkrainian() => UnityLocalize.CurrentLanguage = SystemLanguage.Ukrainian;

        [MenuItem("Languages/Ukrainian", true)]
        public static bool ChangeToUkrainianCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Ukrainian);


        [MenuItem("Languages/Vietnamese", false)]
        public static void ChangeToVietnamese() => UnityLocalize.CurrentLanguage = SystemLanguage.Vietnamese;

        [MenuItem("Languages/Vietnamese", true)]
        public static bool ChangeToVietnameseCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.Vietnamese);


        [MenuItem("Languages/ChineseSimplified", false)]
        public static void ChangeToChineseSimplified() => UnityLocalize.CurrentLanguage = SystemLanguage.ChineseSimplified;

        [MenuItem("Languages/ChineseSimplified", true)]
        public static bool ChangeToChineseSimplifiedCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.ChineseSimplified);


        [MenuItem("Languages/ChineseTraditional", false)]
        public static void ChangeToChineseTraditional() => UnityLocalize.CurrentLanguage = SystemLanguage.ChineseTraditional;

        [MenuItem("Languages/ChineseTraditional", true)]
        public static bool ChangeToChineseTraditionalCheck() => UnityLocalize.Settings.SupportedLanguages.Contains(SystemLanguage.ChineseTraditional);
    }
}