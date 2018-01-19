using BlockChain.Dto;

namespace BlockChain.Services
{
    public interface IBlockChainGetRepository
    {
        BlockDto GetLatestBlock();
    }

    public interface IBlockChainAddRepository
    {
        void AddBlockIntoBlockChain(BlockDto blockDto);
    }
}