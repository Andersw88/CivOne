﻿// CivOne
//
// To the extent possible under law, the person who associated CC0 with
// CivOne has waived all copyright and related or neighboring rights
// to CivOne.
//
// You should have received a copy of the CC0 legalcode along with this
// work. If not, see <http://creativecommons.org/publicdomain/zero/1.0/>.
//
// Author: Kevin Routley, 2019-Oct-26
//
using System;
using CivOne.Graphics;
using CivOne.Units;
using CivOne.UserInterface;

namespace CivOne.Screens.Dialogs
{
    // Prompt the user when performing a "weak" attack (Moves=0/PartMoves<=2)
    internal class WeakAttack : BaseDialog
    {
        private static int WIDE = 80;
        private int _dX;
        private int _dY;
        private BaseUnit _unit;

        private void Continue(object sender, EventArgs args)
        {
            _unit.Confront(_dX, _dY);
            Cancel();
        }

        protected override void FirstUpdate()
        {
            Menu menu = new Menu(Palette, Selection(3, 10 + 2*FontHigh, WIDE-8, (2 * FontHigh) + 4))
            {
                X = 103, // TODO this is hard: have the menu be positioned relative to "owner"
                Y = 85 + 2 * FontHigh,
                MenuWidth = WIDE - 8,
                ActiveColour = 11,
                TextColour = 5,
                FontId = 0
            };

            menu.Items.Add("Cancel").OnSelect(Cancel);
            menu.Items.Add("Attack").OnSelect(Continue);

            menu.MissClick += Cancel;
            menu.Cancel += Cancel;

            AddMenu(menu);
        }

        private static int DialogHeight()
        {
            return 4 * FontHigh + 10;
        }

        private static int FontHigh => Resources.GetFontHeight(0);

        internal WeakAttack(BaseUnit unit, int relX, int relY)
            : base(100, 80, WIDE, DialogHeight())
        {
            _dX = relX;
            _dY = relY;
            _unit = unit;

            string prompt = unit.PartMoves >= 2 ? "2" : "1";
            prompt += "/3 strength?";
            DialogBox.DrawText($"Attack at", 0, 15, 5, 5);
            DialogBox.DrawText(prompt, 0, 15, 5, 5 + FontHigh);
        }
    }
}
