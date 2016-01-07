namespace TheSlum.GameEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Characters;
    using Items;

    public class Engine
    {
        protected List<Character> characterList = new List<Character>();
        protected List<Bonus> timeoutItems;

        private const int GameTurns = 4;

        public virtual void Run()
        {
            this.ReadUserInput();
            this.InitializeTimeoutItems();

            for (int i = 0; i < GameTurns; i++)
            {
                foreach (var character in this.characterList)
                {
                    if (character.IsAlive)
                    {
                        this.ProcessTargetSearch(character);
                    }
                }

                this.ProcessItemTimeout(this.timeoutItems);
            }

            this.PrintGameOutcome();
        }

        public void ProcessItemTimeout(List<Bonus> timeoutItems)
        {
            for (int i = 0; i < timeoutItems.Count; i++)
            {
                timeoutItems[i].Countdown--;
                if (timeoutItems[i].Countdown == 0)
                {
                    var item = timeoutItems[i];
                    item.HasTimedOut = true;
                    var itemHolder = this.GetCharacterByItem(item);
                    itemHolder.RemoveFromInventory(item);
                    i--;
                }
            }
        }

        public void InitializeTimeoutItems()
        {
            this.timeoutItems = this.characterList
                .SelectMany(c => c.Inventory)
                .Where(i => i is Bonus)
                .Cast<Bonus>()
                .ToList();
        }

        protected virtual void ExecuteCommand(string[] inputParams)
        {
            switch (inputParams[0])
            {
                case "status":
                    this.PrintCharactersStatus(this.characterList);
                    break;
                case "create":
                    this.CreateCharacter(inputParams);
                        break;
                case "add":
                    this.AddItem(inputParams);
                        break;
                default:
                    throw new ArgumentException("Current command is unknown!");
            }
        }

        protected virtual void CreateCharacter(string[] inputParams)
        {
            Character character = null;
            switch (inputParams[1])
            {
                case "warrior":
                    Warrior warrior = new Warrior(inputParams[2]
                        , int.Parse(inputParams[3])
                        , int.Parse(inputParams[4])
                        , 200 //Health
                        , 100 //DefPoints
                        , 150 //AttackPoints
                        ,(Team)Enum.Parse(typeof(Team)
                        , inputParams[5])
                        , 2);
                    character = warrior;
                    break;
                case "mage":
                    Mage mage = new Mage(inputParams[2]
                        , int.Parse(inputParams[3])
                        , int.Parse(inputParams[4])
                        , 150 //Same as warrior's
                        , 50
                        , 300
                        , (Team)Enum.Parse(typeof(Team
                        ), inputParams[5])
                        , 5);
                    character = mage;
                    break;
                case "healer":
                    Healer healer = new Healer(inputParams[2]
                        , int.Parse(inputParams[3])
                        , int.Parse(inputParams[4])
                        , 75 //Health
                        , 50 //DefPoints
                        , 60 //AttackPoints
                        , (Team)Enum.Parse(typeof(Team)
                        , inputParams[5])
                        , 6);
                    character = healer;
                    break;
                default:
                    break;
            }
            characterList.Add(character);
        }

        protected void AddItem(string[] inputParams)
        {
            Item itemToAdd;
            switch (inputParams[2])
            {
                case "axe":
                    Axe axe = new Axe(inputParams[3]);
                    itemToAdd = axe;
                    GetCharacterById(inputParams[1]).AddToInventory(itemToAdd);
                    break;
                case "shield":
                    Shield shield = new Shield(inputParams[3]);
                    itemToAdd = shield;
                    GetCharacterById(inputParams[1]).AddToInventory(itemToAdd);
                    break;
                case "pill":
                    Pill pill = new Pill(inputParams[3]);
                    itemToAdd = pill;
                    GetCharacterById(inputParams[1]).AddToInventory(itemToAdd);
                    break;
                case "injection":
                    Injection injection = new Injection(inputParams[3]);
                    itemToAdd = injection;
                    GetCharacterById(inputParams[1]).AddToInventory(itemToAdd);
                    break;
                default:
                    break;
            }
        }

        protected void ProcessTargetSearch(Character currentCharacter)
        {
            var availableTargets = this.characterList
                .Where(t => this.IsWithinRange(currentCharacter.X, currentCharacter.Y, t.X, t.Y, currentCharacter.Range))
                .ToList();
            if (availableTargets.Contains(currentCharacter))
            {
                availableTargets.Remove(currentCharacter);
            }
            if (availableTargets.Count == 0)
            {
                return;
            }

            var target = currentCharacter.GetTarget(availableTargets);
            if (target == null)
            {
                return;
            }

            this.ProcessInteraction(currentCharacter, target);
        }

        protected void ProcessInteraction(Character currentCharacter, Character target)
        {
            if (currentCharacter is IHeal)
            {
                target.HealthPoints += (currentCharacter as IHeal).HealingPoints;
            }
            else if (currentCharacter is IAttack)
            {
                target.HealthPoints -= (currentCharacter as IAttack).AttackPoints - target.DefensePoints;
                if (target.HealthPoints <= 0)
                {
                    target.IsAlive = false;
                }
            }
        }

        protected bool IsWithinRange(int attackerX, int attackerY, int targetX, int targetY, int range)
        {
            double distance = Math.Sqrt(
                (attackerX - targetX) * (attackerX - targetX) +
                (attackerY - targetY) * (attackerY - targetY));

            return distance <= range;
        }

        protected Character GetCharacterById(string characterId)
        {
            return this.characterList.FirstOrDefault(x => x.Id == characterId);
        }

        protected Character GetCharacterByItem(Item item)
        {
            return this.characterList.FirstOrDefault(x => x.Inventory.Contains(item));
        }

        protected void PrintCharactersStatus(IEnumerable<Character> characters)
        {
            foreach (var character in characters)
            {
                Console.WriteLine(character.ToString());
            }
        }

        protected void PrintGameOutcome()
        {
            var charactersAlive = this.characterList.Where(c => c.IsAlive);
            var redTeamCount = charactersAlive.Count(x => x.Team == Team.Red);
            var blueTeamCount = charactersAlive.Count(x => x.Team == Team.Blue);

            if (redTeamCount == blueTeamCount)
            {
                Console.WriteLine("Tie game!");
            }
            else
            {
                string winningTeam = redTeamCount > blueTeamCount ? "Red" : "Blue";
                Console.WriteLine(winningTeam + " team wins the game!");
            }

            var aliveCharacters = this.characterList.Where(c => c.IsAlive);
            this.PrintCharactersStatus(aliveCharacters);
        }

        private void ReadUserInput()
        {
            string inputLine = Console.ReadLine();
            while (inputLine != string.Empty)
            {
                string[] parameters = inputLine
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                this.ExecuteCommand(parameters);
                inputLine = Console.ReadLine();
            }
        }
    }
}
