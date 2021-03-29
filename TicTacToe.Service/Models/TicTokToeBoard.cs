namespace TicTacToe.Service.Models
{
    public  class TicTokToeBoard
    {
        public int? Value1 { get; set; }
        public int? Value2 { get; set; }
        public int? Value3 { get; set; }
        public int? Value4 { get; set; }
        public int? Value5 { get; set; }
        public int? Value6 { get; set; }
        public int? Value7 { get; set; }
        public int? Value8 { get; set; }
        public int? Value9 { get; set; }

        public byte?[,] GetArray()
        {
            return new byte?[,]
            {
                {(byte?)Value1, (byte?)Value2, (byte?)Value3 },
                {(byte?)Value4, (byte?)Value5, (byte?)Value6 },
                {(byte?)Value7, (byte?)Value8, (byte?)Value9 },
            };
        }
    }
}
