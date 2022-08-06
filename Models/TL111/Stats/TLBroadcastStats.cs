using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace  TeleNet.Models.TL111.Stats
{
	[TLObject(-1107852396)]
    public class TLBroadcastStats : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -1107852396;
            }
        }

             public TLStatsDateRangeDays Period {get;set;}
     public TLStatsAbsValueAndPrev Followers {get;set;}
     public TLStatsAbsValueAndPrev ViewsPerPost {get;set;}
     public TLStatsAbsValueAndPrev SharesPerPost {get;set;}
     public TLStatsPercentValue EnabledNotifications {get;set;}
     public TLAbsStatsGraph GrowthGraph {get;set;}
     public TLAbsStatsGraph FollowersGraph {get;set;}
     public TLAbsStatsGraph MuteGraph {get;set;}
     public TLAbsStatsGraph TopHoursGraph {get;set;}
     public TLAbsStatsGraph InteractionsGraph {get;set;}
     public TLAbsStatsGraph IvInteractionsGraph {get;set;}
     public TLAbsStatsGraph ViewsBySourceGraph {get;set;}
     public TLAbsStatsGraph NewFollowersBySourceGraph {get;set;}
     public TLAbsStatsGraph LanguagesGraph {get;set;}
     public TLVector<TLMessageInteractionCounters> RecentMessageInteractions {get;set;}


		public void ComputeFlags()
		{
			
		}

        public override void DeserializeBody(BinaryReader br)
        {
            Period = (TLStatsDateRangeDays)ObjectUtils.DeserializeObject(br);
Followers = (TLStatsAbsValueAndPrev)ObjectUtils.DeserializeObject(br);
ViewsPerPost = (TLStatsAbsValueAndPrev)ObjectUtils.DeserializeObject(br);
SharesPerPost = (TLStatsAbsValueAndPrev)ObjectUtils.DeserializeObject(br);
EnabledNotifications = (TLStatsPercentValue)ObjectUtils.DeserializeObject(br);
GrowthGraph = (TLAbsStatsGraph)ObjectUtils.DeserializeObject(br);
FollowersGraph = (TLAbsStatsGraph)ObjectUtils.DeserializeObject(br);
MuteGraph = (TLAbsStatsGraph)ObjectUtils.DeserializeObject(br);
TopHoursGraph = (TLAbsStatsGraph)ObjectUtils.DeserializeObject(br);
InteractionsGraph = (TLAbsStatsGraph)ObjectUtils.DeserializeObject(br);
IvInteractionsGraph = (TLAbsStatsGraph)ObjectUtils.DeserializeObject(br);
ViewsBySourceGraph = (TLAbsStatsGraph)ObjectUtils.DeserializeObject(br);
NewFollowersBySourceGraph = (TLAbsStatsGraph)ObjectUtils.DeserializeObject(br);
LanguagesGraph = (TLAbsStatsGraph)ObjectUtils.DeserializeObject(br);
RecentMessageInteractions = (TLVector<TLMessageInteractionCounters>)ObjectUtils.DeserializeVector<TLMessageInteractionCounters>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ObjectUtils.SerializeObject(Period,bw);
ObjectUtils.SerializeObject(Followers,bw);
ObjectUtils.SerializeObject(ViewsPerPost,bw);
ObjectUtils.SerializeObject(SharesPerPost,bw);
ObjectUtils.SerializeObject(EnabledNotifications,bw);
ObjectUtils.SerializeObject(GrowthGraph,bw);
ObjectUtils.SerializeObject(FollowersGraph,bw);
ObjectUtils.SerializeObject(MuteGraph,bw);
ObjectUtils.SerializeObject(TopHoursGraph,bw);
ObjectUtils.SerializeObject(InteractionsGraph,bw);
ObjectUtils.SerializeObject(IvInteractionsGraph,bw);
ObjectUtils.SerializeObject(ViewsBySourceGraph,bw);
ObjectUtils.SerializeObject(NewFollowersBySourceGraph,bw);
ObjectUtils.SerializeObject(LanguagesGraph,bw);
ObjectUtils.SerializeObject(RecentMessageInteractions,bw);

        }
    }
}
