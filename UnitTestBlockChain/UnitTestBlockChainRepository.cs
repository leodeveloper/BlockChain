
using BlockChain.Services;
using NUnit.Framework;

namespace UnitTestBlockChain
{
    /// <summary>
    /// Summary description for UnitTestBlockChainRepository
    /// </summary>
    [TestFixture]
    public class UnitTestBlockChainRepository
    {
        [Test]
        public void AddBlockIntoBlockChain_AddNewBlock_ReturnTrue()
        {
            //Arrange
            IBlockChainAddRepository addNewBlock = new BlockChainRepository();
            //Act
            var result = addNewBlock.AddBlockIntoBlockChain(new BlockChain.Dto.BlockDto { Data = "{Amount=4}" });
            result = addNewBlock.AddBlockIntoBlockChain(new BlockChain.Dto.BlockDto { Data = "{Amount=4}" });
            result = addNewBlock.AddBlockIntoBlockChain(new BlockChain.Dto.BlockDto { Data = "{Amount=4}" });
            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void GetAllBlocks_RetrunListOfBlocks()
        {
            //Arrange
            IBlockChainGetRepository getAllBlocks = new BlockChainRepository();
            //Act
            var result = getAllBlocks.GetAllBlocks();
            //Assert
            Assert.That(result, !Is.Null);
        }
    }
}
