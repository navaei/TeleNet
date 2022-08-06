using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;
using TeleNet.Models.TL111;

namespace TeleNet.Models.TL123.Stats
{
    [TLObject(-276825834)]
    public class TLMegagroupStats : TLObject
    {
        public override int Constructor
        {
            get
            {
                return -276825834;
            }
        }

        public TLStatsDateRangeDays Period { get; set; }
        public TLStatsAbsValueAndPrev Members { get; set; }
        public TLStatsAbsValueAndPrev Messages { get; set; }
        public TLStatsAbsValueAndPrev Viewers { get; set; }
        public TLStatsAbsValueAndPrev Posters { get; set; }
        public TLAbsStatsGraph GrowthGraph { get; set; }
        public TLAbsStatsGraph MembersGraph { get; set; }
        public TLAbsStatsGraph NewMembersBySourceGraph { get; set; }
        public TLAbsStatsGraph LanguagesGraph { get; set; }
        public TLAbsStatsGraph MessagesGraph { get; set; }
        public TLAbsStatsGraph ActionsGraph { get; set; }
        public TLAbsStatsGraph TopHoursGraph { get; set; }
        public TLAbsStatsGraph WeekdaysGraph { get; set; }
        public TLVector<TLStatsGroupTopPoster> TopPosters { get; set; }
        public TLVector<TLStatsGroupTopAdmin> TopAdmins { get; set; }
        public TLVector<TLStatsGroupTopInviter> TopInviters { get; set; }
        public TLVector<TLAbsUser> Users { get; set; }


        public void ComputeFlags()
        {

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Period = (TLStatsDateRangeDays)ObjectUtils.DeserializeObject(br);
            Members = (TLStatsAbsValueAndPrev)ObjectUtils.DeserializeObject(br);
            Messages = (TLStatsAbsValueAndPrev)ObjectUtils.DeserializeObject(br);
            Viewers = (TLStatsAbsValueAndPrev)ObjectUtils.DeserializeObject(br);
            Posters = (TLStatsAbsValueAndPrev)ObjectUtils.DeserializeObject(br);
            GrowthGraph = (TLAbsStatsGraph)ObjectUtils.DeserializeObject(br);
            MembersGraph = (TLAbsStatsGraph)ObjectUtils.DeserializeObject(br);
            NewMembersBySourceGraph = (TLAbsStatsGraph)ObjectUtils.DeserializeObject(br);
            LanguagesGraph = (TLAbsStatsGraph)ObjectUtils.DeserializeObject(br);
            MessagesGraph = (TLAbsStatsGraph)ObjectUtils.DeserializeObject(br);
            ActionsGraph = (TLAbsStatsGraph)ObjectUtils.DeserializeObject(br);
            TopHoursGraph = (TLAbsStatsGraph)ObjectUtils.DeserializeObject(br);
            WeekdaysGraph = (TLAbsStatsGraph)ObjectUtils.DeserializeObject(br);
            TopPosters = (TLVector<TLStatsGroupTopPoster>)ObjectUtils.DeserializeVector<TLStatsGroupTopPoster>(br);
            TopAdmins = (TLVector<TLStatsGroupTopAdmin>)ObjectUtils.DeserializeVector<TLStatsGroupTopAdmin>(br);
            TopInviters = (TLVector<TLStatsGroupTopInviter>)ObjectUtils.DeserializeVector<TLStatsGroupTopInviter>(br);
            Users = (TLVector<TLAbsUser>)ObjectUtils.DeserializeVector<TLAbsUser>(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(Period, bw);
            ObjectUtils.SerializeObject(Members, bw);
            ObjectUtils.SerializeObject(Messages, bw);
            ObjectUtils.SerializeObject(Viewers, bw);
            ObjectUtils.SerializeObject(Posters, bw);
            ObjectUtils.SerializeObject(GrowthGraph, bw);
            ObjectUtils.SerializeObject(MembersGraph, bw);
            ObjectUtils.SerializeObject(NewMembersBySourceGraph, bw);
            ObjectUtils.SerializeObject(LanguagesGraph, bw);
            ObjectUtils.SerializeObject(MessagesGraph, bw);
            ObjectUtils.SerializeObject(ActionsGraph, bw);
            ObjectUtils.SerializeObject(TopHoursGraph, bw);
            ObjectUtils.SerializeObject(WeekdaysGraph, bw);
            ObjectUtils.SerializeObject(TopPosters, bw);
            ObjectUtils.SerializeObject(TopAdmins, bw);
            ObjectUtils.SerializeObject(TopInviters, bw);
            ObjectUtils.SerializeObject(Users, bw);

        }
    }
}
