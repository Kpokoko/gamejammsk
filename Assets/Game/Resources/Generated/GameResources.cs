using Game.Scripts;
using Game.Scripts.Triggers;
using UnityEngine;
using UnityEngine.UIElements;

// This file is auto-generated. Do not modify manually.

public static class GameResources
{
    public static class Animations
    {
    }
    public static class Audios
    {
        public static class sound
        {
            public static AudioClip pressed => Resources.Load<AudioClip>("Audios/sound/pressed");
            public static AudioClip walk => Resources.Load<AudioClip>("Audios/sound/walk");
        }
        public static AudioClip music_dialoge => Resources.Load<AudioClip>("Audios/music_dialoge");
        public static AudioClip music_menu => Resources.Load<AudioClip>("Audios/music_menu");
        public static AudioClip music_vibe => Resources.Load<AudioClip>("Audios/music_vibe");
    }
    public static class Dialogues
    {
    }
    public static class Effects
    {
    }
    public static class Generated
    {
    }
    public static class Levels
    {
    }
    public static class Prefabs
    {
        public static class Carriages
        {
            public static Carriage BaseCarriage => Resources.Load<Carriage>("Prefabs/Carriages/BaseCarriage");
            public static Carriage CarriagePortal => Resources.Load<Carriage>("Prefabs/Carriages/CarriagePortal");
            public static Carriage CutsceneCarriage_1 => Resources.Load<Carriage>("Prefabs/Carriages/CutsceneCarriage 1");
            public static Carriage CutsceneCarriage_2 => Resources.Load<Carriage>("Prefabs/Carriages/CutsceneCarriage 2");
            public static Carriage CutsceneCarriage_3 => Resources.Load<Carriage>("Prefabs/Carriages/CutsceneCarriage 3");
            public static Carriage CutsceneCarriage => Resources.Load<Carriage>("Prefabs/Carriages/CutsceneCarriage");
            public static Carriage FakeCarriage => Resources.Load<Carriage>("Prefabs/Carriages/FakeCarriage");
            public static Carriage LastLevelCarriage => Resources.Load<Carriage>("Prefabs/Carriages/LastLevelCarriage");
            public static Carriage LCarriageWithDoor => Resources.Load<Carriage>("Prefabs/Carriages/LCarriageWithDoor");
            public static Carriage LTurnstileCarriage => Resources.Load<Carriage>("Prefabs/Carriages/LTurnstileCarriage");
            public static Carriage RCarriageWithDoor => Resources.Load<Carriage>("Prefabs/Carriages/RCarriageWithDoor");
            public static Carriage RTurnstileCarriage => Resources.Load<Carriage>("Prefabs/Carriages/RTurnstileCarriage");
            public static Carriage TrashCarriage => Resources.Load<Carriage>("Prefabs/Carriages/TrashCarriage");
            public static Carriage WallCarriage => Resources.Load<Carriage>("Prefabs/Carriages/WallCarriage");
        }
        public static class Layout
        {
            public static GameObject Wall => Resources.Load<GameObject>("Prefabs/Layout/Wall");
        }
        public static GameObject Door => Resources.Load<GameObject>("Prefabs/Door");
        public static DoorButton DoorButton => Resources.Load<DoorButton>("Prefabs/DoorButton");
        public static CarriageBounds LeftBorder => Resources.Load<CarriageBounds>("Prefabs/LeftBorder");
        public static PortalTrigger LPortal => Resources.Load<PortalTrigger>("Prefabs/LPortal");
        public static GameObject PauseCont => Resources.Load<GameObject>("Prefabs/PauseCont");
        public static CharacterController Player => Resources.Load<CharacterController>("Prefabs/Player");
        public static PortalTrigger Portal => Resources.Load<PortalTrigger>("Prefabs/Portal");
        public static CarriageBounds RightBorder => Resources.Load<CarriageBounds>("Prefabs/RightBorder");
        public static PortalTrigger RPortal => Resources.Load<PortalTrigger>("Prefabs/RPortal");
        public static TurnstileButton TurnstileButton => Resources.Load<TurnstileButton>("Prefabs/TurnstileButton");
    }
    public static class Sprites
    {
        public static class brooooo
        {
            public static Sprite Злыдень => Resources.Load<Sprite>("Sprites/brooooo/Злыдень");
            public static Sprite ЗлыденьСпрайт => Resources.Load<Sprite>("Sprites/brooooo/ЗлыденьСпрайт");
        }
        public static class ded
        {
            public static Sprite ded_sit => Resources.Load<Sprite>("Sprites/ded/ded_sit");
            public static Sprite дед_спрайт__2_ => Resources.Load<Sprite>("Sprites/ded/дед спрайт (2)");
            public static Sprite дед_спрайт_улыбка__2_ => Resources.Load<Sprite>("Sprites/ded/дед спрайт улыбка (2)");
        }
        public static class Dialoge
        {
            public static class ded
            {
                public static Sprite cmile => Resources.Load<Sprite>("Sprites/Dialoge/ded/cmile");
                public static Sprite common => Resources.Load<Sprite>("Sprites/Dialoge/ded/common");
            }
        }
        public static class girl
        {
            public static Sprite girl_sit01 => Resources.Load<Sprite>("Sprites/girl/girl_sit01");
            public static Sprite girl_sit02 => Resources.Load<Sprite>("Sprites/girl/girl_sit02");
            public static Sprite girl_sit03 => Resources.Load<Sprite>("Sprites/girl/girl_sit03");
            public static Sprite girl_sit04 => Resources.Load<Sprite>("Sprites/girl/girl_sit04");
            public static Sprite girl_sit05 => Resources.Load<Sprite>("Sprites/girl/girl_sit05");
            public static Sprite girl_sit06 => Resources.Load<Sprite>("Sprites/girl/girl_sit06");
            public static Sprite ГлавнаяГероиняСпрайтЗлобни__2_ => Resources.Load<Sprite>("Sprites/girl/ГлавнаяГероиняСпрайтЗлобни (2)");
            public static Sprite ДевочкаСпрайт => Resources.Load<Sprite>("Sprites/girl/ДевочкаСпрайт");
            public static Sprite ДевочкаСпрайтУлыбка => Resources.Load<Sprite>("Sprites/girl/ДевочкаСпрайтУлыбка");
        }
        public static class main_hero
        {
            public static class Walk
            {
                public static Sprite Walk01 => Resources.Load<Sprite>("Sprites/main_hero/Walk/Walk01");
                public static Sprite Walk02 => Resources.Load<Sprite>("Sprites/main_hero/Walk/Walk02");
                public static Sprite Walk03 => Resources.Load<Sprite>("Sprites/main_hero/Walk/Walk03");
                public static Sprite Walk04 => Resources.Load<Sprite>("Sprites/main_hero/Walk/Walk04");
                public static Sprite Walk05 => Resources.Load<Sprite>("Sprites/main_hero/Walk/Walk05");
                public static Sprite Walk06 => Resources.Load<Sprite>("Sprites/main_hero/Walk/Walk06");
                public static Sprite Walk07 => Resources.Load<Sprite>("Sprites/main_hero/Walk/Walk07");
                public static Sprite Walk08 => Resources.Load<Sprite>("Sprites/main_hero/Walk/Walk08");
            }
            public static Sprite stand => Resources.Load<Sprite>("Sprites/main_hero/stand");
            public static Sprite ГлавнаяГероиняСпрайт__2_ => Resources.Load<Sprite>("Sprites/main_hero/ГлавнаяГероиняСпрайт (2)");
            public static Sprite ГлавнаяГероиняСпрайт => Resources.Load<Sprite>("Sprites/main_hero/ГлавнаяГероиняСпрайт");
            public static Sprite ГлавнаяГероиняСпрайтЗлобни__2_ => Resources.Load<Sprite>("Sprites/main_hero/ГлавнаяГероиняСпрайтЗлобни (2)");
            public static Sprite ГлавнаяГероиняСпрайтУлыбка__2_ => Resources.Load<Sprite>("Sprites/main_hero/ГлавнаяГероиняСпрайтУлыбка (2)");
        }
        public static Sprite BaseCarriage => Resources.Load<Sprite>("Sprites/BaseCarriage");
        public static Sprite CarriageDialogue1 => Resources.Load<Sprite>("Sprites/CarriageDialogue1");
        public static Sprite CarriageDialogue2 => Resources.Load<Sprite>("Sprites/CarriageDialogue2");
        public static Sprite CarriageDialogue3 => Resources.Load<Sprite>("Sprites/CarriageDialogue3");
        public static Sprite CarriagePlaceholder => Resources.Load<Sprite>("Sprites/CarriagePlaceholder");
        public static Sprite chel1 => Resources.Load<Sprite>("Sprites/chel1");
        public static Sprite вагон_6 => Resources.Load<Sprite>("Sprites/вагон 6");
        public static Sprite портал => Resources.Load<Sprite>("Sprites/портал");
    }
}
