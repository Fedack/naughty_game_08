using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NaughtyGame08
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StartRoom();
            myFlowDocument.Blocks.Add(myParagraph);
            this.Content = myFlowDocument;
        }
        double gametime = 0;
        int gamemonth = 0;
        int gameyear = 0;
        int gameday = 0;
        int gameweek = 0;
        int totalgamemonth = 0;
        int totalgameyear = 0;
        int totalgameday = 0;
        int totalgameweek = 0;
        Player Player = new Player();
        Paragraph myParagraph = new Paragraph();
        #region Initialize Rooms
        Room Start = new Room("Start", 0, 0);
        Room Elf_Look = new Room("Elf_Look", 1, 0);
        Room Elf_Speak = new Room("Elf_Speak", 1.1, 1);
        Room Elf_Use = new Room("Elf_Use", 1.2, 1);
        Room LiltDoom = new Room("LiltDoom", 2, 1.2);

        #endregion
        #region Initialize Items
        Item Cock_Pump = new Item(1, "Cock Pump", false);
        #endregion
        public void StartRoom()
        {
            #region Runs tStartingText
            //Start.Run.Add(Room.CreateRun(@" Strange? Where are you right now? Oh, there is something in front of you... and it is seems to be the conception of cats! Despicable cats... An ELF! Well restrained to a contraption. You'll need to take a closer "));
            //Start.Run.Add(Room.CreateRun("\n\n Or you could go for a "));
            #endregion
            ClearParagraph();
            var look = Room.CreateContainer("look.", () => Elf_LookRoom());
            var re = Room.CreateContainer("random event!", () => RandomEventRoom());
            AddInline($@" Strange? Where are you right now? Oh, there is something in front of you... and it is seems to be the conception of cats! Despicable cats... An ELF! Well restrained to a contraption. You'll need to take a closer ", look, "\n\n Or you could go for a ", re);

            var key = Room.CreateContainer("key ", () => KeyRoom());
            AddInline($@"The dragon looked toward the ", key, " and blinked twice.");
            void KeyRoom()
            {
                AddInline($@"The key is fantastic.");
            }
        }
        void RandomEventRoom()
        {
            ClearParagraph();
            WeightedItem<int> P50 = new WeightedItem<int>(1, 5);
            WeightedItem<int> P20 = new WeightedItem<int>(2, 2);
            WeightedItem<int> P10 = new WeightedItem<int>(3, 1);
            WeightedItem<int> P1 = new WeightedItem<int>(4, 1);
            var rerun = Room.CreateContainer("Rerun", () => RandomEventRoom());
            List<WeightedItem<int>> myList = new List<WeightedItem<int>> { P50, P20, P10, P1 };
            int chosen = WeightedItem<int>.Choose(myList);
            Run pick = new Run();
            if (chosen == 1)
            {
                Player.HasKnot = true;
                pick = Room.CreateRun($"It landed on one! {HasKnot("I will fuck you tonight")}");
            }
            else if (chosen == 2)
            {
                Player.HasKnot = false;
                pick = Room.CreateRun($"It landed on two! {HasKnot("I will fuck you tonight")}");
            }
            else if (chosen == 3)
            {
                pick = Room.CreateRun("It landed on three!");
            }
            else if (chosen == 4)
            {
                pick = Room.CreateRun("It landed on four!");
            }
            Run stats = Room.CreateRun(GameStats());
            AddInline(pick, rerun, "\n\n", stats);

        }
        #region Elf 001
        void Elf_LookRoom()
        {
            #region Runs tElfLook
            Elf_Look.Run.Add(Room.CreateRun($@" You take a few steps closer to the elf stuck in the frame and look her over. She’s slim, but not in the skinny sort of way. Smooth all over, her body almost seeming to flow down in a series of delicate curves from shoulders, down her rather fitting, moderately sized B cup breasts, to her hourglass hips and sleek, slender legs. Her skin is a fair, pale white, save for patches of an embarrassed blush on the cheeks of her narrow face, and the darker skin of her small, well rounded nipples. Her hair is almost silvery, with just a hint of gold to make it a rather opulent blonde, and each side has a slightly pointed ear poking out through the strands. Perhaps most intriguing is what’s between her legs.

As you move even closer to investigate, she’ll let a groan out of the ball gag stuffed between her slim lips, lifting her head to look up at you with a pair of almost glowing, bright blue eyes.Between her legs, she’s got a cock; it’s soft at the moment, flopped at about three inches, with a modest thickness. It can probably grow decently big, you’d assume, by the science of guessing. Below it hang a set of full looking balls, either shaved smooth, or naturally so, matching everywhere on her body, save for her head. Getting right up before her, you lift the herm’s smooth, hairless, but rather heavy balls to find her neat slit underneath, with neat and delicate, petal - like folds and a soft little clit stuck as the cherry on top.She’s a rather unusual and exquisite thing, and as you lower her sack and step back, you can’t help but admire her beauty. 

It would be a bit hard to "));
            Elf_Look.Run.Add(Room.CreateRun("\n\nYou could "));
            Elf_Look.Run.Add(Room.CreateRun(" that juicy looking Cock Pump you have."));
            Elf_Look.Run.Add(Room.CreateRun("\n\nYou can see a "));
            Elf_Look.Run.Add(Room.CreateRun(" to your side. You remember it leads to a certain cat."));
            #endregion
            ClearParagraph();
            Elf_Look.Link.Add(Room.CreateContainer("speak.", () => Elf_SpeakRoom()));
            Elf_Look.Link.Add(Room.CreateContainer("use", () => Elf_UseRoom()));
            Elf_Look.Link.Add(Room.CreateContainer("door", () => LiltDoomRoom()));
            bool CockPumpUsed = false;
            if (Elf_Look.HasVisited == true && CockPumpUsed == false)
            {
                var HasVisited = Room.CreateRun(@"Once again you find yourself in front of the elf. She's following you with her gaze, beggingly and pitifully. She squirms to make her point clear, but you can't release her until science is done, right?");
                AddInline(HasVisited);

            }
            else if (CockPumpUsed == true)
            {
                var CockPumpBeenUsed = Room.CreateRun("She's panting still, whimpering under her gag, her eyes wide and looking at you with fear in her eyes... but also her face as red as it could be. She knows what you've done! Not that it matter, Science will not be stopped that easily.");
                AddInline(CockPumpUsed);
            }

            else if (Elf_Look.HasVisited == false && CockPumpUsed == false)
            {
                AddInline(Elf_Look.Run[0], Elf_Look.Link[0]);
            }

            if (Player.Inventory.Contains(Cock_Pump))
            {   
                AddInline(Elf_Look.Run[1], Elf_Look.Link[1], Elf_Look.Run[2]);
            }
            Elf_Look.HasVisited = true;
            AddInline(Elf_Look.Run[3], Elf_Look.Link[2], Elf_Look.Run[4]);
        }

        void Elf_SpeakRoom()
        {
            #region Runs tElfSpeak
            Elf_Speak.Run.Add(Room.CreateRun(@"She lifts her head as you step forwards to speak to her, her faintly glowing, sapphire-blue eyes almost sparkling with a bit of hope, a few shakes of her head trying to dislodge the fringe that had started to grow over them.
“Hmmhp mhhhm!” She’d try and call out words to you, but the dark blue ball gag in her mouth -someone seemed to like to colour - coordinate - blocked any attempt at her speech getting out. It was secured around her narrow cheeks by a black strap, and if you wanted to tilt her head around, you’d find that there was a lock at the back preventing it from being taken off easily.Likewise, the leather straps looped around her wrists and ankles to keep her stretched out on the frame also held locks, making releasing her impossible. “Plhhemm, ffhhn hemmh heeeh!” No matter how much meaning she tried to put in her wide eyes, her muffled words didn’t hold any understandable information, only bringing a slight drop of saliva around the ball to roll down her chin, which you politely dab off with a nearby tissue and toss it in a bin marked ‘Biohazard Waste’. 

Science has to be hygienic, after all!

You could have another "));
            Elf_Speak.Run.Add(Room.CreateRun(" or you could "));
            Elf_Speak.Run.Add(Room.CreateRun(" that juicy looking Insemination Machine you have."));
            #endregion
            ClearParagraph();
            AddInline(Elf_Speak.Run[0], Start.Link[0], Elf_Speak.Run[1], Elf_Look.Link[1], Elf_Speak.Run[2]);
        }

        void Elf_UseRoom()
        {
            #region Runs tElfUse1
            Elf_Use.Run.Add(Room.CreateRun(@"You step right up before the elf, looking her again from head to toe, nodding as if you know exactly what you’re doing, before reaching out and cupping a hand under her balls. The two orbs inside the delicate skin seem to almost bounce on your fingers, as you slowly rise them up to catch a glimpse of her tight little pussy, almost shyly hiding behind her out-of place malehood.
“Mppf?” She’d groan at you, looking a bit worried as you don’t make any move to free her from the binds, or help her escape the strange lab in any way, her bright blue eyes trying to catch the attention of your own, head tilting and with it her fringe of light, almost silver hair, grown long and parted down her shoulders, her elfin ears poking out at either side.

You take the base of her cock between thumb and forefinger, teasing the softie, toying by gently squeezing and rubbing, until you feel it start to harden. With rigidity came warmth, and then length, enough for more of your fingers to start wrapping around the shaft, teasing her with each stroke. It was somewhat mesmerising to watch it grow to seven inches, precum beading at the hole in the head each time you teased her foreskin up over it, and then when you pulled it back down to expose the tip in all its glory. But now was not the time for watching her large but delicate elven cock.

Now was the time for science. Still holding her ladydick in one hand, rolling your wrist in the perfect, practiced way every guy knew how to work his own junk, you reach into your pocket and pulled out the penis pump. It was just big enough, you were sure, keeping it low to try and avoid the eyes of the poor trapped elf, although she was busy looking up at the ceiling, flexing her little toes and flattening her feet, wiggling her wrists in their restraints, trying to fight the pleasure coming with your deft and purposeful handjob.

Although she certainly noticed when you reeled out the female connector, plug and tube, and pushed it to her tight pussy, those bright blue eyes going wide with confusion and focusing first on you, then at the object in your hands, trying to figure out what was going on. You gave her a second, before pushing it inside and pressing the Enter button, this advanced machine knowing just how to work itself. With a buzzing vibration that had the elf suddenly squealing in her gag, fighting in her bonds as the most intense sensation wracked her pussy, the connector started to almost crawl through her pussy, going deeper and deeper, further than any man had ever touched her, until it anchored against the wall of her cervix, the buzzing started to slow to a gentle sucking drone.

The elf was too shocked by the ordeal to even make a sound of accusation, only able to pant heavily through her nose and rock her head back, blinking hard - it felt like her pussy had been trying to shake itself apart from the inside, her sudden cramping having made her feel rather wound up and tight. But it was one artificial forced pleasure replaced with another, as you take your hand off her throbbing, dribbling cock and slide the pump over it, the rubber seal neatly fitting around her shaft and when it reached the bottom, constricted tight.

It was then the weary herm must’ve caught on to your strange experiment, her head levelling to look at yours, and glistening fear in her eyes, flicking from the primed pump on her cock, totally transparent, showing every twitch and throb of her long, smooth organ, to the tube leading into her slid, disappearing deep inside to her most fertile place. But you don’t do what you do for the fun of it. No sir, you do this because science. These are the real questions that need answering, and you don’t see anyone else around to answer them for you!

With a little poke, you press the Suck button and immediately the elf falls back into tremors and twitches, struggling enough to rattle and heave the leather bonds at her arms and legs, keeping her connected to the rack. She’s getting a blowjob, you can see, as the transparent gel inside starts to vibrate and roll, coursing around her cock in strong waves, coupled with a buzzing, whirring, sucking noise coming, from the machine itself. It must be good, and you note it to try it on yourself sometime, as you watch the elf’s eyes rolling up, her head only able to make a few shakes, before she suddenly cries out into her gag.

You reach out and cup her balls, feeling them give that squeeze, the pressure in her loins abating, before a long, white, pearly streak shoots from the tip of her throbbing, now deep-pink cock, and sails up the tube, pulled along by suction power. Her large testicles throb again, and you watch the motion seem to then travel through her shaft, in perfect sync with the milking machine, before her next spurt is carried on up as the one before it, through the coil of tube like someone sucking on a bendy straw, straight to the plug against her cervix and spreading her sperm into her own womb. You manage to get seven more long, hard spurts out of her, before she’d done, her dick shrinking in the suction machine, even as it keeps going, torturing the elf with oversensitivity, until you switch it off.

With a huff, she slumps back, and you can retrieve the milker from around her dick, hygienically sterilising it by giving it a few hard shakes, before you wait a few moments to really let that seed set - for optimum testing results, before pulling the plug with a squishy pop. There isn’t a drop of cum left in the end, so you can safely assume your experiment was a success! With a grin, you can stow away the kit, pat the top of her head, adjust your glasses and lab coat, and set your watch for nine months, or however long elves take to cook a bun in the oven, who knows, who cares? What are we, nerds?

Would you like to "));
            Elf_Use.Run.Add(Room.CreateRun(@" or "));
            Elf_Use.Run.Add(Room.CreateRun(@" how to really treat a catto?"));
            #endregion
            ClearParagraph();
            Elf_Use.Link.Add(Room.CreateContainer("restart", () => StartRoom()));
            Elf_Use.Link.Add(Room.CreateContainer("see", () => LiltDoomRoom()));
            AddInline(Elf_Use.Run[0], Elf_Use.Link[0], Elf_Use.Run[1], Elf_Use.Link[1], Elf_Use.Run[2]);
        }
        #endregion
        void LiltDoomRoom()
        {
            #region Runs LiltDoom
            LiltDoom.Run.Add(Room.CreateRun(@"Satisfied with your deeds for RESEARCH! it is time to start the next phase in your plans. Promptly you commute to an adjacent door, opening it then closing it behind you. Here lies into view the most filthy and gay thing you would have ever laid your eyes on...

Suspended by their wrists by two mechanichal arms that held his wrists, a small serval hanged in the middle of the room. Spotlights illuminating them so you can see them clearly. Naked, their sand colored body was presented bold. Their stomach and chest was lighter than the rest of their body with dark spots dotting it.

A set of blue eyes would open, staring at you with a tiny bit of hope, but what transpired within was mostly fear and tiredness. The reason readily apparently, a light pneumatic pistoning heard from behind them as a large, phallic object was pushed deep within their rear, stretching them as big as they could go. Each slow but steady press would bring about a groan and heavy breath from the feline.

At their front, tied around their small sack, was a ring that supported a tube not unlike the elf had got. Except within that tube, the pink barbed malehood was being squished on two sides by vibrating eggs which were buzzing loud enough to vibrate the whole glass bell that kept the malehood trapped.

You arrived just in time, to see their eyes roll back and their jaw clenching. Little toes spreading apart and the glass bell quickly got filled with catjuice, creamy white which was sucked right into a tube. Following the cum travelling through, you'd see it went to fall and pool in a glass tank just out of reach of the feline's legs. The thing was half empty, but could contain a few litters... by the rate that it pooled it could be seen that he'd been in this position for a while. You do remember that you had placed him there nearly three days ago.

Of course, this meant that the cock within was nearly blue, the barbs extended and those blue eyes staring at you once the feline recovered was one of despair. ""P - Please...I'll be good... Stop it. It burns, I didn't mean to steal all this spegot...PLEASE."" The voice trailed into a satisfying whimper.

You grinned, satisfied and approached to get a closer look, raising a hand and placing it on the soft fur of their chest.They couldn't be too old, even if due to their species small size, it was often hard to determine age. One thing was true, they were quite adorable.

You wonder what to do with them next...listening to the groans and sniffs that were given to you, those hopeful eyes full of misery...Just how cats eyes should be."));
            LiltDoom.Run.Add(Room.CreateRun("\n\nIt seems you could pick up the "));
            LiltDoom.Run.Add(Room.CreateRun(@" and maybe do something with the elf in the "));
            #endregion
            ClearParagraph();
            LiltDoom.Link.Add(Room.CreateContainer("Cock Pump", () => LiltDoom_PickUpPump()));
            LiltDoom.Link.Add(Room.CreateContainer("other room.", () => Elf_LookRoom()));
            AddInline(LiltDoom.Run[0], LiltDoom.Run[1], LiltDoom.Link[0], LiltDoom.Run[2], LiltDoom.Link[1]);
            void LiltDoom_PickUpPump()
            {
                Cock_Pump.IsCarried = true;
                Player.Inventory.Add(Cock_Pump);
                var tPickUpPump1 = "\n\nSweet! You approach and pick up the pump! Let's hope that it will be of use!";
                AddInline(tPickUpPump1);
            }
        }

        //Template
        //#region Runs replaceme
        //replaceme.Run.Add(Room.CreateRun(@" "));
        //replaceme.Run.Add(Room.CreateRun(@" "));
        //replaceme.Run.Add(Room.CreateRun(@" "));
        //#endregion
        //ClearParagraph();
        //replaceme.Link.Add(Room.CreateContainer("speak", () => Elf_SpeakRoom()));
        //replaceme.Link.Add(Room.CreateContainer("use", () => Elf_UseRoom()));
        //AddInline(replaceme.Run[0], replaceme.Link[0], replaceme.Run[1], replaceme.Link[1], replaceme.Run[2]);

        void ClearParagraph()
        {
            foreach (Inline run in myParagraph.Inlines.ToList())
            {
                myParagraph.Inlines.Remove(run);
            }
        }
        public void AddGameTime(double seconds, int days, int week, int month, int year)
        {
            gametime = gametime + seconds;
            gameday = gameday + days;
            totalgameday = totalgameday + days;
            gameweek = gameweek + week;
            totalgameweek = totalgameweek + week;
            gamemonth = gamemonth + month;
            totalgamemonth = totalgamemonth + month;
            gameyear = gameyear + year;
            totalgameyear = totalgameyear + year;
            if (gametime >= 86400)
            {
                while (gametime > 86400)
                {
                    gametime = gametime - 86400;
                    gameday = gameday + 1;
                    totalgameday = totalgameday + 1;
                }
            }
            if (gameday > 7)
            {
                while (gameday > 7)
                {
                    gameday = gameday - 7;
                    gameweek = gameweek + 1;
                    totalgameweek = totalgameweek + 1;
                }
            }
            if (gameweek > 4)
            {
                while (gameweek > 4)
                {
                    gameweek = gameweek - 4;
                    gamemonth = gamemonth + 1;
                    totalgamemonth = totalgamemonth + 1;
                }
            }
            if (gamemonth > 12)
            {
                while (gamemonth > 12)
                {
                    gamemonth = gamemonth - 12;
                    gameyear = gameyear + 1;
                    totalgameyear = totalgameday + 1;
                }
            }
        }
        public string CurrentGameTime()
        {
            TimeSpan t = TimeSpan.FromSeconds(gametime);
            return t.ToString();
        }
        public string GameStats()
        {
            string r = CurrentGameTime() + " " + $"Current Day: {gameday} Current Week: {gameweek} Current Month: {gamemonth} Current Year: {gameyear}. TotalStats: {totalgameday}:{totalgameweek}:{totalgamemonth}:{totalgameyear}";
            return r;
        }
        public void AddInline(params object[] inline)
        {
            foreach (dynamic element in inline)
            {
                myParagraph.Inlines.Add(element);
            }
        }
        private void RemoveDoubleClickEvent(Label b)
        {
            FieldInfo f1 = typeof(Control).GetField("EventDoubleClick",
                BindingFlags.Static | BindingFlags.NonPublic);
            object obj = f1.GetValue(b);
            PropertyInfo pi = b.GetType().GetProperty("Events",
                BindingFlags.NonPublic | BindingFlags.Instance);
            EventHandlerList list = (EventHandlerList)pi.GetValue(b, null);
            list.RemoveHandler(obj, list[obj]);
        }
        public class WeightedItem<T>
        {
            private T value;
            private int weight;
            private int cumulativeSum;
            private static Random rndInst = new Random();

            public WeightedItem(T value, int weight)
            {
                this.value = value;
                this.weight = weight;
            }

            public static T Choose(List<WeightedItem<T>> items)
            {
                int cumulSum = 0;
                int cnt = items.Count();

                for (int slot = 0; slot < cnt; slot++)
                {
                    cumulSum += items[slot].weight;
                    items[slot].cumulativeSum = cumulSum;
                }

                double divSpot = rndInst.NextDouble() * cumulSum;
                WeightedItem<T> chosen = items.FirstOrDefault(i => i.cumulativeSum >= divSpot);
                if (chosen == null) throw new Exception("No item chosen - there seems to be a problem with the probability distribution.");
                return chosen.value;
            }
        }
        public void RemoveInline(object[] inline)
        {
            foreach (dynamic element in inline)
            {
                myParagraph.Inlines.Add(element);
            }
        }

        #region TextSwitches
        public string HasKnot(string text)
        {
            if (Player.HasKnot == true)
            {
                return text;
            }
            else return string.Empty;
        }
        #endregion
    }
}
