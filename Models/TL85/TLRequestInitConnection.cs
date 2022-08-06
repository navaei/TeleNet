using System.IO;

namespace  TeleNet.Models.TL85
{
    [TLObject(2018609336)]
    public class TLRequestInitConnection : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 2018609336;
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
        public TLInputClientProxy Proxy { get; set; }
        public TLObject Query { get; set; }
        //NOT MAPPED
        public int ApiLayer { get; set; }

        public TLObject Response { get; set; }

        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Proxy != null ? (Flags | 1) : (Flags & ~1);

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
                Proxy = (TLInputClientProxy)ObjectUtils.DeserializeObject(br);
            else
                Proxy = null;

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
            ObjectUtils.SerializeObject(Query, bw);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLObject)ObjectUtils.DeserializeObject(br);

        }
    }
}
