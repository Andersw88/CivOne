// CivOne
//
// To the extent possible under law, the person who associated CC0 with
// CivOne has waived all copyright and related or neighboring rights
// to CivOne.
//
// You should have received a copy of the CC0 legalcode along with this
// work. If not, see <http://creativecommons.org/publicdomain/zero/1.0/>.

using CivOne.Civilizations;
using CivOne.Tasks;

namespace CivOne.Players
{
	internal class HumanPlayer : BasePlayer
	{
		public override void ChooseGovernment() => GameTask.Enqueue(Show.ChooseGovernment);

		public HumanPlayer(ICivilization civilization, string leaderName = null, string civilizationName = null, string citizenName = null) : base(civilization, leaderName, civilizationName, citizenName)
		{
		}

		public HumanPlayer(ComputerPlayer computerPlayer) : base(computerPlayer)
		{
		}

		public HumanPlayer(BarbarianPlayer barbarianPlayer) : base(barbarianPlayer)
		{
		}
	}
}