using System.Collections.Generic;

namespace E_Commerce.DataIntegration
{
    public class BlockChain
    {
        public List<Block> Blocks { get; set; }
        public decimal difficulty { get; set; }
        public decimal miningReward { get; set; }
        public decimal maxSupply { get; set; }
        public List<TransactionBlock> pendingTransactions { get; set; }
        public BlockChain() { pendingTransactions = new List<TransactionBlock>(); }

    }
    public class Block
    {
        public string previousHash { get; set; }
        public string timestamp { get; set; }
        public int nonce { get; set; }
        public string hash { get; set; }
        public List<TransactionBlock> Transactions { get; set; }
        public Block() { Transactions = new List<TransactionBlock>(); }
    }
    public class TransactionBlock
    {
        public string fromAddress { get; set; }
        public string fromAddressPrivateKey { get; set; }
        public string toAddress { get; set; }
        public decimal amount { get; set; }
    }
    public class WalletKeys
    {

    }


}
