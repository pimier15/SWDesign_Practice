using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Practice.dataType.Handler;
using Practice.dataType;
namespace UIPractice
{
	class Core
	{
		Maybe<List<double>> MainData;

		public Core()
		{
			
		}

#region First
		private Func<List<double>, double[]> AllHalf
			=> xs => xs.Map( x => x / 2 ).ToArray();

		private Func<IEnumerable<double>, IEnumerable<string>> ToStringList
			=> xs => xs.Map( x => x.ToString() );

		#endregion



		#region  Side

		public void UpdateMainData( List<double> val )
		{
			if ( val == null )
			{
				MainData = None;
			}
			else
			{
				MainData = Just( val );
			}
		}

		#endregion


	}
}
