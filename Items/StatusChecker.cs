using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace StatusChecker.Items
{
	public class StatusChecker : ModItem
	{
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

			int life = player.statLifeMax2;
			int defense = player.statDefense;
			int mana = player.statManaMax;
			float weaponDamage = player.GetWeaponDamage(player.HeldItem);
			float dps = player.getDPS();
			float flightTime = player.wingTimeMax;
			float maxRunSpeed = player.moveSpeed;

			int minions = player.maxMinions;
			int turrets = player.maxTurrets;

			float meleeCrit = player.GetTotalCritChance(DamageClass.Melee);
			float rangedCrit = player.GetCritChance(DamageClass.Ranged);
			float magicCrit = player.GetCritChance(DamageClass.Magic);
			float thrownCrit = player.GetCritChance(DamageClass.Throwing);

			float attackSpeedMelee = player.GetTotalAttackSpeed(DamageClass.Melee);
			float attackSpeedRanged = player.GetTotalAttackSpeed(DamageClass.Ranged);
			float attackSpeedMagic = player.GetTotalAttackSpeed(DamageClass.Magic);
			float attackSpeedThrowing = player.GetTotalAttackSpeed(DamageClass.Throwing);

			float penetrationArmorMelee = player.GetTotalArmorPenetration(DamageClass.Melee);
			float penetrationArmorRanged = player.GetTotalArmorPenetration(DamageClass.Ranged);
			float penetrationArmorMagic = player.GetTotalArmorPenetration(DamageClass.Magic);
			float penetrationArmorThrowing = player.GetTotalArmorPenetration(DamageClass.Throwing);


			float[] critValues = { meleeCrit, rangedCrit, magicCrit, thrownCrit };
			float[] asValues = { attackSpeedMelee, attackSpeedRanged, attackSpeedMagic, attackSpeedThrowing };
			float[] paValues = { penetrationArmorMelee, penetrationArmorRanged, penetrationArmorMagic, penetrationArmorThrowing };

			float averageCrit = CalculateAverage(critValues);
			float averageAS = CalculateAverage(asValues);
			float averagePA = CalculateAverage(paValues);


			int heldItemIndex = player.HeldItem.type;

			string playerClass = GetPlayerClass(heldItemIndex);

			string colorClass;

			if (playerClass == "Melee")
			{
				colorClass = "f90000";
			}
			else if (playerClass == "Ranged")
			{
				colorClass = "40f900";
			}
			else if (playerClass == "Summoner")
			{
				colorClass = "f900f9";
			}
			else if (playerClass == "Mage")
			{
				colorClass = "411bfd";
			}
			else
			{
				colorClass = "fcfcfc";
			}

			TooltipLine line1 = new TooltipLine(Mod, "Tooltip", $"[c/00f43f:Basic Statistics:] ");
			TooltipLine line2 = new TooltipLine(Mod, "Tooltip", $"Health: [c/FF0000:{life}]       Defense: [c/9c9c9d:{defense}]       Mana: [c/0000FF:{mana}]");
			TooltipLine line3 = new TooltipLine(Mod, "Tooltip", $"[c/f6ff3b:Class Statistics:] ");
			TooltipLine line4 = new TooltipLine(Mod, "Class", $"Class: [c/{colorClass}:{playerClass}]");
			TooltipLine line5 = new TooltipLine(Mod, "Tooltip", $"Damage: [c/a00303:{weaponDamage}]       DPS: [c/fdffbb:{dps}]");
			TooltipLine line6 = new TooltipLine(Mod, "Tooltip", $"[c/51fafd:Additional Statistics:] ");
			TooltipLine line7 = new TooltipLine(Mod, "Tooltip", $"Max.Flight: [c/a898f7:{flightTime}%]       Speed: [c/436af8:{maxRunSpeed}]");


			TooltipLine lineCA = new TooltipLine(Mod, "Tooltip", $"Crit. Chance: [c/fe4b4b:{averageCrit}%]       Att. Speed: [c/c2ffbb:{averageAS}]");
			TooltipLine lineA = new TooltipLine(Mod, "Tooltip", $"Arm. Penetration: [c/878787:{averagePA}]");

			TooltipLine lineMT = new TooltipLine(Mod, "Tooltip", $"Max. Minions: [c/41f84c:{minions}]       Max. Turrets: [c/ad31f9:{turrets}]");



			tooltips.Add(line1);
			tooltips.Add(line2);
			tooltips.Add(line3);
			tooltips.Add(line4);
			tooltips.Add(line5);

			if (playerClass == "Melee" || playerClass == "Ranged")
			{
				tooltips.Add(lineCA);
				tooltips.Add(lineA);
			}
			else if (playerClass == "Summoner")
			{
				tooltips.Add(lineMT);
			}
			else if (playerClass == "Mage")
			{
				tooltips.Add(lineCA);
			}

			tooltips.Add(line6);
			tooltips.Add(line7);




		}

		private float CalculateAverage(float[] values)
		{
			int count = 0;
			float sum = 0;

			foreach (float value in values)
			{
				if (value != 0)
				{
					sum += value;
					count++;
				}
			}

			return count > 0 ? sum / count : 0;
		}
		private string GetPlayerClass(int heldItemType)
		{
			Item heldItem = new Item();
			heldItem.SetDefaults(heldItemType);



			string tipo = heldItem.DamageType.ToString();


			if (tipo == "Terraria.ModLoader.MeleeDamageClass" || tipo == "Terraria.ModLoader.MeleeNoSpeedDamageClass")
			{
				return "Melee";
			}
			else if (tipo == "Terraria.ModLoader.RangedDamageClass")
			{
				return "Ranged";
			}
			else if (tipo == "Terraria.ModLoader.SummonDamageClass" || tipo == "Terraria.ModLoader.SummonMeleeSpeedDamageClass")
			{
				return "Summoner";
			}
			else if (tipo == "Terraria.ModLoader.MagicDamageClass")
			{
				return "Mage";
			}
			else
			{
				return "No Class";
			}
		}



	}
}

