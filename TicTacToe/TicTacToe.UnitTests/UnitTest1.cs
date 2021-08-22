using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe;

namespace TicTacToeTests
{

    [TestClass]
    public class UnitTest1
    {
            
        [TestMethod]
        public void ShowBoard()
        {
            Board board = new Board();

            board.ShowBoard();

            Assert.AreEqual(3, board.row.Length);
            

        }

        [TestMethod]
        public void ChooseValidRow()
        {
            Row row = new Row();

            int result = row.ChooseCol("4");

        }
    }
}
