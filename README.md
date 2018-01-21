# BlockChain
BlockChain C# Implementation, BlockChain by using c#

The problem
Right now we can create blocks and add them to our blockchain really quickly. And this creates 3 problems:

First of all: people can create blocks incredibly fast and spam our blockchain. A flood of blocks would overload our blockchain and would make it unusable.

Secondly, because it's so easy to create a valid block, people could tamper with one of the blocks in our chain and then simply recalculate all the hashes for the blocks after it. They would end up with a valid blockchain, even though they've tampered with it.

And thirdly, you can combine the two problems above to effectively take control of the blockchain. Blockchains are powered by a peer-to-peer network in which the nodes will add blocks to the longest chain available. So you can tamper with a block, recalculate all the other blocks and then add as many blocks as you want. You will then end up with the longest chain and all the peers will accept it and start adding their own blocks to it.

Clearly we need a solution for these problems. Enter: proof-of-work.

What is proof-of-work?
Proof-of-work is a mechanism that existed before the first blockchain was created. It's a simple technique that prevents abuse by requiring a certain amount of computing work. That amount of work is key to prevent spam and tampering. Spamming is no longer worth it if it requires a lot of computing power.

Bitcoin implements proof-of-work by requiring that the hash of a block starts with a specific number of zero's. This is also called the difficulty.

But hang on a minute! How can the hash of a block change? In case of Bitcoin a block contains details about a financial transaction. We sure don't want to mess with that data just to get a correct hash!

To fix this problem, blockchains add a nonce value. This is a number that gets incremented until a good hash is found. And because you cannot predict the output of a hash function, you simply have to try a lot of combinations before you get a hash that satisfies the difficulty. Looking for a valid hash (to create a new block) is also called "mining" in the cryptoworld.

In case of Bitcoin, the proof-of-work mechanism ensures that only 1 block can be added every 10 minutes. You can imagine spammers having a hard time to fool the network if they need so much compute power just to create a new block, let alone tamper with the entire chain.

Implementing proof-of-work
So how do you implement it? Let's start by modifying our block class and adding the nonce variable in it's constructor. I'll initialize it's value and set it 0.
