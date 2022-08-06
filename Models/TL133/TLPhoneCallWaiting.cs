using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
    [TLObject(-987599081)]
    public class TLPhoneCallWaiting : TLAbsPhoneCall
    {
        public override int Constructor
        {
            get
            {
                return -987599081;
            }
        }

        public int Flags { get; set; }
        public bool Video { get; set; }
        public long Id { get; set; }
        public long AccessHash { get; set; }
        public int Date { get; set; }
        public long AdminId { get; set; }
        public long ParticipantId { get; set; }
        public TLAbsPhoneCallProtocol Protocol { get; set; }
        public int? ReceiveDate { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Video ? (Flags | 64) : (Flags & ~64);
            Flags = ReceiveDate != null ? (Flags | 1) : (Flags & ~1);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Video = (Flags & 64) != 0;
            Id = br.ReadInt64();
            AccessHash = br.ReadInt64();
            Date = br.ReadInt32();
            AdminId = br.ReadInt64();
            ParticipantId = br.ReadInt64();
            Protocol = (TLAbsPhoneCallProtocol)ObjectUtils.DeserializeObject(br);
            if ((Flags & 1) != 0)
                ReceiveDate = br.ReadInt32();
            else
                ReceiveDate = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);

            bw.Write(Id);
            bw.Write(AccessHash);
            bw.Write(Date);
            bw.Write(AdminId);
            bw.Write(ParticipantId);
            ObjectUtils.SerializeObject(Protocol, bw);
            if ((Flags & 1) != 0)
                bw.Write(ReceiveDate.Value);

        }
    }
}
