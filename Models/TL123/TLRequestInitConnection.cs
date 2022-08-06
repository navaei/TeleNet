using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123
{
    [TLObject(-1043505495)]
    public class TLRequestInitConnection : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return -1043505495;
            }
        }

        public int Flags { get; set; }
        public int ApiId { get; set; }
        public string DeviceModel { get; set; }
        public string SystemVersion { get; set; }
        public string AppVersion { get; set; }
        public string SystemLangCode { get; set; }
        public string LangPack { get; set; }
        public string LangCode { get; set; }
        public TeleNet.Models.TL.TLInputClientProxy Proxy { get; set; }
        public TeleNet.Models.TL96.TLAbsJSONValue Params { get; set; }
        public TLObject Query { get; set; }
        public TLObject Response { get; set; }

        public int ApiLayer { get; set; }
        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Proxy != null ? (Flags | 1) : (Flags & ~1);
            Flags = Params != null ? (Flags | 2) : (Flags & ~2);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            ApiId = br.ReadInt32();
            DeviceModel = StringUtil.Deserialize(br);
            SystemVersion = StringUtil.Deserialize(br);
            AppVersion = StringUtil.Deserialize(br);
            SystemLangCode = StringUtil.Deserialize(br);
            LangPack = StringUtil.Deserialize(br);
            LangCode = StringUtil.Deserialize(br);
            if ((Flags & 1) != 0)
                Proxy = (TeleNet.Models.TL.TLInputClientProxy)ObjectUtils.DeserializeObject(br);
            else
                Proxy = null;

            if ((Flags & 2) != 0)
                Params = (TeleNet.Models.TL96.TLAbsJSONValue)ObjectUtils.DeserializeObject(br);
            else
                Params = null;

            Query = (TLObject)ObjectUtils.DeserializeObject(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);
            bw.Write(ApiId);
            StringUtil.Serialize(DeviceModel, bw);
            StringUtil.Serialize(SystemVersion, bw);
            StringUtil.Serialize(AppVersion, bw);
            StringUtil.Serialize(SystemLangCode, bw);
            StringUtil.Serialize(LangPack, bw);
            StringUtil.Serialize(LangCode, bw);
            if ((Flags & 1) != 0)
                ObjectUtils.SerializeObject(Proxy, bw);
            if ((Flags & 2) != 0)
                ObjectUtils.SerializeObject(Params, bw);
            ObjectUtils.SerializeObject(Query, bw);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLObject)ObjectUtils.DeserializeObject(br);

        }
    }
}
