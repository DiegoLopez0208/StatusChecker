
using System;
using System.Collections.Generic;


using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StatusChecker.Items
{
	public class FishMissionChecker : ModItem
	{
		private List<FishInfo> fishList;

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.useStyle = 4;
			Item.useAnimation = 20;
			Item.useTime = 10;
			Item.value = Item.buyPrice(0, 1, 0, 0);
			Item.rare = -13;
			Item.useTurn = true;
			Item.autoReuse = true;
			fishList = new List<FishInfo>(FishData.AllFishes);


		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Cactus, 10);
			recipe.AddIngredient(ItemID.Wood, 10);
			recipe.AddIngredient(ItemID.BorealWood, 10);
			recipe.AddIngredient(ItemID.PalmWood, 10);
			recipe.AddIngredient(ItemID.RichMahogany, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
		public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> tooltips)
		{
			Player player = Main.LocalPlayer;


			int anglerQuestCount = player.anglerQuestsFinished;


			int anglerQuest = Main.anglerQuest;
			int[] anglerQuestItemNetIDs = Main.anglerQuestItemNetIDs;

			if (anglerQuest >= 0 && anglerQuest < anglerQuestItemNetIDs.Length)
			{
				int netID = anglerQuestItemNetIDs[anglerQuest];
				string questItemName = Lang.GetItemNameValue(netID);
				string nameSearch = questItemName;
				FishInfo fishInfo = fishList.Find(fish => fish.Name == nameSearch);
				TooltipLine questItemNameLine = new TooltipLine(Mod, "Tooltip", $"Angler Fish: [c/00ff00:{questItemName}]");
				tooltips.Add(questItemNameLine);
				if (fishInfo != null)
				{
					TooltipLine questItemInfo = new TooltipLine(Mod, "Tooltip", $"Angler Fish Biome: [c/00ff00:{fishInfo.Biome}]");
					tooltips.Add(questItemInfo);
				}


				TooltipLine lineAnglerMissions = new TooltipLine(Mod, "Tooltip", $"Angler Total Missions Completed: [c/00ff00:{anglerQuestCount}]");

				tooltips.Add(lineAnglerMissions);


			}
		}

		public class FishInfo
		{
			public string Name { get; set; }
			public string Biome { get; set; }

			public FishInfo(string name, string biome)
			{
				Name = name;
				Biome = biome;
			}
		}
		public class FishData
		{
			public static List<FishInfo> AllFishes = new List<FishInfo>
	{
		 new FishInfo(name:"Amanita Fungifin", biome: "Glowing Mushroom biome"),
			new FishInfo(name:"Angelfish", biome: "Space/Sky"),
			new FishInfo(name:"Batfish", biome: "Underground, Cavern, Underworld"),
			new FishInfo(name:"Bloody Manowar", biome: "Any"),
			new FishInfo(name:"Bonefish", biome: "Underground, Cavern, Underworld"),
			new FishInfo(name:"Bumblebee Tuna", biome: "Any (Must be fished from Honey)"),
			new FishInfo(name:"Bunnyfish", biome: "Surface"),
			new FishInfo(name:"Cap'n Tunabeard", biome: "Space/Sky, Surface (Ocean, Hardmode)"),
			new FishInfo(name:"Catfish", biome: "Surface (Jungle)"),
			new FishInfo(name:"Cloudfish", biome: "Space/Sky, Surface (Forest)"),
			new FishInfo(name:"Clownfish", biome: "Space/Sky, Surface (Ocean)"),
			new FishInfo(name:"Cursedfish", biome: "Any (Corruption, Hardmode)"),
			new FishInfo(name:"Demonic Hellfish", biome: "Cavern, Underworld (Forest)"),
			new FishInfo(name:"Derpfish", biome: "Surface (Jungle, Hardmode)"),
			new FishInfo(name:"Dirtfish", biome: "Surface, Underground (Forest)"),
			new FishInfo(name:"Dynamite Fish", biome: "Surface (Forest)"),
			new FishInfo(name:"Eater of Plankton", biome: "Any (Corruption)"),
			new FishInfo(name:"Fallen Starfish", biome: "Space/Sky, Surface (Forest, Ocean)"),
			new FishInfo(name:"The Fish of Cthulhu", biome: "Space/Sky, Surface (Forest)"),
			new FishInfo(name:"Fishotron", biome: "Cavern, Underworld (Forest)"),
			new FishInfo(name:"Fishron", biome: "Underground, Cavern (Snow biome, Hardmode)"),
			new FishInfo(name:"Guide Voodoo Fish", biome: "Cavern, Underworld (Forest)"),
			new FishInfo(name:"Harpyfish", biome: "Space/Sky, Surface (Forest)"),
			new FishInfo(name:"Hungerfish", biome: "Cavern, Underworld (Forest, Hardmode)"),
			new FishInfo(name:"Ichorfish", biome: "Any (Crimson, Hardmode)"),
			new FishInfo(name:"Infected Scabbardfish", biome: "Any (Corruption)"),
			new FishInfo(name:"Jewelfish", biome: "Underground, Cavern, Underworld (Forest)"),
			new FishInfo(name:"Mirage Fish", biome: "Underground, Cavern (Hallow, Hardmode)"),
			new FishInfo(name:"Mudfish", biome: "Jungle"),
			new FishInfo(name:"Mutant Flinxfin", biome: "Underground, Cavern, Underworld (Snow biome)"),
			new FishInfo(name:"Pengfish", biome: "Space/Sky, Surface (Snow biome)"),
			new FishInfo(name:"Pixiefish", biome: "Space/Sky, Surface (Hallow, Hardmode)"),
			new FishInfo(name:"Scarab Fish", biome: "Any (Desert)"),
			new FishInfo(name:"Scorpio Fish", biome: "Any (Desert)"),
			new FishInfo(name:"Slimefish", biome: "Surface (Forest)"),
			new FishInfo(name:"Spiderfish", biome: "Underground, Cavern, Underworld (Forest)"),
			new FishInfo(name:"Tropical Barracuda", biome: "Surface (Jungle)"),
			new FishInfo(name:"Tundra Trout", biome: "Surface (Snow biome)"),
			new FishInfo(name:"Unicorn Fish", biome: "Any (Hallow)"),
			new FishInfo(name:"Wyverntail", biome: "Space/Sky (Hardmode)"),
			new FishInfo(name:"Zombie Fish", biome: "Surface (Forest)"),


  new FishInfo(name: "Amanita Fungifin", biome: "Bioma de setas"),
  new FishInfo(name: "Atún abejorro", biome: "Cualquier bioma (en miel)"),
  new FishInfo(name: "Aletacopito mutante", biome: "Tundra"),
  new FishInfo(name: "Anguila infectada", biome: "Corrupción"),
  new FishInfo(name: "Barracuda tropical", biome: "Selva"),
  new FishInfo(name: "Buque de guerra sangriento", biome: "Carmesí"),
  new FishInfo(name: "Capitán Barbatún", biome: "Océano"),
  new FishInfo(name: "Cola de guiverno", biome: "Bosque"),
  new FishInfo(name: "Comedor de plancton", biome: "Corrupción"),
  new FishInfo(name: "El pez de Cthulhu", biome: "Bosque"),
  new FishInfo(name: "Estrella de mar caída", biome: "Bosque"),
  new FishInfo(name: "Fishron", biome: "Tundra"),
  new FishInfo(name: "Misgurnus", biome: "Selva"),
  new FishInfo(name: "Pez ángel", biome: "Bosque"),
  new FishInfo(name: "Pez araña", biome: "Cualquier bioma"),
  new FishInfo(name: "Pez arpía", biome: "Bosque"),
  new FishInfo(name: "Pez conejo", biome: "Bosque"),
  new FishInfo(name: "Pez del fango", biome: "Bosque"),
  new FishInfo(name: "Pez dinamita", biome: "Bosque"),
  new FishInfo(name: "Pez escarabajo", biome: "Desierto"),
  new FishInfo(name: "Pez escorpión", biome: "Desierto"),
  new FishInfo(name: "Pez espejismo", biome: "Bendición"),
  new FishInfo(name: "Pez gato", biome: "Selva"),
  new FishInfo(name: "Pez guía vudú", biome: "Bosque"),
  new FishInfo(name: "Pez hada", biome: "Bendición"),
  new FishInfo(name: "Pez hambriento", biome: "Bosque"),
  new FishInfo(name: "Pez hueso", biome: "Bosque"),
  new FishInfo(name: "Pez infernal demoníaco", biome: "Bosque"),
  new FishInfo(name: "Pez joya", biome: "Bosque"),
  new FishInfo(name: "Pez maldito", biome: "Corrupción"),
  new FishInfo(name: "Pez murciélago", biome: "Bosque"),
  new FishInfo(name: "Pez nube", biome: "Bosque"),
  new FishInfo(name: "Pezotrón", biome: "Bosque"),
  new FishInfo(name: "Pez payaso", biome: "Océano"),
  new FishInfo(name: "Pez picor", biome: "Carmesí"),
  new FishInfo(name: "Pez pingüino", biome: "Tundra"),
  new FishInfo(name: "Pez slime", biome: "Bosque"),
  new FishInfo(name: "Pez tonto", biome: "Selva"),
  new FishInfo(name: "Pez unicornio", biome: "Bendición"),
  new FishInfo(name: "Pez zombi", biome: "Bosque"),
  new FishInfo(name: "Trucha de la tundra", biome: "Tundra")
	};
		}
	}
}



