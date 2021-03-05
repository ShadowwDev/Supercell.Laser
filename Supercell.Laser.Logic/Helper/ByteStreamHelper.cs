namespace Supercell.Laser.Logic.Helper
{
    using Supercell.Laser.Logic.Data;
    using Supercell.Laser.Titan.DataStream;

    public static class ByteStreamHelper
    {
        private static int m_classid;
        private static int m_instanceId;

        public static void WriteDataReference(ChecksumEncoder encoder, int classId, int instanceId)
        {
            encoder.WriteVInt(classId);
            encoder.WriteVInt(instanceId);
        }

        public static int ReadDataReference(ByteStream stream)
        {
            m_classid = stream.ReadVInt();
            m_instanceId = stream.ReadVInt();

            return GlobalID.CreateGlobalID(m_classid, m_instanceId);
        }
    }
}
