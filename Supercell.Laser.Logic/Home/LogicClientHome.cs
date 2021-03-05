namespace Supercell.Laser.Logic.Home
{
    using Supercell.Laser.Titan.Math;
    using Supercell.Laser.Titan.DataStream;
    using Supercell.Laser.Logic.Helper;
    
    public class LogicClientHome
    {
        private LogicLong m_homeId;

        public LogicClientHome()
        {
            this.Init();
        }

        public void Init()
        {
            this.m_homeId = new LogicLong();
        }

        public virtual void Encode(ChecksumEncoder encoder)
        {
            //sub_2045CC start 
            encoder.WriteVInt(2020188);
            encoder.WriteVInt(72152);
            encoder.WriteVInt(99999);
            encoder.WriteVInt(99999);
            encoder.WriteVInt(122);
            encoder.WriteVInt(200);
            encoder.WriteVInt(99999);

            ByteStreamHelper.WriteDataReference(encoder, 28, 0);
            ByteStreamHelper.WriteDataReference(encoder, 43, 0);

            encoder.WriteVInt(0);

            encoder.WriteVInt(0);

            encoder.WriteVInt(0);

            encoder.WriteVInt(0);

            encoder.WriteVInt(0);
            encoder.WriteVInt(0);
            encoder.WriteVInt(0);
            encoder.WriteVInt(0);
            encoder.WriteBoolean(false);
            encoder.WriteVInt(1000);
            encoder.WriteVInt(10);
            encoder.WriteVInt(20);
            encoder.WriteVInt(30);

            //sub_18C96C
            encoder.WriteVInt(0);
            encoder.WriteVInt(0);
            encoder.WriteVInt(0);

            encoder.WriteBoolean(false);

            encoder.WriteBoolean(false);

            encoder.WriteBoolean(false);
            encoder.WriteVInt(0);
            encoder.WriteVInt(0);
            encoder.WriteVInt(0);
            encoder.WriteVInt(0);
            encoder.WriteVInt(0);

            encoder.WriteVInt(0);

            encoder.WriteVInt(0);

            encoder.WriteVInt(200);
            encoder.WriteVInt(0);

            encoder.WriteVInt(0);

            encoder.WriteVInt(99999);
            encoder.WriteVInt(0);

            ByteStreamHelper.WriteDataReference(encoder, 16, 0);

            encoder.WriteString("RU");
            encoder.WriteString("Supercell.Laser");

            encoder.WriteVInt(1);
            {
                encoder.WriteInt(0);
                encoder.WriteInt(0);
            }

            encoder.WriteVInt(1);
            {
                encoder.WriteVInt(0);

                ByteStreamHelper.WriteDataReference(encoder, 16, 0);

                encoder.WriteVInt(0);
            }
            encoder.WriteVInt(1);
            {
                encoder.WriteVInt(1);
                encoder.WriteVInt(0);
                encoder.WriteBoolean(false);
                encoder.WriteVInt(1);

                encoder.WriteBoolean(true);
                {
                    encoder.WriteInt(0);
                    encoder.WriteInt(0);
                    encoder.WriteInt(0);
                    encoder.WriteInt(0);
                }

                encoder.WriteBoolean(true);
                {
                    encoder.WriteInt(0);
                    encoder.WriteInt(0);
                    encoder.WriteInt(0);
                    encoder.WriteInt(0);
                }
            }
            encoder.WriteVInt(1);
            {
                encoder.WriteVInt(0);
                encoder.WriteVInt(0);
            }

            encoder.WriteBoolean(true);
            {
                encoder.WriteVInt(0);
            }

            encoder.WriteBoolean(true);
            {
                encoder.WriteVInt(0);
            }
            //sub_2045CC end

            //sub_2AE048 start
            encoder.WriteVInt(2020141);
            encoder.WriteVInt(100);
            encoder.WriteVInt(10);
            encoder.WriteVInt(30);
            encoder.WriteVInt(3);
            encoder.WriteVInt(80);
            encoder.WriteVInt(10);
            encoder.WriteVInt(40);
            encoder.WriteVInt(1000);
            encoder.WriteVInt(550);
            encoder.WriteVInt(0);
            encoder.WriteVInt(999900);

            encoder.WriteVInt(0); //sub_1D3FB8

            encoder.WriteVInt(8);
            for (int i = 0; i < 8; i++)
            {
                encoder.WriteVInt(i);
            }

            encoder.WriteVInt(1);
            {
                encoder.WriteVInt(0);
                encoder.WriteVInt(1);
                encoder.WriteVInt(0);
                encoder.WriteVInt(75992);
                encoder.WriteVInt(10);

                ByteStreamHelper.WriteDataReference(encoder, 15, 7);

                encoder.WriteVInt(3);
                encoder.WriteString(null);
                encoder.WriteVInt(0);
                encoder.WriteVInt(0);
                encoder.WriteVInt(0);

                encoder.WriteVInt(0);

                encoder.WriteVInt(0);
                encoder.WriteVInt(0);
            }

            encoder.WriteVInt(0);

            encoder.WriteVInt(0); //sub_1D3FB8
            encoder.WriteVInt(0); //sub_1D3FB8
            encoder.WriteVInt(0); //sub_1D3FB8
            encoder.WriteVInt(0); //sub_1D3FB8
            encoder.WriteVInt(0); //sub_1D3FB8
            encoder.WriteVInt(0); //sub_1D3FB8

            encoder.WriteVInt(0);
            encoder.WriteVInt(0);
            encoder.WriteVInt(0);
            encoder.WriteVInt(0);
            encoder.WriteVInt(0);
            encoder.WriteVInt(0);

            encoder.WriteBoolean(false);
            encoder.WriteBoolean(false);
            encoder.WriteBoolean(false);

            encoder.WriteVInt(0);
            encoder.WriteVInt(0);

            encoder.WriteBoolean(false);

            encoder.WriteVInt(0);
            encoder.WriteVInt(0);
            encoder.WriteVInt(0);
            encoder.WriteVInt(0);
            //sub_2AE048 end

            encoder.WriteLong(m_homeId);

            encoder.WriteVInt(0);
            encoder.WriteVInt(0);

            encoder.WriteBoolean(false);
            encoder.WriteVInt(0);

            encoder.WriteVInt(0);
        }

        public void Decode(ByteStream stream)
        {

        }
    }
}
