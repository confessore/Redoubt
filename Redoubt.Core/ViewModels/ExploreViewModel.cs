using MvvmCross.Core.ViewModels;
using System.Collections.Generic;
using System.Windows.Input;

namespace Redoubt.Core.ViewModels
{
    public class ExploreViewModel : MvxViewModel
    {
        public ExploreViewModel()
        {
            Player = App.Player;
            NPC = new NPC("placeholder");
            Log = new List<string>();
            Log.Add("text");
            PlayerHealth = Player.Health;
            NPCHealth = NPC.Health;
        }

        Player Player { get; set; }
        NPC NPC { get; set; }

        List<string> log;
        public List<string> Log
        {
            get => log;
            set
            {
                log = value;
                RaisePropertyChanged(() => Log);
            }
        }

        public ICommand NavBack
        {
            get => new MvxCommand(() => Close(this));
        }

        public ICommand Attack
        {
            get =>
                new MvxCommand(() =>
                {
                    Log.Remove("text");
                    Log.Add("more text");
                    PlayerHealth = PlayerHealth - 5;
                });
        }

        int playerHealth;
        public int PlayerHealth
        {
            get => playerHealth;
            set
            {
                playerHealth = value;
                RaisePropertyChanged(() => PlayerHealth);
            }
        }

        int npcHealth;
        public int NPCHealth
        {
            get => npcHealth;
            set
            {
                npcHealth = value;
                RaisePropertyChanged(() => NPCHealth);
            }
        }
    }
}
